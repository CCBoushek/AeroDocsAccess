Public Class Form1
    Private DBcon As New DBConnection
    Private AeroDBcon As New AeroDBConnection
    Private dtQuotes As New DataTable
    Private dtCustomers As New DataTable
    Private DictCustNames As New Dictionary(Of String, String)
    Private SearchStringTxtLen As Integer = 0
    Private SpecialFilter As Boolean = False
    Private ReloadTimer As New Timer
    Private bShowOpen As Boolean = False
    Private bShowJob As Boolean = False
    Private bShowDead As Boolean = False
    Private bShowActive As Boolean = False
    Dim X, Y As Integer
    Dim NewPoint As New System.Drawing.Point
    'This should/could be updated to show Jobs and be able to open the electronic job file/Folder When we start doing that.

    ' Also, Should be able to filter/choose to show or not Dead Quotes and Job Quotes

    Private Sub LoadQuotes(iCustID As Integer, sCustName As String)
        Dim SQL As String = "SELECT QTnum, QTDesc, EntDate FROM QuoteDetails WHERE CustID = " & iCustID & " ORDER BY EntDate DESC"
        DBcon.RunQuery(SQL)
        dtQuotes = DBcon.DBds.Tables(0)
        Dim aSQL As String = "SELECT * FROM QUOTE WHERE c_customer = " & iCustID
        AeroDBcon.RunQuery(aSQL)
        Dim dtQuoteDBF As New DataTable
        dtQuoteDBF = AeroDBcon.DBds.Tables(0)

        Dim drs As DataRow()
        Dim dr As DataRow
        Dim sSelExpression As String
        For i As Integer = 0 To dtQuotes.Rows.Count - 1
            Dim qt As New ucQuoteDetail

            With dtQuotes.Rows(i)
                sSelExpression = "Q_QUOTE = '" & .Item("QTnum") & "'"
                Debug.Print(sSelExpression)
                drs = dtQuoteDBF.Select(sSelExpression)
                If drs.Count = 1 Then
                    dr = drs(0)
                    Select Case dr("Q_Status")
                        Case "O"
                            qt.qStatus = ucQuoteDetail.qtStat.Open
                        Case "J"
                            qt.qStatus = ucQuoteDetail.qtStat.Job
                            qt.JobNum = dr("j_job")
                        Case "D"
                            qt.qStatus = ucQuoteDetail.qtStat.Dead
                        Case "A"
                            qt.qStatus = ucQuoteDetail.qtStat.Active
                    End Select
                    Debug.Print(dr("q_quote"))
                End If
                qt.CustNum = iCustID
                qt.QtNum = ValidResponse(.Item("QTnum"))
                qt.Desc = ValidResponse(.Item("QTDesc"))
                qt.CustName = sCustName
                If ShowQt(qt) Then qt.Show() Else qt.Hide()
            End With
            flpQuotes.Controls.Add(qt)
            flpQuotes.Show()
        Next
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblUpdated.Text = DateTime.Now.ToString("hh: mm:ss tt")
        ReloadTimer.Interval = 300000 '5 min
        ReloadTimer.Start()
        AddHandler ReloadTimer.Tick, AddressOf ReloadTimer_Tick
        Me.TransparencyKey = Me.BackColor
        'These are so the transparency on the controls works properly i think
        lbCust.Parent = PictureBox1
        lblUpdated.Parent = PictureBox1
        lblInstructions.Parent = PictureBox1
        cbOpen.Parent = PictureBox1
        cbJob.Parent = PictureBox1
        cbDead.Parent = PictureBox1
        'FlowLayoutPanel1.Parent = PictureBox1
        tbCust.Select()
        cbOpen.Checked = True
        lbCustSelect.AutoSize = True 'There is no AutoSize option to check in Properties in the designer for some reason so you have to set it here.
    End Sub
    Private Sub ReloadTimer_Tick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        'LoadQuotes()
        lblUpdated.Text = DateTime.Now.ToString("hh:mm:ss tt")
        tbCust.Select()
    End Sub
    Private Function ValidResponse(DBValue As Object) As String
        If Not IsDBNull(DBValue) Then
            Return DBValue
        Else
            Return ""
        End If
    End Function

    Private Sub btClose_Click() Handles btClose.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown, lblInstructions.MouseDown, lbCust.MouseDown
        X = Control.MousePosition.X - Me.Location.X
        Y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove, lblInstructions.MouseMove, lbCust.MouseMove
        If e.Button = MouseButtons.Left Then
            NewPoint = Control.MousePosition
            NewPoint.X -= (X)
            NewPoint.Y -= (Y)
            Me.Location = NewPoint
        End If
    End Sub

    Private Sub tbCust_TextChanged(sender As Object, e As EventArgs) Handles tbCust.TextChanged
        'This populated the Customer Selection list box with customers whose names start with the
        'string of letters in the customer name text box.
        If tbCust.TextLength > 0 Then
            lbCustSelect.Visible = True
            Dim SQL As String
            SQL = "SELECT C_CUSTOMER as ID, C_SHIPNAME as Name FROM CUSTOMER WHERE LEFT(C_SHIPNAME," & tbCust.TextLength & ") ='" & tbCust.Text & "'"
            Debug.Print(SQL)
            AeroDBcon.RunQuery(SQL)
            dtCustomers = AeroDBcon.DBds.Tables(0)
            lbCustSelect.DataSource = dtCustomers
            lbCustSelect.DisplayMember = "Name"
            lbCustSelect.ValueMember = "ID"
            If dtCustomers.Rows.Count = 0 Then
                lbCustSelect.Visible = False
            End If
        Else
            'if there is no text in the customer name text box, hide the listbox
            lbCustSelect.Visible = False
        End If
    End Sub

    Private Sub tbCust_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCust.KeyDown
        If e.Modifiers = Keys.Control Then
            e.SuppressKeyPress = True
            Select Case e.KeyCode
                Case Keys.J
                    cbJob.Checked = Not cbJob.Checked 'Hide_Show_Quotes event is handled/fired by the radio_button_Changed event
                Case Keys.D
                    cbDead.Checked = Not cbDead.Checked
                Case Keys.O
                    cbOpen.Checked = Not cbOpen.Checked
                Case Keys.A
                    'cbActive.Checked = Not cbActive.Checked
            End Select
        Else
            Select Case e.KeyCode
                Case Keys.Return
                    Dim sCustName As String = lbCustSelect.GetItemText(lbCustSelect.SelectedItem) 'This is the only way I could find to get the 'display memeber' of the listbox into a string (used a variable to save typing)
                    e.SuppressKeyPress = True 'Stops the ding when you press enter.
                    tbCust.Text = sCustName
                    tbCust.SelectAll()
                    lbCustSelect.Visible = False
                    flpQuotes.Controls.Clear()
                    LoadQuotes(lbCustSelect.SelectedValue, sCustName)
                Case Keys.Down
                    If Not lbCustSelect.SelectedIndex = lbCustSelect.Items.Count - 1 Then lbCustSelect.SelectedIndex = lbCustSelect.SelectedIndex + 1
                    e.Handled = True
                Case Keys.Up
                    If Not lbCustSelect.SelectedIndex = 0 Then lbCustSelect.SelectedIndex = lbCustSelect.SelectedIndex - 1
                    e.Handled = True
            End Select
        End If
    End Sub
    Private Sub Hide_Show_Quotes()
        For Each q As ucQuoteDetail In flpQuotes.Controls
            If ShowQt(q) Then q.Show() Else q.Hide()
        Next
    End Sub

    Private Sub Radio_Button_Changed(sender As Object, e As EventArgs) Handles cbOpen.CheckedChanged, cbJob.CheckedChanged, cbDead.CheckedChanged
        bShowJob = cbJob.Checked 'rbJob.Checked returns true if checked and false if not checked.
        bShowDead = cbDead.Checked
        bShowOpen = cbOpen.Checked
        'bShowActive = rbOpen.checked
        Hide_Show_Quotes()
    End Sub

    Private Function ShowQt(Qt As ucQuoteDetail) As Boolean
        Select Case Qt.qStatus
            Case ucQuoteDetail.qtStat.Active
                If bShowActive Then
                    Return True
                Else
                    Return False
                End If
            Case ucQuoteDetail.qtStat.Open
                If bShowOpen Then
                    Return True
                Else
                    Return False
                End If
            Case ucQuoteDetail.qtStat.Dead
                If bShowDead Then
                    Return True
                Else
                    Return False
                End If
            Case ucQuoteDetail.qtStat.Job
                If bShowJob Then
                    Return True
                Else
                    Return False
                End If
            Case Else
                Return False
        End Select
    End Function
End Class
