Imports System.Data.SqlClient
Imports System.Threading
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class MyTasks

    Private originalItems As List(Of String)
    Private originalTaskStates As List(Of Boolean)
    Public TaskList As New List(Of String)()

    Private Sub ToDo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTasksIntoCheckedListBox(True)

        originalItems = chkboxTasks.Items.Cast(Of Object)().Select(Function(item) item.ToString()).ToList()
        ' Attach the TextChanged event to the SearchControl1
        originalTaskStates = chkboxTasks.Items.Cast(Of Object)().Select(Function(item) CBool(chkboxTasks.GetItemCheckState(chkboxTasks.Items.IndexOf(item)))).ToList()
        AddHandler srchTask.TextChanged, AddressOf srchTask_TextChanged
    End Sub

    Private Sub srchTask_TextChanged(sender As Object, e As EventArgs)
        Dim searchText As String = srchTask.Text.ToLower()

        ' Clear the CheckedListBoxControl and repopulate it based on the search text
        chkboxTasks.Items.Clear()

        For Each itemText In originalItems
            If itemText.ToLower().Contains(searchText) Then
                chkboxTasks.Items.Add(itemText)
            End If
        Next
    End Sub
    Private Sub LoadTasksIntoCheckedListBox(status As Boolean)
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("SELECT ID, Title, Description, IsCompleted FROM TblTasks", con)
        Dim reader As SqlDataReader
        TaskList.Clear()

        Try
            con.Open()
            reader = cmd.ExecuteReader()

            chkboxTasks.Items.Clear() ' Öğeleri temizler ve indeksin sıfırlanmasını sağlar

            ' Görevlerin listeye tersten eklenmesi, son eklenenin ilk sırada olmasını sağlar
            Dim taskListTemp As New List(Of Tuple(Of Integer, String, Boolean))

            While reader.Read()
                Dim taskId As Integer = reader("ID")
                Dim taskText As String = $"{reader("Title")}"
                Dim taskStatus As Boolean = reader("IsCompleted")

                If status = False And taskStatus = False Then
                    taskListTemp.Add(Tuple.Create(taskId, taskText, taskStatus))
                    TaskList.Add(taskId)

                ElseIf status = True Then
                    taskListTemp.Add(Tuple.Create(taskId, taskText, taskStatus))
                    TaskList.Add(taskId)

                End If
            End While

            ' Son eklenen görevlerin ilk sırada olması için ters sırayla ekleme yapılır
            For i As Integer = taskListTemp.Count - 1 To 0 Step -1
                Dim task = taskListTemp(i)
                chkboxTasks.Items.Insert(0, New CheckedListBoxItem(task.Item2, task.Item3))
            Next

        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub LoadFilteredTasks(searchText As String)
        chkboxTasks.Items.Clear()

        For i As Integer = 0 To originalItems.Count - 1
            Dim itemText = originalItems(i)
            Dim itemState = originalTaskStates(i)

            If itemText.ToLower().Contains(searchText) Then
                If Not ToggleSwitch1.IsOn OrElse itemState = False Then
                    chkboxTasks.Items.Add(itemText, itemState)
                End If
            End If
        Next
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        If chkboxTasks.SelectedIndex >= 0 Then
            Dim selectedIndex As Integer = chkboxTasks.SelectedIndex
            Dim detailsForm As New TaskDetails1()
            TaskDetails1.TaskID = GetTaskIDByIndex(selectedIndex)
            TaskDetails1.Show()
        Else
            MessageBox.Show("Please select a task to view details.", "No Selection")
        End If
    End Sub

    Public Function GetTaskIDByIndex(index As Integer) As Integer
        Return TaskList(index)
    End Function

    Private Sub ToggleSwitch1_Toggled(sender As Object, e As EventArgs) Handles ToggleSwitch1.Toggled
        Dim isInverted As Boolean = Not ToggleSwitch1.IsOn
        LoadTasksIntoCheckedListBox(isInverted)
        Dim searchText As String = srchTask.Text.ToLower()
        LoadFilteredTasks(searchText)
    End Sub
End Class