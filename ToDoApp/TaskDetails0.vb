Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports System.IO

Public Class TaskDetails0
    Public Property TaskID As Integer
    Private ReadOnlyMode As Boolean = True 'Declare ReadOnlyMode at the class level

    Private Sub TaskDetailsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTaskDetails(TaskID)
        btnSave.Enabled = False 'Disable save button initially (nothing to save before editing)
    End Sub

    Private Sub LoadTaskDetails(id As Integer)
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("SELECT ID, Title, Description, Photograph, IsCompleted FROM TblTasks WHERE ID = @ID", con)
        cmd.Parameters.AddWithValue("@ID", id)
        Dim reader As SqlDataReader
        Try
            con.Open()
            reader = cmd.ExecuteReader()
            While reader.Read()
                txtTitle.Text = reader("Title").ToString()
                txtDescription.Text = reader("Description").ToString()

                If reader("Photograph") IsNot DBNull.Value Then
                    Dim photoData As Byte() = CType(reader("Photograph"), Byte())
                    Dim ms As New MemoryStream(photoData)
                    picImage.Image = Image.FromStream(ms)
                    picImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
                End If
            End While
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
        Dim cmd As SqlCommand = New SqlCommand("UPDATE TblTasks SET Title = @Title, Description = @Description WHERE ID = @ID", con)
        cmd.Parameters.AddWithValue("@ID", TaskID)
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
End Class