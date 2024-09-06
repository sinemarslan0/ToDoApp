Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Threading

Public Class TaskDetails1
    Public Property TaskID As Integer
    Private InitialIsCompleted As Boolean
    Private InitialAssignedTo As Integer? 'Store the previous assignee ID
    Private Sub TaskDetails1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'According to RoleID show or hide the Assign part
        If Login.LoggedInRoleID = 1 OrElse Login.LoggedInRoleID = 2 Then
            GridLookUpEdit1.Visible = True
            lblAssign.Visible = True
        Else
            GridLookUpEdit1.Visible = False
            lblAssign.Visible = False
        End If

        LoadUsers()
        LoadTaskDetails(TaskID)
    End Sub

    Private Sub LoadTaskDetails(id As Integer)
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("SELECT TaskID, Title, Description, Photograph, IsCompleted, AssignedTo FROM TblTask WHERE TaskID = @TaskID", con)
        cmd.Parameters.AddWithValue("@TaskID", id)
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

                'chkEdit (Done button) initiliaze
                InitialIsCompleted = CBool(reader("IsCompleted"))
                chkDone.Checked = InitialIsCompleted

                'Assign bar initiliaze
                If reader("AssignedTo") IsNot DBNull.Value Then
                    Dim assignedUserID As Integer = Convert.ToInt32(reader("AssignedTo"))
                    GridLookUpEdit1.EditValue = assignedUserID
                    InitialAssignedTo = assignedUserID 'Store InitialAssignedTo value to check when cliked to Save/Close
                Else
                    GridLookUpEdit1.EditValue = Nothing
                    InitialAssignedTo = Nothing 'If AssignedTo is NULL, InitialAssignedTo is NULL
                    GridLookUpEdit1.Properties.NullText = "Select a person"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading task details: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LoadUsers()
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("SELECT UserID, Username FROM tblUsers", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim users As New DataTable()

        Try
            con.Open()
            adapter.Fill(users)
            'Bind users to the GridLookUpEdit
            GridLookUpEdit1.Properties.DataSource = users
            GridLookUpEdit1.Properties.DisplayMember = "Username" ' Display Username
            GridLookUpEdit1.Properties.ValueMember = "UserID"  ' Store UserID
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading users: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click
        Dim taskTitle As String = txtTitle.Text
        Dim taskDescription As String = txtDescription.Text
        Dim isCompleted As Boolean = chkDone.Checked
        Dim selectedUserID As Integer? = CType(GridLookUpEdit1.EditValue, Integer?) ' Get the selected UserID

        'SQL Connection
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("UPDATE TblTask SET IsCompleted = @IsCompleted, AssignedTo = @AssignedTo WHERE TaskID = @TaskID", con)
        cmd.Parameters.AddWithValue("@TaskID", TaskID)
        cmd.Parameters.AddWithValue("@IsCompleted", chkDone.Checked)
        cmd.Parameters.AddWithValue("@AssignedTo", If(selectedUserID.HasValue, CType(selectedUserID, Object), DBNull.Value)) ' Save selected UserID or DBNull

        Try
            con.Open()
            cmd.ExecuteNonQuery()

            'First check AssignedTo is NULL or not
            If Not InitialAssignedTo.HasValue AndAlso selectedUserID.HasValue Then
                'AssignedTo was NULL but now task assigned someone
                Dim recipientEmail As String = GetUserEmail(selectedUserID.Value)
                If Not String.IsNullOrEmpty(recipientEmail) Then
                    MessageBox.Show("Task assigned successfully!")
                    SendTaskAssignmentEmail(taskTitle, taskDescription, recipientEmail)
                Else
                    MessageBox.Show("Failed to retrieve recipient email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            'Second scenario: AssignedTo is not NULL, there is a value and this value has changed, send email to new person
            If InitialAssignedTo.HasValue AndAlso selectedUserID.HasValue AndAlso selectedUserID.Value <> InitialAssignedTo.Value Then
                Dim newRecipientEmail As String = GetUserEmail(selectedUserID.Value)
                If Not String.IsNullOrEmpty(newRecipientEmail) Then
                    MessageBox.Show("Task assigned to new person successfully!")
                    SendTaskAssignmentEmail(taskTitle, taskDescription, newRecipientEmail)
                Else
                    MessageBox.Show("Failed to retrieve recipient email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            'Lastly, no action or assigned same person again
            If InitialAssignedTo.HasValue AndAlso selectedUserID.HasValue AndAlso selectedUserID.Value = InitialAssignedTo.Value Then
                MessageBox.Show("No changes to assignee, closing form.")
            End If

            'In case of assigned person changed
            InitialAssignedTo = selectedUserID

            'If responsible person of the task checked the Done button
            If chkDone.Checked AndAlso Not InitialIsCompleted Then
                Dim teamLeadEmail As String = GetTeamLeadEmail()
                If Not String.IsNullOrEmpty(teamLeadEmail) Then
                    SendTaskCompletedEmail(TaskID, taskTitle, taskDescription, teamLeadEmail)
                Else
                    MessageBox.Show("Failed to retrieve team lead email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred while updating task: " & ex.Message)
        Finally
            con.Close()
        End Try

        Me.Close()
    End Sub

    Private Function GetUserEmail(userId As Integer) As String
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("SELECT Email FROM tblUsers WHERE UserID = @UserID", con)
        cmd.Parameters.AddWithValue("@UserID", userId)
        Try
            con.Open()
            Dim recipientEmail As Object = cmd.ExecuteScalar()
            If recipientEmail IsNot Nothing Then
                Return recipientEmail.ToString()
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to fetch user email: " & ex.Message)
            Return String.Empty
        Finally
            con.Close()
        End Try
    End Function

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

    Private Sub SendTaskAssignmentEmail(ByVal taskTitle As String, ByVal taskDescription As String, ByVal recipientEmail As String)
        Try
            Dim smtpClient As New SmtpClient("smtp.gmail.com") With {
                .Port = 587,
                .Credentials = New NetworkCredential("rsln.snm@gmail.com", "pmps yzuw utyn vysl"),
                .EnableSsl = True
            }

            Dim mailMessage As New MailMessage() With {
                .From = New MailAddress("rsln.snm@gmail.com"),
                .Subject = "New Task Assigned to You",
                .Body = $"You have been assigned a new task:{Environment.NewLine}" &
                    $"Title: {taskTitle}{Environment.NewLine}" &
                    $"Description: {taskDescription}{Environment.NewLine}{Environment.NewLine}" &
                    $"Please log in to the application to view and manage this task.{Environment.NewLine}",
                .IsBodyHtml = False
            }

            mailMessage.To.Add(recipientEmail)

            smtpClient.Send(mailMessage)
            MessageBox.Show("Assigment notification email sent successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Failed to send email: " & ex.Message)
        End Try
    End Sub
    Private Sub SendTaskCompletedEmail(ByVal taskID As Integer, ByVal taskTitle As String, ByVal taskDescription As String, ByVal teamLeadEmail As String)
        Try
            Dim smtpClient As New SmtpClient("smtp.gmail.com") With {
                .Port = 587,
                .Credentials = New NetworkCredential("rsln.snm@gmail.com", "pmps yzuw utyn vysl"),
                .EnableSsl = True
        }

            Dim mailMessage As New MailMessage() With {
            .From = New MailAddress("rsln.snm@gmail.com"),
            .Subject = $"Task #{taskID} Completed",
            .Body = $"The following task has been marked as completed:{Environment.NewLine}" &
                    $"Task ID: {taskID}{Environment.NewLine}" &
                    $"Title: {taskTitle}{Environment.NewLine}" &
                    $"Description: {taskDescription}{Environment.NewLine}{Environment.NewLine}" &
                    $"Please review the task completion and update any relevant records.{Environment.NewLine}",
            .IsBodyHtml = False
        }

            mailMessage.To.Add(teamLeadEmail)

            smtpClient.Send(mailMessage)
            MessageBox.Show("Completion notification email sent successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Failed to send email: " & ex.Message)
        End Try
    End Sub

End Class