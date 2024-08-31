<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdatePresetForm
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
        Me.ResetPresetSelectionButton = New System.Windows.Forms.Button()
        Me.UpdatePresetButton = New System.Windows.Forms.Button()
        Me.PresetServersLabel = New System.Windows.Forms.Label()
        Me.UpdatePresetNameTextBox = New System.Windows.Forms.TextBox()
        Me.PresetNameLabel = New System.Windows.Forms.Label()
        Me.PresetServersCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'ResetPresetSelectionButton
        '
        Me.ResetPresetSelectionButton.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.ResetPresetSelectionButton.Location = New System.Drawing.Point(66, 457)
        Me.ResetPresetSelectionButton.Name = "ResetPresetSelectionButton"
        Me.ResetPresetSelectionButton.Size = New System.Drawing.Size(123, 26)
        Me.ResetPresetSelectionButton.TabIndex = 15
        Me.ResetPresetSelectionButton.Text = "Reset Selection"
        Me.ResetPresetSelectionButton.UseVisualStyleBackColor = True
        '
        'UpdatePresetButton
        '
        Me.UpdatePresetButton.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.UpdatePresetButton.Location = New System.Drawing.Point(214, 457)
        Me.UpdatePresetButton.Name = "UpdatePresetButton"
        Me.UpdatePresetButton.Size = New System.Drawing.Size(123, 26)
        Me.UpdatePresetButton.TabIndex = 14
        Me.UpdatePresetButton.Text = "Update Preset"
        Me.UpdatePresetButton.UseVisualStyleBackColor = True
        '
        'PresetServersLabel
        '
        Me.PresetServersLabel.AutoSize = True
        Me.PresetServersLabel.Font = New System.Drawing.Font("Arial", 8.75!, System.Drawing.FontStyle.Bold)
        Me.PresetServersLabel.Location = New System.Drawing.Point(63, 75)
        Me.PresetServersLabel.Name = "PresetServersLabel"
        Me.PresetServersLabel.Size = New System.Drawing.Size(116, 18)
        Me.PresetServersLabel.TabIndex = 13
        Me.PresetServersLabel.Text = "Preset Servers"
        '
        'UpdatePresetNameTextBox
        '
        Me.UpdatePresetNameTextBox.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.UpdatePresetNameTextBox.Location = New System.Drawing.Point(66, 43)
        Me.UpdatePresetNameTextBox.Name = "UpdatePresetNameTextBox"
        Me.UpdatePresetNameTextBox.Size = New System.Drawing.Size(271, 24)
        Me.UpdatePresetNameTextBox.TabIndex = 12
        '
        'PresetNameLabel
        '
        Me.PresetNameLabel.AutoSize = True
        Me.PresetNameLabel.Font = New System.Drawing.Font("Arial", 8.75!, System.Drawing.FontStyle.Bold)
        Me.PresetNameLabel.Location = New System.Drawing.Point(63, 18)
        Me.PresetNameLabel.Name = "PresetNameLabel"
        Me.PresetNameLabel.Size = New System.Drawing.Size(99, 18)
        Me.PresetNameLabel.TabIndex = 11
        Me.PresetNameLabel.Text = "Preset Name"
        '
        'PresetServersCheckedListBox
        '
        Me.PresetServersCheckedListBox.CheckOnClick = True
        Me.PresetServersCheckedListBox.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.PresetServersCheckedListBox.FormattingEnabled = True
        Me.PresetServersCheckedListBox.Location = New System.Drawing.Point(66, 100)
        Me.PresetServersCheckedListBox.Name = "PresetServersCheckedListBox"
        Me.PresetServersCheckedListBox.Size = New System.Drawing.Size(271, 327)
        Me.PresetServersCheckedListBox.TabIndex = 10
        '
        'UpdatePresetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 500)
        Me.Controls.Add(Me.ResetPresetSelectionButton)
        Me.Controls.Add(Me.UpdatePresetButton)
        Me.Controls.Add(Me.PresetServersLabel)
        Me.Controls.Add(Me.UpdatePresetNameTextBox)
        Me.Controls.Add(Me.PresetNameLabel)
        Me.Controls.Add(Me.PresetServersCheckedListBox)
        Me.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "UpdatePresetForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Update Preset"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ResetPresetSelectionButton As Button
    Friend WithEvents UpdatePresetButton As Button
    Friend WithEvents PresetServersLabel As Label
    Friend WithEvents UpdatePresetNameTextBox As TextBox
    Friend WithEvents PresetNameLabel As Label
    Friend WithEvents PresetServersCheckedListBox As CheckedListBox
End Class
