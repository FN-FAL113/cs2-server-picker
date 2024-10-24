Module DataGridViewService

    Public Sub Load_Server_List()
        Dim serverDict As Dictionary(Of String, String) = IIf(App.Get_Is_Clustered(), App.Get_Server_Dictionary_Clustered(), App.Get_Server_Dictionary_Unclustered)

        Dim dg As DataGridView = App.Get_DataGridView_Control()

        ' display each server name key value from server dictionary in the datagridview control
        For Each kvp As KeyValuePair(Of String, String) In serverDict
            Dim rowIndex As Integer = App.Get_DataGridView_Control().Rows().Add()

            dg.Rows(rowIndex).Cells(0).Value = My.Resources.ResourceManager.GetObject(kvp.Key)
            dg.Rows(rowIndex).Cells(1).Value = kvp.Key
        Next

    End Sub

    Public Sub Clear_Column_Values()
        For Each row As DataGridViewRow In App.Get_DataGridView_Control().Rows
            row.Cells(2).Value = String.Empty
            row.Cells(2).Style.BackColor = Color.Empty
        Next
    End Sub

    Public Sub Clear_DataGridView_Rows()
        App.Get_DataGridView_Control.Rows.Clear()
    End Sub
End Module
