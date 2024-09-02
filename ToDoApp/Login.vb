Imports System.Data.SqlClient

Public Class Login
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        ' Define the connection string
        Dim connectionString As String = "Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True"

        ' Define the query to check the user's credentials
        Dim query As String = "SELECT IsAdmin FROM tblUsers WHERE Username = @username AND Password = @password"

        ' Create a new SQL connection
        Using conn As New SqlConnection(connectionString)
            ' Create a new SQL command
            Using cmd As New SqlCommand(query, conn)
                ' Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)

                ' Open the connection
                conn.Open()

                ' Execute the command and retrieve the IsAdmin value
                Dim result As Object = cmd.ExecuteScalar()

                ' Check if the result is not null (meaning the username and password are correct)
                If result IsNot Nothing Then
                    Dim isAdmin As Boolean = Convert.ToBoolean(result)

                    ' Open the appropriate form based on the IsAdmin value
                    If isAdmin Then
                        ' User is an admin, open mytasks.vb
                        MyTasks.Show()
                    Else
                        ' User is not an admin, open todo.vb
                        Dim userForm As New ToDo
                        userForm.Show()
                    End If

                    ' Hide the login form
                    Me.Hide()
                Else
                    ' If the result is null, display an error message
                    MessageBox.Show("Invalid username or password.")
                End If
            End Using
        End Using
    End Sub
End Class