Public Class App

#If DEBUG Then
    Public Debug = True
#Else
    Public Debug = False
#End If

    Private serverDictClustered As New Dictionary(Of String, String)

    Private serverDictUnclustered As New Dictionary(Of String, String)

    Private pingObjsDict As New Dictionary(Of String, Net.NetworkInformation.Ping)

    Private pendingOperation As Boolean = False

    Private isClustered As Boolean = My.Settings.Is_Clustered

    Public Function Get_Server_Dictionary_Clustered() As Dictionary(Of String, String)
        Return serverDictClustered
    End Function

    Public Function Get_Server_Dictionary_Unclustered() As Dictionary(Of String, String)
        Return serverDictUnclustered
    End Function

    Public Function Get_Ping_Objects_Dictionary() As Dictionary(Of String, Net.NetworkInformation.Ping)
        Return pingObjsDict
    End Function

    Public Function Get_Pending_Operation() As Boolean
        Return pendingOperation
    End Function

    Public Sub Set_Pending_Operation(bool As Boolean)
        pendingOperation = bool

        ProgBar.Visible = bool
    End Sub

    Public Function Get_Is_Clustered() As Boolean
        Return isClustered
    End Function

    Public Sub Set_Is_Clustered(bool As Boolean)
        isClustered = bool
    End Sub

    Public Function Get_DataGridView_Control() As DataGridView
        Return MainDataGridView
    End Function

    Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
        Ping_All_Servers()
    End Sub

    Private Sub MainDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles MainDataGridView.SelectionChanged
        ' when selecting a single or multiple cell then also select whole row
        For Each cell As DataGridViewCell In MainDataGridView.SelectedCells
            MainDataGridView.Rows(cell.RowIndex).Selected = True
        Next
    End Sub

    Private Async Sub App_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Append to window title if using debug build
        If Debug Then
            Text = Text + " (DEBUG Build)"
        End If

        Version_Check()

        Set_Pending_Operation(True)

        Dim serverRevision As String = Await Fetch_Server_Data()

        Set_Pending_Operation(False)

        ' if app failed to retrieve server data or somehow steam api got updated with different response structure
        If serverRevision = "null" Then
            Return
        End If

        Load_Server_List()

        If Not My.Settings.Server_Revision = serverRevision Then
            MessageBox.Show("Server data just got updated by Valve! All blocked servers will be unblocked in order to synchronize new server data.", "Please Standby")

            My.Settings.Server_Revision = serverRevision
            My.Settings.Save()
            My.Settings.Reload()

            Await Block_Unblock_All_Servers(False)
        Else
            Ping_All_Servers()
        End If

        If isClustered Then
            ClusterButton.Text = "Uncluster"
        Else
            ClusterButton.Text = "Cluster"
        End If
    End Sub

    Private Sub App_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Cancel_Pending_Ping()
    End Sub

    Private Async Sub BlockAllButton_Click(sender As Object, e As EventArgs) Handles BlockAllButton.Click
        Await Block_Unblock_All_Servers(True)
    End Sub

    Private Async Sub UnblockAllButton_Click(sender As Object, e As EventArgs) Handles UnblockAllButton.Click
        Await Block_Unblock_All_Servers(False)
    End Sub

    Private Sub BlockSelectedButton_Click(sender As Object, e As EventArgs) Handles BlockSelectedButton.Click
        Block_Unblock_Selected_Servers(True)
    End Sub

    Private Sub UnblockSelectedButton_Click(sender As Object, e As EventArgs) Handles UnblockSelectedButton.Click
        Block_Unblock_Selected_Servers(False)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Process.Start("https://github.com/FN-FAL113/cs2-server-picker")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Process.Start("https://www.paypal.com/paypalme/fnfal113")
    End Sub

    Private Sub InfoButton_Click(sender As Object, e As EventArgs) Handles InfoButton.Click
        MessageBox.Show(
            "How to select server/s:" + Environment.NewLine +
            "  - hold down CTRL and left click any server." + Environment.NewLine +
            "  - hold down LEFT CLICK on a server then drag down." + Environment.NewLine +
            Environment.NewLine +
            "Note:" + Environment.NewLine +
            "  - Blocked servers will be automatically unblocked if server data is updated on next launch." + Environment.NewLine +
            "  - You may ping single or multiple selected server/s by double clicking on the highlighted region." + Environment.NewLine +
            "  - Servers that get un/clustered are China, India, Japan, Stockholm." + Environment.NewLine +
            Environment.NewLine +
            "Author: FN-FAL113 (github username)" + Environment.NewLine +
            "License: GNU General Public License V3" + Environment.NewLine +
            "App Version: " + IIf(Debug, "DEBUG", "2.5.0"),
            "App Info"
        )
    End Sub

    Private Sub MainDataGridView_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles MainDataGridView.SortCompare
        ' sort latency column by splitting "ms" and parsing numeric value
        e.Handled = True

        If e.CellValue1 Is Nothing Or e.CellValue2 Is Nothing Then Return

        If e.Column.Index = 2 Then
            Dim cell1Val As Integer = Integer.Parse(IIf(e.CellValue1.ToString().Contains("ms"), e.CellValue1.ToString().Split("ms")(0), "999999"))
            Dim cell2Val As Integer = Integer.Parse(IIf(e.CellValue2.ToString().Contains("ms"), e.CellValue2.ToString().Split("ms")(0), "999999"))

            e.SortResult = cell1Val.CompareTo(cell2Val)
        End If
    End Sub

    Private Sub MainDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles MainDataGridView.CellDoubleClick
        If e.RowIndex = -1 Or MainDataGridView.SelectedRows.Count <= 0 Then
            Return
        End If

        Ping_Servers(MainDataGridView.SelectedRows)
    End Sub

    Private Async Sub ClusterButton_Click(sender As Object, e As EventArgs) Handles ClusterButton.Click
        If pendingOperation Then
            MessageBox.Show("Operation in progress, please wait a moment...")

            Return
        End If

        MessageBox.Show("App will unblock all servers before " + IIf(isClustered, "unclustering", "clustering") + " servers. Please standby...", "Info")

        Await Block_Unblock_All_Servers(False, False)

        Clear_DataGridView_Rows()

        If isClustered Then
            ClusterButton.Text = "Cluster"

            isClustered = False
        Else
            ClusterButton.Text = "Uncluster"

            isClustered = True
        End If

        Load_Server_List()

        ' save clustered settings
        My.Settings.Is_Clustered = isClustered
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub PresetsButton_Click(sender As Object, e As EventArgs) Handles PresetsButton.Click
        Presets.ShowDialog()
        Presets.Activate()
    End Sub

    Private Sub SettingsIcon_Click(sender As Object, e As EventArgs) Handles SettingsIcon.Click
        Settings.ShowDialog()
        Settings.Activate()
    End Sub
End Class
