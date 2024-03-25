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
        Me.ResetPresetSelectionButton.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetPresetSelectionButton.Location = New System.Drawing.Point(66, 424)
        Me.ResetPresetSelectionButton.Name = "ResetPresetSelectionButton"
        Me.ResetPresetSelectionButton.Size = New System.Drawing.Size(123, 24)
        Me.ResetPresetSelectionButton.TabIndex = 15
        Me.ResetPresetSelectionButton.Text = "Reset Selection"
        Me.ResetPresetSelectionButton.UseVisualStyleBackColor = True
        '
        'UpdatePresetButton
        '
        Me.UpdatePresetButton.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdatePresetButton.Location = New System.Drawing.Point(214, 424)
        Me.UpdatePresetButton.Name = "UpdatePresetButton"
        Me.UpdatePresetButton.Size = New System.Drawing.Size(123, 24)
        Me.UpdatePresetButton.TabIndex = 14
        Me.UpdatePresetButton.Text = "Update Preset"
        Me.UpdatePresetButton.UseVisualStyleBackColor = True
        '
        'PresetServersLabel
        '
        Me.PresetServersLabel.AutoSize = True
        Me.PresetServersLabel.Location = New System.Drawing.Point(63, 70)
        Me.PresetServersLabel.Name = "PresetServersLabel"
        Me.PresetServersLabel.Size = New System.Drawing.Size(87, 12)
        Me.PresetServersLabel.TabIndex = 13
        Me.PresetServersLabel.Text = "Preset Servers"
        '
        'UpdatePresetNameTextBox
        '
        Me.UpdatePresetNameTextBox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdatePresetNameTextBox.Location = New System.Drawing.Point(66, 40)
        Me.UpdatePresetNameTextBox.Name = "UpdatePresetNameTextBox"
        Me.UpdatePresetNameTextBox.Size = New System.Drawing.Size(271, 21)
        Me.UpdatePresetNameTextBox.TabIndex = 12
        '
        'PresetNameLabel
        '
        Me.PresetNameLabel.AutoSize = True
        Me.PresetNameLabel.Location = New System.Drawing.Point(63, 17)
        Me.PresetNameLabel.Name = "PresetNameLabel"
        Me.PresetNameLabel.Size = New System.Drawing.Size(76, 12)
        Me.PresetNameLabel.TabIndex = 11
        Me.PresetNameLabel.Text = "Preset Name"
        '
        'PresetServersCheckedListBox
        '
        Me.PresetServersCheckedListBox.CheckOnClick = True
        Me.PresetServersCheckedListBox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PresetServersCheckedListBox.FormattingEnabled = True
        Me.PresetServersCheckedListBox.Location = New System.Drawing.Point(66, 93)
        Me.PresetServersCheckedListBox.Name = "PresetServersCheckedListBox"
        Me.PresetServersCheckedListBox.Size = New System.Drawing.Size(271, 308)
        Me.PresetServersCheckedListBox.TabIndex = 10
        '
        'UpdatePresetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 11.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 464)
        Me.Controls.Add(Me.ResetPresetSelectionButton)
        Me.Controls.Add(Me.UpdatePresetButton)
        Me.Controls.Add(Me.PresetServersLabel)
        Me.Controls.Add(Me.UpdatePresetNameTextBox)
        Me.Controls.Add(Me.PresetNameLabel)
        Me.Controls.Add(Me.PresetServersCheckedListBox)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "UpdatePresetForm"
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
