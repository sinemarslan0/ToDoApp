Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports System.IO

Public Class TaskDetails0
    Public Property TaskID As Integer
    Private ReadOnlyMode As Boolean = True 'Declare ReadOnlyMode at the class level

    Private Sub TaskDetails0Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTaskDetails(TaskID)
        btnSave.Enabled = False ' Disable save button initially (nothing to save before editing)
    End Sub

    Private Sub LoadTaskDetails(id As Integer)
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("SELECT TaskID, Title, Description, Photograph, IsCompleted FROM TblTask WHERE TaskID = @TaskID", con)
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
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading task details: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        'Toggle read-only mode
        ReadOnlyMode = Not ReadOnlyMode
        txtTitle.ReadOnly = ReadOnlyMode
        txtDescription.ReadOnly = ReadOnlyMode
        btnEdit.Text = If(ReadOnlyMode, "Edit", "Cancel")
        btnSave.Enabled = Not ReadOnlyMode
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save changes to the database
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("UPDATE TblTask SET Title = @Title, Description = @Description WHERE TaskID = @TaskID", con)
        cmd.Parameters.AddWithValue("@TaskID", TaskID)
        cmd.Parameters.AddWithValue("@Title", txtTitle.Text)
        cmd.Parameters.AddWithValue("@Description", txtDescription.Text)

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Task updated successfully!")
            ReadOnlyMode = True
            txtTitle.ReadOnly = ReadOnlyMode
            txtDescription.ReadOnly = ReadOnlyMode
            btnEdit.Text = "Edit"
            btnSave.Enabled = Not ReadOnlyMode
        Catch ex As Exception
            MessageBox.Show("An error occurred while updating task: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnOpenChat_Click(sender As Object, e As EventArgs) Handles btnOpenChat.Click
        Dim chatForm As New Chat()
        chatForm.TaskID = Me.TaskID 'Send taskID for database
        chatForm.LoggedInUserID = Login.LoggedInUserID 'Send LoggedInUserID for datase
        chatForm.Show()
    End Sub
End Class