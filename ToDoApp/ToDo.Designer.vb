<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ToDo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToDo))
        Me.btnShow = New DevExpress.XtraEditors.SimpleButton()
        Me.ToggleSwitch1 = New DevExpress.XtraEditors.ToggleSwitch()
        Me.lblToDo = New DevExpress.XtraEditors.LabelControl()
        Me.srchTask = New DevExpress.XtraEditors.SearchControl()
        Me.chkboxTasks = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ToggleSwitch1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.srchTask.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkboxTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnShow
        '
        Me.btnShow.ImageOptions.SvgImage = CType(resources.GetObject("btnShow.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnShow.Location = New System.Drawing.Point(276, 490)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnShow.Size = New System.Drawing.Size(123, 38)
        Me.btnShow.TabIndex = 11
        Me.btnShow.Text = "Show Details"
        '
        'ToggleSwitch1
        '
        Me.ToggleSwitch1.Location = New System.Drawing.Point(49, 497)
        Me.ToggleSwitch1.Name = "ToggleSwitch1"
        Me.ToggleSwitch1.Properties.OffText = "Show All"
        Me.ToggleSwitch1.Properties.OnText = "Not Completed"
        Me.ToggleSwitch1.Size = New System.Drawing.Size(141, 24)
        Me.ToggleSwitch1.TabIndex = 10
        '
        'lblToDo
        '
        Me.lblToDo.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblToDo.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblToDo.Appearance.Options.UseFont = True
        Me.lblToDo.Appearance.Options.UseForeColor = True
        Me.lblToDo.Location = New System.Drawing.Point(49, 33)
        Me.lblToDo.Name = "lblToDo"
        Me.lblToDo.Size = New System.Drawing.Size(105, 36)
        Me.lblToDo.TabIndex = 9
        Me.lblToDo.Text = "TO-DO"
        '
        'srchTask
        '
        Me.srchTask.Location = New System.Drawing.Point(49, 91)
        Me.srchTask.Name = "srchTask"
        Me.srchTask.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.srchTask.Size = New System.Drawing.Size(350, 22)
        Me.srchTask.TabIndex = 8
        '
        'chkboxTasks
        '
        Me.chkboxTasks.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.chkboxTasks.ItemPadding = New System.Windows.Forms.Padding(12)
        Me.chkboxTasks.Location = New System.Drawing.Point(49, 129)
        Me.chkboxTasks.Name = "chkboxTasks"
        Me.chkboxTasks.PictureChecked = CType(resources.GetObject("chkboxTasks.PictureChecked"), System.Drawing.Image)
        Me.chkboxTasks.PictureUnchecked = CType(resources.GetObject("chkboxTasks.PictureUnchecked"), System.Drawing.Image)
        Me.chkboxTasks.Size = New System.Drawing.Size(350, 344)
        Me.chkboxTasks.TabIndex = 7
        '
        'btnAdd
        '
        Me.btnAdd.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnAdd.Appearance.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnAdd.Appearance.Options.UseFont = True
        Me.btnAdd.Appearance.Options.UseForeColor = True
        Me.btnAdd.ImageOptions.SvgImage = CType(resources.GetObject("btnAdd.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnAdd.Location = New System.Drawing.Point(261, 31)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(138, 38)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "Add New Task"
        '
        'ToDo
        '
        Me.Appearance.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 560)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.ToggleSwitch1)
        Me.Controls.Add(Me.lblToDo)
        Me.Controls.Add(Me.srchTask)
        Me.Controls.Add(Me.chkboxTasks)
        Me.IconOptions.LargeImage = CType(resources.GetObject("ToDo.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "ToDo"
        Me.Text = "ToDo"
        CType(Me.ToggleSwitch1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.srchTask.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkboxTasks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnShow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ToggleSwitch1 As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents lblToDo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents srchTask As DevExpress.XtraEditors.SearchControl
    Friend WithEvents chkboxTasks As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
End Class
