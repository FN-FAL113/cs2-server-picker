Module DataGridViewService
    Public Sub Load_Server_List()
        Dim i As Integer = 0

        ' display each server name key value from server dictionary in the datagridview control
        For Each kvp As KeyValuePair(Of String, String) In App.Get_Server_Dictionary()
            App.Get_DataGridView_Control().Rows().Add()
            App.Get_DataGridView_Control().Rows(i).Cells(0).Value = kvp.Key

            i += 1
        Next
    End Sub

    Public Sub Clear_Column_Values()
        For Each row As DataGridViewRow In App.Get_DataGridView_Control().Rows
            row.Cells(1).Value = String.Empty
        Next
    End Sub
End Module
