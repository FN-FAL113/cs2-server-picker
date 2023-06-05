Module ServerService
    Public Sub Should_Block_Selected_Servers(block As Boolean)
        Dim MainDataGridView As DataGridView = App.Get_DataGridView_Control()

        If MainDataGridView.SelectedRows.Count <= 0 Then
            MessageBox.Show("You haven't selected any server", "Warning")

            Return
        End If

        Cancel_Pending_Ping()

        Dim proc As Process = Create_Custom_CMD_Process()
        Dim shouldBlock = If(block, "add", "delete")

        For Each row As DataGridViewRow In MainDataGridView.SelectedRows
            If Is_Server_Blocked(row.Cells(0).Value, block) Then
                Continue For
            End If

            Try
                Dim region As String = row.Cells(0).Value

                proc.StartInfo.Arguments = "/c netsh advfirewall firewall " + shouldBlock + " rule " +
                    "name=CSGOServerPicker_" + region.Replace(" ", "") + If(block, " dir=out action=block protocol=UDP " +
                    "remoteip=" + App.Get_Server_Dictionary().Item(region), "")
                proc.Start()
                proc.WaitForExit()

                If proc.ExitCode = 1 Or proc.ExitCode < 0 Then
                    Throw New Exception(proc.StandardOutput.ReadToEnd().Split(".")(0))

                    Continue For
                End If
            Catch ex As Exception
                MessageBox.Show("An error has occured while blocking/unblocking selected server with the following message: " + Environment.NewLine + ex.Message)
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

            Dim shouldBlock = If(block, "add", "delete")

            For i = 0 To MainDataGridView.Rows.Count - 1
                Dim region As String = MainDataGridView.Rows(i).Cells(0).Value

                If Is_Server_Blocked(region, block) Then
                    Continue For
                End If

                proc.StartInfo.Arguments = "/c netsh advfirewall firewall " + shouldBlock + " rule " +
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
            MessageBox.Show("An error has occured while blocking/unblocking all servers with the following message: " + Environment.NewLine + ex.Message)
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
