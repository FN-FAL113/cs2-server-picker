Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Module DataGridViewService

    ' cache server flag image to prevent unnecessary requests
    Private ServerFlagDictionary As Dictionary(Of String, Image) = New Dictionary(Of String, Image)

    Public Sub Load_Server_List()
        Dim serverDict As Dictionary(Of String, String) = IIf(App.Get_Is_Clustered(), App.Get_Server_Dictionary_Clustered(), App.Get_Server_Dictionary_Unclustered)

        Dim dg As DataGridView = App.Get_DataGridView_Control()

        Dim wClient As WebClient = New WebClient()

        ' display each server name key value from server dictionary in the datagridview control
        For Each kvp As KeyValuePair(Of String, String) In serverDict
            Dim rowIndex As Integer = App.Get_DataGridView_Control().Rows().Add()

            If (Not ServerFlagDictionary.ContainsKey(kvp.Key)) Then
                Dim ipCountryRes As String = wClient.DownloadString(" https://ipapi.co/" + kvp.Value.Split(",")(0).ToString() + "/country_code")

                'Dim countryCodeJson As JObject = JObject.Parse(ipCountryRes)
                Dim countryCodeJson As String = ipCountryRes

                Dim image As Bitmap = Drawing.Image.FromStream(New MemoryStream(wClient.DownloadData("https://flagsapi.com/" + countryCodeJson.ToString() + "/flat/64.png")))

                dg.Rows(rowIndex).Cells(0).Value = image

                ServerFlagDictionary.Add(kvp.Key, image)
            Else
                dg.Rows(rowIndex).Cells(0).Value = ServerFlagDictionary(kvp.Key)
            End If

            dg.Rows(rowIndex).Cells(1).Value = kvp.Key
        Next

        wClient.Dispose()
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
