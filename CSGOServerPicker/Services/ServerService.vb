Imports Newtonsoft.Json.Linq
Module ServerService

    Public Function Fetch_Server_Data() As String
        Try
            Dim webReq As String = New Net.WebClient().DownloadString("https://api.steampowered.com/ISteamApps/GetSDRConfig/v1/?appid=730")

            Dim mainJson As JObject = JObject.Parse(webReq)
            Dim serverRevision As String = mainJson.SelectToken("revision").ToString()

            If serverRevision Is Nothing Then
                MessageBox.Show("Failed to load server data! Please report to github issue-tracker.", "Error")

                Return "null"
            End If

            If My.Settings.Server_Revision Is Nothing Or String.IsNullOrEmpty(My.Settings.Server_Revision) Then
                My.Settings.Server_Revision = serverRevision
                My.Settings.Save()
                My.Settings.Reload()
            End If

            ' loop every server prop that holds an object that contains server info
            For Each serverProp As JProperty In mainJson.SelectToken("pops")
                ' if serverProp object value has relays prop then loop its Object array value
                If serverProp.Value.SelectToken("relays") IsNot Nothing Then
                    Dim ipObjArr As JArray = serverProp.Value.SelectToken("relays")
                    Dim ipArr As List(Of String) = New List(Of String)

                    ' collect server relay addresses to an array
                    For Each ipToken As JToken In ipObjArr
                        ipArr.Add(ipToken.SelectToken("ipv4").ToString())
                    Next

                    App.Get_Server_Dictionary().Add(serverProp.Value.SelectToken("desc").ToString(), String.Join(",", ipArr))
                End If
            Next

            Return serverRevision
        Catch ex As Exception
            MessageBox.Show("An error has occured while retriving server data! Please report to github issue-tracker.", "Error")

            Return "null"
        End Try
    End Function

    Public Sub Should_Block_Selected_Servers(block As Boolean)
        Dim MainDataGridView As DataGridView = App.Get_DataGridView_Control()

        If MainDataGridView.SelectedRows.Count <= 0 Then
            MessageBox.Show("You haven't selected any server", "Info")

            Return
        End If

        Cancel_Pending_Ping()

        Dim proc As Process = Create_Custom_CMD_Process()

        For Each row As DataGridViewRow In MainDataGridView.SelectedRows
            If Is_Server_Blocked(row.Cells(0).Value, block) Then
                Continue For
            End If

            Try
                Dim region As String = row.Cells(0).Value

                proc.StartInfo.Arguments = "/c netsh advfirewall firewall " + If(block, "add", "delete") + " rule " +
                    "name=CSGOServerPicker_" + region.Replace(" ", "") + If(block, " dir=out action=block protocol=UDP " +
                    "remoteip=" + App.Get_Server_Dictionary().Item(region), "")
                proc.Start()
                proc.WaitForExit()

                If proc.ExitCode = 1 Or proc.ExitCode < 0 Then
                    Throw New Exception(proc.StandardOutput.ReadToEnd().Split(".")(0))

                    Continue For
                End If
            Catch ex As Exception
                MessageBox.Show("An error has occured while blocking/unblocking selected server with the following message: " + Environment.NewLine + ex.Message, "Error")
            End Try
        Next

        proc.Dispose()

        Ping_Servers()
    End Sub

    Public Sub Should_Block_All_Servers(block As Boolean)
        Try
            Cancel_Pending_Ping()

            Dim MainDataGridView As DataGridView = App.Get_DataGridView_Control()

            Dim proc As Process = Create_Custom_CMD_Process()

            For i = 0 To MainDataGridView.Rows.Count - 1
                Dim region As String = MainDataGridView.Rows(i).Cells(0).Value

                If Is_Server_Blocked(region, block) Then
                    Continue For
                End If

                proc.StartInfo.Arguments = "/c netsh advfirewall firewall " + If(block, "add", "delete") + " rule " +
                "name=CSGOServerPicker_" + region.Replace(" ", "") + If(block, " dir=out action=block protocol=UDP " +
                    "remoteip=" + App.Get_Server_Dictionary().Item(region), "")
                proc.Start()
                proc.WaitForExit()

                If proc.ExitCode = 1 Or proc.ExitCode < 0 Then
                    Throw New Exception(proc.StandardOutput.ReadToEnd().Split(".")(0))

                    Continue For
                End If
            Next

            proc.Dispose()
        Catch ex As Exception
            MessageBox.Show("An error has occured while blocking/unblocking all servers with the following message: " + Environment.NewLine + ex.Message, "Error")
        End Try

        Ping_Servers()
    End Sub

    Public Function Is_Server_Blocked(serverName As String, block As Boolean) As Boolean
        Dim proc As Process = Create_Custom_CMD_Process()

        proc.StartInfo.FileName = "cmd.exe"
        proc.StartInfo.Arguments = "/c netsh advfirewall firewall show rule name=CSGOServerPicker_" +
                serverName.Replace(" ", "") + " | findstr ""No Rules"""
        proc.Start()
        proc.WaitForExit()

        Dim containsNoRules = proc.StandardOutput.ReadLine().Contains("No rules")
        Dim result As Boolean = IIf(block, Not containsNoRules, containsNoRules)

        proc.Dispose()

        Return result
    End Function
End Module
