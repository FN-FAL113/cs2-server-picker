Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO

Public Class AddPresetForm
    Private Sub AddPresetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' reset checked list box items
        PresetServersCheckedListBox.Items.Clear()

        ' load server dictionary names to checked list box on add preset form load
        Dim serverDictionary As Dictionary(Of String, String) = IIf(App.Get_Is_Clustered(), App.Get_Server_Dictionary_Clustered(), App.Get_Server_Dictionary_Unclustered())

        For Each kvp As KeyValuePair(Of String, String) In serverDictionary
            PresetServersCheckedListBox.Items.Add(kvp.Key)
        Next
    End Sub

    Private Sub AddPresetButton_Click(sender As Object, e As EventArgs) Handles AddPresetButton.Click
        ' add/create a preset from selected servers on add preset button click
        Dim presetName As String = AddPresetNameTextBox.Text
        Dim presetNameTrimmed = presetName.Replace(" ", "")
        Dim regex As Text.RegularExpressions.Regex = New Text.RegularExpressions.Regex("[^a-zA-Z0-9 ]")

        If String.IsNullOrWhiteSpace(presetName) Or regex.IsMatch(presetName) Then
            MessageBox.Show("Preset name field cannot be empty nor have special characters.", "Info")

            Return
        End If

        If PresetServersCheckedListBox.CheckedItems.Count <= 0 Then
            MessageBox.Show("Please select atleast 1 or more servers to add a preset.", "Info")

            Return
        End If

        Try
            ' deserialize presets back to its complex form
            Dim jObj As JObject = JObject.Parse(File.ReadAllText("presets.json"))

            If jObj.ContainsKey(presetNameTrimmed) Then
                MessageBox.Show("Given preset name already exists.", "Info")

                Return
            End If

            ' property uses trimmed preset name, access unmodified name through child prop (presetName)
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

            MessageBox.Show("Succesfully added preset!", "Info")
        Catch ex As Exception
            Log_Exception_To_File(ex, "An error has occured while adding preset!")

            MessageBox.Show("An error has occured while adding preset! Please upload error file to github issue tracker.", "Add Preset Error")
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