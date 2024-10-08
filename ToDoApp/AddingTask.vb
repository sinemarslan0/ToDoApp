﻿Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Threading

Public Class AddingTask
    Public Event TaskAdded()

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("INSERT INTO TblTask (Title, Description, Photograph, IsCompleted, CreatedTime) VALUES (@Title, @Description, @Photograph, @IsCompleted, @CreatedTime)", con)

        cmd.Parameters.AddWithValue("@Title", txtTitle.Text)
        cmd.Parameters.AddWithValue("@Description", txtDescription.Text)
        'Set IsCompleted to 0 by default (new task cannot be in the completed state)
        cmd.Parameters.AddWithValue("@IsCompleted", 0)

        If picImage.Image IsNot Nothing Then
            Dim photoBytes As Byte() = ImageToByteArray(picImage.Image)
            cmd.Parameters.AddWithValue("@Photograph", photoBytes)
        Else
            'Define the type as varbinary(max) for NULL
            cmd.Parameters.Add("@Photograph", SqlDbType.VarBinary, -1).Value = DBNull.Value
        End If

        'Set CreatedTime to the current date And time
        cmd.Parameters.AddWithValue("@CreatedTime", DateTime.Now)

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("The task has been successfully registered in the system.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Notify other forms that a task has been added
            RaiseEvent TaskAdded()

            Dim teamLeadEmail As String = GetTeamLeadEmail()
            'Sending email after the task is successfully added
            SendEmailNotification(txtTitle.Text, txtDescription.Text, teamLeadEmail)

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            con.Close()
        End Try

        Me.Close()
    End Sub

    Private Function GetTeamLeadEmail() As String
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("SELECT Email FROM tblUsers WHERE RoleID = 2", con) 'RoleID = 2 is for Team Leads

        Try
            con.Open()
            Dim teamLeadEmail As Object = cmd.ExecuteScalar()
            If teamLeadEmail IsNot Nothing Then
                Return teamLeadEmail.ToString()
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to fetch team lead email: " & ex.Message)
            Return String.Empty
        Finally
            con.Close()
        End Try
    End Function
    Private Sub SendEmailNotification(ByVal taskTitle As String, ByVal taskDescription As String, ByVal teamLeadEmail As String)
        Try
            Dim smtpClient As New SmtpClient("smtp.gmail.com") With {
                .Port = 587,
                .Credentials = New NetworkCredential("rsln.snm@gmail.com", "pmps yzuw utyn vysl"),
                .EnableSsl = True
            }

            Dim mailMessage As New MailMessage() With {
                .From = New MailAddress("rsln.snm@gmail.com"),
                .Subject = "New Task Added by Company",
                .Body = $"A new task has been added by Company: {taskTitle}{Environment.NewLine}Description: {taskDescription}",
                .IsBodyHtml = False
            }

            mailMessage.To.Add(teamLeadEmail)

            smtpClient.Send(mailMessage)
            MessageBox.Show("Notification email sent successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Failed to send email: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim xtraOpenFileDialog As New DevExpress.XtraEditors.XtraOpenFileDialog()

        xtraOpenFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png"

        'Show the XtraOpenFileDialog and check if the user clicked OK
        If xtraOpenFileDialog.ShowDialog() = DialogResult.OK Then
            'Load the selected image into picture box
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