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
        Me.lbQtNum = New System.Windows.Forms.Label()
        Me.lbCustName = New System.Windows.Forms.Label()
        Me.lbDesc = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbQtNum
        '
        Me.lbQtNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtNum.Location = New System.Drawing.Point(12, 0)
        Me.lbQtNum.Name = "lbQtNum"
        Me.lbQtNum.Size = New System.Drawing.Size(180, 27)
        Me.lbQtNum.TabIndex = 0
        Me.lbQtNum.Text = "CB2XXP0XXX"
        '
        'lbCustName
        '
        Me.lbCustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCustName.Location = New System.Drawing.Point(198, 0)
        Me.lbCustName.Name = "lbCustName"
        Me.lbCustName.Size = New System.Drawing.Size(377, 27)
        Me.lbCustName.TabIndex = 0
        Me.lbCustName.Text = "Customer Name"
        '
        'lbDesc
        '
        Me.lbDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesc.Location = New System.Drawing.Point(31, 28)
        Me.lbDesc.Name = "lbDesc"
        Me.lbDesc.Size = New System.Drawing.Size(544, 25)
        Me.lbDesc.TabIndex = 0
        Me.lbDesc.Text = "Quote Description"
        '
        'ucQuoteDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Controls.Add(Me.lbDesc)
        Me.Controls.Add(Me.lbCustName)
        Me.Controls.Add(Me.lbQtNum)
        Me.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Margin = New System.Windows.Forms.Padding(0, 2, 2, 0)
        Me.Name = "ucQuoteDetail"
        Me.Size = New System.Drawing.Size(578, 55)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbQtNum As Label
    Friend WithEvents lbCustName As Label
    Friend WithEvents lbDesc As Label
End Class
