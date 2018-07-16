Imports System.Data.OleDb
Public Class Form1
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim test As Boolean = True
        If TextBox1.Text.Trim = "" Or TextBox2.Text.Trim = "" Then
            MsgBox("Please enter valid username or password")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.Focus()
            test = False
        End If
        If test Then
            connectdb()
            Dim gend As String
            If RadioButton1.Checked Then
                gend = "m"
            ElseIf RadioButton2.Checked Then
                gend = "f"
            End If
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [Dtbs] WHERE [Username] = '" & TextBox1.Text & "'", myConnection)
            Dim dr As OleDbDataReader = cmd.ExecuteReader
            Dim existuser As Boolean = False
            While dr.Read
                existuser = True
            End While
            If existuser = True Then
                MsgBox("User already exist")
                myConnection.Close()
                Me.Close()
            End If
            cmd = New OleDbCommand("INSERT INTO [Dtbs] VALUES ('" & TextBox4.Text & "' , '" & TextBox5.Text & "' , '" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "' , '" & gend & "', '" & DateTimePicker1.Text & "', '" & TextBox8.Text & "', '" & TextBox7.Text & "'  )", myConnection)
            dr = cmd.ExecuteReader
            myConnection.Close()
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        RadioButton1.Checked() = False
        RadioButton2.Checked() = False

    End Sub
    Private Sub connectdb()
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        dataFile = "../../Database1.accdb"
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
    End Sub
End Class
