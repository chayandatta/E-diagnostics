Imports System.Data.OleDb

Public Class LOGIN
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim Attempt As Integer = 1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        connectdb()
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [Dtbs] WHERE [Username] = '" & TextBox1.Text & "' AND [Password] = '" & TextBox2.Text & "'", myConnection)
        Dim dr As OleDbDataReader = cmd.ExecuteReader
        Dim userFound As Boolean = False
        While dr.Read
            userFound = True
        End While

        If userFound = True Then
            Form2.Show()
        ElseIf Attempt = 3 Then
            MsgBox("Good Bye")
            myConnection.Close()
            Close()
        Else : MsgBox("Wrong Credentials " & Attempt & " of 3 ")
            Attempt = Attempt + 1
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.Focus()
            myConnection.Close()
        End If
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus()
        End If
    End Sub
    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(Me, EventArgs.Empty)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.Show()
        '  User_Info_Questionnaire.Form1.Show()
    End Sub
    Private Sub connectdb()
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        dataFile = "../../Database1.accdb"
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
