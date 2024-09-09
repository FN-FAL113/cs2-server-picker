Public Class Settings

    Private Sub VersionCheckerCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles VersionCheckerCheckBox.CheckedChanged
        My.Settings.VersionCheckOnStartup = VersionCheckerCheckBox.Checked
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VersionCheckerCheckBox.Checked = My.Settings.VersionCheckOnStartup
    End Sub

End Class