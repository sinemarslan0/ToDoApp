<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TaskDetails1
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TaskDetails1))
        Me.btnSaveClose = New DevExpress.XtraEditors.SimpleButton()
        Me.chkDone = New DevExpress.XtraEditors.CheckEdit()
        Me.picImage = New DevExpress.XtraEditors.PictureEdit()
        Me.txtDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.txtTitle = New DevExpress.XtraEditors.TextEdit()
        Me.lblPhotograph = New DevExpress.XtraEditors.LabelControl()
        Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
        Me.lblTitle = New DevExpress.XtraEditors.LabelControl()
        Me.lblAssign = New DevExpress.XtraEditors.LabelControl()
        Me.GridLookUpEdit1 = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        Me.lblComment = New DevExpress.XtraEditors.LabelControl()
        Me.btnZoom = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.chkDone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTitle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSaveClose
        '
        Me.btnSaveClose.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSaveClose.Appearance.Font = New System.Drawing.Font("Tahoma", 8.5!)
        Me.btnSaveClose.Appearance.Options.UseBackColor = True
        Me.btnSaveClose.Appearance.Options.UseFont = True
        Me.btnSaveClose.Location = New System.Drawing.Point(346, 644)
        Me.btnSaveClose.Name = "btnSaveClose"
        Me.btnSaveClose.Size = New System.Drawing.Size(111, 29)
        Me.btnSaveClose.TabIndex = 17
        Me.btnSaveClose.Text = "Save/Close"
        '
        'chkDone
        '
        Me.chkDone.Location = New System.Drawing.Point(77, 502)
        Me.chkDone.Name = "chkDone"
        Me.chkDone.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.chkDone.Properties.Appearance.Options.UseFont = True
        Me.chkDone.Properties.Caption = "Done"
        Me.chkDone.Size = New System.Drawing.Size(94, 25)
        Me.chkDone.TabIndex = 16
        '
        'picImage
        '
        Me.picImage.Location = New System.Drawing.Point(77, 288)
        Me.picImage.Name = "picImage"
        Me.picImage.Properties.ReadOnly = True
        Me.picImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.picImage.Size = New System.Drawing.Size(259, 149)
        Me.picImage.TabIndex = 14
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(77, 141)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Properties.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(323, 108)
        Me.txtDescription.TabIndex = 13
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(77, 75)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Properties.ReadOnly = True
        Me.txtTitle.Size = New System.Drawing.Size(323, 22)
        Me.txtTitle.TabIndex = 12
        '
        'lblPhotograph
        '
        Me.lblPhotograph.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblPhotograph.Appearance.Options.UseFont = True
        Me.lblPhotograph.Location = New System.Drawing.Point(77, 258)
        Me.lblPhotograph.Name = "lblPhotograph"
        Me.lblPhotograph.Size = New System.Drawing.Size(109, 24)
        Me.lblPhotograph.TabIndex = 11
        Me.lblPhotograph.Text = "Photograph:"
        '
        'lblDescription
        '
        Me.lblDescription.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblDescription.Appearance.Options.UseFont = True
        Me.lblDescription.Location = New System.Drawing.Point(77, 111)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(107, 24)
        Me.lblDescription.TabIndex = 10
        Me.lblDescription.Text = "Description:"
        '
        'lblTitle
        '
        Me.lblTitle.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblTitle.Appearance.Options.UseFont = True
        Me.lblTitle.Location = New System.Drawing.Point(77, 45)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(47, 24)
        Me.lblTitle.TabIndex = 9
        Me.lblTitle.Text = "Title:"
        '
        'lblAssign
        '
        Me.lblAssign.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblAssign.Appearance.Options.UseFont = True
        Me.lblAssign.Location = New System.Drawing.Point(77, 454)
        Me.lblAssign.Name = "lblAssign"
        Me.lblAssign.Size = New System.Drawing.Size(64, 24)
        Me.lblAssign.TabIndex = 19
        Me.lblAssign.Text = "Assign:"
        '
        'GridLookUpEdit1
        '
        Me.GridLookUpEdit1.Location = New System.Drawing.Point(77, 484)
        Me.GridLookUpEdit1.Name = "GridLookUpEdit1"
        Me.GridLookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GridLookUpEdit1.Properties.PopupView = Me.GridLookUpEdit1View
        Me.GridLookUpEdit1.Size = New System.Drawing.Size(259, 22)
        Me.GridLookUpEdit1.TabIndex = 20
        '
        'GridLookUpEdit1View
        '
        Me.GridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridLookUpEdit1View.Name = "GridLookUpEdit1View"
        Me.GridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Location = New System.Drawing.Point(80, 557)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Size = New System.Drawing.Size(320, 71)
        Me.MemoEdit1.TabIndex = 21
        '
        'lblComment
        '
        Me.lblComment.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblComment.Appearance.Options.UseFont = True
        Me.lblComment.Location = New System.Drawing.Point(80, 533)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(69, 18)
        Me.lblComment.TabIndex = 22
        Me.lblComment.Text = "Comment:"
        '
        'btnZoom
        '
        Me.btnZoom.ImageOptions.Image = CType(resources.GetObject("btnZoom.ImageOptions.Image"), System.Drawing.Image)
        Me.btnZoom.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnZoom.Location = New System.Drawing.Point(342, 279)
        Me.btnZoom.Name = "btnZoom"
        Me.btnZoom.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnZoom.Size = New System.Drawing.Size(42, 65)
        Me.btnZoom.TabIndex = 23
        Me.btnZoom.Text = "Zoom"
        '
        'TaskDetails1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 710)
        Me.Controls.Add(Me.btnZoom)
        Me.Controls.Add(Me.lblComment)
        Me.Controls.Add(Me.MemoEdit1)
        Me.Controls.Add(Me.GridLookUpEdit1)
        Me.Controls.Add(Me.lblAssign)
        Me.Controls.Add(Me.btnSaveClose)
        Me.Controls.Add(Me.chkDone)
        Me.Controls.Add(Me.picImage)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.lblPhotograph)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.IconOptions.LargeImage = CType(resources.GetObject("TaskDetails1.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "TaskDetails1"
        Me.Text = "Task Details"
        CType(Me.chkDone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTitle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSaveClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkDone As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents picImage As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtTitle As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPhotograph As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblAssign As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridLookUpEdit1 As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblComment As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnZoom As DevExpress.XtraEditors.SimpleButton
End Class
