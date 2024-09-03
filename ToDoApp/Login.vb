Imports System.Data.SqlClient

Public Class Login
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        'Connection string
        Dim connectionString As String = "Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True"

        'Query to check the user's credentials
        Dim query As String = "SELECT IsAdmin FROM tblUsers WHERE Username = @username AND Password = @password"

        'New SQL connection
        Using conn As New SqlConnection(connectionString)
            'New SQL command
            Using cmd As New SqlCommand(query, conn)
                'Parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)

                conn.Open()

                'Retrieve the IsAdmin value
                Dim result As Object = cmd.ExecuteScalar()

                'Check if the result is not null
                If result IsNot Nothing Then
                    Dim isAdmin As Boolean = Convert.ToBoolean(result)

                    'Open the appropriate form based on the IsAdmin value
                    If isAdmin Then
                        'User is an admin
                        MyTasks.Show()
                    Else
                        'User is not an admin
                        ToDo.Show()
                    End If

                    'Hide the login form
                    Me.Hide()
                Else
                    'If the result is null
                    MessageBox.Show("Invalid username or password.")
                End If
            End Using
        End Using
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class