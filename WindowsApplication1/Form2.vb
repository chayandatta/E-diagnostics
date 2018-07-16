Imports System.Data.OleDb
Public Class Form2
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        LOGIN.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connectdb()
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [Dtbs] WHERE [Username] = '" & LOGIN.TextBox1.Text & "'", myConnection)
        Dim dr As OleDbDataReader = cmd.ExecuteReader
        Dim name, mname, lname, uname, gend, dob, add, pass, email As String
        While dr.Read
            name = dr("First Name").ToString
            mname = dr("Middle Name").ToString
            lname = dr("Last Name").ToString
            uname = dr("Username").ToString
            gend = dr("Gender").ToString
            dob = dr("Date of Birth").ToString
            add = dr("Address").ToString
            pass = dr("Password").ToString
            email = dr("Email Address").ToString
        End While
        TextBox1.Text = name
        TextBox2.Text = mname
        TextBox3.Text = lname
        TextBox4.Text = uname
        TextBox8.Text = add
        TextBox5.Text = pass
        TextBox7.Text = email
        DateTimePicker1.Text = dob
        If gend = "m" Then
            RadioButton1.Checked = True
        ElseIf gend = "n" Then
            RadioButton2.Checked = True
        End If
        myConnection.Close()
    End Sub
    Private Sub connectdb()
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        dataFile = "../../Database1.accdb"
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
    End Sub

End Class