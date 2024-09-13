Imports System.Data.SqlClient
Imports System.Threading

Public Class Chat
    Public Property LoggedInUserID As Integer
    Public Property TaskID As Integer

    Private Sub Chat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMessages()
    End Sub

    Private Sub LoadMessages()
        Using connection As New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
            connection.Open()

            Dim query As String = "SELECT m.messageID, m.MESSAGE, m.Time, u.Username " &
                                  "FROM tblMessages m " &
                                  "INNER JOIN tblUsers u ON m.UserID = u.UserID " &
                                  "WHERE m.TaskID = @TaskID " &
                                  "ORDER BY m.Time ASC"

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@TaskID", TaskID)

                Using reader As SqlDataReader = command.ExecuteReader()
                    FlowLayoutPanel1.Controls.Clear()

                    While reader.Read()
                        Dim messagePanel As New Panel()

                        messagePanel.Width = FlowLayoutPanel1.Width - 20
                        messagePanel.Margin = New Padding(2)
                        messagePanel.BorderStyle = BorderStyle.FixedSingle

                        'Username label
                        Dim usernameLabel As New Label()
                        usernameLabel.Text = reader("Username").ToString()
                        usernameLabel.Font = New Font("Arial", 7)
                        usernameLabel.AutoSize = True
                        usernameLabel.Location = New Point(10, 10)

                        'Message label
                        Dim messageLabel As New Label()
                        messageLabel.Text = reader("MESSAGE").ToString()
                        messageLabel.Font = New Font("Arial", 9, FontStyle.Bold)
                        messageLabel.AutoSize = True
                        messageLabel.Location = New Point(10, 30)

                        'Time label
                        Dim dateLabel As New Label()
                        dateLabel.Text = Convert.ToDateTime(reader("Time")).ToString("g")
                        dateLabel.Font = New Font("Arial", 7, FontStyle.Italic)
                        dateLabel.AutoSize = True
                        dateLabel.Location = New Point(10, 50)

                        messagePanel.Controls.Add(usernameLabel)
                        messagePanel.Controls.Add(messageLabel)
                        messagePanel.Controls.Add(dateLabel)

                        messagePanel.Height = dateLabel.Bottom + 10 'empty space after time label
                        FlowLayoutPanel1.Controls.Add(messagePanel)
                    End While
                End Using
            End Using
        End Using

        If FlowLayoutPanel1.Controls.Count > 0 Then
            FlowLayoutPanel1.ScrollControlIntoView(FlowLayoutPanel1.Controls(FlowLayoutPanel1.Controls.Count - 1))
        End If
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim messageText As String = txtMessage.Text.Trim()

        If String.IsNullOrEmpty(messageText) Then
            MessageBox.Show("Mesaj boş olamaz!")
            Return
        End If

        Using connection As New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
            connection.Open()

            Dim query As String = "INSERT INTO tblMessages (TaskID, UserID, Message, Time) " &
                              "VALUES (@TaskID, @UserID, @Message, @Time)"

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@TaskID", TaskID)
                command.Parameters.AddWithValue("@UserID", LoggedInUserID)
                command.Parameters.AddWithValue("@Message", messageText)
                command.Parameters.AddWithValue("@Time", DateTime.Now)

                Try
                    command.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox.Show($"Veritabanına eklenirken bir hata oluştu: {ex.Message}")
                End Try
            End Using
        End Using

        'Refresh messages
        LoadMessages()
        txtMessage.Text = "" 'Clean textEdit
    End Sub
End Class