Public Class App

    Private serverDict As New Dictionary(Of String, String)

    Private pingObjs As List(Of Net.NetworkInformation.Ping) = New List(Of Net.NetworkInformation.Ping)
    Public Property relays As String

    Public Function Get_Server_Dictionary() As Dictionary(Of String, String)
        Return serverDict
    End Function

    Public Function Get_DataGridView_Control() As DataGridView
        Return MainDataGridView
    End Function

    Public Function Get_Ping_Objects() As List(Of Net.NetworkInformation.Ping)
        Return pingObjs
    End Function

    Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
        Ping_Servers()
    End Sub

    Private Sub MainDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles MainDataGridView.SelectionChanged
        ' when selecting a single or multiple cell then also select whole row
        For Each cell As DataGridViewCell In MainDataGridView.SelectedCells
            MainDataGridView.Rows(cell.RowIndex).Selected = True
        Next
    End Sub

    Private Sub App_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim serverRevision As String = Fetch_Server_Data()

        ' if app failed to retrieve server data
        If serverRevision = "null" Then
            Return
        End If

        Load_Server_List()

        If Not My.Settings.Server_Revision = serverRevision Then
            MessageBox.Show("Server data just got updated by Valve! All blocked servers will be unblocked in order to synchronize new server data.", "Please Standby")

            My.Settings.Server_Revision = serverRevision
            My.Settings.Save()
            My.Settings.Reload()

            Should_Block_All_Servers(False)
        Else
            Ping_Servers()
        End If
    End Sub

    Private Sub App_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Cancel_Pending_Ping()
    End Sub

    Private Sub BlockAllButton_Click(sender As Object, e As EventArgs) Handles BlockAllButton.Click
        Should_Block_All_Servers(True)
    End Sub

    Private Sub BlockSelectedButton_Click(sender As Object, e As EventArgs) Handles BlockSelectedButton.Click
        Should_Block_Selected_Servers(True)
    End Sub

    Private Sub UnblockAllButton_Click(sender As Object, e As EventArgs) Handles UnblockAllButton.Click
        Should_Block_All_Servers(False)
    End Sub

    Private Sub UnblockSelectedButton_Click(sender As Object, e As EventArgs) Handles UnblockSelectedButton.Click
        Should_Block_Selected_Servers(False)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Process.Start("https://github.com/FN-FAL113/csgo-server-picker")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show(
            "How to select server:" + Environment.NewLine +
            "  - hold down CTRL to select multiple server or" + Environment.NewLine +
            "  - hold LEFT CLICK on a server name then drag down" + Environment.NewLine +
            Environment.NewLine + Environment.NewLine +
            "Author: FN-FAL113 (Github username)" + Environment.NewLine +
            "License: GNU General Public License V3",
            "App Info"
        )
    End Sub

    Private Sub MainDataGridView_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles MainDataGridView.SortCompare
        ' sort latency column by splitting "ms" and parsing numeric value
        If e.Column.Index = 1 Then
            Dim cell1Val As Integer = Integer.Parse(IIf(e.CellValue1.ToString().Contains("ms"), e.CellValue1.ToString().Split("ms")(0), "999999"))
            Dim cell2Val As Integer = Integer.Parse(IIf(e.CellValue2.ToString().Contains("ms"), e.CellValue2.ToString().Split("ms")(0), "999999"))

            e.SortResult = cell1Val.CompareTo(cell2Val)
            e.Handled = True
        End If
    End Sub
End Class
