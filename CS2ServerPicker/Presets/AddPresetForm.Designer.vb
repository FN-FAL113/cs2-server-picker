<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddPresetForm
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
        Me.PresetServersCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.PresetNameLabel = New System.Windows.Forms.Label()
        Me.AddPresetNameTextBox = New System.Windows.Forms.TextBox()
        Me.PresetServersLabel = New System.Windows.Forms.Label()
        Me.AddPresetButton = New System.Windows.Forms.Button()
        Me.ResetPresetSelectionButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PresetServersCheckedListBox
        '
        Me.PresetServersCheckedListBox.CheckOnClick = True
        Me.PresetServersCheckedListBox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PresetServersCheckedListBox.FormattingEnabled = True
        Me.PresetServersCheckedListBox.Location = New System.Drawing.Point(59, 97)
        Me.PresetServersCheckedListBox.Name = "PresetServersCheckedListBox"
        Me.PresetServersCheckedListBox.Size = New System.Drawing.Size(271, 308)
        Me.PresetServersCheckedListBox.TabIndex = 0
        '
        'PresetNameLabel
        '
        Me.PresetNameLabel.AutoSize = True
        Me.PresetNameLabel.Location = New System.Drawing.Point(56, 21)
        Me.PresetNameLabel.Name = "PresetNameLabel"
        Me.PresetNameLabel.Size = New System.Drawing.Size(95, 16)
        Me.PresetNameLabel.TabIndex = 1
        Me.PresetNameLabel.Text = "Preset Name"
        '
        'AddPresetNameTextBox
        '
        Me.AddPresetNameTextBox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddPresetNameTextBox.Location = New System.Drawing.Point(59, 44)
        Me.AddPresetNameTextBox.Name = "AddPresetNameTextBox"
        Me.AddPresetNameTextBox.Size = New System.Drawing.Size(271, 25)
        Me.AddPresetNameTextBox.TabIndex = 2
        '
        'PresetServersLabel
        '
        Me.PresetServersLabel.AutoSize = True
        Me.PresetServersLabel.Location = New System.Drawing.Point(56, 74)
        Me.PresetServersLabel.Name = "PresetServersLabel"
        Me.PresetServersLabel.Size = New System.Drawing.Size(109, 16)
        Me.PresetServersLabel.TabIndex = 3
        Me.PresetServersLabel.Text = "Preset Servers"
        '
        'AddPresetButton
        '
        Me.AddPresetButton.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddPresetButton.Location = New System.Drawing.Point(207, 428)
        Me.AddPresetButton.Name = "AddPresetButton"
        Me.AddPresetButton.Size = New System.Drawing.Size(123, 24)
        Me.AddPresetButton.TabIndex = 8
        Me.AddPresetButton.Text = "Add Preset"
        Me.AddPresetButton.UseVisualStyleBackColor = True
        '
        'ResetPresetSelectionButton
        '
        Me.ResetPresetSelectionButton.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetPresetSelectionButton.Location = New System.Drawing.Point(59, 428)
        Me.ResetPresetSelectionButton.Name = "ResetPresetSelectionButton"
        Me.ResetPresetSelectionButton.Size = New System.Drawing.Size(123, 24)
        Me.ResetPresetSelectionButton.TabIndex = 9
        Me.ResetPresetSelectionButton.Text = "Reset Selection"
        Me.ResetPresetSelectionButton.UseVisualStyleBackColor = True
        '
        'AddPresetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 464)
        Me.Controls.Add(Me.ResetPresetSelectionButton)
        Me.Controls.Add(Me.AddPresetButton)
        Me.Controls.Add(Me.PresetServersLabel)
        Me.Controls.Add(Me.AddPresetNameTextBox)
        Me.Controls.Add(Me.PresetNameLabel)
        Me.Controls.Add(Me.PresetServersCheckedListBox)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "AddPresetForm"
        Me.Text = "Add Preset"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PresetServersCheckedListBox As CheckedListBox
    Friend WithEvents PresetNameLabel As Label
    Friend WithEvents AddPresetNameTextBox As TextBox
    Friend WithEvents PresetServersLabel As Label
    Friend WithEvents AddPresetButton As Button
    Friend WithEvents ResetPresetSelectionButton As Button
End Class
