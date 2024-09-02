Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class TaskDetails
    Public Property TaskID As Integer

    Private Sub TaskDetailsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TaskID'yi kullanarak görevin detaylarını yükleyin
        LoadTaskDetails(TaskID)
    End Sub

    Private Sub LoadTaskDetails(id As Integer)
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("SELECT ID, Title, Description, IsCompleted FROM TblTasks WHERE ID = @ID", con)
        cmd.Parameters.AddWithValue("@ID", id)
        Dim reader As SqlDataReader
        Try
            con.Open()
            reader = cmd.ExecuteReader()
            While reader.Read()
                ' Görev bilgilerini formdaki ilgili kontrollerde gösterin
                txtTitle.Text = reader("Title").ToString()
                txtDescription.Text = reader("Description").ToString()
            End While
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading task details: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub txtTitle_TextChanged(sender As Object, e As EventArgs) Handles txtTitle.TextChanged

    End Sub
End Class