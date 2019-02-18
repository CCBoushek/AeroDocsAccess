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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbCustSelect = New System.Windows.Forms.ListBox()
        Me.cbOpenQuotes = New System.Windows.Forms.CheckBox()
        Me.cbJobQuotes = New System.Windows.Forms.CheckBox()
        Me.cbDeadQuotes = New System.Windows.Forms.CheckBox()
        Me.cbClosedJobs = New System.Windows.Forms.CheckBox()
        Me.flpJobs = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbOpenJobs = New System.Windows.Forms.CheckBox()
        Me.lblQuoteNum = New System.Windows.Forms.Label()
        Me.lblJobNum = New System.Windows.Forms.Label()
        Me.lblJobCount = New System.Windows.Forms.Label()
        Me.lblQuoteCount = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btClose
        '
        Me.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btClose.Location = New System.Drawing.Point(650, 39)
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
        Me.lblCust.Location = New System.Drawing.Point(93, 16)
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
        Me.tbCust.Location = New System.Drawing.Point(230, 17)
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
        Me.flpQuotes.Location = New System.Drawing.Point(0, 108)
        Me.flpQuotes.MaximumSize = New System.Drawing.Size(378, 300)
        Me.flpQuotes.MinimumSize = New System.Drawing.Size(378, 50)
        Me.flpQuotes.Name = "flpQuotes"
        Me.flpQuotes.Size = New System.Drawing.Size(378, 50)
        Me.flpQuotes.TabIndex = 13
        Me.flpQuotes.Visible = False
        Me.flpQuotes.WrapContents = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.QuoteDocs_QuickAccess.My.Resources.Resources.Button_Background_MedDark
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(765, 127)
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
        Me.lbCustSelect.Location = New System.Drawing.Point(230, 44)
        Me.lbCustSelect.MaximumSize = New System.Drawing.Size(420, 100)
        Me.lbCustSelect.MinimumSize = New System.Drawing.Size(420, 25)
        Me.lbCustSelect.Name = "lbCustSelect"
        Me.lbCustSelect.Size = New System.Drawing.Size(420, 25)
        Me.lbCustSelect.TabIndex = 16
        Me.lbCustSelect.Visible = False
        '
        'cbOpenQuotes
        '
        Me.cbOpenQuotes.AutoSize = True
        Me.cbOpenQuotes.BackColor = System.Drawing.Color.Transparent
        Me.cbOpenQuotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbOpenQuotes.Location = New System.Drawing.Point(80, 45)
        Me.cbOpenQuotes.Name = "cbOpenQuotes"
        Me.cbOpenQuotes.Size = New System.Drawing.Size(71, 24)
        Me.cbOpenQuotes.TabIndex = 18
        Me.cbOpenQuotes.Text = "Open"
        Me.cbOpenQuotes.UseVisualStyleBackColor = False
        '
        'cbJobQuotes
        '
        Me.cbJobQuotes.AutoSize = True
        Me.cbJobQuotes.BackColor = System.Drawing.Color.Transparent
        Me.cbJobQuotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbJobQuotes.Location = New System.Drawing.Point(167, 45)
        Me.cbJobQuotes.Name = "cbJobQuotes"
        Me.cbJobQuotes.Size = New System.Drawing.Size(58, 24)
        Me.cbJobQuotes.TabIndex = 18
        Me.cbJobQuotes.Text = "Job"
        Me.cbJobQuotes.UseVisualStyleBackColor = False
        '
        'cbDeadQuotes
        '
        Me.cbDeadQuotes.AutoSize = True
        Me.cbDeadQuotes.BackColor = System.Drawing.Color.Transparent
        Me.cbDeadQuotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDeadQuotes.Location = New System.Drawing.Point(239, 45)
        Me.cbDeadQuotes.Margin = New System.Windows.Forms.Padding(0)
        Me.cbDeadQuotes.Name = "cbDeadQuotes"
        Me.cbDeadQuotes.Size = New System.Drawing.Size(71, 24)
        Me.cbDeadQuotes.TabIndex = 18
        Me.cbDeadQuotes.Text = "Dead"
        Me.cbDeadQuotes.UseVisualStyleBackColor = False
        '
        'cbClosedJobs
        '
        Me.cbClosedJobs.AutoSize = True
        Me.cbClosedJobs.BackColor = System.Drawing.Color.Transparent
        Me.cbClosedJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbClosedJobs.Location = New System.Drawing.Point(533, 45)
        Me.cbClosedJobs.Margin = New System.Windows.Forms.Padding(0)
        Me.cbClosedJobs.Name = "cbClosedJobs"
        Me.cbClosedJobs.Size = New System.Drawing.Size(83, 24)
        Me.cbClosedJobs.TabIndex = 21
        Me.cbClosedJobs.Text = "Closed"
        Me.cbClosedJobs.UseVisualStyleBackColor = False
        '
        'flpJobs
        '
        Me.flpJobs.AutoScroll = True
        Me.flpJobs.AutoSize = True
        Me.flpJobs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpJobs.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.flpJobs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpJobs.Location = New System.Drawing.Point(385, 108)
        Me.flpJobs.MaximumSize = New System.Drawing.Size(378, 300)
        Me.flpJobs.MinimumSize = New System.Drawing.Size(378, 50)
        Me.flpJobs.Name = "flpJobs"
        Me.flpJobs.Size = New System.Drawing.Size(378, 50)
        Me.flpJobs.TabIndex = 14
        Me.flpJobs.Visible = False
        Me.flpJobs.WrapContents = False
        '
        'cbOpenJobs
        '
        Me.cbOpenJobs.AutoSize = True
        Me.cbOpenJobs.BackColor = System.Drawing.Color.Transparent
        Me.cbOpenJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbOpenJobs.Location = New System.Drawing.Point(446, 45)
        Me.cbOpenJobs.Name = "cbOpenJobs"
        Me.cbOpenJobs.Size = New System.Drawing.Size(71, 24)
        Me.cbOpenJobs.TabIndex = 18
        Me.cbOpenJobs.Text = "Open"
        Me.cbOpenJobs.UseVisualStyleBackColor = False
        '
        'lblQuoteNum
        '
        Me.lblQuoteNum.AutoSize = True
        Me.lblQuoteNum.BackColor = System.Drawing.Color.Transparent
        Me.lblQuoteNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuoteNum.Location = New System.Drawing.Point(56, 65)
        Me.lblQuoteNum.Name = "lblQuoteNum"
        Me.lblQuoteNum.Size = New System.Drawing.Size(88, 25)
        Me.lblQuoteNum.TabIndex = 1
        Me.lblQuoteNum.Text = "Quote #:"
        '
        'lblJobNum
        '
        Me.lblJobNum.AutoSize = True
        Me.lblJobNum.BackColor = System.Drawing.Color.Transparent
        Me.lblJobNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobNum.Location = New System.Drawing.Point(391, 65)
        Me.lblJobNum.Name = "lblJobNum"
        Me.lblJobNum.Size = New System.Drawing.Size(67, 25)
        Me.lblJobNum.TabIndex = 1
        Me.lblJobNum.Text = "Job #:"
        '
        'lblJobCount
        '
        Me.lblJobCount.AutoSize = True
        Me.lblJobCount.BackColor = System.Drawing.Color.Transparent
        Me.lblJobCount.Location = New System.Drawing.Point(392, 88)
        Me.lblJobCount.Name = "lblJobCount"
        Me.lblJobCount.Size = New System.Drawing.Size(72, 17)
        Me.lblJobCount.TabIndex = 22
        Me.lblJobCount.Text = "Job Count"
        '
        'lblQuoteCount
        '
        Me.lblQuoteCount.AutoSize = True
        Me.lblQuoteCount.BackColor = System.Drawing.Color.Transparent
        Me.lblQuoteCount.Location = New System.Drawing.Point(37, 88)
        Me.lblQuoteCount.Name = "lblQuoteCount"
        Me.lblQuoteCount.Size = New System.Drawing.Size(64, 17)
        Me.lblQuoteCount.TabIndex = 22
        Me.lblQuoteCount.Text = "Qt Count"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.CancelButton = Me.btClose
        Me.ClientSize = New System.Drawing.Size(765, 132)
        Me.Controls.Add(Me.lbCustSelect)
        Me.Controls.Add(Me.lblQuoteCount)
        Me.Controls.Add(Me.lblJobCount)
        Me.Controls.Add(Me.cbClosedJobs)
        Me.Controls.Add(Me.cbDeadQuotes)
        Me.Controls.Add(Me.cbJobQuotes)
        Me.Controls.Add(Me.cbOpenJobs)
        Me.Controls.Add(Me.cbOpenQuotes)
        Me.Controls.Add(Me.tbCust)
        Me.Controls.Add(Me.lblJobNum)
        Me.Controls.Add(Me.lblQuoteNum)
        Me.Controls.Add(Me.lblCust)
        Me.Controls.Add(Me.flpJobs)
        Me.Controls.Add(Me.flpQuotes)
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
    Friend WithEvents lbCustSelect As ListBox
    Friend WithEvents cbOpenQuotes As CheckBox
    Friend WithEvents cbJobQuotes As CheckBox
    Friend WithEvents cbDeadQuotes As CheckBox
    Friend WithEvents cbClosedJobs As CheckBox
    Friend WithEvents flpJobs As FlowLayoutPanel
    Friend WithEvents cbOpenJobs As CheckBox
    Friend WithEvents lblQuoteNum As Label
    Friend WithEvents lblJobNum As Label
    Friend WithEvents lblJobCount As Label
    Friend WithEvents lblQuoteCount As Label
End Class
