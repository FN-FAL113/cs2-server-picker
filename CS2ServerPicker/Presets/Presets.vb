Public Class Presets
    Private Sub AddPresetFormButton_Click(sender As Object, e As EventArgs) Handles AddPresetFormButton.Click
        AddPresetForm.ShowDialog()
        AddPresetForm.Activate()
    End Sub

    Private Sub DeletePresetFormButton_Click(sender As Object, e As EventArgs) Handles DeletePresetFormButton.Click
        DeletePresetForm.ShowDialog()
        DeletePresetForm.Activate()
    End Sub

    Private Sub Presets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Presets()
    End Sub

    Private Sub PresetsDataGridView_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PresetsDataGridView.CellEnter
        ' load preset servers for the initial focused (first cell is focused on load) or user selected preset name cell 
        ' this event gets fired twice on initial load, cell value validations needed
        Dim presetName As String = PresetsDataGridView.Rows(e.RowIndex).Cells(0).Value

        Load_Preset_Servers(presetName)
    End Sub

    Private Sub BlockPresetServersButton_Click(sender As Object, e As EventArgs) Handles BlockPresetServersButton.Click
        If PresetServerListDataGridView.Rows.Count <= 0 Then
            MessageBox.Show("Please select a preset that contain servers.", "Info")

            Return
        End If

        ActiveForm.Close()

        Block_Preset_Servers()
    End Sub
End Class