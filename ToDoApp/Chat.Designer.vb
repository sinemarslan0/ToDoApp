<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Chat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Chat))
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblUsername = New DevExpress.XtraEditors.LabelControl()
        Me.lblMessage = New DevExpress.XtraEditors.LabelControl()
        Me.lblTime = New DevExpress.XtraEditors.LabelControl()
        Me.txtMessage = New DevExpress.XtraEditors.TextEdit()
        Me.btnSend = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTitle = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtMessage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(55, 52)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(470, 519)
        Me.FlowLayoutPanel1.TabIndex = 0
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblUsername)
        Me.Panel1.Controls.Add(Me.lblMessage)
        Me.Panel1.Controls.Add(Me.lblTime)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 100)
        Me.Panel1.TabIndex = 3
        '
        'lblUsername
        '
        Me.lblUsername.Location = New System.Drawing.Point(13, 12)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(78, 16)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "LabelControl2"
        '
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(13, 34)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(78, 16)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "LabelControl4"
        '
        'lblTime
        '
        Me.lblTime.Location = New System.Drawing.Point(13, 56)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(78, 16)
        Me.lblTime.TabIndex = 1
        Me.lblTime.Text = "LabelControl3"
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(55, 588)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(431, 22)
        Me.txtMessage.TabIndex = 1
        '
        'btnSend
        '
        Me.btnSend.ImageOptions.Image = CType(resources.GetObject("btnSend.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSend.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btnSend.Location = New System.Drawing.Point(492, 577)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnSend.Size = New System.Drawing.Size(33, 42)
        Me.btnSend.TabIndex = 2
        '
        'lblTitle
        '
        Me.lblTitle.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Appearance.Options.UseFont = True
        Me.lblTitle.Location = New System.Drawing.Point(59, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(46, 24)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "Chat"
        '
        'PanelControl1
        '
        Me.PanelControl1.AutoSize = True
        Me.PanelControl1.Controls.Add(Me.lblTitle)
        Me.PanelControl1.Controls.Add(Me.btnSend)
        Me.PanelControl1.Controls.Add(Me.txtMessage)
        Me.PanelControl1.Controls.Add(Me.FlowLayoutPanel1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(598, 660)
        Me.PanelControl1.TabIndex = 0
        '
        'Chat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 660)
        Me.Controls.Add(Me.PanelControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("Chat.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "Chat"
        Me.Text = "Chat"
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtMessage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents lblUsername As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblMessage As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTime As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMessage As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnSend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Panel1 As Panel
End Class
