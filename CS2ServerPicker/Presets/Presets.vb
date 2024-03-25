Imports Newtonsoft.Json.Linq
Imports System.IO

Public Class Presets
    Private Sub AddPresetFormButton_Click(sender As Object, e As EventArgs) Handles AddPresetFormButton.Click
        AddPresetForm.ShowDialog()
        AddPresetForm.Activate()
    End Sub

    Private Sub DeletePresetFormButton_Click(sender As Object, e As EventArgs) Handles DeletePresetFormButton.Click
        DeletePresetForm.ShowDialog()
        DeletePresetForm.Activate()
    End Sub

    Private Sub UpdatePresetFormButton_Click(sender As Object, e As EventArgs) Handles UpdatePresetFormButton.Click
        UpdatePresetForm.ShowDialog()
        UpdatePresetForm.Activate()
    End Sub

    Private Sub BlockPresetServersButton_Click(sender As Object, e As EventArgs) Handles BlockPresetServersButton.Click
        If PresetServerListDataGridView.Rows.Count <= 0 Then
            MessageBox.Show("Please select a preset above.", "Info")

            Return
        End If

        ActiveForm.Close()

        Block_Except_Preset_Servers(False)
    End Sub

    Private Sub BlockExceptPresetServersButton_Click(sender As Object, e As EventArgs) Handles BlockExceptPresetServersButton.Click
        If PresetServerListDataGridView.Rows.Count <= 0 Then
            MessageBox.Show("Please select a preset above.", "Info")

            Return
        End If

        ActiveForm.Close()

        Block_Except_Preset_Servers(True)
    End Sub

    Private Sub Presets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Presets()
    End Sub

    Private Sub PresetsDataGridView_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PresetsDataGridView.CellEnter
        ' load preset servers for the initial focused (first cell is focused on load) or user selected preset name cell 
        ' this event gets fired twice on initial load, cell value validations needed
        Dim presetName As String = PresetsDataGridView.Rows(e.RowIndex).Cells(0).Value

        If String.IsNullOrWhiteSpace(presetName) Then
            Return
        End If

        Load_Preset_Servers(presetName)
    End Sub

    Public Sub Load_Presets()
        ' load presets into presets data grid view

        ' clear preset and preset servers datagrid view rows
        PresetsDataGridView.Rows.Clear()
        PresetServerListDataGridView.Rows.Clear()

        Try
            ' create preset json file if not exists
            If Not File.Exists("presets.json") Then
                File.WriteAllText("presets.json", "{}")

                Return
            End If

            Dim presetsObj As JToken = JObject.Parse(File.ReadAllText("presets.json"))

            ' iterate presetsObj children properties to be added inside presets datagrid view
            For Each preset As JProperty In presetsObj
                ' skip adding preset if preset cluster boolean value is not equal to current cluster setting
                If Not CBool(preset.Value.SelectToken("clustered")) = App.Get_Is_Clustered() Then
                    Continue For
                End If

                Dim rowIndex As Integer = PresetsDataGridView.Rows.Add()

                PresetsDataGridView.Rows(rowIndex).Cells(0).Value = preset.Value.SelectToken("presetName")
            Next
        Catch ex As Exception
            MessageBox.Show("An error has occured while loading presets! Please report to github issue-tracker. Error: " _
                + Environment.NewLine + Environment.NewLine + ex.Message, "Load Presets Error")
        End Try
    End Sub

    Public Sub Load_Preset_Servers(presetName As String)
        ' clear preset servers datagrid view rows
        PresetServerListDataGridView.Rows.Clear()

        Try
            ' this will only get triggered probably if presets.json file was deleted before loading preset servers
            If Not File.Exists("presets.json") Then
                MessageBox.Show("Presets missing! Presets file must have been deleted.", "Info")

                Load_Presets()

                Return
            End If

            Dim presetsObj As JObject = JObject.Parse(File.ReadAllText("presets.json"))

            ' iterate selected preset JArray servers to be added inside preset servers datagrid view
            ' escape preset name prop key to prevent invalid json path exception
            For Each server As JValue In presetsObj.SelectToken("['" + presetName.Replace(" ", "") + "']" + "." + "servers")
                Dim rowIndex As Integer = PresetServerListDataGridView.Rows.Add()

                PresetServerListDataGridView.Rows(rowIndex).Cells(0).Value = server
            Next
        Catch ex As Exception
            MessageBox.Show("An error has occured while loading preset servers! Please report to github issue-tracker. Error: " _
               + Environment.NewLine + Environment.NewLine + ex.Message, "Load Preset Servers Error")
        End Try
    End Sub
End Class