Module PingService
    Public Sub Ping_Servers()
        Clear_Column_Values()

        Cancel_Pending_Ping()

        For Each dgRow As DataGridViewRow In App.Get_DataGridView_Control().Rows()
            For Each addressRange As String In App.Get_Server_Dictionary().Item(dgRow.Cells(0).Value).Split(",")
                ' replace host id from ip address since this will be traversed from 0 to max 8 bit value
                Dim startingAdress = addressRange.Split("-")(0)
                Dim address As String = startingAdress.Remove(startingAdress.LastIndexOf(".") + 1, startingAdress.Split(".")(3).Length)

                Call Ping_Handler(address, dgRow)

                Exit For
            Next
        Next
    End Sub

    Public Async Sub Ping_Handler(address As String, row As DataGridViewRow)
        '' do not ping if server is blocked
        With row
            If Is_Server_Blocked(.Cells(0).Value, True) Then
                .Cells(0).Style.BackColor = Color.Red
                .Cells(1).Value = "Blocked"


                Return
            ElseIf .Cells(0).Style.BackColor = Color.Red Then
                .Cells(0).Style.BackColor = Color.Empty
            End If
        End With

        Dim ping As New Net.NetworkInformation.Ping
        Dim lowestPing As Integer = 0

        ' add created ping obj to a list that will be cleared disposed and cleared on ping cancel or form close
        App.Get_Ping_Objects.Add(ping)

        row.Cells(1).Value = "Getting latency..."

        ' Async operation for pinging an ip range
        ' this loop maintains its context so I don't have to worry about unpredictability
        ' ping whole server host range
        For i = 0 To 255
            Try
                Dim result = Await ping.SendPingAsync(address + i.ToString(), 500)

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

    Public Sub Cancel_Pending_Ping()
        Dim pingObjs = App.Get_Ping_Objects()

        If pingObjs.Count <= 0 Then
            Return
        End If

        For Each ping As Net.NetworkInformation.Ping In pingObjs
            ping.SendAsyncCancel()
        Next

        pingObjs.Clear()
    End Sub
End Module
