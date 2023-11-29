Imports Newtonsoft.Json.Linq
Imports System.IO

Module DataGridViewService
    Public Sub Load_Server_List()
        Dim serverDict As Dictionary(Of String, String) = IIf(App.Get_Is_Clustered(), App.Get_Server_Dictionary_Clustered(), App.Get_Server_Dictionary_Unclustered)

        ' display each server name key value from server dictionary in the datagridview control
        For Each kvp As KeyValuePair(Of String, String) In serverDict
            Dim rowIndex As Integer = App.Get_DataGridView_Control().Rows().Add()

            App.Get_DataGridView_Control().Rows(rowIndex).Cells(0).Value = kvp.Key
        Next
    End Sub

    Public Sub Load_Presets()
        ' load presets into presets data grid view

        ' clear preset and preset servers datagrid view rows
        Presets.PresetsDataGridView.Rows.Clear()
        Presets.PresetServerListDataGridView.Rows.Clear()

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

                Dim rowIndex As Integer = Presets.PresetsDataGridView.Rows.Add()

                Presets.PresetsDataGridView.Rows(rowIndex).Cells(0).Value = preset.Value.SelectToken("presetName")
            Next
        Catch ex As Exception
            MessageBox.Show("An error has occured while loading presets! Please report to github issue-tracker. Error: " _
                + Environment.NewLine + Environment.NewLine + ex.Message, "Load Presets Error")
        End Try
    End Sub

    Public Sub Load_Preset_Servers(presetName As String)
        If String.IsNullOrWhiteSpace(presetName) Then
            Return
        End If

        ' clear preset servers datagrid view rows
        Presets.PresetServerListDataGridView.Rows.Clear()

        Try
            ' create preset json file if not exists, then refresh/reload preset names inside preset names datagrid view
            ' this will only get triggered probably if presets.json file was deleted before loading preset servers
            If Not File.Exists("presets.json") Then
                MessageBox.Show("Presets missing!. Presets file must have been deleted.", "Info")

                Load_Presets()

                Return
            End If

            Dim presetsObj As JObject = JObject.Parse(File.ReadAllText("presets.json"))

            ' iterate selected preset name JArray servers to be added inside preset servers datagrid view
            ' escape preset name prop key to prevent invalid json path exception even if adding preset with special characters is not allowed
            For Each server As JValue In presetsObj.SelectToken("['" + presetName.Replace(" ", "") + "']" + "." + "servers")
                Dim rowIndex As Integer = Presets.PresetServerListDataGridView.Rows.Add()

                Presets.PresetServerListDataGridView.Rows(rowIndex).Cells(0).Value = server
            Next
        Catch ex As Exception
            MessageBox.Show("An error has occured while loading preset servers! Please report to github issue-tracker. Error: " _
               + Environment.NewLine + Environment.NewLine + ex.Message, "Load Preset Servers Error")
        End Try
    End Sub

    Public Sub Clear_Column_Values()
        For Each row As DataGridViewRow In App.Get_DataGridView_Control().Rows
            row.Cells(1).Value = String.Empty
            row.Cells(1).Style.BackColor = Color.Empty
        Next
    End Sub

    Public Sub Clear_DataGridView_Rows()
        App.Get_DataGridView_Control.Rows.Clear()
    End Sub
End Module
