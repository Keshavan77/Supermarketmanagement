<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateAccountForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateAccountForm))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        txtConfirmPassword = New TextBox()
        btnCreateAccount = New Button()
        btnCancel = New Button()
        Label4 = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Location = New Point(360, 156)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 15)
        Label1.TabIndex = 0
        Label1.Text = "User name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Location = New Point(360, 224)
        Label2.Name = "Label2"
        Label2.Size = New Size(57, 15)
        Label2.TabIndex = 1
        Label2.Text = "Password"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Location = New Point(360, 290)
        Label3.Name = "Label3"
        Label3.Size = New Size(99, 15)
        Label3.TabIndex = 2
        Label3.Text = "Confirm pasword"
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(496, 148)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(113, 23)
        txtUsername.TabIndex = 3
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(496, 216)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(113, 23)
        txtPassword.TabIndex = 4
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.Location = New Point(496, 287)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.Size = New Size(113, 23)
        txtConfirmPassword.TabIndex = 5
        ' 
        ' btnCreateAccount
        ' 
        btnCreateAccount.BackColor = Color.Transparent
        btnCreateAccount.FlatStyle = FlatStyle.Popup
        btnCreateAccount.Location = New Point(372, 357)
        btnCreateAccount.Name = "btnCreateAccount"
        btnCreateAccount.Size = New Size(75, 23)
        btnCreateAccount.TabIndex = 6
        btnCreateAccount.Text = "Create"
        btnCreateAccount.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Transparent
        btnCancel.FlatStyle = FlatStyle.Popup
        btnCancel.Location = New Point(507, 357)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 7
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(419, 88)
        Label4.Name = "Label4"
        Label4.Size = New Size(146, 20)
        Label4.TabIndex = 8
        Label4.Text = "Create account page"
        ' 
        ' CreateAccountForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1000, 556)
        Controls.Add(Label4)
        Controls.Add(btnCancel)
        Controls.Add(btnCreateAccount)
        Controls.Add(txtConfirmPassword)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "CreateAccountForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "CreateAccountForm"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents btnCreateAccount As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label4 As Label
End Class
