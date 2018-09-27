<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btClose = New System.Windows.Forms.Button()
        Me.lblCust = New System.Windows.Forms.Label()
        Me.tbCust = New System.Windows.Forms.TextBox()
        Me.flpQuotes = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbCustSelect = New System.Windows.Forms.ListBox()
        Me.cbOpen = New System.Windows.Forms.CheckBox()
        Me.cbJob = New System.Windows.Forms.CheckBox()
        Me.cbDead = New System.Windows.Forms.CheckBox()
        Me.rbtnQuotes = New System.Windows.Forms.RadioButton()
        Me.rbtnJobs = New System.Windows.Forms.RadioButton()
        Me.cbClosed = New System.Windows.Forms.CheckBox()
        Me.flpJobs = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btClose
        '
        Me.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btClose.Location = New System.Drawing.Point(526, 39)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(25, 23)
        Me.btClose.TabIndex = 10
        Me.btClose.TabStop = False
        Me.btClose.Text = "X"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'lblCust
        '
        Me.lblCust.AutoSize = True
        Me.lblCust.BackColor = System.Drawing.Color.Transparent
        Me.lblCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCust.Location = New System.Drawing.Point(22, 61)
        Me.lblCust.Name = "lblCust"
        Me.lblCust.Size = New System.Drawing.Size(123, 29)
        Me.lblCust.TabIndex = 1
        Me.lblCust.Text = "Customer:"
        '
        'tbCust
        '
        Me.tbCust.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tbCust.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbCust.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCust.Location = New System.Drawing.Point(147, 62)
        Me.tbCust.Margin = New System.Windows.Forms.Padding(3, 3, 3, 8)
        Me.tbCust.Name = "tbCust"
        Me.tbCust.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbCust.Size = New System.Drawing.Size(420, 27)
        Me.tbCust.TabIndex = 2
        '
        'flpQuotes
        '
        Me.flpQuotes.AutoScroll = True
        Me.flpQuotes.AutoSize = True
        Me.flpQuotes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpQuotes.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.flpQuotes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpQuotes.Location = New System.Drawing.Point(29, 96)
        Me.flpQuotes.MaximumSize = New System.Drawing.Size(608, 300)
        Me.flpQuotes.MinimumSize = New System.Drawing.Size(608, 50)
        Me.flpQuotes.Name = "flpQuotes"
        Me.flpQuotes.Size = New System.Drawing.Size(608, 50)
        Me.flpQuotes.TabIndex = 13
        Me.flpQuotes.Visible = False
        Me.flpQuotes.WrapContents = False
        '
        'lblInstructions
        '
        Me.lblInstructions.AutoSize = True
        Me.lblInstructions.BackColor = System.Drawing.Color.Transparent
        Me.lblInstructions.Location = New System.Drawing.Point(29, 16)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(232, 34)
        Me.lblInstructions.TabIndex = 14
        Me.lblInstructions.Text = "CTRL + Click --> Open Current PDF" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Double Click --> Open Docs Folder"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.QuoteDocs_QuickAccess.My.Resources.Resources.Button_Background_MedDark
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(690, 127)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'lbCustSelect
        '
        Me.lbCustSelect.BackColor = System.Drawing.Color.Silver
        Me.lbCustSelect.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lbCustSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCustSelect.FormattingEnabled = True
        Me.lbCustSelect.ItemHeight = 25
        Me.lbCustSelect.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.lbCustSelect.Location = New System.Drawing.Point(146, 88)
        Me.lbCustSelect.MaximumSize = New System.Drawing.Size(420, 100)
        Me.lbCustSelect.MinimumSize = New System.Drawing.Size(420, 25)
        Me.lbCustSelect.Name = "lbCustSelect"
        Me.lbCustSelect.Size = New System.Drawing.Size(420, 25)
        Me.lbCustSelect.TabIndex = 16
        Me.lbCustSelect.Visible = False
        '
        'cbOpen
        '
        Me.cbOpen.AutoSize = True
        Me.cbOpen.BackColor = System.Drawing.Color.Transparent
        Me.cbOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbOpen.Location = New System.Drawing.Point(284, 29)
        Me.cbOpen.Name = "cbOpen"
        Me.cbOpen.Size = New System.Drawing.Size(71, 24)
        Me.cbOpen.TabIndex = 18
        Me.cbOpen.Text = "Open"
        Me.cbOpen.UseVisualStyleBackColor = False
        '
        'cbJob
        '
        Me.cbJob.AutoSize = True
        Me.cbJob.BackColor = System.Drawing.Color.Transparent
        Me.cbJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbJob.Location = New System.Drawing.Point(367, 29)
        Me.cbJob.Name = "cbJob"
        Me.cbJob.Size = New System.Drawing.Size(58, 24)
        Me.cbJob.TabIndex = 18
        Me.cbJob.Text = "Job"
        Me.cbJob.UseVisualStyleBackColor = False
        '
        'cbDead
        '
        Me.cbDead.AutoSize = True
        Me.cbDead.BackColor = System.Drawing.Color.Transparent
        Me.cbDead.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDead.Location = New System.Drawing.Point(437, 29)
        Me.cbDead.Margin = New System.Windows.Forms.Padding(0)
        Me.cbDead.Name = "cbDead"
        Me.cbDead.Size = New System.Drawing.Size(71, 24)
        Me.cbDead.TabIndex = 18
        Me.cbDead.Text = "Dead"
        Me.cbDead.UseVisualStyleBackColor = False
        '
        'rbtnQuotes
        '
        Me.rbtnQuotes.AutoSize = True
        Me.rbtnQuotes.BackColor = System.Drawing.Color.Transparent
        Me.rbtnQuotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnQuotes.Location = New System.Drawing.Point(574, 28)
        Me.rbtnQuotes.Name = "rbtnQuotes"
        Me.rbtnQuotes.Size = New System.Drawing.Size(84, 24)
        Me.rbtnQuotes.TabIndex = 19
        Me.rbtnQuotes.Text = "Quotes"
        Me.rbtnQuotes.UseVisualStyleBackColor = False
        '
        'rbtnJobs
        '
        Me.rbtnJobs.AutoSize = True
        Me.rbtnJobs.BackColor = System.Drawing.Color.Transparent
        Me.rbtnJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnJobs.Location = New System.Drawing.Point(574, 62)
        Me.rbtnJobs.Name = "rbtnJobs"
        Me.rbtnJobs.Size = New System.Drawing.Size(66, 24)
        Me.rbtnJobs.TabIndex = 20
        Me.rbtnJobs.Text = "Jobs"
        Me.rbtnJobs.UseVisualStyleBackColor = False
        '
        'cbClosed
        '
        Me.cbClosed.AutoSize = True
        Me.cbClosed.BackColor = System.Drawing.Color.Transparent
        Me.cbClosed.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbClosed.Location = New System.Drawing.Point(402, 29)
        Me.cbClosed.Margin = New System.Windows.Forms.Padding(0)
        Me.cbClosed.Name = "cbClosed"
        Me.cbClosed.Size = New System.Drawing.Size(83, 24)
        Me.cbClosed.TabIndex = 21
        Me.cbClosed.Text = "Closed"
        Me.cbClosed.UseVisualStyleBackColor = False
        Me.cbClosed.Visible = False
        '
        'flpJobs
        '
        Me.flpJobs.AutoScroll = True
        Me.flpJobs.AutoSize = True
        Me.flpJobs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpJobs.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.flpJobs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpJobs.Location = New System.Drawing.Point(29, 96)
        Me.flpJobs.MaximumSize = New System.Drawing.Size(608, 300)
        Me.flpJobs.MinimumSize = New System.Drawing.Size(608, 50)
        Me.flpJobs.Name = "flpJobs"
        Me.flpJobs.Size = New System.Drawing.Size(608, 50)
        Me.flpJobs.TabIndex = 14
        Me.flpJobs.Visible = False
        Me.flpJobs.WrapContents = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.CancelButton = Me.btClose
        Me.ClientSize = New System.Drawing.Size(690, 132)
        Me.Controls.Add(Me.flpJobs)
        Me.Controls.Add(Me.cbClosed)
        Me.Controls.Add(Me.rbtnJobs)
        Me.Controls.Add(Me.rbtnQuotes)
        Me.Controls.Add(Me.cbDead)
        Me.Controls.Add(Me.cbJob)
        Me.Controls.Add(Me.cbOpen)
        Me.Controls.Add(Me.lbCustSelect)
        Me.Controls.Add(Me.lblInstructions)
        Me.Controls.Add(Me.flpQuotes)
        Me.Controls.Add(Me.tbCust)
        Me.Controls.Add(Me.lblCust)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quote Search"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btClose As Button
    Friend WithEvents lblCust As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents tbCust As TextBox
    Friend WithEvents flpQuotes As FlowLayoutPanel
    Friend WithEvents lblInstructions As Label
    Friend WithEvents lbCustSelect As ListBox
    Friend WithEvents cbOpen As CheckBox
    Friend WithEvents cbJob As CheckBox
    Friend WithEvents cbDead As CheckBox
    Friend WithEvents rbtnQuotes As RadioButton
    Friend WithEvents rbtnJobs As RadioButton
    Friend WithEvents cbClosed As CheckBox
    Friend WithEvents flpJobs As FlowLayoutPanel
End Class
