Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base.ViewInfo

Public Class MyTasks
    Private bindingSource As New BindingSource()
    Private tasks As New DataTable()
    Private originalTaskStates As New Dictionary(Of Integer, Boolean)()

    Private Sub MyTasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set up the CheckedListBoxControl data source
        chkboxTasks.DataSource = bindingSource
        chkboxTasks.DisplayMember = "Title"
        chkboxTasks.ValueMember = "TaskID"

        LoadTasksIntoDataTable()

        'SearchControl (search bar) text changed event
        AddHandler srchTask.TextChanged, AddressOf srchTask_TextChanged

        'Initial filter based on the ToggleSwitch state
        ToggleSwitch1_Toggled(Nothing, Nothing)

        'Initialize item check states
        InitializeCheckedStates()
    End Sub

    Private Sub LoadTasksIntoDataTable()
        Dim con As SqlConnection = New SqlConnection("Data Source=SINEM\SQLEXPRESS;Initial Catalog=DbToDo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True")

        'SQL query to fetch tasks assigned to individual user or their team
        Dim query As String
        If Login.LoggedInRoleID = 1 OrElse Login.LoggedInRoleID = 2 Then
            'Company user, Admin, or Team Lead sees all tasks
            query = "SELECT TaskID, Title, Description, IsCompleted FROM TblTask"
        Else
            'Regular employees (developers, analysts) see only tasks assigned to them or their teams
            query = "SELECT t.TaskID, t.Title, t.Description, t.IsCompleted FROM TblTask AS t " &
                    "JOIN TblUsers AS u ON u.UserID = @UserID " &
                    "LEFT JOIN TblTeams AS tm ON tm.TeamID = u.TeamID " &
                    "WHERE t.AssignedToUser = @UserID OR t.AssignedToTeam = tm.TeamID"
        End If

        'Create the command and set the parameter for UserID
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        If Login.LoggedInRoleID > 2 Then  'Only pass the UserID if the user is not a company user, Admin, or Team Lead
            cmd.Parameters.AddWithValue("@UserID", Login.LoggedInUserID)
        End If

        'Execute and fill the DataTable
        Dim adapter As New SqlDataAdapter(cmd)
        tasks.Clear()
        adapter.Fill(tasks)
        bindingSource.DataSource = tasks

        'Store task states
        originalTaskStates.Clear()
        For Each row As DataRow In tasks.Rows
            originalTaskStates(row.Field(Of Integer)("TaskID")) = row.Field(Of Boolean)("IsCompleted")
        Next
    End Sub

    Private Sub InitializeCheckedStates()
        For i As Integer = 0 To chkboxTasks.ItemCount - 1
            Dim itemID As Integer = CType(chkboxTasks.GetItemValue(i), Integer)
            Dim isChecked As Boolean = originalTaskStates(itemID)
            chkboxTasks.SetItemChecked(i, isChecked)
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
            TaskDetails1.TaskID = selectedID
            Chat.TaskID = selectedID
            TaskDetails1.Show()
        Else
            MessageBox.Show("Please select a task to view details.", "No Selection")
        End If
    End Sub

    Public Sub RefreshTasks()
        LoadTasksIntoDataTable()
        InitializeCheckedStates()  'Ensure checked states are updated
    End Sub
End Class
