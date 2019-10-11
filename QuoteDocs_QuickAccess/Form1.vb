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
    Private bShowOpenQuotes As Boolean = False
    Private bShowJobQuotes As Boolean = False
    Private bShowDeadQuotes As Boolean = False
    Private bShowActiveQuotes As Boolean = False
    Private bShowOpenJobs As Boolean = False
    Private bShowClosedJobs As Boolean = False
    Private bOverrideLBPopulate As Boolean = False
    Private bFilterSelected As Boolean = False
    Public pStopWatch As New Stopwatch
    Dim X, Y As Integer
    Dim NewPoint As New System.Drawing.Point

    Private Customers As IEnumerable(Of Customer)
    Private ReadOnly querytimer As New System.Threading.Timer(AddressOf executeQuery, Nothing, -1, -1)
    Private ReadOnly keyPressDelay As Integer = 100
    Private filterString As String = ""
    'This should/could be updated to show Jobs and be able to open the electronic job file/Folder When we start doing that. <-- Started 9/26/18... finished rev 1 on 9/26/18 which allows you to open jobs that are associated with a quote.
    'Started rev 2 of the job folders so Jobs are searched independantly and allowed to open without an associated quote 9/26/18
    'Also, Should be able to filter/choose to show or not Dead Quotes and Job Quotes <-- done a while ago


    '++++++ Version History +++++++
    'v4.0.0 --> Added version label to form
    'v4.0.1 --> Fixed loop issue on Loading Jobs.
    '         Customers with only 1 job and 1 PO on that job would cause an uncaught error and would not show that job at all. 
    'v4.0.2 --> Updated Version label on form (forgot to on v4.0.1... no other changes)
    'v4.0.3 --> Changed to only load top 50 jobs/quotes to keep from stalling so bad when loading customers with lots of history.
    'v4.0.4 --> Added a SORT BY in the nested select for jobs to show in order of jobs
    'v4.0.5 --> Added some debugging and testing code to help with adding PO re-searching on right click on qtDetail 6/23/19
    'v4.1.0 --> Added right click on qtDetail to reload PO's functionality 6/23/19


    Private Sub LoadQuotes(iCustID As Integer, sCustName As String)
        Console.WriteLine("Loading Quotes")
        pStopWatch.Reset()
        pStopWatch.Start()
        Dim t0 As Double = pStopWatch.ElapsedMilliseconds
        'Search Quotes accdb for Quotes related to the selected customer
        Dim SQL As String = "SELECT QTnum, QTDesc, EntDate, QTamt FROM QuoteDetails WHERE CustID = " & iCustID & " ORDER BY EntDate DESC"
        DBcon.RunQuery(SQL)
        Dim t1 As Double = pStopWatch.ElapsedMilliseconds
        Console.WriteLine("  ACCDB Query took {0}ms", t1 - t0)
        dtQuotes = DBcon.DBds.Tables(0)
        Dim t2 As Double = pStopWatch.ElapsedMilliseconds
        Console.WriteLine("  Filling Datatable took {0}ms", t2 - t1)
        'Query DBF the selected customer to retrieve Quote Status and PO count
        'Dim aSQL As String = "SELECT * FROM QUOTE WHERE c_customer = " & iCustID
        Dim aSQL As String = "SELECT * FROM QUOTE a LEFT JOIN JOB b ON a.Q_QUOTE = b.Q_QUOTE WHERE a.C_CUSTOMER = " & iCustID
        AeroDBcon.RunQuery(aSQL)
        Dim t3 As Double = pStopWatch.ElapsedMilliseconds
        Console.WriteLine("  DBF Query took {0}ms", t3 - t2)
        Dim dtQuoteDBF As New DataTable
        dtQuoteDBF = AeroDBcon.DBds.Tables(0)
        Dim t4 As Double = pStopWatch.ElapsedMilliseconds
        Console.WriteLine("  Fill DBF Datatable took {0}ms", t4 - t3)
        'Loop through the quotes retrieved from the accdb and assign their status
        Dim drs As DataRow() 'array of data rows
        Dim dr As DataRow 'Single data row
        Dim sSelExpression As String
        lblQuoteCount.Text = "Quote Count: " & dtQuotes.Rows.Count
        Dim i As Integer
        Dim z As Integer
        Dim Qt_Count As Integer = 0
        'rows_to_load prevents from loading tons of old quotes
        Dim rows_to_Load As Integer = Math.Min(dtQuotes.Rows.Count - 1, 24)
        For i = 0 To rows_to_Load
            Dim qt As New ucQuoteDetail
            Qt_Count += 1
            With dtQuotes.Rows(i)
                'Search the data rows array for each quote and assign status
                sSelExpression = "a.Q_QUOTE = '" & .Item("QTnum") & "'"
                'Debug.Print(sSelExpression)
                drs = dtQuoteDBF.Select(sSelExpression)
                If drs.Count = 1 Then
                    dr = drs(0)
                    Select Case dr("Q_Status")
                        Case "O"
                            qt.qStatus = ucQuoteDetail.qtStat.Open
                        Case "J"
                            qt.qStatus = ucQuoteDetail.qtStat.Job
                            qt.JobNum = ValidResponse(dr("b.j_job"))
                            Try
                                'SQL = "SELECT * FROM JOB WHERE J_JOB = " & dr("j_job")
                                'AeroDBcon.RunQuery(SQL)
                                qt.poCount = ValidResponse(dr("J_POCOUNT"))
                            Catch ex As Exception
                                z = z + 1
                                Debug.Print(ex.Message)
                                Debug.Print("Job: " & qt.JobNum & " Quote: " & .Item("QTnum"))
                            End Try
                        Case "D"
                            qt.qStatus = ucQuoteDetail.qtStat.Dead
                        Case "A"
                            qt.qStatus = ucQuoteDetail.qtStat.Active
                    End Select
                End If
                qt.CustNum = iCustID
                qt.QtNum = ValidResponse(.Item("QTnum"))
                'You need to set QtNum or JobNum before setting QuoteOrJob Type since the QuoteOrJob routine sets the Quote or Job number on the label
                qt.QuoteOrJob = ucQuoteDetail.DetailType.Quote
                qt.Desc = ValidResponse(.Item("QTDesc"))
                qt.CustName = sCustName
                If ShowQt(qt) Then qt.Show() Else qt.Hide()
            End With
            flpQuotes.Controls.Add(qt)
        Next
        Dim t5 As Double = pStopWatch.ElapsedMilliseconds
        pStopWatch.Stop()
        Console.WriteLine("{0} Errors", z)
        Console.WriteLine("  t0:{0}, t5:{1}, i:{2}", t0, t5, i)
        Console.WriteLine("  Loaded {0} Quotes in {1} ms [{2}ms/qt]", i, t5 - t0, (t5 - t0) / i)

        Dim etime As Double = t5 - t0
        lblQuoteCount.Text = "Loaded & " & Qt_Count & " Quotes in " & etime & " ms [" & Math.Round(etime / Qt_Count, 2) & "ms/Job]"
    End Sub


    Private Sub LoadJobs(iCustID As Integer, sCustName As String)
        Console.WriteLine("Loading Jobs")
        pStopWatch.Reset()
        pStopWatch.Start()
        Dim t0 As Double = pStopWatch.ElapsedMilliseconds
        'AND j_entdate >= #" & DateTime.Now.AddDays(-730).ToString("MM/dd/yyy") & "# 
        'Dim SQL As String = "SELECT * FROM JOB WHERE c_customer = " & iCustID & " ORDER BY j_job DESC"
        'This SQL limits the amount of jobs returned to 50 so we dont unnecessarily load really old jobs and bogg everything down.
        Dim SQL As String = "SELECT a.*, PO_NUMBER, V_NAME FROM (((SELECT TOP 50 * FROM JOB WHERE c_customer = " & iCustID & " ORDER BY J_JOB DESC) a LEFT JOIN PO b ON a.J_JOB = b.J_JOB) LEFT JOIN VENDOR c On b.V_VENDOR = c.V_VENDOR) ORDER BY a.J_JOB DESC, PO_NUMBER ASC"
        AeroDBcon.RunQuery(SQL)
        Dim t1 As Double = pStopWatch.ElapsedMilliseconds
        Console.WriteLine("  DBF Query took {0}ms", t1 - t0)
        dtJobs = AeroDBcon.DBds.Tables(0)
        Dim t2 As Double = pStopWatch.ElapsedMilliseconds
        Console.WriteLine("  Fill Datatable took {0}ms", t2 - t1)
        Dim j As Integer
        j = dtJobs.Rows.Count
        Dim i As Integer
        Dim J_JOB As Integer
        Dim Job_Count As Integer = 0
        Dim jobs_to_load As Integer = j - 1
        If j > 0 Then 'j=0 actually means (1) job was returned see above where j is set.
            Dim qt As ucQuoteDetail
            For i = 0 To jobs_to_load
                Job_Count = Job_Count + 1
                With dtJobs.Rows(i)
                    qt = New ucQuoteDetail
                    'Debug.Print("Status: " & .Item("j_status"))
                    If IsDBNull(.Item("J_STATUS")) Then
                        'DB field is just blank if the job is open, "C" if closed
                        qt.qStatus = ucQuoteDetail.qtStat.Open
                        'if open, show PSale
                        qt.JobValue = .Item("J_PSALE")
                    ElseIf .Item("J_STATUS") = "C" Then
                        qt.qStatus = ucQuoteDetail.qtStat.Closed
                        'If job is closed, display ASALE
                        qt.JobValue = .Item("J_ASALE")
                    End If
                    qt.CustNum = iCustID
                    If Not IsDBNull(.Item("Q_QUOTE")) Then
                        qt.QtNum = .Item("Q_QUOTE")
                    End If
                    'qt.JobNum has to be set before setting the type. Ref Number shown on detail is set when setting Type.
                    J_JOB = .Item("J_JOB")
                    qt.JobNum = J_JOB
                    qt.QuoteOrJob = ucQuoteDetail.DetailType.Job
                    qt.Desc = ValidResponse(.Item("J_DESCRIPT"))
                    qt.CustName = sCustName
                End With

                'scroll through dtJobs until you get to the next job. There will be a line in the table for each PO that exists.
                Do While dtJobs.Rows(i).Item("J_JOB") = J_JOB And i <= j - 1
                    If Not IsDBNull(dtJobs.Rows(i).Item("PO_NUMBER")) And Not IsDBNull(dtJobs.Rows(i).Item("V_NAME")) Then
                        'Add PO's to the detail for the right click menu function
                        qt.ADD_PO(dtJobs.Rows(i).Item("PO_NUMBER"), dtJobs.Rows(i).Item("V_NAME"))
                    End If

                    i = i + 1

                    If i = j Then
                        Exit Do
                    End If
                Loop
                'Need to undo the last increment to i since row(i) now no longer matches the current job.
                'the 'Next' in the loop will autoincrement i again.
                i = i - 1
                If ShowJob(qt) Then qt.Show() Else qt.Hide()
                flpJobs.Controls.Add(qt)
            Next
        Else
            'no records found
        End If
        Dim t3 As Double = pStopWatch.ElapsedMilliseconds
        pStopWatch.Stop()
        Console.WriteLine("  t0:{0}, t3:{1}, i:{2}", t0, t3, i)
        Console.WriteLine("  Loaded {0} Jobs in {1} ms [{2}ms/Job]", i, t3 - t0, (t3 - t0) / j)
        Dim etime As Double = t3 - t0
        lblJobCount.Text = "Loaded & " & Job_Count & " Jobs in " & etime & " ms [" & Math.Round(etime / Job_Count, 2) & "ms/Job]"
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Allow drag and drop on form
        Me.AllowDrop = True

        'The form would resize the first time the Database Connection was opened so i just put this here so it resizes right away and the user doens't have to see it large and then go small.
        Dim initializerDBcon As New DBConnection
        initializerDBcon.RunQuery("SELECT MAX(ID) FROM QuoteDetails")

        Me.TransparencyKey = Me.BackColor
        'These are so the transparency on the controls works properly i think
        lblCust.Parent = PictureBox1
        lblQuoteNum.Parent = PictureBox1
        lblJobNum.Parent = PictureBox1
        cbOpenJobs.Parent = PictureBox1
        cbOpenQuotes.Parent = PictureBox1
        cbJobQuotes.Parent = PictureBox1
        cbDeadQuotes.Parent = PictureBox1
        cbClosedJobs.Parent = PictureBox1
        lblJobCount.Parent = PictureBox1
        lblQuoteCount.Parent = PictureBox1
        lblRevision.Parent = PictureBox1
        'FlowLayoutPanel1.Parent = PictureBox1
        KeyPreview = True
        tbCust.Select()
        cbOpenQuotes.Checked = True
        cbOpenJobs.Checked = True
        lbCustSelect.AutoSize = True 'There is no AutoSize option to check in Properties in the designer for some reason so you have to set it here.

        'Loads customer collection to be searched and displayed in listbox
        If Customers Is Nothing Then
            Dim sql = "SELECT C_CUSTOMER as ID, C_SHIPNAME as Name FROM CUSTOMER"
            AeroDBcon.RunQuery(sql)
            Customers =
                AeroDBcon.DBds.Tables(0).
                AsEnumerable().Select(Function(dr) New Customer With {.ID = dr("ID").ToString(), .name = dr("Name").ToString()})
            Debug.Print("Customer List Loaded")
        End If

        flpQuotes.Show()
        flpJobs.Show()
        Debug.Print(flpQuotes.Controls.Count)
    End Sub


    Private Function ValidResponse(DBValue As Object) As String
        If Not IsDBNull(DBValue) Then
            Return DBValue
        Else
            Return 0
        End If
    End Function

    Private Sub btClose_Click() Handles btClose.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown, lblCust.MouseDown, lblJobNum.MouseDown, lblQuoteNum.MouseDown
        X = Control.MousePosition.X - Me.Location.X
        Y = Control.MousePosition.Y - Me.Location.Y
    End Sub
    Private Sub Form1_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        'here for source of this code "https://stackoverflow.com/questions/11686631/vb-net-drag-drop-and-get-file-path"
        'See here for email handling "https://www.emoreau.com/Entries/Articles/2016/04/Drag--Drop-emails-on-a-Net-application-from-Outlook-with-attachments.aspx"
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            MsgBox(path)
        Next
    End Sub

    Private Sub Form1_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Move
        End If
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove, lblCust.MouseMove, lblJobNum.MouseMove, lblQuoteNum.MouseMove
        If e.Button = MouseButtons.Left Then
            NewPoint = Control.MousePosition
            NewPoint.X -= (X)
            NewPoint.Y -= (Y)
            Me.Location = NewPoint
        End If
    End Sub
    Private Sub tbCust_TextChanged(sender As Object, e As EventArgs) Handles tbCust.TextChanged
        filterString = tbCust.Text
        lbCustSelect.Visible = filterString.Length > 0
        If filterString.Length > 0 Then querytimer.Change(keyPressDelay, -1)
    End Sub
    Private Sub tbCust_TextChanged_(sender As Object, e As EventArgs)
        'This populated the Customer Selection list box with customers whose names start with the
        'string of letters in the customer name text box.

        'This prevents errors with SQL when customer name has single quotes (Bongards' Creamery)
        If bOverrideLBPopulate Then
            Exit Sub
        End If

        If tbCust.TextLength > 0 Then
            lbCustSelect.Visible = True
            Dim SQL As String
            SQL = "SELECT C_CUSTOMER as ID, C_SHIPNAME as Name FROM CUSTOMER WHERE C_SHIPNAME LIKE '%" & tbCust.Text & "%' ORDER BY C_SHIPNAME ASC"
            'Debug.Print(SQL)
            AeroDBcon.RunQuery(SQL)
            dtCustomers = AeroDBcon.DBds.Tables(0)

            lbCustSelect.DataSource = Nothing
            lbCustSelect.DisplayMember = "Name"
            lbCustSelect.ValueMember = "ID"
            lbCustSelect.DataSource = dtCustomers
            If dtCustomers.Rows.Count = 0 Then
                lbCustSelect.Visible = False
            End If
        Else
            'if there is no text in the customer name text box, hide the listbox
            lbCustSelect.Visible = False
        End If
    End Sub

    Private Sub executeQuery(state As Object)

        'Dim filteredCustomers = Customers.Where(Function(c) c.name.StartsWith(filterString)).ToList()
        Dim filteredCustomers = Customers.Where(Function(c) c.name.Contains(filterString)).ToList()

        ' update the control on the UI thread
        lbCustSelect.Invoke(
            Sub()
                lbCustSelect.DataSource = Nothing
                lbCustSelect.DisplayMember = "Name"
                lbCustSelect.ValueMember = "ID"
                lbCustSelect.DataSource = filteredCustomers
            End Sub)
    End Sub

    Private Sub tbCust_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCust.KeyDown
        If e.Modifiers = Keys.Control Then
            e.SuppressKeyPress = True
            Select Case e.KeyCode
                Case Keys.J
                    cbJobQuotes.Checked = Not cbJobQuotes.Checked 'Hide_Show_Quotes event is handled/fired by the radio_button_Changed event
                Case Keys.D
                    cbDeadQuotes.Checked = Not cbDeadQuotes.Checked
                Case Keys.O
                    cbOpenQuotes.Checked = Not cbOpenQuotes.Checked
                    cbOpenJobs.Checked = Not cbOpenJobs.Checked
                Case Keys.C
                    cbClosedJobs.Checked = Not cbClosedJobs.Checked
                Case Keys.A
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
                    LoadJobs(lbCustSelect.SelectedValue, sCustName)
                    LoadQuotes(lbCustSelect.SelectedValue, sCustName)

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
    Private Sub Filter_Checkboxes_Changed(sender As Object, e As EventArgs) Handles cbOpenQuotes.CheckedChanged, cbJobQuotes.CheckedChanged, cbDeadQuotes.CheckedChanged, cbClosedJobs.CheckedChanged, cbOpenJobs.CheckedChanged
        bShowJobQuotes = cbJobQuotes.Checked 'cbJob.Checked returns true if checked and false if not checked.
        bShowDeadQuotes = cbDeadQuotes.Checked
        bShowOpenQuotes = cbOpenQuotes.Checked
        bShowActiveQuotes = cbOpenQuotes.Checked 'Instead of having a checkbox for Active and Open, Open will show both open and active quotes.
        bShowClosedJobs = cbClosedJobs.Checked
        bShowOpenJobs = cbOpenJobs.Checked
        Hide_Show_Quotes()
        Hide_Show_Jobs()
    End Sub

    Private Function ShowQt(Qt As ucQuoteDetail) As Boolean
        Select Case Qt.qStatus
            Case ucQuoteDetail.qtStat.Active
                If bShowActiveQuotes Then
                    Return True
                Else
                    Return False
                End If
            Case ucQuoteDetail.qtStat.Open
                If bShowOpenQuotes Then
                    Return True
                Else
                    Return False
                End If
            Case ucQuoteDetail.qtStat.Dead
                If bShowDeadQuotes Then
                    Return True
                Else
                    Return False
                End If
            Case ucQuoteDetail.qtStat.Job
                If bShowJobQuotes Then
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
                If bShowClosedJobs Then
                    Return True
                Else
                    Return False
                End If
            Case ucQuoteDetail.qtStat.Open
                If bShowOpenJobs Then
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

    Private Sub rbtnJobs_CheckedChanged(sender As Object, e As EventArgs)
        'When the Jobs radio button is checked, the "Closed" check box should be visible and the "DEAD" and "JOB" check boxes should be hidden. This also reverses the hiding when Quotes is checked.
        tbCust.Focus()
        tbCust.SelectAll()
        flpQuotes.Controls.Clear()
        flpJobs.Controls.Clear()

        'Reload the quotes or jobs for that customer
        Dim sCustName As String = lbCustSelect.GetItemText(lbCustSelect.SelectedItem) 'This is the only way I could find to get the 'display memeber' of the listbox into a string (used a variable to save typing)
        LoadQuotes(lbCustSelect.SelectedValue, sCustName)
        LoadJobs(lbCustSelect.SelectedValue, sCustName)
    End Sub

End Class
