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
        Dim regex As Text.RegularExpressions.Regex = New Text.RegularExpressions.Regex("[^a-zA-Z0-9 ]")

        If String.IsNullOrWhiteSpace(presetName) Or regex.IsMatch(presetName) Then
            MessageBox.Show("Preset name field cannot be empty or have special characters.", "Info")

            Return
        End If

        If PresetServersCheckedListBox.CheckedItems.Count <= 0 Then
            MessageBox.Show("Please select atleast 1 or more servers to add a preset.", "Info")

            Return
        End If

        Try
            Dim jObj As JObject = JObject.Parse(File.ReadAllText("presets.json"))

            If jObj.ContainsKey(presetName.Replace(" ", "")) Then
                MessageBox.Show("Given preset name already exists.", "Info")

                Return
            End If

            ' create property using preset name trimmed as key with object as value that contains necessary props 
            ' "presetName" prop with untrimmed preset name as string value and "servers" prop contains the checked items as JArray value
            jObj.Add(presetName.Replace(" ", ""), New JObject(
                     New JProperty("presetName", presetName),
                     New JProperty("clustered", App.Get_Is_Clustered()),
                     New JProperty("servers", JArray.FromObject(PresetServersCheckedListBox.CheckedItems))
                )
            )

            ' serialize jObj to presets json file
            File.WriteAllText("presets.json", JsonConvert.SerializeObject(jObj, Formatting.Indented))

            ' refresh/reload presets control data grids
            Load_Presets()
        Catch ex As Exception
            MessageBox.Show("An error has occured while adding preset! Please report to github issue-tracker. Error: " _
                + Environment.NewLine + Environment.NewLine + ex.Message, "Add Preset Error")

            Return
        End Try

        MessageBox.Show("Succesfully added preset!")
    End Sub
End Class