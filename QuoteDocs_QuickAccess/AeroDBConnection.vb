Imports System.Data
Imports System.Data.OleDb

Public Class AeroDBConnection
    'DATABASE CONNECTION
    Private DBcon As New OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=Z:\DATA\DATABASE\;extended properties=dbase Iv;")

    Private DBcmd As OleDbCommand

    'DB Data
    Public DBda As OleDbDataAdapter
    Public DBds As DataSet

    'QUERY PARAMETERS
    Public Params As New List(Of OleDbParameter)

    'QUERY STATS
    Public RecordCount As Integer
    Public Exception As String

    Dim Cnt As Integer = 0

    Public Sub RunQuery(Query As String)
        Cnt += 1
        Try
            DBcon.Open()

            'CREATE SQL COMMAND
            DBcmd = New OleDbCommand(Query, DBcon)

            'LOAD PARAMETERS INTO OLEDB COMMAND
            Params.ForEach(Sub(x) DBcmd.Parameters.Add(x))

            'CLEAR PARAMETERS LIST
            Params.Clear()

            'EXECUTE COMMAND AND FILL DATASET
            DBds = New DataSet
            DBds.Clear()

            DBda = New OleDbDataAdapter(DBcmd)

            RecordCount = DBda.Fill(DBds, "DB_Data")


            DBcon.Close()
        Catch ex As Exception
            'CAPTURE ERRORS
            MsgBox(ex.Message)
            Dim i As Integer = 1
        End Try

        'MAKE SURE CONNECTION IS CLOSED
        If DBcon.State = ConnectionState.Open Then DBcon.Close()

    End Sub

    Public Sub AddParam(Name As String, Value As Object)
        Dim NewParam As New OleDbParameter(Name, Value)
        Params.Add(NewParam)
    End Sub
End Class
