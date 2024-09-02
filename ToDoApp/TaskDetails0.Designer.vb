<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TaskDetails0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TaskDetails0))
        Me.lblTitle = New DevExpress.XtraEditors.LabelControl()
        Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
        Me.lblPhotograph = New DevExpress.XtraEditors.LabelControl()
        Me.txtTitle = New DevExpress.XtraEditors.TextEdit()
        Me.txtDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.picImage = New DevExpress.XtraEditors.PictureEdit()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtTitle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblTitle.Appearance.Options.UseFont = True
        Me.lblTitle.Location = New System.Drawing.Point(69, 36)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(47, 24)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Title:"
        '
        'lblDescription
        '
        Me.lblDescription.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblDescription.Appearance.Options.UseFont = True
        Me.lblDescription.Location = New System.Drawing.Point(69, 102)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(107, 24)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "Description:"
        '
        'lblPhotograph
        '
        Me.lblPhotograph.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblPhotograph.Appearance.Options.UseFont = True
        Me.lblPhotograph.Location = New System.Drawing.Point(69, 309)
        Me.lblPhotograph.Name = "lblPhotograph"
        Me.lblPhotograph.Size = New System.Drawing.Size(109, 24)
        Me.lblPhotograph.TabIndex = 2
        Me.lblPhotograph.Text = "Photograph:"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(69, 66)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Properties.ReadOnly = True
        Me.txtTitle.Size = New System.Drawing.Size(299, 22)
        Me.txtTitle.TabIndex = 3
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(69, 132)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Properties.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(299, 156)
        Me.txtDescription.TabIndex = 4
        '
        'picImage
        '
        Me.picImage.Location = New System.Drawing.Point(69, 339)
        Me.picImage.Name = "picImage"
        Me.picImage.Properties.ReadOnly = True
        Me.picImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.picImage.Size = New System.Drawing.Size(259, 149)
        Me.picImage.TabIndex = 5
        '
        'btnEdit
        '
        Me.btnEdit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEdit.ImageOptions.SvgImage = CType(resources.GetObject("btnEdit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnEdit.Location = New System.Drawing.Point(347, 9)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnEdit.Size = New System.Drawing.Size(63, 51)
        Me.btnEdit.TabIndex = 6
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(315, 506)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(94, 29)
        Me.SimpleButton1.TabIndex = 8
        Me.SimpleButton1.Text = "Save"
        '
        'TaskDetails0
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 560)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.picImage)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.lblPhotograph)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.IconOptions.LargeImage = CType(resources.GetObject("TaskDetails0.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "TaskDetails0"
        Me.Text = "Task Details"
        CType(Me.txtTitle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPhotograph As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTitle As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents picImage As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
