﻿Module PingService

    Public Async Sub Ping_Servers(dgRows As DataGridViewSelectedRowCollection)
        ' DO NOT call this procedure in a separate thread
        ' it references UI controls which can only be accessed in the UI thread
        Dim serverDict As Dictionary(Of String, String) = IIf(App.Get_Is_Clustered(), App.Get_Server_Dictionary_Clustered(), App.Get_Server_Dictionary_Unclustered())

        For Each dgRow As DataGridViewRow In dgRows
            Dim serverName As String = dgRow.Cells(0).Value.ToString()
            Dim address = serverDict.Item(serverName).Split(",")(0)

            Cancel_Pending_Ping(serverName)

            dgRow.Cells(1).Value = "Reloading..."

            ' replace host id from ip address since this will be traversed from 0 to max 8 bit value
            Dim addressNoHostValue As String = address.Remove(address.LastIndexOf(".") + 1, address.Split(".")(3).Length)

            Await Task.Run(Sub() Ping_Handler(addressNoHostValue, dgRow))
        Next
    End Sub

    Public Async Sub Ping_All_Servers()
        ' DO NOT call this procedure in a separate thread
        Clear_Column_Values()

        Cancel_Pending_Ping()

        Dim serverDict As Dictionary(Of String, String) = IIf(App.Get_Is_Clustered(), App.Get_Server_Dictionary_Clustered(), App.Get_Server_Dictionary_Unclustered())

        For Each dgRow As DataGridViewRow In App.Get_DataGridView_Control().Rows()
            For Each address As String In serverDict.Item(dgRow.Cells(0).Value).Split(",")
                ' replace host id from ip address since this will be traversed from 0 to max 8 bit value
                Dim addressNoHostValue As String = address.Remove(address.LastIndexOf(".") + 1, address.Split(".")(3).Length)

                Await Task.Run(Sub() Ping_Handler(addressNoHostValue, dgRow))

                ' ping first address only, skip pinging others to prevent race conditions
                Exit For
            Next
        Next
    End Sub

    Public Async Sub Ping_Handler(addressNoHostValue As String, row As DataGridViewRow)
        ' do not ping if server is blocked
        With row.Cells(0)
            If Is_Server_Blocked_Or_Unblocked(.Value, True) Then
                .Style.BackColor = Color.Red
                row.Cells(1).Value = "Blocked"

                Return
            ElseIf .Style.BackColor = Color.Red Then
                .Style.BackColor = Color.Empty
            End If
        End With

        Dim ping As New Net.NetworkInformation.Ping
        Dim pingObjsDict As Dictionary(Of String, Net.NetworkInformation.Ping) = App.Get_Ping_Objects_Dictionary()
        Dim lowestPing As Integer = 0

        ' add created ping obj to dictionary that gets cleared on refresh (ping all) or form close
        If Not pingObjsDict.ContainsKey(row.Cells(0).Value) Then
            pingObjsDict.Add(row.Cells(0).Value, ping)
        End If

        row.Cells(1).Value = "Getting latency..."

        ' Async operation for pinging whole server host range
        ' this loop maintains its context so I don't have to worry about unpredictability
        For i = 0 To 255
            Try
                Dim result = Await ping.SendPingAsync(addressNoHostValue + i.ToString(), 500)

                If row.Cells(1).Value = "Blocked" Then
                    Exit For
                End If

                If lowestPing = 0 Then
                    lowestPing = result.RoundtripTime
                End If

                If result.RoundtripTime > 0 And result.RoundtripTime < lowestPing Then
                    lowestPing = result.RoundtripTime

                    row.Cells(1).Value = lowestPing.ToString() + "ms"
                End If
            Catch ex As Exception
                Exit For
            End Try
        Next

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
