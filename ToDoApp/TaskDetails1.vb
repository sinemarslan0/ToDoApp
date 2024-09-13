Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Threading
Imports DevExpress.XtraGrid.Views.Grid

Public Class TaskDetails1
    Public Property TaskID As Integer
    Private InitialIsCompleted As Boolean
    Private InitialAssignedTo As Integer? 'Store the previous assignee ID
    Private InitialAssignedTeam As Integer?
    Private Sub TaskDetails1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'According to RoleID show or hide the Assign part
        If Login.LoggedInRoleID = 1 OrElse Login.LoggedInRoleID = 2 Then
            GridLookUpEdit1.Visible = True
            lblAssign.Visible = True
            chkDone.Visible = False 'Admin and Team lead assign uncompleted task so no need to see done button
        Else
            GridLookUpEdit1.Visible = False
            lblAssign.Visible = False
            chkDone.Visible = True
        End If

        LoadUsersAndTeams()
        LoadTaskDetails(TaskID)
    End Sub

    Private Sub LoadTaskDetails(id As Integer)
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("SELECT TaskID, Title, Description, Photograph, IsCompleted, AssignedToUser, AssignedToTeam FROM TblTask WHERE TaskID = @TaskID", con)
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

                'chkEdit (Done button) initialization
                InitialIsCompleted = CBool(reader("IsCompleted"))
                chkDone.Checked = InitialIsCompleted

                'Assign bar initialization
                GridLookUpEdit1.EditValue = Nothing
                Dim assignedUserID As Object = reader("AssignedToUser")
                Dim assignedTeamID As Object = reader("AssignedToTeam")

                If Not IsDBNull(assignedUserID) AndAlso assignedUserID IsNot Nothing Then
                    GridLookUpEdit1.EditValue = "U" & assignedUserID.ToString()
                ElseIf Not IsDBNull(assignedTeamID) AndAlso assignedTeamID IsNot Nothing Then
                    GridLookUpEdit1.EditValue = "T" & assignedTeamID.ToString()
                Else
                    GridLookUpEdit1.Properties.NullText = "Select a person or team"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading task details: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LoadUsersAndTeams()
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim usersCmd As SqlCommand = New SqlCommand("SELECT UserID, Username FROM tblUsers WHERE UserID > @MinUserID", con)
        usersCmd.Parameters.AddWithValue("@MinUserID", 1)
        Dim usersAdapter As New SqlDataAdapter(usersCmd)
        Dim usersTable As New DataTable()

        Dim teamsCmd As SqlCommand = New SqlCommand("SELECT TeamID, TeamName FROM tblTeams", con)
        Dim teamsAdapter As New SqlDataAdapter(teamsCmd)
        Dim teamsTable As New DataTable()

        Dim combinedTable As New DataTable()
        combinedTable.Columns.Add("ID", GetType(String))
        combinedTable.Columns.Add("Name", GetType(String))
        combinedTable.Columns.Add("Type", GetType(String))

        Try
            con.Open()

            'Fill users data
            usersAdapter.Fill(usersTable)
            For Each row As DataRow In usersTable.Rows
                combinedTable.Rows.Add("U" & row("UserID").ToString(), row("Username"), "User")
            Next

            'Fill teams data
            teamsAdapter.Fill(teamsTable)
            For Each row As DataRow In teamsTable.Rows
                combinedTable.Rows.Add("T" & row("TeamID").ToString(), row("TeamName"), "Team")
            Next

            'Bind to GridLookUpEdit
            GridLookUpEdit1.Properties.DataSource = combinedTable
            GridLookUpEdit1.Properties.DisplayMember = "Name"
            GridLookUpEdit1.Properties.ValueMember = "ID"
            GridLookUpEdit1.Properties.PopulateViewColumns()

            Dim view As GridView = GridLookUpEdit1.Properties.View
            view.Columns("ID").Visible = False
            view.Columns("Name").Caption = "Name"
            view.Columns("Type").Visible = False
            view.BestFitColumns()

        Catch ex As Exception
            MessageBox.Show("An error occurred while loading users and teams: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub GridLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles GridLookUpEdit1.EditValueChanged
        Dim selectedValue As Object = GridLookUpEdit1.EditValue
        Dim selectedRow As DataRow = CType(GridLookUpEdit1.Properties.View.GetFocusedDataRow(), DataRow)
        If selectedRow IsNot Nothing Then
            Dim selectedType As String = If(selectedRow("Type") IsNot DBNull.Value, selectedRow("Type").ToString(), String.Empty)
            If selectedType = "User" Then
                Dim userId As Integer
                If Integer.TryParse(selectedRow("ID").ToString(), userId) Then
                    MessageBox.Show("Selected User ID: " & userId)
                End If
            ElseIf selectedType = "Team" Then
                Dim teamId As Integer
                If Integer.TryParse(selectedRow("ID").ToString(), teamId) Then
                    MessageBox.Show("Selected Team ID: " & teamId)
                End If
            End If
        End If
    End Sub

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click
        Dim taskTitle As String = txtTitle.Text
        Dim taskDescription As String = txtDescription.Text
        Dim isCompleted As Boolean = chkDone.Checked

        'Retrieve the selected value from GridLookUpEdit
        Dim selectedValue As String = TryCast(GridLookUpEdit1.EditValue, String)
        Dim assignedToUser As Object = DBNull.Value
        Dim assignedToTeam As Object = DBNull.Value
        Dim currentAssignedToUser As Object = DBNull.Value
        Dim currentAssignedToTeam As Object = DBNull.Value

        If Not String.IsNullOrEmpty(selectedValue) Then
            Dim prefix As String = selectedValue.Substring(0, 1)
            Dim id As Integer = Convert.ToInt32(selectedValue.Substring(1))

            If prefix = "U" Then
                assignedToUser = id
            ElseIf prefix = "T" Then
                assignedToTeam = id
            End If
        End If

        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")

        ' Fetch current assignment from the database
        Dim fetchCmd As SqlCommand = New SqlCommand("SELECT AssignedToUser, AssignedToTeam FROM TblTask WHERE TaskID = @TaskID", con)
        fetchCmd.Parameters.AddWithValue("@TaskID", TaskID)

        Try
            con.Open()
            Using reader As SqlDataReader = fetchCmd.ExecuteReader()
                If reader.Read() Then
                    currentAssignedToUser = reader("AssignedToUser")
                    currentAssignedToTeam = reader("AssignedToTeam")
                End If
            End Using

            'Determine if the assignment has changed
            Dim assignmentChanged As Boolean = (Not Object.Equals(currentAssignedToUser, assignedToUser)) OrElse (Not Object.Equals(currentAssignedToTeam, assignedToTeam))

            'Update task details
            Dim updateCmd As SqlCommand
            If isCompleted Then
                updateCmd = New SqlCommand("UPDATE TblTask SET IsCompleted = @IsCompleted, AssignedToUser = @AssignedToUser, AssignedToTeam = @AssignedToTeam, CompletedTime = @CompletedTime WHERE TaskID = @TaskID", con)
                updateCmd.Parameters.AddWithValue("@CompletedTime", DateTime.Now)
            Else
                updateCmd = New SqlCommand("UPDATE TblTask SET IsCompleted = @IsCompleted, AssignedToUser = @AssignedToUser, AssignedToTeam = @AssignedToTeam, WHERE TaskID = @TaskID", con)
            End If

            updateCmd.Parameters.AddWithValue("@IsCompleted", isCompleted)
            updateCmd.Parameters.AddWithValue("@AssignedToUser", assignedToUser)
            updateCmd.Parameters.AddWithValue("@AssignedToTeam", assignedToTeam)
            updateCmd.Parameters.AddWithValue("@TaskID", TaskID)

            updateCmd.ExecuteNonQuery()

            'Send notification emails if the assignment changed
            If assignmentChanged Then
                If assignedToUser IsNot DBNull.Value Then
                    Dim recipientEmail As String = GetUserEmail(assignedToUser)
                    If Not String.IsNullOrEmpty(recipientEmail) Then
                        SendTaskAssignmentEmail(taskTitle, taskDescription, recipientEmail)
                        MessageBox.Show("Task assigned and email sent to the person successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                ElseIf assignedToTeam IsNot DBNull.Value Then
                    Dim teamEmails As List(Of String) = GetTeamEmailsByTeamID(assignedToTeam)
                    For Each email As String In teamEmails
                        SendTaskAssignmentEmail(taskTitle, taskDescription, email)
                        MessageBox.Show("Task assigned and emails sent to the team successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Next
                End If
            End If

            'If responsible person of the task checked the Done button
            If chkDone.Checked Then
                ' Notify the team lead
                Dim teamLeadEmail As String = GetTeamLeadEmail()
                If Not String.IsNullOrEmpty(teamLeadEmail) Then
                    SendTaskCompletedEmail(TaskID, taskTitle, taskDescription, teamLeadEmail)
                Else
                    MessageBox.Show("Failed to retrieve team lead email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred while updating the task: " & ex.Message)
        Finally
            con.Close()
        End Try

        'Notify MyTasks to refresh
        Dim myTasksForm As MyTasks = Application.OpenForms.OfType(Of MyTasks)().FirstOrDefault()
        If myTasksForm IsNot Nothing Then
            myTasksForm.RefreshTasks()
        End If

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

    Private Function GetTeamEmailsByTeamID(teamID As Integer) As List(Of String)
        Dim emails As New List(Of String)()

        'SQL connection and command to fetch emails of users belonging to the specified TeamID
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("SELECT Email FROM tblUsers WHERE TeamID = @TeamID", con)
        cmd.Parameters.AddWithValue("@TeamID", teamID)

        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                emails.Add(reader("Email").ToString())
            End While
        Catch ex As Exception
            MessageBox.Show("An error occurred while retrieving team emails: " & ex.Message)
        Finally
            con.Close()
        End Try

        Return emails
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
            'MessageBox.Show("Assigment notification email sent successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub btnZoom_Click(sender As Object, e As EventArgs) Handles btnZoom.Click
        ' Check if there's an image loaded
        If picImage.Image IsNot Nothing Then
            ' Create a new instance of TaskImageViewer
            Dim imageViewer As New TaskImageViewer()

            ' Pass the image to TaskImageViewer
            imageViewer.picEnlargedImage.Image = picImage.Image

            imageViewer.Show()
        Else
            MessageBox.Show("No image to display.")
        End If
    End Sub

    Private Sub btnOpenChat_Click(sender As Object, e As EventArgs) Handles btnOpenChat.Click
        Dim chatForm As New Chat()
        chatForm.TaskID = Me.TaskID 'Send taskID for database
        chatForm.LoggedInUserID = Login.LoggedInUserID 'Send LoggedInUserID for datase
        chatForm.Show()
    End Sub
End Class