Imports System.Data.OleDb
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" Then
            MsgBox("Please enter details", MsgBoxStyle.Critical)
        ElseIf TextBox2.Text <> TextBox3.Text Then
            MsgBox("Password is not the same", MsgBoxStyle.Critical)
        ElseIf TextBox2.Text.Length < 6 Then
            MsgBox("Password must be at least 6 characters")
        Else
            Call CheckIfUserExist()
        End If
    End Sub

    Private Sub CheckIfUserExist()
        sql = "SELECT [username] from tblUsers where [username] = '" & TextBox1.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.Read = True Then
            MsgBox("User already exist on database", MsgBoxStyle.Exclamation, MsgBox("Change your username!!"))
        Else
            Call saveData()
        End If
    End Sub


    Private Sub saveData()
        sql = "INSERT INTO tblUsers ([username],[password]) VALUES ([@username],[@password])"
        cmd = New OleDbCommand(sql, cn)
        With cmd
            .Parameters.AddWithValue("@username", TextBox1.Text)
            .Parameters.AddWithValue("@password", TextBox2.Text)
        End With
        cmd.ExecuteNonQuery()
        MsgBox("User saved successfully!", MsgBoxStyle.Information)
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connection()
        TextBox1.Select()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MsgBox("Do you want to close the application?", vbQuestion + vbYesNo) = vbYes Then
            MsgBox("Thanks for using the Application", MsgBoxStyle.Information)
            Me.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTime.Text = Now
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form2.Show()
    End Sub
End Class
