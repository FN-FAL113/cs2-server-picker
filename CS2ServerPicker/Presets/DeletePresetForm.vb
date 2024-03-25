﻿Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO

Public Class DeletePresetForm
    Private Sub DeletePresetButton_Click(sender As Object, e As EventArgs) Handles DeletePresetButton.Click
        If Presets.PresetsDataGridView.SelectedCells.Count <= 0 Then
            MessageBox.Show("Please select a preset to delete.", "Info")

            Return
        End If

        ' delete a preset from given preset name on delete preset button click
        Dim presetName As String = Presets.PresetsDataGridView.SelectedCells.Item(0).Value

        If String.IsNullOrWhiteSpace(presetName) Then
            MessageBox.Show("Preset name field cannot be empty.", "Info")

            Return
        End If

        Try
            Dim jObj As JObject = JObject.Parse(File.ReadAllText("presets.json"))

            If Not jObj.ContainsKey(presetName.Replace(" ", "")) Then
                MessageBox.Show("Given preset name does not exists.", "Info")

                Return
            End If

            ' remove property from jObj
            jObj.Remove(presetName.Replace(" ", ""))

            ' serialize jObj to presets json file
            File.WriteAllText("presets.json", JsonConvert.SerializeObject(jObj, Formatting.Indented))

            ' refresh/reload presets control data grids
            Presets.Load_Presets()
        Catch ex As Exception
            MessageBox.Show("An error has occured while deleting preset! Please report to github issue-tracker. Error: " _
                + Environment.NewLine + Environment.NewLine + ex.Message, "Delete Preset Error")

            Return
        End Try

        MessageBox.Show("Succesfully deleted preset!")

        Close()
    End Sub

    Private Sub CloseDeletePresetFormButton_Click(sender As Object, e As EventArgs) Handles CloseDeletePresetFormButton.Click
        Close()
    End Sub
End Class