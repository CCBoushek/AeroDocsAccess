<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucQuoteDetail
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.lbRefNum = New System.Windows.Forms.Label()
        Me.lbCustName = New System.Windows.Forms.Label()
        Me.lbDesc = New System.Windows.Forms.Label()
        Me.RtClickMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenQtFldr_ContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuJobFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.RtClickMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbRefNum
        '
        Me.lbRefNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRefNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbRefNum.Location = New System.Drawing.Point(0, 5)
        Me.lbRefNum.Name = "lbRefNum"
        Me.lbRefNum.Size = New System.Drawing.Size(160, 27)
        Me.lbRefNum.TabIndex = 0
        Me.lbRefNum.Text = "CB2XXP0XXX"
        '
        'lbCustName
        '
        Me.lbCustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCustName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbCustName.Location = New System.Drawing.Point(150, 5)
        Me.lbCustName.Name = "lbCustName"
        Me.lbCustName.Size = New System.Drawing.Size(200, 27)
        Me.lbCustName.TabIndex = 0
        Me.lbCustName.Text = "Customer Name"
        '
        'lbDesc
        '
        Me.lbDesc.AutoSize = True
        Me.lbDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesc.ForeColor = System.Drawing.Color.Silver
        Me.lbDesc.Location = New System.Drawing.Point(0, 30)
        Me.lbDesc.MaximumSize = New System.Drawing.Size(350, 50)
        Me.lbDesc.Name = "lbDesc"
        Me.lbDesc.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.lbDesc.Size = New System.Drawing.Size(128, 21)
        Me.lbDesc.TabIndex = 0
        Me.lbDesc.Text = "Quote Description"
        '
        'RtClickMenu1
        '
        Me.RtClickMenu1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.RtClickMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenQtFldr_ContextMenuItem, Me.menuJobFolder})
        Me.RtClickMenu1.Name = "ContextMenuStrip1"
        Me.RtClickMenu1.Size = New System.Drawing.Size(166, 52)
        '
        'OpenQtFldr_ContextMenuItem
        '
        Me.OpenQtFldr_ContextMenuItem.Name = "OpenQtFldr_ContextMenuItem"
        Me.OpenQtFldr_ContextMenuItem.Size = New System.Drawing.Size(165, 24)
        Me.OpenQtFldr_ContextMenuItem.Text = "Quote Folder"
        '
        'menuJobFolder
        '
        Me.menuJobFolder.Name = "menuJobFolder"
        Me.menuJobFolder.Size = New System.Drawing.Size(165, 24)
        Me.menuJobFolder.Text = "Job Folder"
        '
        'ucQuoteDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ContextMenuStrip = Me.RtClickMenu1
        Me.Controls.Add(Me.lbDesc)
        Me.Controls.Add(Me.lbCustName)
        Me.Controls.Add(Me.lbRefNum)
        Me.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Margin = New System.Windows.Forms.Padding(0, 2, 2, 0)
        Me.MaximumSize = New System.Drawing.Size(350, 75)
        Me.Name = "ucQuoteDetail"
        Me.Size = New System.Drawing.Size(350, 51)
        Me.RtClickMenu1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbRefNum As Label
    Friend WithEvents lbCustName As Label
    Friend WithEvents lbDesc As Label
    Friend WithEvents RtClickMenu1 As ContextMenuStrip
    Friend WithEvents OpenQtFldr_ContextMenuItem As ToolStripMenuItem
    Friend WithEvents menuJobFolder As ToolStripMenuItem
End Class
