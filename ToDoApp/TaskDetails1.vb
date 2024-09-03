Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Threading

Public Class TaskDetails1
    Public Property TaskID As Integer
    Private InitialIsCompleted As Boolean
    Private Sub TaskDetails1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTaskDetails(TaskID)
    End Sub

    Private Sub LoadTaskDetails(id As Integer)
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("SELECT ID, Title, Description, Photograph, IsCompleted FROM TblTasks WHERE ID = @ID", con)
        cmd.Parameters.AddWithValue("@ID", id)
        Dim reader As SqlDataReader
        Try
            con.Open()
            reader = cmd.ExecuteReader()
            If reader.Read() Then
                txtTitle.Text = reader("Title").ToString()
                txtDescription.Text = reader("Description").ToString()

                If reader("Photograph") IsNot DBNull.Value Then
                    Dim photoData As Byte() = CType(reader("Photograph"), Byte())
                    Dim ms As New MemoryStream(photoData)
                    picImage.Image = Image.FromStream(ms)
                    picImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
                End If

                'Check Edit (Done button) initilaize
                InitialIsCompleted = CBool(reader("IsCompleted"))
                chkDone.Checked = InitialIsCompleted
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading task details: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click
        Dim taskTitle As String = txtTitle.Text
        Dim taskDescription As String = txtDescription.Text
        Dim isCompleted As Boolean = chkDone.Checked

        'If IsCompleted state has changed
        If chkDone.Checked <> InitialIsCompleted Then
            Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
            Dim cmd As SqlCommand = New SqlCommand("UPDATE TblTasks SET IsCompleted = @IsCompleted WHERE ID = @ID", con)
            cmd.Parameters.AddWithValue("@ID", TaskID)
            cmd.Parameters.AddWithValue("@IsCompleted", chkDone.Checked)

            Try
                con.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("Task updated successfully!")
                'Sending email after the task is completed
                SendEmailNotification(taskTitle, taskDescription)
            Catch ex As Exception
                MessageBox.Show("An error occurred while updating task: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If
        Me.Close()
    End Sub

    Private Sub SendEmailNotification(ByVal taskTitle As String, ByVal taskDescription As String)
        Try
            Dim smtpClient As New SmtpClient("smtp.gmail.com") With {
                .Port = 587,
                .Credentials = New NetworkCredential("rsln.snm@gmail.com", "pmps yzuw utyn vysl"),
                .EnableSsl = True
            }

            Dim mailMessage As New MailMessage() With {
                .From = New MailAddress("rsln.snm@gmail.com"),
                .Subject = "Task Completed",
                .Body = $"A task has been marked as completed: {taskTitle}{Environment.NewLine}Description: {taskDescription}",
                .IsBodyHtml = False
            }

            mailMessage.To.Add("sinemarslan089@gmail.com")

            smtpClient.Send(mailMessage)
            MessageBox.Show("Notification email sent successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Failed to send email: " & ex.Message)
        End Try
    End Sub
End Class