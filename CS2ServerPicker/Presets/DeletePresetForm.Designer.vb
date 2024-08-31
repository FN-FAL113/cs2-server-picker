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
        Me.PresetConfirmationLabel = New System.Windows.Forms.Label()
        Me.DeletePresetButton = New System.Windows.Forms.Button()
        Me.CloseDeletePresetFormButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PresetConfirmationLabel
        '
        Me.PresetConfirmationLabel.AutoSize = True
        Me.PresetConfirmationLabel.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold)
        Me.PresetConfirmationLabel.Location = New System.Drawing.Point(85, 44)
        Me.PresetConfirmationLabel.Name = "PresetConfirmationLabel"
        Me.PresetConfirmationLabel.Size = New System.Drawing.Size(179, 18)
        Me.PresetConfirmationLabel.TabIndex = 3
        Me.PresetConfirmationLabel.Text = "Delete selected preset?"
        '
        'DeletePresetButton
        '
        Me.DeletePresetButton.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeletePresetButton.Location = New System.Drawing.Point(40, 87)
        Me.DeletePresetButton.Name = "DeletePresetButton"
        Me.DeletePresetButton.Size = New System.Drawing.Size(97, 26)
        Me.DeletePresetButton.TabIndex = 9
        Me.DeletePresetButton.Text = "Yes"
        Me.DeletePresetButton.UseVisualStyleBackColor = True
        '
        'CloseDeletePresetFormButton
        '
        Me.CloseDeletePresetFormButton.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseDeletePresetFormButton.Location = New System.Drawing.Point(165, 87)
        Me.CloseDeletePresetFormButton.Name = "CloseDeletePresetFormButton"
        Me.CloseDeletePresetFormButton.Size = New System.Drawing.Size(97, 26)
        Me.CloseDeletePresetFormButton.TabIndex = 10
        Me.CloseDeletePresetFormButton.Text = "No"
        Me.CloseDeletePresetFormButton.UseVisualStyleBackColor = True
        '
        'DeletePresetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 140)
        Me.Controls.Add(Me.CloseDeletePresetFormButton)
        Me.Controls.Add(Me.DeletePresetButton)
        Me.Controls.Add(Me.PresetConfirmationLabel)
        Me.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "DeletePresetForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Delete Preset"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PresetConfirmationLabel As Label
    Friend WithEvents DeletePresetButton As Button
    Friend WithEvents CloseDeletePresetFormButton As Button
End Class
