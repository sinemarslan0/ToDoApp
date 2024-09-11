<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TaskImageViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TaskImageViewer))
        Me.picEnlargedImage = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.picEnlargedImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picEnlargedImage
        '
        Me.picEnlargedImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picEnlargedImage.Location = New System.Drawing.Point(0, 0)
        Me.picEnlargedImage.Name = "picEnlargedImage"
        Me.picEnlargedImage.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.[True]
        Me.picEnlargedImage.Properties.AllowScrollViaMouseDrag = True
        Me.picEnlargedImage.Properties.AllowZoom = DevExpress.Utils.DefaultBoolean.[True]
        Me.picEnlargedImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.picEnlargedImage.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.[True]
        Me.picEnlargedImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.picEnlargedImage.Size = New System.Drawing.Size(1428, 810)
        Me.picEnlargedImage.TabIndex = 0
        '
        'TaskImageViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 810)
        Me.Controls.Add(Me.picEnlargedImage)
        Me.IconOptions.LargeImage = CType(resources.GetObject("TaskImageViewer.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "TaskImageViewer"
        Me.Text = "TaskImageViewer"
        CType(Me.picEnlargedImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picEnlargedImage As DevExpress.XtraEditors.PictureEdit
End Class
