Module PingService

    Public Async Sub Ping_Servers(dgRows As DataGridViewSelectedRowCollection)
        ' DO NOT call this procedure in a separate thread
        ' it references UI controls which can only be accessed in the UI thread
        Dim serverDict As Dictionary(Of String, String) = IIf(App.Get_Is_Clustered(), App.Get_Server_Dictionary_Clustered(), App.Get_Server_Dictionary_Unclustered())

        For Each dgRow As DataGridViewRow In dgRows
            Dim serverName As String = dgRow.Cells(1).Value
            ' string of addresses joined by "," wil be splitted where each address is pinged
            Dim addresses As String = serverDict.Item(serverName)

            Cancel_Pending_Ping(serverName)

            dgRow.Cells(2).Value = "Refreshing..."

            Await Task.Run(Sub() Ping_Handler(addresses, dgRow))
        Next
    End Sub

    Public Async Sub Ping_All_Servers()
        ' DO NOT call this procedure in a separate thread
        Clear_Column_Values()

        Cancel_Pending_Ping()

        Dim serverDictionary As Dictionary(Of String, String) = IIf(App.Get_Is_Clustered(), App.Get_Server_Dictionary_Clustered(), App.Get_Server_Dictionary_Unclustered())

        For Each dgRow As DataGridViewRow In App.Get_DataGridView_Control().Rows()
            ' comma separated server addresses, will get split
            Dim addresses As String = serverDictionary.Item(dgRow.Cells(1).Value)

            Await Task.Run(Sub() Ping_Handler(addresses, dgRow))
        Next
    End Sub

    Public Async Sub Ping_Handler(addresses As String, row As DataGridViewRow)
        If Is_Server_Blocked_Or_Unblocked(row.Cells(1).Value, True) Then
            ' do not ping if server is blocked
            row.Cells(1).Style.BackColor = Color.FromArgb(255, 128, 128)
            row.Cells(2).Style.BackColor = Color.FromArgb(255, 128, 128)
            row.Cells(2).Value = "Blocked"

            Return
        ElseIf row.Cells(1).Style.BackColor = Color.FromArgb(255, 128, 128) Then
            ' if server is not blocked and cell back color is red then unset color
            row.Cells(1).Style.BackColor = Color.Empty
            row.Cells(2).Style.BackColor = Color.Empty
        End If

        Dim ping As New Net.NetworkInformation.Ping
        Dim pingObjsDict As Dictionary(Of String, Net.NetworkInformation.Ping) = App.Get_Ping_Objects_Dictionary()
        Dim pingResult As Integer = 0

        ' add created ping obj to dictionary that gets cleared on subsequent refresh or form close
        If Not pingObjsDict.ContainsKey(row.Cells(1).Value) Then
            pingObjsDict.Add(row.Cells(1).Value, ping)
        End If

        row.Cells(2).Value = "Getting latency..."

        ' this loop maintains its context through suspension points (Await) so I don't have to worry about race conditions
        For Each address As String In addresses.Split(",")
            Try
                Dim result = Await ping.SendPingAsync(address)

                ' exit loop on first successful ping
                If result.RoundtripTime > 0 Then
                    pingResult = result.RoundtripTime

                    row.Cells(2).Value = pingResult.ToString() + "ms"
                    row.Cells(2).Style.BackColor = Color.LightGreen

                    Exit For
                End If
            Catch ex As Exception
                Continue For
            End Try
        Next

        If pingResult = 0 Then
            row.Cells(2).Value = "Ping timed out, try again..."
            row.Cells(2).Style.BackColor = Color.Orange
        End If

        ping.Dispose()
    End Sub

    Public Sub Cancel_Pending_Ping(Optional serverName As String = "")
        Dim pingObjs = App.Get_Ping_Objects_Dictionary()

        If pingObjs.Count <= 0 Then
            Return
        End If

        If String.IsNullOrEmpty(serverName) Then
            For Each ping As Net.NetworkInformation.Ping In pingObjs.Values
                ping.SendAsyncCancel()
                ping.Dispose()
            Next

            pingObjs.Clear()
        ElseIf pingObjs.ContainsKey(serverName) Then
            pingObjs.Item(serverName).SendAsyncCancel()
            pingObjs.Item(serverName).Dispose()

            pingObjs.Remove(serverName)
        End If
    End Sub
End Module
