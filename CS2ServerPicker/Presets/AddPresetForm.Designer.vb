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
        Me.PresetServersCheckedListBox.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.PresetServersCheckedListBox.FormattingEnabled = True
        Me.PresetServersCheckedListBox.Location = New System.Drawing.Point(66, 100)
        Me.PresetServersCheckedListBox.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.PresetServersCheckedListBox.Name = "PresetServersCheckedListBox"
        Me.PresetServersCheckedListBox.Size = New System.Drawing.Size(271, 327)
        Me.PresetServersCheckedListBox.TabIndex = 0
        '
        'PresetNameLabel
        '
        Me.PresetNameLabel.AutoSize = True
        Me.PresetNameLabel.Font = New System.Drawing.Font("Arial", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PresetNameLabel.Location = New System.Drawing.Point(63, 18)
        Me.PresetNameLabel.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.PresetNameLabel.Name = "PresetNameLabel"
        Me.PresetNameLabel.Size = New System.Drawing.Size(99, 18)
        Me.PresetNameLabel.TabIndex = 1
        Me.PresetNameLabel.Text = "Preset Name"
        '
        'AddPresetNameTextBox
        '
        Me.AddPresetNameTextBox.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.AddPresetNameTextBox.Location = New System.Drawing.Point(66, 43)
        Me.AddPresetNameTextBox.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.AddPresetNameTextBox.Name = "AddPresetNameTextBox"
        Me.AddPresetNameTextBox.Size = New System.Drawing.Size(271, 24)
        Me.AddPresetNameTextBox.TabIndex = 2
        '
        'PresetServersLabel
        '
        Me.PresetServersLabel.AutoSize = True
        Me.PresetServersLabel.Font = New System.Drawing.Font("Arial", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PresetServersLabel.Location = New System.Drawing.Point(63, 75)
        Me.PresetServersLabel.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.PresetServersLabel.Name = "PresetServersLabel"
        Me.PresetServersLabel.Size = New System.Drawing.Size(116, 18)
        Me.PresetServersLabel.TabIndex = 3
        Me.PresetServersLabel.Text = "Preset Servers"
        '
        'AddPresetButton
        '
        Me.AddPresetButton.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddPresetButton.Location = New System.Drawing.Point(214, 457)
        Me.AddPresetButton.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.AddPresetButton.Name = "AddPresetButton"
        Me.AddPresetButton.Size = New System.Drawing.Size(123, 26)
        Me.AddPresetButton.TabIndex = 8
        Me.AddPresetButton.Text = "Add Preset"
        Me.AddPresetButton.UseVisualStyleBackColor = True
        '
        'ResetPresetSelectionButton
        '
        Me.ResetPresetSelectionButton.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetPresetSelectionButton.Location = New System.Drawing.Point(66, 457)
        Me.ResetPresetSelectionButton.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ResetPresetSelectionButton.Name = "ResetPresetSelectionButton"
        Me.ResetPresetSelectionButton.Size = New System.Drawing.Size(123, 26)
        Me.ResetPresetSelectionButton.TabIndex = 9
        Me.ResetPresetSelectionButton.Text = "Reset Selection"
        Me.ResetPresetSelectionButton.UseVisualStyleBackColor = True
        '
        'AddPresetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 500)
        Me.Controls.Add(Me.ResetPresetSelectionButton)
        Me.Controls.Add(Me.AddPresetButton)
        Me.Controls.Add(Me.PresetServersLabel)
        Me.Controls.Add(Me.AddPresetNameTextBox)
        Me.Controls.Add(Me.PresetNameLabel)
        Me.Controls.Add(Me.PresetServersCheckedListBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.MaximizeBox = False
        Me.Name = "AddPresetForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
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
