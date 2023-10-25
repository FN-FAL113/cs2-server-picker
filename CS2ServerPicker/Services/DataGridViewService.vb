Module DataGridViewService
    Public Sub Load_Server_List()
        Dim i As Integer = 0

        Dim serverDict As Dictionary(Of String, String) = IIf(App.Get_Is_Clustered(), App.Get_Server_Dictionary_Clustered(), App.Get_Server_Dictionary_Unclustered)

        ' display each server name key value from server dictionary in the datagridview control
        For Each kvp As KeyValuePair(Of String, String) In serverDict
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

    Public Sub Clear_DataGridView_Rows()
        App.Get_DataGridView_Control.Rows.Clear()
    End Sub
End Module
