Imports System.Data.SqlClient

Public Class Login
    'Store RoleID and UserID for use in other forms
    Public Shared LoggedInRoleID As Integer
    Public Shared LoggedInUserID As Integer


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        'Connection string
        Dim connectionString As String = "Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True"

        'Query to check the user's credentials
        Dim query As String = "SELECT UserID, RoleID FROM tblUsers WHERE Username = @username AND Password = @password"

        Using conn As New SqlConnection(connectionString)
            'New SQL command
            Using cmd As New SqlCommand(query, conn)
                'Parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)

                conn.Open()

                'Use SqlDataReader to read both UserID and RoleID
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Store the UserID and RoleID for use in other forms
                        LoggedInUserID = Convert.ToInt32(reader("UserID"))
                        LoggedInRoleID = Convert.ToInt32(reader("RoleID"))

                        'Open the appropriate form based on the RoleID value
                        Select Case LoggedInRoleID
                            Case 0
                                'Company user
                                ToDo.Show()
                            Case 1
                                'Admin
                                MyTasks.Show()
                            Case 2
                                'Team Lead
                                MyTasks.Show()
                            Case 3, 4
                                'Developer, Data Analyst
                                MyTasks.Show()
                            Case Else
                                'Unknown role
                                MessageBox.Show("Invalid role.")
                        End Select

                        'Hide the login form
                        Me.Hide()
                    Else
                        'If the credentials are invalid
                        MessageBox.Show("Invalid username or password.")
                    End If
                End Using
            End Using
        End Using
    End Sub
End Class