<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class App
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.RefreshButton = New System.Windows.Forms.Button()
        Me.Latency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Servers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MainDataGridView = New System.Windows.Forms.DataGridView()
        Me.UnblockAllButton = New System.Windows.Forms.Button()
        Me.BlockSelectedButton = New System.Windows.Forms.Button()
        Me.UnblockSelectedButton = New System.Windows.Forms.Button()
        Me.BlockAllButton = New System.Windows.Forms.Button()
        Me.InfoButton = New System.Windows.Forms.Button()
        Me.ProgBar = New System.Windows.Forms.ProgressBar()
        Me.ClusterButton = New System.Windows.Forms.Button()
        Me.PresetsButton = New System.Windows.Forms.Button()
        Me.DarkModeButton = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.MainDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RefreshButton
        '
        Me.RefreshButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefreshButton.Location = New System.Drawing.Point(599, 24)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(87, 24)
        Me.RefreshButton.TabIndex = 1
        Me.RefreshButton.Text = "Refresh"
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'Latency
        '
        Me.Latency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Latency.HeaderText = "Latency"
        Me.Latency.MinimumWidth = 6
        Me.Latency.Name = "Latency"
        Me.Latency.ReadOnly = True
        Me.Latency.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Servers
        '
        Me.Servers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Servers.HeaderText = "Servers"
        Me.Servers.MinimumWidth = 6
        Me.Servers.Name = "Servers"
        Me.Servers.ReadOnly = True
        Me.Servers.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'MainDataGridView
        '
        Me.MainDataGridView.AllowUserToAddRows = False
        Me.MainDataGridView.AllowUserToDeleteRows = False
        Me.MainDataGridView.AllowUserToOrderColumns = True
        Me.MainDataGridView.AllowUserToResizeRows = False
        Me.MainDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MainDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.MainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MainDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Servers, Me.Latency})
        Me.MainDataGridView.Location = New System.Drawing.Point(76, 54)
        Me.MainDataGridView.Name = "MainDataGridView"
        Me.MainDataGridView.RowHeadersVisible = False
        Me.MainDataGridView.RowHeadersWidth = 51
        Me.MainDataGridView.RowTemplate.Height = 24
        Me.MainDataGridView.Size = New System.Drawing.Size(610, 291)
        Me.MainDataGridView.TabIndex = 0
        '
        'UnblockAllButton
        '
        Me.UnblockAllButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.UnblockAllButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnblockAllButton.Location = New System.Drawing.Point(423, 363)
        Me.UnblockAllButton.Name = "UnblockAllButton"
        Me.UnblockAllButton.Size = New System.Drawing.Size(89, 46)
        Me.UnblockAllButton.TabIndex = 3
        Me.UnblockAllButton.Text = "Unblock All"
        Me.UnblockAllButton.UseVisualStyleBackColor = False
        '
        'BlockSelectedButton
        '
        Me.BlockSelectedButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BlockSelectedButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockSelectedButton.Location = New System.Drawing.Point(241, 363)
        Me.BlockSelectedButton.Name = "BlockSelectedButton"
        Me.BlockSelectedButton.Size = New System.Drawing.Size(94, 46)
        Me.BlockSelectedButton.TabIndex = 3
        Me.BlockSelectedButton.Text = "Block Selected"
        Me.BlockSelectedButton.UseVisualStyleBackColor = False
        '
        'UnblockSelectedButton
        '
        Me.UnblockSelectedButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.UnblockSelectedButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnblockSelectedButton.Location = New System.Drawing.Point(518, 363)
        Me.UnblockSelectedButton.Name = "UnblockSelectedButton"
        Me.UnblockSelectedButton.Size = New System.Drawing.Size(95, 46)
        Me.UnblockSelectedButton.TabIndex = 3
        Me.UnblockSelectedButton.Text = "Unblock Selected"
        Me.UnblockSelectedButton.UseVisualStyleBackColor = False
        '
        'BlockAllButton
        '
        Me.BlockAllButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BlockAllButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockAllButton.Location = New System.Drawing.Point(145, 363)
        Me.BlockAllButton.Name = "BlockAllButton"
        Me.BlockAllButton.Size = New System.Drawing.Size(90, 46)
        Me.BlockAllButton.TabIndex = 3
        Me.BlockAllButton.Text = "Block All"
        Me.BlockAllButton.UseVisualStyleBackColor = False
        '
        'InfoButton
        '
        Me.InfoButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoButton.Location = New System.Drawing.Point(76, 26)
        Me.InfoButton.Name = "InfoButton"
        Me.InfoButton.Size = New System.Drawing.Size(75, 22)
        Me.InfoButton.TabIndex = 4
        Me.InfoButton.Text = "Info"
        Me.InfoButton.UseVisualStyleBackColor = True
        '
        'ProgBar
        '
        Me.ProgBar.Location = New System.Drawing.Point(300, 26)
        Me.ProgBar.MarqueeAnimationSpeed = 20
        Me.ProgBar.Name = "ProgBar"
        Me.ProgBar.Size = New System.Drawing.Size(154, 23)
        Me.ProgBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgBar.TabIndex = 6
        Me.ProgBar.Visible = False
        '
        'ClusterButton
        '
        Me.ClusterButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClusterButton.Location = New System.Drawing.Point(506, 24)
        Me.ClusterButton.Name = "ClusterButton"
        Me.ClusterButton.Size = New System.Drawing.Size(87, 24)
        Me.ClusterButton.TabIndex = 7
        Me.ClusterButton.Text = "Uncluster"
        Me.ClusterButton.UseVisualStyleBackColor = True
        '
        'PresetsButton
        '
        Me.PresetsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PresetsButton.Location = New System.Drawing.Point(157, 25)
        Me.PresetsButton.Name = "PresetsButton"
        Me.PresetsButton.Size = New System.Drawing.Size(87, 24)
        Me.PresetsButton.TabIndex = 8
        Me.PresetsButton.Text = "Presets"
        Me.PresetsButton.UseVisualStyleBackColor = True
        '
        'DarkModeButton
        '
        Me.DarkModeButton.AutoSize = True
        Me.DarkModeButton.BackColor = System.Drawing.Color.Transparent
        Me.DarkModeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.DarkModeButton.FlatAppearance.BorderSize = 0
        Me.DarkModeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.DarkModeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.DarkModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DarkModeButton.ForeColor = System.Drawing.Color.White
        Me.DarkModeButton.Image = Global.CS2ServerPicker.My.Resources.Resources.Button_Light_Theme
        Me.DarkModeButton.Location = New System.Drawing.Point(1, 37)
        Me.DarkModeButton.Name = "DarkModeButton"
        Me.DarkModeButton.Size = New System.Drawing.Size(38, 38)
        Me.DarkModeButton.TabIndex = 9
        Me.DarkModeButton.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.CS2ServerPicker.My.Resources.Resources.GitHub_Mark
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Location = New System.Drawing.Point(6, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 28)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'App
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(756, 430)
        Me.Controls.Add(Me.DarkModeButton)
        Me.Controls.Add(Me.PresetsButton)
        Me.Controls.Add(Me.ClusterButton)
        Me.Controls.Add(Me.ProgBar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.InfoButton)
        Me.Controls.Add(Me.BlockAllButton)
        Me.Controls.Add(Me.UnblockSelectedButton)
        Me.Controls.Add(Me.BlockSelectedButton)
        Me.Controls.Add(Me.UnblockAllButton)
        Me.Controls.Add(Me.RefreshButton)
        Me.Controls.Add(Me.MainDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "App"
        Me.Text = "Counter Strike 2 Server Picker"
        CType(Me.MainDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RefreshButton As Button
    Friend WithEvents Latency As DataGridViewTextBoxColumn
    Friend WithEvents Servers As DataGridViewTextBoxColumn
    Friend WithEvents MainDataGridView As DataGridView
    Friend WithEvents UnblockAllButton As Button
    Friend WithEvents BlockSelectedButton As Button
    Friend WithEvents UnblockSelectedButton As Button
    Friend WithEvents BlockAllButton As Button
    Friend WithEvents InfoButton As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ProgBar As ProgressBar
    Friend WithEvents ClusterButton As Button
    Friend WithEvents PresetsButton As Button
    Friend WithEvents DarkModeButton As Button
End Class
