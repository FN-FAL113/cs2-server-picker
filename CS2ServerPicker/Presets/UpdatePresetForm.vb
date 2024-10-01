Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class UpdatePresetForm

    Private initialPresetName As String

    Private Sub UpdatePresetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' reset checked list box items
        PresetServersCheckedListBox.Items.Clear()

        ' will be used to select unmodified JObject instead of using updated preset name
        initialPresetName = Presets.PresetsDataGridView.SelectedCells.Item(0).Value

        UpdatePresetNameTextBox.Text = initialPresetName

        ' load server dictionary names to checked list box on add preset form load
        Dim serverDictionary As Dictionary(Of String, String) = IIf(App.Get_Is_Clustered(), App.Get_Server_Dictionary_Clustered(), App.Get_Server_Dictionary_Unclustered())

        Dim presetServersDataGridView As DataGridView = Presets.PresetServerListDataGridView

        Dim presetServerNames As HashSet(Of String) = New HashSet(Of String)

        ' collect preset server names as basis for displaying preset servers
        For Each presetRow As DataGridViewRow In presetServersDataGridView.Rows
            presetServerNames.Add(presetRow.Cells(0).Value)
        Next

        For Each serverKvp As KeyValuePair(Of String, String) In serverDictionary
            Dim serverIndex As Integer = PresetServersCheckedListBox.Items.Add(serverKvp.Key)

            ' conditionally check preset servers
            If presetServerNames.Contains(serverKvp.Key) Then
                PresetServersCheckedListBox.SetItemChecked(serverIndex, True)
            End If
        Next
    End Sub

    Private Sub UpdatePresetButton_Click(sender As Object, e As EventArgs) Handles UpdatePresetButton.Click
        Dim presetName As String = UpdatePresetNameTextBox.Text
        Dim presetNameTrimmed = presetName.Replace(" ", "")
        Dim regex As Text.RegularExpressions.Regex = New Text.RegularExpressions.Regex("[^a-zA-Z0-9 ]")

        If String.IsNullOrWhiteSpace(presetName) Or regex.IsMatch(presetName) Then
            MessageBox.Show("Preset name field cannot be empty nor have any special characters.", "Info")

            Return
        End If

        If PresetServersCheckedListBox.CheckedItems.Count <= 0 Then
            MessageBox.Show("Please select preset servers.", "Info")

            Return
        End If

        Try
            ' deserialize presets back to its complex form
            Dim jObj As JObject = JObject.Parse(File.ReadAllText("presets.json"))

            ' remove old property, an exception will be thrown if same property exist
            jObj.Remove(initialPresetName.Replace(" ", ""))

            ' property uses trimmed preset name, untrimmed preset name through a child prop (presetName)
            jObj.Add(presetNameTrimmed, New JObject(
                     New JProperty("presetName", presetName),
                     New JProperty("clustered", App.Get_Is_Clustered()),
                     New JProperty("servers", JArray.FromObject(PresetServersCheckedListBox.CheckedItems))
                )
            )

            ' serialize jObj to primitive form in presets json file
            File.WriteAllText("presets.json", JsonConvert.SerializeObject(jObj, Formatting.Indented))

            ' refresh/reload presets control data grids
            Presets.Load_Presets()

            initialPresetName = presetName

            MessageBox.Show("Succesfully updated preset!", "Info")
        Catch ex As Exception
            Log_Exception_To_File(ex, "An error has occured while updating preset!")

            MessageBox.Show("An error has occured while updating preset! Please upload error file to github issue tracker.", "Update Preset Error")
        End Try
    End Sub

    Private Sub ResetPresetSelectionButton_Click(sender As Object, e As EventArgs) Handles ResetPresetSelectionButton.Click
        Dim checkedIndexes As CheckedListBox.CheckedIndexCollection = PresetServersCheckedListBox.CheckedIndices

        If checkedIndexes.Count = 0 Then
            Return
        End If

        For Each selectedIndex As Integer In checkedIndexes
            PresetServersCheckedListBox.SetItemChecked(selectedIndex, False)
        Next
    End Sub
End Class