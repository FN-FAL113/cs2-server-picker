Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq
Module ServerService

    Private clusterDict As New Dictionary(Of String, String) From {
        {"China", "Perfect,Hong Kong,Alibaba"},
        {"Japan", "Tokyo"},
        {"Stockholm (Sweden)", "Stockholm"},
        {"India", "Chennai,Mumbai"}
    }

    Public Async Function Fetch_Server_Data() As Task(Of String)
        Try
            Dim webReq As String = Await New WebClient().DownloadStringTaskAsync("https://api.steampowered.com/ISteamApps/GetSDRConfig/v1/?appid=730")

            Dim mainJson As JObject = JObject.Parse(webReq)
            Dim serverRevision As String = mainJson.SelectToken("revision").ToString()

            If serverRevision Is Nothing Then
                MessageBox.Show("Failed to load server data!" + Environment.NewLine + Environment.NewLine +
                                "Possible solutions:" + Environment.NewLine +
                                "1. Please make sure you are connected to the internet and no third-party software is blocking the app's internet access." + Environment.NewLine +
                                "2. Use VPN incase your ISP has blocked access to numerous internet services, you may turn off the vpn after using this app." + Environment.NewLine +
                                "3. Report to github tracker if previous steps are not able to resolve the issue.", "Server Data Fetch Error")

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

                    ' Fetch_Save_Server_Flags(serverProp)

                    ' collect server relay addresses to an array
                    For Each ipToken As JObject In ipObjArr
                        ipArr.Add(ipToken.SelectToken("ipv4").ToString())
                    Next

                    Dim serverName As String = serverProp.Value.SelectToken("desc").ToString() + " (" + serverProp.Name + ")"

                    Dim serverIsClustered As Boolean = False

                    ' if server is part of clustered servers then add/concatenate its ip addresses to its cluster name key 
                    For Each clusterKvp As KeyValuePair(Of String, String) In clusterDict  ' traverse every cluster
                        For Each clusterValue As String In clusterKvp.Value.Split(",") ' traverse cluster comma-separated server name values
                            If serverName.Contains(clusterValue) Then ' check if server name prop is included as cluster array value
                                If Not App.Get_Server_Dictionary_Clustered().ContainsKey(clusterKvp.Key) Then ' initialize cluster with values
                                    App.Get_Server_Dictionary_Clustered().Add(clusterKvp.Key, String.Join(",", ipArr))
                                Else ' concatenate server ip to clustered server
                                    App.Get_Server_Dictionary_Clustered().Item(clusterKvp.Key) = App.Get_Server_Dictionary_Clustered().Item(clusterKvp.Key) _
                                            + "," + String.Join(",", ipArr)
                                End If

                                serverIsClustered = True
                            End If
                        Next
                    Next

                    ' As of november the 1st server revision, different server network IDs and geolocation that has existing server name prop were added. 
                    ' Have to make validations on the dictionary to prevent duplicate key exception.
                    If Not App.Get_Server_Dictionary_Unclustered().ContainsKey(serverName) Then
                        App.Get_Server_Dictionary_Unclustered().Add(serverName, String.Join(",", ipArr))
                    Else
                        App.Get_Server_Dictionary_Unclustered().Item(serverName) = App.Get_Server_Dictionary_Unclustered().Item(serverName) _
                                + "," + String.Join(",", ipArr)
                    End If

                    ' server is not part of clustered servers 
                    If Not serverIsClustered Then
                        If Not App.Get_Server_Dictionary_Clustered().ContainsKey(serverName) Then
                            App.Get_Server_Dictionary_Clustered().Add(serverName, String.Join(",", ipArr))
                        Else
                            App.Get_Server_Dictionary_Clustered().Item(serverName) = App.Get_Server_Dictionary_Clustered().Item(serverName) _
                                + "," + String.Join(",", ipArr)
                        End If
                    End If
                End If
            Next

            Return serverRevision
        Catch ex As Exception
            MessageBox.Show("An error has occured while retrieving or displaying server data! Please report to github issue-tracker.", "Server Data Fetch/Display Error")

            Return "null"
        End Try
    End Function

    Private Sub Fetch_Save_Server_Flags(serverProp As JProperty)
        ' this method was particularly used on development for fetching flag images and saving them locally as resources instead due to rate limits
        ' server relay addresses are not geolocation accurate thus it was not utilized although a separate branch was created with the implementation (Dev/server-flags-using-api)
        Dim latitude As String = serverProp.Value.SelectToken("geo").AsEnumerable()(0).ToString()
        Dim longitude As String = serverProp.Value.SelectToken("geo").AsEnumerable()(1).ToString()

        Dim wClient As WebClient = New WebClient()

        Dim locResponse As JObject = JObject.Parse(wClient.DownloadString("https://api.opencagedata.com/geocode/v1/json?key=<API_KEY>&q=" + longitude + "%2C+" + latitude + "&pretty=1&no_annotations=1"))
        Dim locResultsArr As JArray = locResponse.SelectToken("results")

        Dim baseAppDotVbPath As String = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\"))
        Dim serverName As String = serverProp.Value.SelectToken("desc").ToString() + " (" + serverProp.Name + ")" + ".png"

        If (Not File.Exists(baseAppDotVbPath + serverName)) Then
            Dim countryCode As String = ""

            If (serverProp.Name = "mad") Then
                ' reverse geocode fails for madrid, coords points to balearic sea lol 
                countryCode = "ES"
            Else
                countryCode = locResultsArr(0).SelectToken("components").SelectToken("country_code").ToString().ToUpper()
            End If

            wClient.DownloadFile("https://flagsapi.com/" + countryCode + "/flat/48.png", baseAppDotVbPath + serverName)

            wClient.Dispose()
        End If
    End Sub

    Public Async Sub Block_Except_Preset_Servers(Optional exceptPresetServers As Boolean = False)
        If App.Get_Pending_Operation() Then
            MessageBox.Show("Operation in progress, please wait a moment...")

            Return
        End If

        ' unblock all servers first before doing a block by preset
        Await Block_Unblock_All_Servers(False, False)

        ' is passed as a reference, should be cloned in case of unwanted modification  
        Dim serverDIctionary As Dictionary(Of String, String) = IIf(App.Get_Is_Clustered(), App.Get_Server_Dictionary_Clustered(), App.Get_Server_Dictionary_Unclustered())

        Dim presetServersDataGridView As DataGridView = Presets.PresetServerListDataGridView

        App.Set_Pending_Operation(True)

        Cancel_Pending_Ping()

        ' offload this blocking task into a seperate thread from the thread pool to lessen load in the UI thread
        Await Task.Run(Sub() Handle_Block_Except_Preset_Servers(presetServersDataGridView, serverDIctionary, exceptPresetServers))

        App.Set_Pending_Operation(False)

        Ping_All_Servers()
    End Sub

    Private Sub Handle_Block_Except_Preset_Servers(presetServersDataGridView As DataGridView, serverDictionary As Dictionary(Of String, String), exceptPresetServers As Boolean)
        Dim proc As Process = Create_Custom_CMD_Process()

        Dim presetServerNames As HashSet(Of String) = New HashSet(Of String)

        ' collect preset server names as basis for the next operation
        For Each presetRow As DataGridViewRow In presetServersDataGridView.Rows
            presetServerNames.Add(presetRow.Cells(0).Value)
        Next

        ' traverse servers, conditionally diff preset server names against the dictionary
        For Each serverKvp As KeyValuePair(Of String, String) In serverDictionary
            ' skip blocking preset servers
            If exceptPresetServers And presetServerNames.Contains(serverKvp.Key) Then
                Continue For
            End If

            ' block preset servers only
            If Not exceptPresetServers And Not presetServerNames.Contains(serverKvp.Key) Then
                Continue For
            End If

            Try
                proc.StartInfo.Arguments = "/c netsh advfirewall firewall add rule " +
                        "name=CS2ServerPicker_" + serverKvp.Key.Replace(" ", "") + " dir=out action=block protocol=ANY " +
                        "remoteip=" + serverKvp.Value
                proc.Start()
                proc.WaitForExit()

                If proc.ExitCode = 1 Or proc.ExitCode < 0 Then
                    Throw New Exception(proc.StandardOutput.ReadToEnd().Split(".")(0))

                    Continue For
                End If
            Catch ex As Exception
                MessageBox.Show("An error has occured while blocking servers by preset with the following message: " + Environment.NewLine + ex.Message, "Error")
            End Try
        Next

        proc.Dispose()
    End Sub

    Public Async Sub Block_Unblock_Selected_Servers(block As Boolean)
        Dim mainDataGridView As DataGridView = App.Get_DataGridView_Control()
        Dim serverDIctionary As Dictionary(Of String, String) = IIf(App.Get_Is_Clustered(), App.Get_Server_Dictionary_Clustered(), App.Get_Server_Dictionary_Unclustered())

        Dim selectedRows As DataGridViewSelectedRowCollection = mainDataGridView.SelectedRows

        If App.Get_Pending_Operation() Then
            MessageBox.Show("Operation in progress, please wait a moment...")

            Return
        End If

        If selectedRows.Count <= 0 Then
            MessageBox.Show("You haven't selected any server.", "Info")

            Return
        End If

        App.Set_Pending_Operation(True)

        Cancel_Pending_Ping()

        ' offload this blocking task into a seperate thread from the thread pool to lessen load in the UI thread
        Await Task.Run(Sub() Handle_Block_Unblock_Selected_Servers(mainDataGridView, serverDIctionary, block))

        App.Set_Pending_Operation(False)

        Ping_Servers(selectedRows)
    End Sub

    Private Sub Handle_Block_Unblock_Selected_Servers(mainDataGridView As DataGridView, serverDIctionary As Dictionary(Of String, String), block As Boolean)
        Dim proc As Process = Create_Custom_CMD_Process()

        ' traverse every datagrid row and block/unblock selected servers
        For Each row As DataGridViewRow In mainDataGridView.SelectedRows
            If Is_Server_Blocked_Or_Unblocked(row.Cells(1).Value, block) Then
                Continue For
            End If

            Try
                Dim region As String = row.Cells(1).Value

                proc.StartInfo.Arguments = "/c netsh advfirewall firewall " + If(block, "add", "delete") + " rule " +
                        "name=CS2ServerPicker_" + region.Replace(" ", "") + If(block, " dir=out action=block protocol=ANY " +
                        "remoteip=" + serverDIctionary.Item(region), "")
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

    Public Async Function Block_Unblock_All_Servers(block As Boolean, Optional pingServers As Boolean = True) As Task
        ' this method was converted async since its invoked by other methods/tasks and
        ' it does not evaluate synchronously due to its async operation that must be awaited
        Dim serverDIctionary As Dictionary(Of String, String) = IIf(App.Get_Is_Clustered(), App.Get_Server_Dictionary_Clustered(), App.Get_Server_Dictionary_Unclustered())
        Dim mainDataGridView As DataGridView = App.Get_DataGridView_Control()

        If App.Get_Pending_Operation() Then
            MessageBox.Show("Operation in progress, please wait a moment...")

            Return
        End If

        App.Set_Pending_Operation(True)

        Cancel_Pending_Ping()

        ' offload this blocking task into a seperate thread from the thread pool to lessen load in the UI thread
        Await Task.Run(Sub() Handle_Block_Unblock_All_Servers(mainDataGridView, serverDIctionary, block))

        App.Set_Pending_Operation(False)

        If pingServers Then
            Ping_All_Servers()
        End If
    End Function

    Private Sub Handle_Block_Unblock_All_Servers(mainDataGridView As DataGridView, serverDIctionary As Dictionary(Of String, String), block As Boolean)
        Dim proc As Process = Create_Custom_CMD_Process()

        ' traverse every datagrid row and block/unblock all servers
        For Each row As DataGridViewRow In mainDataGridView.Rows
            Dim region As String = row.Cells(1).Value

            If Is_Server_Blocked_Or_Unblocked(region, block) Then
                Continue For
            End If

            Try
                proc.StartInfo.Arguments = "/c netsh advfirewall firewall " + If(block, "add", "delete") + " rule " +
                "name=CS2ServerPicker_" + region.Replace(" ", "") + If(block, " dir=out action=block protocol=ANY " +
                    "remoteip=" + serverDIctionary.Item(region), "")
                proc.Start()
                proc.WaitForExit()

                If proc.ExitCode = 1 Or proc.ExitCode < 0 Then
                    Throw New Exception(proc.StandardOutput.ReadToEnd().Split(".")(0))

                    Continue For
                End If
            Catch ex As Exception
                MessageBox.Show("An error has occured while blocking/unblocking all servers with the following message: " + Environment.NewLine + ex.Message, "Error")
            End Try
        Next

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
