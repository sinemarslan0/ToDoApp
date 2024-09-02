<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MyTasks
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MyTasks))
        Me.chkboxTasks = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.srchTask = New DevExpress.XtraEditors.SearchControl()
        Me.lblToDo = New DevExpress.XtraEditors.LabelControl()
        Me.ToggleSwitch1 = New DevExpress.XtraEditors.ToggleSwitch()
        Me.btnShow = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.chkboxTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.srchTask.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToggleSwitch1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkboxTasks
        '
        Me.chkboxTasks.ItemPadding = New System.Windows.Forms.Padding(12)
        Me.chkboxTasks.Location = New System.Drawing.Point(47, 126)
        Me.chkboxTasks.Name = "chkboxTasks"
        Me.chkboxTasks.Size = New System.Drawing.Size(350, 350)
        Me.chkboxTasks.TabIndex = 0
        '
        'srchTask
        '
        Me.srchTask.Location = New System.Drawing.Point(47, 88)
        Me.srchTask.Name = "srchTask"
        Me.srchTask.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.srchTask.Size = New System.Drawing.Size(350, 22)
        Me.srchTask.TabIndex = 1
        '
        'lblToDo
        '
        Me.lblToDo.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblToDo.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblToDo.Appearance.Options.UseFont = True
        Me.lblToDo.Appearance.Options.UseForeColor = True
        Me.lblToDo.Location = New System.Drawing.Point(47, 30)
        Me.lblToDo.Name = "lblToDo"
        Me.lblToDo.Size = New System.Drawing.Size(160, 36)
        Me.lblToDo.TabIndex = 4
        Me.lblToDo.Text = "MY TASKS"
        '
        'ToggleSwitch1
        '
        Me.ToggleSwitch1.Location = New System.Drawing.Point(47, 494)
        Me.ToggleSwitch1.Name = "ToggleSwitch1"
        Me.ToggleSwitch1.Properties.OffText = "Show All"
        Me.ToggleSwitch1.Properties.OnText = "Not Completed"
        Me.ToggleSwitch1.Size = New System.Drawing.Size(141, 24)
        Me.ToggleSwitch1.TabIndex = 5
        '
        'btnShow
        '
        Me.btnShow.ImageOptions.SvgImage = CType(resources.GetObject("btnShow.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnShow.Location = New System.Drawing.Point(274, 487)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnShow.Size = New System.Drawing.Size(123, 38)
        Me.btnShow.TabIndex = 6
        Me.btnShow.Text = "Show Details"
        '
        'MyTasks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 560)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.ToggleSwitch1)
        Me.Controls.Add(Me.lblToDo)
        Me.Controls.Add(Me.srchTask)
        Me.Controls.Add(Me.chkboxTasks)
        Me.IconOptions.LargeImage = CType(resources.GetObject("MyTasks.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "MyTasks"
        Me.Text = "ToDo"
        CType(Me.chkboxTasks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.srchTask.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToggleSwitch1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkboxTasks As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents srchTask As DevExpress.XtraEditors.SearchControl
    Friend WithEvents lblToDo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ToggleSwitch1 As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents btnShow As DevExpress.XtraEditors.SimpleButton
End Class
