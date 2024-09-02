Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports System.IO

Public Class TaskDetails0
    Public Property TaskID As Integer

    Private Sub TaskDetailsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TaskID'yi kullanarak görevin detaylarını yükleyin
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
                ' Görev bilgilerini formdaki ilgili kontrollerde gösterin
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
End Class