Imports System.Data.SqlClient
Imports System.IO
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
            While reader.Read()
                txtTitle.Text = reader("Title").ToString()
                txtDescription.Text = reader("Description").ToString()

                If reader("Photograph") IsNot DBNull.Value Then
                    Dim photoData As Byte() = CType(reader("Photograph"), Byte())
                    Dim ms As New MemoryStream(photoData)
                    picImage.Image = Image.FromStream(ms)
                    picImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
                End If

                chkDone.Checked = CBool(reader("IsCompleted"))
                chkDone.Checked = InitialIsCompleted
            End While
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading task details: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click
        ' Check if IsCompleted state has changed
        If chkDone.Checked <> InitialIsCompleted Then
            Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
            Dim cmd As SqlCommand = New SqlCommand("UPDATE TblTasks SET IsCompleted = @IsCompleted WHERE ID = @ID", con)
            cmd.Parameters.AddWithValue("@ID", TaskID)
            cmd.Parameters.AddWithValue("@IsCompleted", chkDone.Checked)

            Try
                con.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("Task updated successfully!")
            Catch ex As Exception
                MessageBox.Show("An error occurred while updating task: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If
        Me.Close()
    End Sub
End Class