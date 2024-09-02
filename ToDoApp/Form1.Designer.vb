<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.CheckedListBoxControl1 = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.lblToDo = New System.Windows.Forms.Label()
        Me.SearchControl1 = New DevExpress.XtraEditors.SearchControl()
        Me.TreeListLookUpEdit1 = New DevExpress.XtraEditors.TreeListLookUpEdit()
        Me.TreeListLookUpEdit1TreeList = New DevExpress.XtraTreeList.TreeList()
        Me.btnAddNewTask = New System.Windows.Forms.Button()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.lblTask = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblPicture = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.btnUploadPhoto = New System.Windows.Forms.Button()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.ToggleSwitch1 = New DevExpress.XtraEditors.ToggleSwitch()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        CType(Me.CheckedListBoxControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TreeListLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TreeListLookUpEdit1TreeList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToggleSwitch1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CheckedListBoxControl1
        '
        Me.CheckedListBoxControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.CheckedListBoxControl1.Appearance.Options.UseFont = True
        Me.CheckedListBoxControl1.ColumnWidth = 10
        Me.CheckedListBoxControl1.ItemPadding = New System.Windows.Forms.Padding(15)
        Me.CheckedListBoxControl1.Location = New System.Drawing.Point(453, 101)
        Me.CheckedListBoxControl1.Name = "CheckedListBoxControl1"
        Me.CheckedListBoxControl1.Padding = New System.Windows.Forms.Padding(1)
        Me.CheckedListBoxControl1.Size = New System.Drawing.Size(348, 308)
        Me.CheckedListBoxControl1.TabIndex = 13
        '
        'lblToDo
        '
        Me.lblToDo.AutoSize = True
        Me.lblToDo.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblToDo.Location = New System.Drawing.Point(447, 30)
        Me.lblToDo.Name = "lblToDo"
        Me.lblToDo.Size = New System.Drawing.Size(102, 31)
        Me.lblToDo.TabIndex = 14
        Me.lblToDo.Text = "TO-DO"
        '
        'SearchControl1
        '
        Me.SearchControl1.Location = New System.Drawing.Point(453, 73)
        Me.SearchControl1.Name = "SearchControl1"
        Me.SearchControl1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.SearchControl1.Size = New System.Drawing.Size(348, 22)
        Me.SearchControl1.TabIndex = 15
        '
        'TreeListLookUpEdit1
        '
        Me.TreeListLookUpEdit1.Location = New System.Drawing.Point(885, 299)
        Me.TreeListLookUpEdit1.Name = "TreeListLookUpEdit1"
        Me.TreeListLookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TreeListLookUpEdit1.Properties.TreeList = Me.TreeListLookUpEdit1TreeList
        Me.TreeListLookUpEdit1.Size = New System.Drawing.Size(8, 22)
        Me.TreeListLookUpEdit1.TabIndex = 17
        '
        'TreeListLookUpEdit1TreeList
        '
        Me.TreeListLookUpEdit1TreeList.Location = New System.Drawing.Point(0, 0)
        Me.TreeListLookUpEdit1TreeList.Name = "TreeListLookUpEdit1TreeList"
        Me.TreeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = True
        Me.TreeListLookUpEdit1TreeList.Size = New System.Drawing.Size(400, 200)
        Me.TreeListLookUpEdit1TreeList.TabIndex = 0
        '
        'btnAddNewTask
        '
        Me.btnAddNewTask.BackColor = System.Drawing.Color.LightGreen
        Me.btnAddNewTask.Location = New System.Drawing.Point(680, 35)
        Me.btnAddNewTask.Name = "btnAddNewTask"
        Me.btnAddNewTask.Size = New System.Drawing.Size(121, 31)
        Me.btnAddNewTask.TabIndex = 18
        Me.btnAddNewTask.Text = "ADD NEW TASK"
        Me.btnAddNewTask.UseVisualStyleBackColor = False
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(726, 415)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(75, 23)
        Me.btnShow.TabIndex = 19
        Me.btnShow.Text = "SHOW"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'lblTask
        '
        Me.lblTask.AutoSize = True
        Me.lblTask.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblTask.Location = New System.Drawing.Point(43, 28)
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Size = New System.Drawing.Size(85, 31)
        Me.lblTask.TabIndex = 2
        Me.lblTask.Text = "TASK"
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(46, 70)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(76, 21)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "Title:"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(51, 141)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(100, 20)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Description:"
        '
        'lblPicture
        '
        Me.lblPicture.AutoSize = True
        Me.lblPicture.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblPicture.Location = New System.Drawing.Point(51, 246)
        Me.lblPicture.Name = "lblPicture"
        Me.lblPicture.Size = New System.Drawing.Size(99, 20)
        Me.lblPicture.TabIndex = 5
        Me.lblPicture.Text = "Photograph:"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(49, 94)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(262, 22)
        Me.txtTitle.TabIndex = 6
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(50, 164)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(265, 64)
        Me.txtDescription.TabIndex = 7
        '
        'btnUploadPhoto
        '
        Me.btnUploadPhoto.Location = New System.Drawing.Point(237, 241)
        Me.btnUploadPhoto.Name = "btnUploadPhoto"
        Me.btnUploadPhoto.Size = New System.Drawing.Size(78, 29)
        Me.btnUploadPhoto.TabIndex = 10
        Me.btnUploadPhoto.Text = "Upload"
        Me.btnUploadPhoto.UseVisualStyleBackColor = True
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Location = New System.Drawing.Point(49, 276)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Size = New System.Drawing.Size(264, 144)
        Me.PictureEdit1.TabIndex = 11
        '
        'ToggleSwitch1
        '
        Me.ToggleSwitch1.Location = New System.Drawing.Point(50, 426)
        Me.ToggleSwitch1.Name = "ToggleSwitch1"
        Me.ToggleSwitch1.Properties.OffText = "Pending"
        Me.ToggleSwitch1.Properties.OnText = "Completed"
        Me.ToggleSwitch1.Size = New System.Drawing.Size(133, 24)
        Me.ToggleSwitch1.TabIndex = 12
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Tomato
        Me.btnDelete.Location = New System.Drawing.Point(240, 28)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(77, 33)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.LightGreen
        Me.btnAdd.Location = New System.Drawing.Point(166, 28)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(77, 33)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 499)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.btnAddNewTask)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.TreeListLookUpEdit1)
        Me.Controls.Add(Me.SearchControl1)
        Me.Controls.Add(Me.lblToDo)
        Me.Controls.Add(Me.CheckedListBoxControl1)
        Me.Controls.Add(Me.ToggleSwitch1)
        Me.Controls.Add(Me.PictureEdit1)
        Me.Controls.Add(Me.btnUploadPhoto)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.lblPicture)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblTask)
        Me.Name = "Form1"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Text = "Form1"
        CType(Me.CheckedListBoxControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TreeListLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TreeListLookUpEdit1TreeList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToggleSwitch1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents CheckedListBoxControl1 As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents lblToDo As Label
    Friend WithEvents SearchControl1 As DevExpress.XtraEditors.SearchControl
    Friend WithEvents TreeListLookUpEdit1 As DevExpress.XtraEditors.TreeListLookUpEdit
    Friend WithEvents TreeListLookUpEdit1TreeList As DevExpress.XtraTreeList.TreeList
    Friend WithEvents btnAddNewTask As Button
    Friend WithEvents btnShow As Button
    Friend WithEvents lblTask As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblPicture As Label
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents btnUploadPhoto As Button
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents ToggleSwitch1 As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAdd As Button
End Class
