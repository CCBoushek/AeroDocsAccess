Public Class ucQuoteDetail
    Private AeroDBcon As New AeroDBConnection
    Private QtNumValue As String
    Private DescValue As String
    Private CustNumValue As String
    Private CustNameValue As String
    Private bVisible As Boolean
    Public qType As qtType
    Private JobNumValue As Integer
    Private qStat As qtStat
    Private _poCount As Integer
    Private _JobValue As Double
    Private QuoteOrJobValue As String
    Public Property QuoteOrJob() As DetailType
        Get
            Return QuoteOrJobValue
        End Get
        Set(ByVal value As DetailType)
            QuoteOrJobValue = value
            If value = DetailType.Job Then
                lbRefNum.Text = UCase(JobNumValue)
            ElseIf value = DetailType.Quote Then
                lbRefNum.Text = UCase(QtNumValue)
            End If
        End Set
    End Property
    Public Property JobValue As Double
        Get
            Return _JobValue
        End Get
        Set
            _JobValue = Value
        End Set
    End Property
    Public Property poCount As Integer
        Get
            Return _poCount
        End Get
        Set
            _poCount = Value 'Value must be the number passed to this sub? Strange that it's not in the declaration
            If _poCount > 0 Then
                For i As Integer = 1 To _poCount - 1
                    Dim menu1 As New ToolStripMenuItem() With {.Text = "-" & i.ToString("D2"), .Name = "poItem" & i.ToString("D2")}
                    menuJobFolder.DropDownItems.Add(menu1)
                    AddHandler menu1.Click, AddressOf poFolder_click
                Next
            End If
        End Set
    End Property
    Public Sub ADD_PO(PO_Number As String, PO_Vendor As String)
        Dim menu1 As New ToolStripMenuItem() With {.Text = "-" & Mid(PO_Number, 8) & " (" & PO_Vendor & ")", .Name = PO_Number}
        menuJobFolder.DropDownItems.Add(menu1)
        AddHandler menu1.Click, AddressOf poFolder_click
    End Sub
    Private Sub poFolder_click(sender As ToolStripMenuItem, e As EventArgs)
        Try
            'poNum is taken from the name (.Name) of the menu item
            Dim poNum As Integer = sender.Name
            Debug.Print(poNum.ToString)
            Dim sPath As String = "Z:\DATA\JOBS\" & JobNum.ToString & "\2 - PURCHASE ORDERS\" & poNum.ToString
            Debug.Print(sPath)
            Process.Start(sPath)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Property qStatus() As qtStat
        Get
            Return qStat
        End Get
        Set(ByVal value As qtStat)
            qStat = value
            Select Case value
                Case qtStat.Open
                    BackColor = Color.FromArgb(0, 100, 50)
                Case qtStat.Job
                    BackColor = Color.FromArgb(0, 50, 100)
                Case qtStat.Dead
                    BackColor = Color.FromArgb(64, 64, 64)
                Case qtStat.Active
                    BackColor = Color.FromArgb(25, 150, 25)
                Case qtStat.Closed
                    BackColor = Color.FromArgb(64, 64, 64)
            End Select
        End Set
    End Property
    Public Enum DetailType
        Quote
        Job
    End Enum
    Public Enum qtStat
        Active
        Open
        Job
        Dead
        Closed
    End Enum
    Public Enum qtType
        Part
        System
    End Enum
    Public Property QtNum() As String
        Get
            Return QtNumValue
        End Get
        Set(ByVal value As String)
            QtNumValue = value
            If Mid(QtNumValue, 6, 1).ToLower.Contains("p") Then
                qType = qtType.Part
            Else
                qType = qtType.System
            End If
        End Set
    End Property
    Public Property Desc() As String
        Get
            Return DescValue
        End Get
        Set(ByVal value As String)
            DescValue = UCase(value)
            lbDesc.Text = DescValue
        End Set
    End Property
    Public Property CustNum() As String
        Get
            Return CustNumValue
        End Get
        Set(ByVal value As String)
            CustNumValue = value
        End Set
    End Property
    Public Property JobNum() As String
        Get
            Return JobNumValue
        End Get
        Set(ByVal value As String)
            JobNumValue = value
        End Set
    End Property
    Public Property CustName() As String
        Get
            Return CustNameValue
        End Get
        Set(ByVal value As String)
            CustNameValue = value
            lbCustName.Text = CustNameValue
        End Set
    End Property
    Public Sub HideMe()
        Me.Hide()
        bVisible = False
    End Sub
    Public Sub ShowMe()
        Me.Show()
        bVisible = True
    End Sub

    Private Sub Open_Folder(sender As Object, e As EventArgs) Handles Me.DoubleClick, lbCustName.DoubleClick, lbDesc.DoubleClick, lbRefNum.DoubleClick
        Try
            Dim strPath As String
            If QuoteOrJob = DetailType.Job Then
                strPath = "Z:\DATA\JOBS\"
                strPath += JobNum & "\"
                Process.Start(strPath)
            ElseIf QuoteOrJob = DetailType.Quote Then
                strPath = "Z:\DATA\QUOTES\"
                Select Case qType
                    Case qtType.Part
                        strPath += "PARTS\"
                    Case qtType.System
                        strPath += "SYSTEMS\"
                End Select
                strPath += "QUOTE DOCs\" & QtNum & "\"
                Process.Start(strPath)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Open_Quote_Folder(sender As Object, e As EventArgs) Handles OpenQtFldr_ContextMenuItem.Click
        Try
            Dim strPath As String = "Z:\DATA\QUOTES\"
            Select Case qType
                Case qtType.Part
                    strPath += "PARTS\"
                Case qtType.System
                    strPath += "SYSTEMS\"
            End Select
            strPath += "QUOTE DOCs\" & QtNum & "\"
            Process.Start(strPath)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub OpenORCreate_Quote_Sent_Folder(sender As Object, e As EventArgs) Handles Me.Click, lbRefNum.Click, lbDesc.Click, lbCustName.Click
        Dim strPath As String = "Z:\DATA\QUOTES\"
        Select Case qType
            Case qtType.Part
                strPath += "PARTS\"
            Case qtType.System
                strPath += "SYSTEMS\"
        End Select

        If Control.ModifierKeys = Keys.Control Then 'this only runs if you hold CTRL + Click (Opens Quote's Current PDF) 
            Try
                strPath += "PDFs\" & CustName & " (" & QtNum & ").PDF"
                Process.Start(strPath)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf Control.ModifierKeys = Keys.Alt Then 'this only runs if you hold ALT + Click (Creates Quote Sent folder and opens it)
            Dim sModDate As Date
            Dim SQL As String = "SELECT ModDAte, EntDate FROM QuoteDetails WHERE QTnum = '" & QtNum & "'"
            Try
                Dim DBconn As New DBConnection
                DBconn.RunQuery(SQL)
                If DBconn.RecordCount = 1 And Not IsDBNull(DBconn.DBds.Tables(0).Rows(0).Item("ModDate")) Then
                    sModDate = DBconn.DBds.Tables(0).Rows(0).Item("ModDate")
                Else
                    sModDate = DBconn.DBds.Tables(0).Rows(0).Item("EntDate")
                End If
                strPath += "QUOTE DOCs\" & QtNum & "\!! Quotes Sent\" & InputBox("Enter date the Quote was Sent:", "Sent Date",
                sModDate.ToString("MM-dd-yyyy"))
                IO.Directory.CreateDirectory(strPath)
                Process.Start(strPath)
            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub Open_Job_Folder(sender As Object, e As EventArgs) Handles menuJobFolder.Click
        Try
            Dim strPath As String = "Z:\DATA\JOBS\"
            'find job(s) related to that quote
            Dim AeroDBConn As New AeroDBConnection
            Dim SQL As String = "SELECT j_job FROM QUOTE WHERE q_quote = '" & QtNumValue & "'"
            AeroDBConn.RunQuery(SQL)
            If IsDBNull(AeroDBConn.DBds.Tables(0).Rows(0).Item("j_job")) Then
                MsgBox("No Job associated with this quote.")
            Else 'Open the job folder associated with this quote.
                'NOTE This does not account for multiple jobs referencing the same quote.
                '+++ ADD MULTIPLES TO RIGHT CLICK MENU +++
                'ALSO, dont need to query for job number as it's already populated with the job
                JobNumValue = AeroDBConn.DBds.Tables(0).Rows(0).Item("j_job")
                strPath += JobNumValue.ToString
                Process.Start(strPath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ucQuoteDetail_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, lbCustName.MouseDown, lbDesc.MouseDown, lbRefNum.MouseDown
        Debug.Print("Right Mouse Button Clicked on " & sender.ToString)
        Console.WriteLine("Loading PO's")
        Dim pStopwatch As New Stopwatch
        pStopwatch.Reset()
        pStopwatch.Start()
        Dim t0 As Double = pStopwatch.Elapsed.TotalMilliseconds

        If e.Button = MouseButtons.Right Then
            'Clear the PO's that were already loaded so you dont duplicate
            menuJobFolder.DropDownItems.Clear()

            'Query Database for all PO's
            '(this could be simplified to just look at the PO and vendor folder i suppose)
            Dim SQL As String = "SELECT a.*, PO_NUMBER, V_NAME FROM (((SELECT * FROM JOB WHERE J_JOB = " & JobNum & ") a LEFT JOIN PO b ON a.J_JOB = b.J_JOB) LEFT JOIN VENDOR c On b.V_VENDOR = c.V_VENDOR) ORDER BY PO_NUMBER ASC"
            AeroDBcon.RunQuery(SQL)
            Dim t1 As Double = pStopwatch.Elapsed.TotalMilliseconds
            Console.WriteLine("  DBF Query took {0}ms", Math.Round(t1 - t0, 2))

            'Load search results into memory/datatable
            Dim dtPOs As New DataTable
            dtPOs = AeroDBcon.DBds.Tables(0)

            Dim i As Integer = 0
            Dim j As Integer = dtPOs.Rows.Count - 1

            Do While i <= j
                If Not IsDBNull(dtPOs.Rows(i).Item("PO_NUMBER")) And Not IsDBNull(dtPOs.Rows(i).Item("V_NAME")) Then
                    'Add PO's to the detail for the right click menu function
                    ADD_PO(dtPOs.Rows(i).Item("PO_NUMBER"), dtPOs.Rows(i).Item("V_NAME"))
                End If

                i = i + 1
            Loop
            Dim t2 As Double = pStopwatch.Elapsed.TotalMilliseconds
            pStopwatch.Stop()
            Console.WriteLine("  Creating PO's took {0}ms", Math.Round(t2 - t1, 3))
        End If
    End Sub
End Class
