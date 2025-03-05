Imports System.IO

Public Class Settings

    Private netshPath As String = Path.Combine(Environment.SystemDirectory, "netsh.exe")

    Private Sub VersionCheckerCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles VersionCheckerCheckBox.CheckedChanged
        My.Settings.VersionCheckOnStartup = VersionCheckerCheckBox.Checked
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VersionCheckerCheckBox.Checked = My.Settings.VersionCheckOnStartup
    End Sub

    Private Sub ResetFirewallButton_Click(sender As Object, e As EventArgs) Handles ResetFirewallButton.Click
        Dim resetWindowsFirewallRes As DialogResult = MessageBox.Show("This will attempt to reset windows firewall to its default state. Confirm action?", "Reset Windows Firewall", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If resetWindowsFirewallRes = DialogResult.No Then
            Return
        End If

        Try
            Dim proc As Process = Create_Custom_CMD_Process()

            proc.StartInfo.Arguments = $"/c {netshPath} advfirewall reset"
            proc.Start()
            proc.WaitForExit()

            If proc.ExitCode = 1 Or proc.ExitCode < 0 Then
                Throw New Exception("Sdtout: " + proc.StandardOutput.ReadToEnd() + Environment.NewLine + "Stderr: " + proc.StandardError.ReadToEnd())
            End If

            MessageBox.Show("Windows firewall reset successful!", "Reset Windows Firewall", MessageBoxButtons.OK, MessageBoxIcon.Information)

            proc.Dispose()
        Catch ex As Exception
            Log_Exception_To_File(ex, "An error has occurred while resetting windows firewall!")

            MessageBox.Show("An error has occurred while resetting windows firewall!", "Error")
        End Try
    End Sub

    Private Sub CheckFirewallButton_Click(sender As Object, e As EventArgs) Handles CheckFirewallButton.Click
        Dim checkWindowsFirewallRes As DialogResult = MessageBox.Show("This will attempt to check current state of windows firewall. Confirm action?", "Check Windows Firewall", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If checkWindowsFirewallRes = DialogResult.No Then
            Return
        End If

        Try
            Dim proc As Process = Create_Custom_CMD_Process()

            proc.StartInfo.Arguments = $"/c {netshPath} advfirewall show allprofiles state"
            proc.Start()
            proc.WaitForExit()

            If proc.ExitCode = 1 Or proc.ExitCode < 0 Then
                Throw New Exception("On firewall check" + Environment.NewLine + "StdOut: " + proc.StandardOutput.ReadToEnd() + Environment.NewLine + "StdErr: " + proc.StandardError.ReadToEnd())
            End If

            If proc.StandardOutput.ReadToEnd().Contains("OFF") Then
                Dim enableWinFirewallRes As DialogResult = MessageBox.Show("This will attempt to enable windows firewall. Confirm action?", "Enable Windows Firewall", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                If enableWinFirewallRes = DialogResult.No Then
                    Return
                End If

                proc.StartInfo.Arguments = $"/c {netshPath} advfirewall set allprofiles state on"
                proc.Start()
                proc.WaitForExit()

                If proc.ExitCode = 1 Or proc.ExitCode < 0 Then
                    Throw New Exception("On firewall enable" + Environment.NewLine + "StdOut: " + proc.StandardOutput.ReadToEnd() + Environment.NewLine + "StdErr: " + proc.StandardError.ReadToEnd())
                End If

                MessageBox.Show("Windows firewall profile states successfully enabled!", "Enable Windows Firewall", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Windows firewall profile states are all enabled.", "Windows Firewall Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            proc.Dispose()
        Catch ex As Exception
            Log_Exception_To_File(ex, "An error has occurred while checking/enabling windows firewall!")

            MessageBox.Show("An error has occurred while checking/enabling windows firewall!", "Error")
        End Try
    End Sub
End Class