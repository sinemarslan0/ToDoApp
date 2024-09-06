Imports System.Data.SqlClient

Public Class ToDo
    Private bindingSource As New BindingSource()
    Private tasks As New DataTable()
    Private originalTaskStates As New Dictionary(Of Integer, Boolean)()

    Private Sub ToDo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CheckedListBoxControl data source
        chkboxTasks.DataSource = bindingSource
        chkboxTasks.DisplayMember = "Title"
        chkboxTasks.ValueMember = "ID"

        LoadTasks()

        'SearchControl (search bar) text changed event
        AddHandler srchTask.TextChanged, AddressOf srchTask_TextChanged

        'Initial filter based on the ToggleSwitch state
        ToggleSwitch1_Toggled(Nothing, Nothing)

        'Initialize item check states
        InitializeCheckedStates()
    End Sub

    Private Sub LoadTasks()
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
        Dim cmd As SqlCommand = New SqlCommand("SELECT TaskID, Title, Description, IsCompleted FROM TblTask", con)
        Dim adapter As New SqlDataAdapter(cmd)
        tasks.Clear()
        adapter.Fill(tasks)
        bindingSource.DataSource = tasks

        'Store task states
        originalTaskStates.Clear()
        For Each row As DataRow In tasks.Rows
            'Conversion of the IsCompleted field to Boolean
            Dim isCompleted As Boolean = Convert.ToBoolean(row("IsCompleted"))
            originalTaskStates(row.Field(Of Integer)("TaskID")) = isCompleted
        Next
    End Sub

    Private Sub InitializeCheckedStates()
        For i As Integer = 0 To chkboxTasks.ItemCount - 1
            Dim itemID As Integer = CType(chkboxTasks.GetItemValue(i), Integer)
            'Retrieve the original state of the task and set the checked state accordingly
            If originalTaskStates.ContainsKey(itemID) Then
                Dim isChecked As Boolean = originalTaskStates(itemID)
                chkboxTasks.SetItemChecked(i, isChecked)
            End If
        Next
    End Sub

    Private Sub srchTask_TextChanged(sender As Object, e As EventArgs)
        Dim searchText As String = srchTask.Text.ToLower()

        'Apply search filter
        bindingSource.Filter = $"Title LIKE '%{searchText}%'"
    End Sub

    Private Sub ToggleSwitch1_Toggled(sender As Object, e As EventArgs) Handles ToggleSwitch1.Toggled
        Dim filter As String = If(ToggleSwitch1.IsOn, "", "IsCompleted = False")
        bindingSource.Filter = If(String.IsNullOrEmpty(filter), Nothing, filter)

        'Reapply the checked states after filtering
        InitializeCheckedStates()
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        If chkboxTasks.SelectedIndex >= 0 Then
            Dim selectedID As Integer = CType(chkboxTasks.GetItemValue(chkboxTasks.SelectedIndex), Integer)
            Dim detailsForm As New TaskDetails0()
            TaskDetails0.TaskID = selectedID
            TaskDetails0.Show()
        Else
            MessageBox.Show("Please select a task to view details.", "No Selection")
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim addTaskForm As New AddingTask()

        'Subscribe to the TaskAdded event
        AddHandler addTaskForm.TaskAdded, AddressOf OnTaskAdded

        'Show the AddingTask form
        addTaskForm.ShowDialog()
    End Sub

    Private Sub OnTaskAdded()
        'Refresh the task list when a new task is added
        LoadTasks()
        InitializeCheckedStates()
    End Sub
End Class