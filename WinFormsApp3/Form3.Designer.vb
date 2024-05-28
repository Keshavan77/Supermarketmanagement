<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Panel1 = New Panel()
        LblRole = New Label()
        Panel3 = New Panel()
        Panel4 = New Panel()
        PictureBox1 = New PictureBox()
        lblUsername = New Label()
        Button1 = New Button()
        Panel2 = New Panel()
        Button6 = New Button()
        Button5 = New Button()
        Button4 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        Panel5 = New Panel()
        Panel1.SuspendLayout()
        Panel4.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.GradientActiveCaption
        Panel1.Controls.Add(LblRole)
        Panel1.Controls.Add(Panel3)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1057, 24)
        Panel1.TabIndex = 0
        ' 
        ' LblRole
        ' 
        LblRole.AutoSize = True
        LblRole.Location = New Point(475, 6)
        LblRole.Name = "LblRole"
        LblRole.Size = New Size(41, 15)
        LblRole.TabIndex = 0
        LblRole.Text = "Label1"
        ' 
        ' Panel3
        ' 
        Panel3.Dock = DockStyle.Left
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(186, 24)
        Panel3.TabIndex = 0
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(PictureBox1)
        Panel4.Controls.Add(lblUsername)
        Panel4.Dock = DockStyle.Top
        Panel4.Location = New Point(0, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(186, 119)
        Panel4.TabIndex = 0
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(57, 49)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(64, 64)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.ForeColor = SystemColors.ControlLight
        lblUsername.Location = New Point(12, 16)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(41, 15)
        lblUsername.TabIndex = 0
        lblUsername.Text = "Label1"
        ' 
        ' Button1
        ' 
        Button1.Dock = DockStyle.Top
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.ForeColor = SystemColors.ControlLight
        Button1.Location = New Point(0, 119)
        Button1.Name = "Button1"
        Button1.Size = New Size(186, 30)
        Button1.TabIndex = 1
        Button1.Text = "Messages"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(44), CByte(58), CByte(71))
        Panel2.Controls.Add(Button6)
        Panel2.Controls.Add(Button5)
        Panel2.Controls.Add(Button4)
        Panel2.Controls.Add(Button3)
        Panel2.Controls.Add(Button2)
        Panel2.Controls.Add(Button1)
        Panel2.Controls.Add(Panel4)
        Panel2.Dock = DockStyle.Left
        Panel2.Location = New Point(0, 24)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(186, 487)
        Panel2.TabIndex = 1
        ' 
        ' Button6
        ' 
        Button6.Dock = DockStyle.Bottom
        Button6.FlatAppearance.BorderSize = 0
        Button6.FlatStyle = FlatStyle.Flat
        Button6.ForeColor = Color.Tomato
        Button6.Location = New Point(0, 457)
        Button6.Name = "Button6"
        Button6.Size = New Size(186, 30)
        Button6.TabIndex = 6
        Button6.Text = "Log out"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Dock = DockStyle.Top
        Button5.FlatAppearance.BorderSize = 0
        Button5.FlatStyle = FlatStyle.Flat
        Button5.ForeColor = SystemColors.ControlLight
        Button5.Location = New Point(0, 239)
        Button5.Name = "Button5"
        Button5.Size = New Size(186, 30)
        Button5.TabIndex = 5
        Button5.Text = "My profile "
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Dock = DockStyle.Top
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.ForeColor = SystemColors.ControlLight
        Button4.Location = New Point(0, 209)
        Button4.Name = "Button4"
        Button4.Size = New Size(186, 30)
        Button4.TabIndex = 4
        Button4.Text = "Billing"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Dock = DockStyle.Top
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.ForeColor = SystemColors.ControlLight
        Button3.Location = New Point(0, 179)
        Button3.Name = "Button3"
        Button3.Size = New Size(186, 30)
        Button3.TabIndex = 3
        Button3.Text = "Inventory"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Dock = DockStyle.Top
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.ForeColor = SystemColors.ControlLight
        Button2.Location = New Point(0, 149)
        Button2.Name = "Button2"
        Button2.Size = New Size(186, 30)
        Button2.TabIndex = 2
        Button2.Text = "Purcahse"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Panel5
        ' 
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(186, 24)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(871, 487)
        Panel5.TabIndex = 2
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1057, 511)
        Controls.Add(Panel5)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form3"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form3"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LblRole As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
