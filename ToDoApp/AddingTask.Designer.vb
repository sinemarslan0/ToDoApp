<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddingTask
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddingTask))
        Me.txtTitle = New DevExpress.XtraEditors.TextEdit()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAttach = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTitle = New DevExpress.XtraEditors.LabelControl()
        Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
        Me.picImage = New DevExpress.XtraEditors.PictureEdit()
        Me.lblPhotograph = New DevExpress.XtraEditors.LabelControl()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.txtDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.lblMainTitle = New DevExpress.XtraEditors.LabelControl()
        Me.XtraOpenFileDialog1 = New DevExpress.XtraEditors.XtraOpenFileDialog(Me.components)
        CType(Me.txtTitle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(55, 92)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(320, 22)
        Me.txtTitle.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnSave.Location = New System.Drawing.Point(325, 476)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSave.Size = New System.Drawing.Size(59, 69)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'btnAttach
        '
        Me.btnAttach.ImageOptions.Image = CType(resources.GetObject("btnAttach.ImageOptions.Image"), System.Drawing.Image)
        Me.btnAttach.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAttach.Location = New System.Drawing.Point(170, 317)
        Me.btnAttach.Name = "btnAttach"
        Me.btnAttach.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnAttach.Size = New System.Drawing.Size(40, 41)
        Me.btnAttach.TabIndex = 4
        '
        'lblTitle
        '
        Me.lblTitle.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblTitle.Appearance.Options.UseFont = True
        Me.lblTitle.Location = New System.Drawing.Point(55, 53)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(47, 24)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "Title:"
        '
        'lblDescription
        '
        Me.lblDescription.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblDescription.Appearance.Options.UseFont = True
        Me.lblDescription.Location = New System.Drawing.Point(55, 132)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(107, 24)
        Me.lblDescription.TabIndex = 6
        Me.lblDescription.Text = "Description:"
        '
        'picImage
        '
        Me.picImage.Location = New System.Drawing.Point(55, 358)
        Me.picImage.Name = "picImage"
        Me.picImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.picImage.Size = New System.Drawing.Size(246, 162)
        Me.picImage.TabIndex = 8
        '
        'lblPhotograph
        '
        Me.lblPhotograph.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblPhotograph.Appearance.Options.UseFont = True
        Me.lblPhotograph.Location = New System.Drawing.Point(55, 328)
        Me.lblPhotograph.Name = "lblPhotograph"
        Me.lblPhotograph.Size = New System.Drawing.Size(109, 24)
        Me.lblPhotograph.TabIndex = 9
        Me.lblPhotograph.Text = "Photograph:"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(55, 162)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(320, 149)
        Me.txtDescription.TabIndex = 10
        '
        'lblMainTitle
        '
        Me.lblMainTitle.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblMainTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMainTitle.Appearance.Options.UseFont = True
        Me.lblMainTitle.Appearance.Options.UseForeColor = True
        Me.lblMainTitle.Location = New System.Drawing.Point(57, 4)
        Me.lblMainTitle.Name = "lblMainTitle"
        Me.lblMainTitle.Size = New System.Drawing.Size(197, 33)
        Me.lblMainTitle.TabIndex = 11
        Me.lblMainTitle.Text = "Add New Task"
        '
        'XtraOpenFileDialog1
        '
        Me.XtraOpenFileDialog1.FileName = "XtraOpenFileDialog1"
        '
        'AddingTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 566)
        Me.Controls.Add(Me.lblMainTitle)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblPhotograph)
        Me.Controls.Add(Me.picImage)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnAttach)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtTitle)
        Me.IconOptions.LargeImage = CType(resources.GetObject("AddingTask.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "AddingTask"
        Me.Text = "AddingTask"
        CType(Me.txtTitle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTitle As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAttach As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents picImage As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblPhotograph As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents txtDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblMainTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XtraOpenFileDialog1 As DevExpress.XtraEditors.XtraOpenFileDialog
End Class
