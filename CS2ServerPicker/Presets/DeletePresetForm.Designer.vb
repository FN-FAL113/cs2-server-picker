<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeletePresetForm
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
        Me.DeletePresetNameTextBox = New System.Windows.Forms.TextBox()
        Me.PresetNameLabel = New System.Windows.Forms.Label()
        Me.DeletePresetButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DeletePresetNameTextBox
        '
        Me.DeletePresetNameTextBox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeletePresetNameTextBox.Location = New System.Drawing.Point(50, 47)
        Me.DeletePresetNameTextBox.Name = "DeletePresetNameTextBox"
        Me.DeletePresetNameTextBox.Size = New System.Drawing.Size(194, 25)
        Me.DeletePresetNameTextBox.TabIndex = 4
        '
        'PresetNameLabel
        '
        Me.PresetNameLabel.AutoSize = True
        Me.PresetNameLabel.Location = New System.Drawing.Point(47, 26)
        Me.PresetNameLabel.Name = "PresetNameLabel"
        Me.PresetNameLabel.Size = New System.Drawing.Size(95, 16)
        Me.PresetNameLabel.TabIndex = 3
        Me.PresetNameLabel.Text = "Preset Name"
        '
        'DeletePresetButton
        '
        Me.DeletePresetButton.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeletePresetButton.Location = New System.Drawing.Point(87, 88)
        Me.DeletePresetButton.Name = "DeletePresetButton"
        Me.DeletePresetButton.Size = New System.Drawing.Size(123, 24)
        Me.DeletePresetButton.TabIndex = 9
        Me.DeletePresetButton.Text = "Delete Preset"
        Me.DeletePresetButton.UseVisualStyleBackColor = True
        '
        'DeletePresetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 130)
        Me.Controls.Add(Me.DeletePresetButton)
        Me.Controls.Add(Me.DeletePresetNameTextBox)
        Me.Controls.Add(Me.PresetNameLabel)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "DeletePresetForm"
        Me.Text = "DeletePresetForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DeletePresetNameTextBox As TextBox
    Friend WithEvents PresetNameLabel As Label
    Friend WithEvents DeletePresetButton As Button
End Class
