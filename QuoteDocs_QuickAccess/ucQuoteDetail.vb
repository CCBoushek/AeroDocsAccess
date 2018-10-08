Public Class ucQuoteDetail
    Private QtNumValue As String
    Private DescValue As String
    Private CustNumValue As String
    Private CustNameValue As String
    Private bVisible As Boolean
    Public qType As qtType

    Private JobNumValue As Integer
    Private qStat As qtStat
    Private _poCount As Integer
    Public Property poCount As Integer
        Get
            Return _poCount
        End Get
        Set
            _poCount = Value
            For i As Integer = 1 To _poCount
                Dim menu1 As New ToolStripMenuItem() With {.Text = "-" & i.ToString("D2"), .Name = "poItem" & i.ToString("D2")}
                menuJobFolder.DropDownItems.Add(menu1)
                AddHandler menu1.Click, AddressOf poFolder_click
            Next
        End Set
    End Property
    Private Sub poFolder_click(sender As ToolStripMenuItem, e As EventArgs)
        Dim poNum As Integer = JobNum & sender.Name.Substring(6, 2)
        Debug.Print(poNum.ToString)
        Dim sPath As String = "Z:\CLOUD STORAGE\JOB FILES\JOBS\" & JobNum.ToString & "\2 - PURCHASE ORDERS\" & poNum.ToString
        Debug.Print(sPath)
        Process.Start(sPath)
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
            lbQtNum.Text = QtNumValue
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
            DescValue = value
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

    Private Sub Open_Quote_Folder(sender As Object, e As EventArgs) Handles Me.DoubleClick, lbCustName.DoubleClick, lbDesc.DoubleClick, lbQtNum.DoubleClick, OpenQtFldr_ContextMenuItem.Click
        Dim strPath As String = "Z:\CLOUD STORAGE\QUOTES\"
        Select Case qType
            Case qtType.Part
                strPath += "PARTS\"
            Case qtType.System
                strPath += "SYSTEMS\"
        End Select
        strPath += "QUOTE DOCs\" & QtNum & "\"
        Process.Start(strPath)
    End Sub

    Private Sub OpenORCreate_Quote_Sent_Folder(sender As Object, e As EventArgs) Handles Me.Click, lbQtNum.Click, lbDesc.Click, lbCustName.Click
        Dim strPath As String = "Z:\CLOUD STORAGE\QUOTES\"
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
        Dim strPath As String = "Z:\CLOUD STORAGE\JOB FILES\JOBS\"
        'find job(s) related to that quote
        Dim AeroDBConn As New AeroDBConnection
        Dim SQL As String = "SELECT j_job FROM QUOTE WHERE q_quote = '" & QtNumValue & "'"
        AeroDBConn.RunQuery(SQL)
        If IsDBNull(AeroDBConn.DBds.Tables(0).Rows(0).Item("j_job")) Then
            MsgBox("No Job associated with this quote.")
        Else 'Open the job folder associated with this quote.
            'NOTE This does not account for multiple jobs referencing the same quote.
            JobNumValue = AeroDBConn.DBds.Tables(0).Rows(0).Item("j_job")
            strPath += JobNumValue.ToString
            Process.Start(strPath)
        End If
    End Sub

End Class
