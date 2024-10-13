<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.VersionCheckerCheckBox = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckFirewallButton = New System.Windows.Forms.Button()
        Me.ResetFirewallButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'VersionCheckerCheckBox
        '
        Me.VersionCheckerCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.VersionCheckerCheckBox.AutoSize = True
        Me.VersionCheckerCheckBox.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.VersionCheckerCheckBox.Location = New System.Drawing.Point(83, 3)
        Me.VersionCheckerCheckBox.Name = "VersionCheckerCheckBox"
        Me.VersionCheckerCheckBox.Size = New System.Drawing.Size(244, 21)
        Me.VersionCheckerCheckBox.TabIndex = 0
        Me.VersionCheckerCheckBox.Text = "Check for new version on startup"
        Me.VersionCheckerCheckBox.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.VersionCheckerCheckBox, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 25)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(408, 166)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.CheckFirewallButton, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ResetFirewallButton, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 123)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(405, 38)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'CheckFirewallButton
        '
        Me.CheckFirewallButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CheckFirewallButton.AutoSize = True
        Me.CheckFirewallButton.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold)
        Me.CheckFirewallButton.Location = New System.Drawing.Point(237, 4)
        Me.CheckFirewallButton.Name = "CheckFirewallButton"
        Me.CheckFirewallButton.Size = New System.Drawing.Size(133, 30)
        Me.CheckFirewallButton.TabIndex = 2
        Me.CheckFirewallButton.Text = "Check Firewall"
        Me.CheckFirewallButton.UseVisualStyleBackColor = True
        '
        'ResetFirewallButton
        '
        Me.ResetFirewallButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ResetFirewallButton.AutoSize = True
        Me.ResetFirewallButton.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold)
        Me.ResetFirewallButton.Location = New System.Drawing.Point(34, 4)
        Me.ResetFirewallButton.Name = "ResetFirewallButton"
        Me.ResetFirewallButton.Size = New System.Drawing.Size(133, 30)
        Me.ResetFirewallButton.TabIndex = 1
        Me.ResetFirewallButton.Text = "Reset Firewall"
        Me.ResetFirewallButton.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 203)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents VersionCheckerCheckBox As CheckBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ResetFirewallButton As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents CheckFirewallButton As Button
End Class
