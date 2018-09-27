Public Class Form1
    Private DBcon As New DBConnection
    Private AeroDBcon As New AeroDBConnection
    Private dtQuotes As New DataTable
    Private dtJobs As New DataTable
    Private dtCustomers As New DataTable
    Private DictCustNames As New Dictionary(Of String, String)
    Private SearchStringTxtLen As Integer = 0
    Private SpecialFilter As Boolean = False
    Private ReloadTimer As New Timer
    Private bShowOpen As Boolean = False
    Private bShowJob As Boolean = False
    Private bShowDead As Boolean = False
    Private bShowActive As Boolean = False
    Private bShowClosed As Boolean = False
    Private bCheckBoxOPenTemp As Boolean
    Private bCheckBoxJobTemp As Boolean
    Private bCheckBoxDeadTemp As Boolean
    Private bCheckBoxActiveTemp As Boolean
    Private bOverrideLBPopulate As Boolean = False
    Private bFilterSelected As Boolean = False
    Private bCheckBoxesCleared As Boolean = False
    Dim X, Y As Integer
    Dim NewPoint As New System.Drawing.Point
    'This should/could be updated to show Jobs and be able to open the electronic job file/Folder When we start doing that. <-- Started 9/26/18... finished rev 1 on 9/26/18 which allows you to open jobs that are associated with a quote.
    'Started rev 2 of the job folders so Jobs are searched independantly and allowed to open without an associated quote 9/26/18
    'Also, Should be able to filter/choose to show or not Dead Quotes and Job Quotes <-- done a while ago

    Private Sub LoadQuotes(iCustID As Integer, sCustName As String)
        'Search Quotes accdb for Quotes related to the selected customer
        Dim SQL As String = "SELECT QTnum, QTDesc, EntDate, QTamt FROM QuoteDetails WHERE CustID = " & iCustID & " ORDER BY EntDate DESC"
        DBcon.RunQuery(SQL)
        dtQuotes = DBcon.DBds.Tables(0)
        'Search QUOTE.DBF for quotes for the selected customer (this is to retrieve quote status)
        Dim aSQL As String = "SELECT * FROM QUOTE WHERE c_customer = " & iCustID
        AeroDBcon.RunQuery(aSQL)
        Dim dtQuoteDBF As New DataTable
        dtQuoteDBF = AeroDBcon.DBds.Tables(0)

        'Loop through the quotes retrieved from the accdb and assign their status
        Dim drs As DataRow()
        Dim dr As DataRow
        Dim sSelExpression As String
        For i As Integer = 0 To dtQuotes.Rows.Count - 1
            Dim qt As New ucQuoteDetail

            With dtQuotes.Rows(i)
                'Search the data rows array for the each quote and assign status
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
                    qt.JobNum = dr("j_job")
                    Debug.Print(qt.JobNum.ToString)
                    Debug.Print(dr("q_quote"))
                End If
                qt.CustNum = iCustID
                qt.QtNum = ValidResponse(.Item("QTnum"))
                qt.Desc = ValidResponse(.Item("QTDesc"))
                qt.CustName = sCustName
                If ShowQt(qt) Then qt.Show() Else qt.Hide()
            End With
            flpQuotes.Controls.Add(qt)
        Next
        flpQuotes.Visible = rbtnQuotes.Checked
        flpJobs.Visible = rbtnJobs.Checked
    End Sub
    Private Sub LoadJobs(iCustID As Integer, sCustName As String)
        Dim SQL As String = "SELECT * FROM JOB WHERE c_customer = " & iCustID & " ORDER BY j_job DESC"
        AeroDBcon.RunQuery(SQL)
        dtJobs = AeroDBcon.DBds.Tables(0)

        For i As Integer = 0 To dtJobs.Rows.Count - 1
            With dtJobs.Rows(i)
                Dim qt As New ucQuoteDetail
                Debug.Print("Status: " & .Item("j_status"))
                If IsDBNull(.Item("j_status")) Then
                    qt.qStatus = ucQuoteDetail.qtStat.Open
                ElseIf .Item("j_status") = "C" Then
                    qt.qStatus = ucQuoteDetail.qtStat.Closed
                End If
                qt.CustNum = iCustID
                qt.QtNum = .Item("j_job")
                qt.Desc = ValidResponse(.Item("j_descript"))
                qt.CustName = sCustName
                If ShowJob(qt) Then qt.Show() Else qt.Hide()
                flpJobs.Controls.Add(qt)
            End With
        Next
        flpQuotes.Visible = rbtnQuotes.Checked
        flpJobs.Visible = rbtnJobs.Checked
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        'The form would resize the first time the Database Connection was opened so i just put this here so it resizes right away and the user doens't have to see it large and then go small.
        Dim initializerDBcon As New DBConnection
        initializerDBcon.RunQuery("SELECT MAX(ID) FROM QuoteDetails")

        Me.TransparencyKey = Me.BackColor
        'These are so the transparency on the controls works properly i think
        lblCust.Parent = PictureBox1
        lblInstructions.Parent = PictureBox1
        cbOpen.Parent = PictureBox1
        cbJob.Parent = PictureBox1
        cbDead.Parent = PictureBox1
        rbtnJobs.Parent = PictureBox1
        rbtnQuotes.Parent = PictureBox1
        cbClosed.Parent = PictureBox1
        'FlowLayoutPanel1.Parent = PictureBox1
        KeyPreview = True
        tbCust.Select()
        cbOpen.Checked = True
        rbtnQuotes.Checked = True
        lbCustSelect.AutoSize = True 'There is no AutoSize option to check in Properties in the designer for some reason so you have to set it here.
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
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown, lblInstructions.MouseDown, lblCust.MouseDown
        X = Control.MousePosition.X - Me.Location.X
        Y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove, lblInstructions.MouseMove, lblCust.MouseMove
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

        'This prevents errors with SQL when customer name has single quotes (Bongards' Creamery)
        If bOverrideLBPopulate Then
            Exit Sub
        End If

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
                    If Not bCheckBoxesCleared Then Clear_Check_Boxes()
                    cbJob.Checked = Not cbJob.Checked 'Hide_Show_Quotes event is handled/fired by the radio_button_Changed event
                Case Keys.D
                    If Not bCheckBoxesCleared Then Clear_Check_Boxes()
                    cbDead.Checked = Not cbDead.Checked
                Case Keys.O
                    If Not bCheckBoxesCleared Then Clear_Check_Boxes()
                    cbOpen.Checked = Not cbOpen.Checked
                Case Keys.C
                    If Not bCheckBoxesCleared Then Clear_Check_Boxes()
                    cbClosed.Checked = Not cbClosed.Checked
                Case Keys.A
                    'If Not bCheckBoxesCleared Then Clear_Check_Boxes()
                    'cbActive.Checked = Not cbActive.Checked
            End Select
        Else
            Select Case e.KeyCode
                Case Keys.Return
                    Dim sCustName As String = lbCustSelect.GetItemText(lbCustSelect.SelectedItem) 'This is the only way I could find to get the 'display memeber' of the listbox into a string (used a variable to save typing)
                    e.SuppressKeyPress = True 'Stops the ding when you press enter.
                    bOverrideLBPopulate = True 'this prevents errors when customer name includes special characters like single quotes (Bongards' Creamery)
                    tbCust.Text = sCustName
                    tbCust.SelectAll()
                    lbCustSelect.Visible = False
                    flpQuotes.Controls.Clear()
                    flpJobs.Controls.Clear()
                    If rbtnQuotes.Checked Then
                        LoadQuotes(lbCustSelect.SelectedValue, sCustName)
                    ElseIf rbtnJobs.Checked Then
                        LoadJobs(lbCustSelect.SelectedValue, sCustName)
                    End If
                    bOverrideLBPopulate = False
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
    Private Sub Hide_Show_Jobs()
        For Each q As ucQuoteDetail In flpJobs.Controls
            If ShowJob(q) Then q.Show() Else q.Hide()
        Next
    End Sub
    Private Sub Clear_Check_Boxes()
        'Clear all check boxes
        cbDead.Checked = False
        cbJob.Checked = False
        cbOpen.Checked = False
        cbClosed.Checked = False
        'cbActive.checked = False
        bCheckBoxesCleared = True
        Debug.Print("CheckBoxes Cleared = " & bCheckBoxesCleared)
    End Sub
    Private Sub Filter_Checkboxes_Changed(sender As Object, e As EventArgs) Handles cbOpen.CheckedChanged, cbJob.CheckedChanged, cbDead.CheckedChanged, cbClosed.CheckedChanged
        bShowJob = cbJob.Checked 'cbJob.Checked returns true if checked and false if not checked.
        bShowDead = cbDead.Checked
        bShowOpen = cbOpen.Checked
        bShowActive = cbOpen.Checked 'Instead of having a checkbox for Active and Open, Open will show both open and active quotes.
        bShowClosed = cbClosed.Checked
        If rbtnQuotes.Checked Then
            Hide_Show_Quotes()
        ElseIf rbtnJobs.Checked Then
            Hide_Show_Jobs()
        End If
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
    Private Function ShowJob(Qt As ucQuoteDetail) As Boolean
        Select Case Qt.qStatus
            Case ucQuoteDetail.qtStat.Closed
                If bShowClosed Then
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
            Case Else
                Return False
        End Select
    End Function

    Private Sub tbCust_Click(sender As Object, e As EventArgs) Handles tbCust.Click
        tbCust.SelectAll()
    End Sub

    Private Sub rbtnJobs_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnJobs.CheckedChanged, rbtnQuotes.CheckedChanged
        'When the Jobs radio button is checked, the "Closed" check box should be visible and the "DEAD" and "JOB" check boxes should be hidden. This also reverses the hiding when Quotes is checked.
        cbClosed.Visible = rbtnJobs.Checked
        cbDead.Visible = Not rbtnJobs.Checked
        cbJob.Visible = Not rbtnJobs.Checked
        tbCust.Focus()
        tbCust.SelectAll()
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Debug.Print(e.KeyCode.ToString)
        If e.KeyCode.ToString = "ControlKey" Then 'I can't figure out how to detect the CTRL KeyUp event any other way than this which seems really dumb.
            bCheckBoxesCleared = False
            Debug.Print("Check Boxes Cleared = " & bCheckBoxesCleared)
        End If
    End Sub
End Class
