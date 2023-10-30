Imports System.Data.OleDb

Module DatabaseConnection

    Public cn As New OleDbConnection
    Public cmd As OleDbCommand
    Public sql As String
    Public dr As OleDbDataReader

    Public Sub Connection()
        cn.Close()
        cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Dela Cruz\Desktop\LOGINWITHSIGNUP\LOGINWITHSIGNUP\MyDb.mdb"
        cn.Open()
        ''MsgBox("Connection Success")
    End Sub

End Module
