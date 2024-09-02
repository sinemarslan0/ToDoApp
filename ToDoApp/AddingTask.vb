Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail

Public Class AddingTask
    Private Sub AddingTask_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("INSERT INTO TblTasks (Title, Description, Photograph, IsCompleted) VALUES (@Title, @Description, @Photograph, @IsCompleted)", con)

        cmd.Parameters.AddWithValue("@Title", txtTitle.Text)
        cmd.Parameters.AddWithValue("@Description", txtDescription.Text)
        'cmd.Parameters.AddWithValue("@IsCompleted", ToggleSwitch1.IsOn)
        If picImage.Image IsNot Nothing Then
            Dim photoBytes As Byte() = ImageToByteArray(picImage.Image)
            cmd.Parameters.AddWithValue("@Photograph", photoBytes)
        Else
            cmd.Parameters.AddWithValue("@Photograph", DBNull.Value)
        End If

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("The task has been successfully registered in the system.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'LoadTasksIntoCheckedListBox()

            ' Sending email after the task is successfully added
            SendEmailNotification(txtTitle.Text, txtDescription.Text)

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            con.Close()
        End Try
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
                .Subject = "New Task Added",
                .Body = $"A new task has been added: {taskTitle}{Environment.NewLine}Description: {taskDescription}",
                .IsBodyHtml = False
            }

            mailMessage.To.Add("sinemarslan089@gmail.com")

            smtpClient.Send(mailMessage)
            MessageBox.Show("Notification email sent successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Failed to send email: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim xtraOpenFileDialog As New DevExpress.XtraEditors.XtraOpenFileDialog()

        xtraOpenFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png"

        ' Show the XtraOpenFileDialog and check if the user clicked OK
        If xtraOpenFileDialog.ShowDialog() = DialogResult.OK Then
            ' Load the selected image into picture box
            picImage.Image = Image.FromFile(xtraOpenFileDialog.FileName)
            picImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        End If
    End Sub

    Public Function ImageToByteArray(ByVal imageIn As Image) As Byte()
        Using ms As New MemoryStream()
            imageIn.Save(ms, imageIn.RawFormat)
            Return ms.ToArray()
        End Using
    End Function
End Class