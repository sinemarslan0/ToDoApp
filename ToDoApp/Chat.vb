Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Threading


Public Class Chat
    Public Property LoggedInUserID As Integer
    Public Shared LoggedInRoleID As Integer
    Public Property TaskID As Integer

    Private Sub Chat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMessages()
    End Sub

    Private Sub LoadMessages()
        Using connection As New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
            connection.Open()

            Dim query As String = "SELECT m.messageID, m.MESSAGE, m.Time, u.Username, u.RoleID " &
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

                        'For UI (round edges)
                        AddHandler messagePanel.Paint, AddressOf DrawRoundedCorners

                        messagePanel.Width = FlowLayoutPanel1.Width - 10
                        messagePanel.Margin = New Padding(2)
                        'messagePanel.BorderStyle = BorderStyle.FixedSingle

                        'Role ID based message panel coloring
                        Dim roleID As Integer = Convert.ToInt32(reader("RoleID"))
                        messagePanel.BackColor = GetColorForRole(roleID)

                        'Username label
                        Dim usernameLabel As New Label()
                        usernameLabel.Text = reader("Username").ToString()
                        usernameLabel.Font = New Font("Arial", 7)
                        usernameLabel.AutoSize = True
                        usernameLabel.Location = New Point(10, 10)

                        'Message Textbox
                        Dim messageTextBox As New TextBox()
                        messageTextBox.Multiline = True
                        messageTextBox.ReadOnly = True
                        messageTextBox.Text = reader("MESSAGE").ToString()
                        messageTextBox.Font = New Font("Arial", 9, FontStyle.Bold)
                        messageTextBox.Location = New Point(10, 30)
                        messageTextBox.Width = messagePanel.Width - 20
                        messageTextBox.Height = 50
                        messageTextBox.BorderStyle = BorderStyle.None
                        messageTextBox.BackColor = messagePanel.BackColor

                        'Time label
                        Dim dateLabel As New Label()
                        dateLabel.Text = Convert.ToDateTime(reader("Time")).ToString("g")
                        dateLabel.Font = New Font("Arial", 7, FontStyle.Italic)
                        dateLabel.AutoSize = True
                        dateLabel.Location = New Point(10, 50)

                        messagePanel.Controls.Add(usernameLabel)
                        messagePanel.Controls.Add(messageTextBox)
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

    'For UI (RoleID based message panel coloring)
    Private Function GetColorForRole(roleID As Integer) As Color
        Select Case roleID
            Case 0 ' Company User
                Return ColorTranslator.FromHtml("#FFB6C1") 'Light Pink
            Case 1, 2 ' Admin or Team Lead
                Return ColorTranslator.FromHtml("#FFFACD") 'Light Yellow
            Case 3 ' Developer
                Return ColorTranslator.FromHtml("#ADD8E6") 'Light Blue
            Case 4 ' Analyst
                Return ColorTranslator.FromHtml("#D8BFD8") 'Light Lilac
            Case Else
                Return Color.LightGray
        End Select
    End Function

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

    Private Sub DrawRoundedCorners(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = CType(sender, Panel)
        Dim cornerRadius As Integer = 20
        Dim path As New GraphicsPath()

        'Round edges
        path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90) ' Sol üst köşe
        path.AddArc(panel.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90) ' Sağ üst köşe
        path.AddArc(panel.Width - cornerRadius, panel.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90) ' Sağ alt köşe
        path.AddArc(0, panel.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90) ' Sol alt köşe
        path.CloseFigure()

        panel.Region = New Region(path)
    End Sub
End Class