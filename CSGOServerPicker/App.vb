Public Class App

    Private serverDict As New Dictionary(Of String, String) From {
        {"London (Europe)", "162.254.196.0-162.254.196.255"},
        {"Madrid (Europe)", "155.133.246.0-155.133.246.255"},
        {"Luxembourg (Europe)", "188.42.190.0-188.42.190.255"},
        {"Frankfurt (Europe)", "162.254.197.0-162.254.197.255," +
                    "155.133.226.0-155.133.226.255"},
        {"Strasbourg (Europe)", "134.119.207.0-134.119.207.255," +
                                "151.106.18.0-151.106.18.255"},
        {"Paris (Europe)", "185.25.182.0-185.25.182.255"},
        {"Amsterdam (Europe)", "155.133.248.0-155.133.248.255"},
        {"Stockholm - Kista (Europe)", "162.254.198.0-162.254.198.255"},
        {"Stockholm - Broma (Europe)", "155.133.252.0-155.133.252.255"},
        {"Vienna (Europe)", "146.66.155.0-146.66.155.255"},
        {"Warsaw (Europe)", "155.133.230.0-155.133.230.255"},
        {"Los Angeles (USA)", "162.254.195.0-162.254.195.255"},
        {"Dallas (USA)", "162.213.192.0-162.213.192.255"},
        {"Seattle (USA)", "205.196.6.0-205.196.6.255"},
        {"Sterling (USA)", "162.254.192.0-162.254.192.255"},
        {"Chicago (USA)", "162.254.193.0-162.254.193.255"},
        {"Atlanta (USA)", "162.254.199.0-162.254.199.255"},
        {"Miami (USA)", "23.251.100.0-23.251.100.255"},
        {"New York (USA)", "74.201.228.0-74.201.228.255"},
        {"Salt Lake City (USA)", "68.169.42.0-68.169.42.255"},
        {"San Jose (USA)", "173.237.41.0-173.237.41.255," +
                            "173.237.51.0-173.237.51.255"},
        {"St Louis (USA)", "148.72.168.0-148.72.168.255," +
                            "148.72.174.0-148.72.174.255"},
        {"Sao Paulo (South America)", "155.133.227.0-155.133.227.255"},
        {"Lima (South America)", "190.217.33.0-190.217.33.255"},
        {"Santiago (South America)", "155.133.249.0-155.133.249.255"},
        {"Buenos Aires (South America)", "155.133.255.0-155.133.255.255"},
        {"China (Asia)", "103.28.54.0-103.28.54.255," +
                            "155.133.253.0-155.133.253.255," +
                            "125.88.173.0-125.88.173.255," +
                            "220.194.68.0-220.194.68.255," +
                            "61.182.135.0-61.182.135.255," +
                            "116.211.132.0-116.211.132.255," +
                            "183.136.230.0-183.136.230.255," +
                            "180.153.252.0-180.153.252.255," +
                            "183.232.229.0-183.232.229.255," +
                            "117.184.42.0-117.184.42.255," +
                            "111.32.164.0-111.32.164.255," +
                            "125.88.174.0-125.88.174.255," +
                            "121.46.225.0-121.46.225.255," +
                            "42.81.120.0-42.81.120.255," +
                            "157.255.37.0-157.255.37.255," +
                            "211.95.37.0-211.95.37.255," +
                            "125.39.181.0-125.39.181.255"},
        {"Singapore (Asia)", "103.10.124.0-103.10.124.255"},
        {"Seoul (Asia)", "146.66.152.0-146.66.152.255"},
        {"Chennai (Asia)", "155.133.232.0-155.133.232.255"},
        {"Mumbai (Asia)", "155.133.233.0-155.133.233.255"},
        {"Japan (Asia)", "155.133.245.0-155.133.245.255," +
                        "155.133.239.0-155.133.239.255"},
        {"Dubai (Asia)", "185.25.183.0-185.25.183.255"},
        {"Johannesburg (Africa)", "155.133.238.0-155.133.238.255"},
        {"Sydney (Australia)", "103.10.125.0-103.10.125.255"}
    }

    Private pingObjs As List(Of Net.NetworkInformation.Ping) = New List(Of Net.NetworkInformation.Ping)

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
        Load_Server_List()

        Ping_Servers()
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
