Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Net

Public Class Form1
    Private originalItems As List(Of String)
    Public TaskList As New List(Of String)()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTasksIntoCheckedListBox()

        originalItems = CheckedListBoxControl1.Items.Cast(Of Object)().Select(Function(item) item.ToString()).ToList()
        ' Attach the TextChanged event to the SearchControl1
        AddHandler SearchControl1.TextChanged, AddressOf SearchControl1_TextChanged
    End Sub

    Private Sub SearchControl1_TextChanged(sender As Object, e As EventArgs)
        Dim searchText As String = SearchControl1.Text.ToLower()

        ' Clear the CheckedListBoxControl and repopulate it based on the search text
        CheckedListBoxControl1.Items.Clear()

        For Each itemText In originalItems
            If itemText.ToLower().Contains(searchText) Then
                CheckedListBoxControl1.Items.Add(itemText)
            End If
        Next
    End Sub

    Private Sub LoadTasksIntoCheckedListBox()
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("SELECT ID, Title, Description, IsCompleted FROM TblTasks", con)
        Dim reader As SqlDataReader

        Try
            con.Open()
            reader = cmd.ExecuteReader()

            CheckedListBoxControl1.Items.Clear()

            While reader.Read()
                Dim taskId As Integer = reader("ID")
                Dim taskText As String = $"{reader("Title")}{Environment.NewLine}{reader("Description")}"
                TaskList.Add(taskId)
                CheckedListBoxControl1.Items.Add(taskText, CBool(If(IsDBNull(reader("IsCompleted")), False, reader("IsCompleted"))))
            End While
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("INSERT INTO TblTasks (Title, Description, Photograph, IsCompleted) VALUES (@Title, @Description, @Photograph, @IsCompleted)", con)

        cmd.Parameters.AddWithValue("@Title", txtTitle.Text)
        cmd.Parameters.AddWithValue("@Description", txtDescription.Text)
        cmd.Parameters.AddWithValue("@IsCompleted", ToggleSwitch1.IsOn)

        If PictureEdit1.Image IsNot Nothing Then
            Dim photoBytes As Byte() = ImageToByteArray(PictureEdit1.Image)
            cmd.Parameters.AddWithValue("@Photograph", photoBytes)
        Else
            cmd.Parameters.AddWithValue("@Photograph", DBNull.Value)
        End If

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("The task has been successfully registered in the system.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadTasksIntoCheckedListBox()

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


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim selectedItems = CheckedListBoxControl1.CheckedItems

        If selectedItems.Count > 0 Then
            Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")

            Try
                con.Open()

                For Each item In selectedItems
                    Dim itemText As String = item.ToString()
                    Dim taskId As Integer = GetTaskIdFromItemText(itemText) ' Implement this method to get the ID based on the text

                    Dim cmd As SqlCommand = New SqlCommand("DELETE FROM TblTasks WHERE ID = @ID", con)
                    cmd.Parameters.AddWithValue("@ID", taskId)
                    cmd.ExecuteNonQuery()
                Next

                MessageBox.Show("The selected tasks were successfully deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh the CheckedListBoxControl1 to remove the deleted tasks
                LoadTasksIntoCheckedListBox()
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            Finally
                con.Close()
            End Try
        Else
            MessageBox.Show("Please select at least one task to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnUploadPhoto_Click(sender As Object, e As EventArgs) Handles btnUploadPhoto.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            PictureEdit1.Image = Image.FromFile(openFileDialog.FileName)
            PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        End If
    End Sub

    Public Function ImageToByteArray(ByVal imageIn As Image) As Byte()
        Using ms As New MemoryStream()
            imageIn.Save(ms, imageIn.RawFormat)
            Return ms.ToArray()
        End Using
    End Function

    Private Function GetTaskIdFromItemText(itemText As String) As Integer
        Dim parts As String() = itemText.Split("."c)
        If parts.Length > 0 Then
            Return Convert.ToInt32(parts(0).Trim())
        Else
            Throw New FormatException("Invalid item text format.")
        End If
    End Function
    Public Function GetTaskIDByIndex(index As Integer) As Integer
        Return TaskList(index)
    End Function
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        If CheckedListBoxControl1.SelectedIndex >= 0 Then
            Dim selectedIndex As Integer = CheckedListBoxControl1.SelectedIndex
            Dim detailsForm As New TaskDetails()
            TaskDetails.TaskID = GetTaskIDByIndex(selectedIndex)
            TaskDetails.Show()
        Else
            MessageBox.Show("Please select a task to view details.", "No Selection")
        End If
    End Sub

    Private Sub btnAddNewTask_Click(sender As Object, e As EventArgs) Handles btnAddNewTask.Click
        AddingTask.Show()
    End Sub

    Private Sub CheckedListBoxControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBoxControl1.SelectedIndexChanged

    End Sub
End Class