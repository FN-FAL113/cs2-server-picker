Imports Newtonsoft.Json.Linq
Module ServerService

    Private clusterDict As New Dictionary(Of String, String) From {
        {"China", "Perfect,Hong Kong,Alibaba"},
        {"Japan", "Tokyo"},
        {"Stockholm (Sweden)", "Stockholm"},
        {"India", "Chennai,Mumbai"}
    }

    Public pendingOperation As Boolean = False

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
                    Dim ipObjArr As JArray = serverProp.Value.SelectToken("relays") ' array of objects
                    Dim ipArr As List(Of String) = New List(Of String)

                    ' collect server relay addresses to an array
                    For Each ipToken As JObject In ipObjArr
                        ipArr.Add(ipToken.SelectToken("ipv4").ToString())
                    Next

                    Dim serverName As String = serverProp.Value.SelectToken("desc").ToString()
                    Dim serverIsClustered As Boolean = False

                    ' if server is part of clustered servers then add/concatenate its ip addresses to its cluster name key 
                    For Each clusterKvp As KeyValuePair(Of String, String) In clusterDict  ' traverse every cluster
                        For Each clusterValue As String In clusterKvp.Value.Split(",") ' traverse cluster comma-separated values
                            If serverName.Contains(clusterValue) Then
                                If Not App.Get_Server_Dictionary().ContainsKey(clusterKvp.Key) Then ' initialize cluster with values
                                    App.Get_Server_Dictionary().Add(clusterKvp.Key, String.Join(",", ipArr))
                                Else ' concatenate server ip to cluter
                                    App.Get_Server_Dictionary().Item(clusterKvp.Key) = App.Get_Server_Dictionary().Item(clusterKvp.Key) _
                                        + "," + String.Join(",", ipArr)
                                End If

                                serverIsClustered = True
                            End If
                        Next
                    Next

                    ' server is not part of clustered servers 
                    If Not serverIsClustered Then
                        App.Get_Server_Dictionary().Add(serverName, String.Join(",", ipArr))
                    End If
                End If
            Next

            Return serverRevision
        Catch ex As Exception
            MessageBox.Show("An error has occured while retrieving server data! Please report to github issue-tracker.", "Error")

            Return "null"
        End Try
    End Function

    Public Async Sub Should_Block_Selected_Servers(block As Boolean)
        Dim MainDataGridView As DataGridView = App.Get_DataGridView_Control()
        Dim serverDictionary As Dictionary(Of String, String) = App.Get_Server_Dictionary()

        If pendingOperation Then
            MessageBox.Show("Operation in progress, please wait a moment...")

            Return
        End If

        pendingOperation = True

        App.ProgBar.Visible = True

        Cancel_Pending_Ping()

        ' offload this blocking task into a seperate thread to lessen load in the UI thread
        Await Task.Run(Sub() Handle_Selected_Server_Block_Unblock(MainDataGridView, serverDictionary, block))

        pendingOperation = False

        App.ProgBar.Visible = False

        Ping_Servers()
    End Sub

    Private Sub Handle_Selected_Server_Block_Unblock(MainDataGridView As DataGridView, ServerDictionary As Dictionary(Of String, String), block As Boolean)
        If MainDataGridView.SelectedRows.Count <= 0 Then
            MessageBox.Show("You haven't selected any server.", "Info")

            Return
        End If

        Dim proc As Process = Create_Custom_CMD_Process()

        ' traverse every datagrid row and block/unblock selected servers
        For Each row As DataGridViewRow In MainDataGridView.SelectedRows
            If Is_Server_Blocked_Or_Unblocked(row.Cells(0).Value, block) Then
                Continue For
            End If

            Try
                Dim region As String = row.Cells(0).Value

                proc.StartInfo.Arguments = "/c netsh advfirewall firewall " + If(block, "add", "delete") + " rule " +
                        "name=CS2ServerPicker_" + region.Replace(" ", "") + If(block, " dir=out action=block protocol=UDP " +
                        "remoteip=" + ServerDictionary.Item(region), "")
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
    End Sub

    Public Async Sub Should_Block_All_Servers(block As Boolean)
        Dim serverDictionary As Dictionary(Of String, String) = App.Get_Server_Dictionary()
        Dim MainDataGridView As DataGridView = App.Get_DataGridView_Control()

        If pendingOperation Then
            MessageBox.Show("Operation in progress, please wait a moment...")

            Return
        End If

        pendingOperation = True

        App.ProgBar.Visible = True

        Cancel_Pending_Ping()

        ' offload this blocking task into a seperate thread to lessen load in the UI thread
        Await Task.Run(Sub() Handle_All_Server_Block_Unblock(MainDataGridView, serverDictionary, block))

        pendingOperation = False

        App.ProgBar.Visible = False

        Ping_Servers()
    End Sub

    Private Sub Handle_All_Server_Block_Unblock(MainDataGridView As DataGridView, ServerDictionary As Dictionary(Of String, String), block As Boolean)
        Dim proc As Process = Create_Custom_CMD_Process()

        Try
            ' traverse every datagrid row and block/unblock all servers
            For i = 0 To MainDataGridView.Rows.Count - 1
                Dim region As String = MainDataGridView.Rows(i).Cells(0).Value

                If Is_Server_Blocked_Or_Unblocked(region, block) Then
                    Continue For
                End If

                proc.StartInfo.Arguments = "/c netsh advfirewall firewall " + If(block, "add", "delete") + " rule " +
                "name=CS2ServerPicker_" + region.Replace(" ", "") + If(block, " dir=out action=block protocol=UDP " +
                    "remoteip=" + ServerDictionary.Item(region), "")
                proc.Start()
                proc.WaitForExit()

                If proc.ExitCode = 1 Or proc.ExitCode < 0 Then
                    Throw New Exception(proc.StandardOutput.ReadToEnd().Split(".")(0))

                    Continue For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("An error has occured while blocking/unblocking all servers with the following message: " + Environment.NewLine + ex.Message, "Error")
        End Try

        proc.Dispose()
    End Sub

    Public Function Is_Server_Blocked_Or_Unblocked(region As String, block As Boolean) As Boolean
        Dim proc As Process = Create_Custom_CMD_Process()
        Dim result As Boolean = False
        Dim is_rule_exist As Boolean
        Dim region_trimmed As String = region.Replace(" ", "")

        proc.StartInfo.Arguments = "/c netsh advfirewall firewall show rule name=CS2ServerPicker_" +
                region_trimmed + " | findstr CS2ServerPicker_" + region_trimmed
        proc.Start()
        proc.WaitForExit()

        Dim procOutput = proc.StandardOutput.ReadToEnd() ' retrieve command output from stdout descriptor

        is_rule_exist = procOutput.Contains("CS2ServerPicker_" + region_trimmed)

        ' if rule does exist and is being blocked, return true to skip blocking.
        ' if rule does not exist and is being unblocked, return true to skip unblocking.
        If (is_rule_exist And block) Or (Not is_rule_exist And Not block) Then
            result = True
        End If

        proc.Dispose()

        Return result
    End Function
End Module
