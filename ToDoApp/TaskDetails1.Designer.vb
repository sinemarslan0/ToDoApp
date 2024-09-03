<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TaskDetails1
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
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
        CType(Me.chkDone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTitle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSaveClose
        '
        Me.btnSaveClose.Appearance.Font = New System.Drawing.Font("Tahoma", 8.5!)
        Me.btnSaveClose.Appearance.Options.UseFont = True
        Me.btnSaveClose.Location = New System.Drawing.Point(294, 494)
        Me.btnSaveClose.Name = "btnSaveClose"
        Me.btnSaveClose.Size = New System.Drawing.Size(111, 29)
        Me.btnSaveClose.TabIndex = 17
        Me.btnSaveClose.Text = "Save/Close"
        '
        'chkDone
        '
        Me.chkDone.Location = New System.Drawing.Point(62, 492)
        Me.chkDone.Name = "chkDone"
        Me.chkDone.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.chkDone.Properties.Appearance.Options.UseFont = True
        Me.chkDone.Properties.Caption = "Done"
        Me.chkDone.Size = New System.Drawing.Size(94, 25)
        Me.chkDone.TabIndex = 16
        '
        'picImage
        '
        Me.picImage.Location = New System.Drawing.Point(62, 327)
        Me.picImage.Name = "picImage"
        Me.picImage.Properties.ReadOnly = True
        Me.picImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.picImage.Size = New System.Drawing.Size(259, 149)
        Me.picImage.TabIndex = 14
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(62, 120)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Properties.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(299, 156)
        Me.txtDescription.TabIndex = 13
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(62, 54)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Properties.ReadOnly = True
        Me.txtTitle.Size = New System.Drawing.Size(299, 22)
        Me.txtTitle.TabIndex = 12
        '
        'lblPhotograph
        '
        Me.lblPhotograph.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblPhotograph.Appearance.Options.UseFont = True
        Me.lblPhotograph.Location = New System.Drawing.Point(62, 297)
        Me.lblPhotograph.Name = "lblPhotograph"
        Me.lblPhotograph.Size = New System.Drawing.Size(109, 24)
        Me.lblPhotograph.TabIndex = 11
        Me.lblPhotograph.Text = "Photograph:"
        '
        'lblDescription
        '
        Me.lblDescription.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblDescription.Appearance.Options.UseFont = True
        Me.lblDescription.Location = New System.Drawing.Point(62, 90)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(107, 24)
        Me.lblDescription.TabIndex = 10
        Me.lblDescription.Text = "Description:"
        '
        'lblTitle
        '
        Me.lblTitle.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblTitle.Appearance.Options.UseFont = True
        Me.lblTitle.Location = New System.Drawing.Point(62, 24)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(47, 24)
        Me.lblTitle.TabIndex = 9
        Me.lblTitle.Text = "Title:"
        '
        'TaskDetails1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 560)
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
        Me.Text = "TaskDetails"
        CType(Me.chkDone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTitle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
