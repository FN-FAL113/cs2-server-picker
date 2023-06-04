Public Class App

    Private serverDict As New Dictionary(Of String, String) From {
        {"Frankfurt (Europe)", "162.254.197.36-162.254.197.52," +
                    "155.133.226.68-155.133.226.73"},
        {"Madrid (Europe)", "155.133.246.34-155.133.246.50"},
        {"Stockholm - Kista (Europe)", "162.254.198.41-162.254.198.103"},
        {"Vienna (Europe)", "146.66.155.66-146.66.155.69"},
        {"Warsaw (Europe)", "155.133.230.98-155.133.230.101"},
        {"Los Angeles (USA)", "162.254.195.70-162.254.195.74"},
        {"Seattle (USA)", "205.196.6.210-205.196.6.213"},
        {"Sterling (USA)", "162.254.192.66-162.254.192.73"},
        {"Chicago (USA)", "162.254.193.71-162.254.193.101"},
        {"Atlanta (USA)", "162.254.199.170-162.254.199.180"},
        {"Sao Paulo (South America)", "155.133.227.35-155.133.227.52"},
        {"Lima (South America)", "190.217.33.34-190.217.33.66"},
        {"Santiago (South America)", "155.133.249.0-155.133.249.255"},
        {"Buenos Aires (South America)", "155.133.255.98-155.133.255.163"},
        {"China (Asia)", "103.28.54.163-103.28.54.184," +
                            "155.133.253.38-155.133.253.55," +
                            "125.88.173.11-125.88.173.14," +
                            "220.194.68.11-220.194.68.14," +
                            "61.182.135.15-61.182.135.72," +
                            "116.211.132.11-116.211.132.14," +
                            "183.136.230.11-183.136.230.14," +
                            "180.153.252.11-180.153.252.14," +
                            "183.232.229.200-183.232.229.205," +
                            "117.184.42.132-117.184.42.137," +
                            "111.32.164.141-111.32.164.146," +
                            "125.88.174.11-125.88.174.16," +
                            "121.46.225.11-121.46.225.16," +
                            "42.81.120.140-42.81.120.145," +
                            "157.255.37.14-157.255.37.19," +
                            "211.95.37.141-211.95.37.146," +
                            "125.39.181.11-125.39.181.16"},
        {"Singapore (Asia)", "103.10.124.116-103.10.124.121"},
        {"Seoul (Asia)", "146.66.152.36-146.66.152.42"},
        {"Chennai (Asia)", "155.133.232.98-155.133.232.99"},
        {"Mumbai (Asia)", "155.133.233.98-155.133.233.100"},
        {"Japan (Asia)", "155.133.245.34-155.133.245.36," +
                        "155.133.239.19-155.133.239.59"},
        {"Dubai (Asia)", "185.25.183.163-185.25.183.179"},
        {"Johannesburg (Africa)", "155.133.238.178-155.133.238.194"},
        {"Sydney (Australia)", "103.10.125.146-103.10.125.155"}
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
        Call Ping_Servers()
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
        Process.Start("https://github.com/FN-FAL113")
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
End Class
