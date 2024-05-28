<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        components = New ComponentModel.Container()
        btnAdd = New Button()
        btnDelete = New Button()
        btnUpdate = New Button()
        DataGridView2 = New DataGridView()
        EmployeeIDDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        UsernameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PasswordDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PhoneNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        JobRoleDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        SalaryDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DateOfBirthDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        EmployeeBindingSource = New BindingSource(components)
        btnCancel = New Button()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        txtDateOfBirth = New TextBox()
        txtSalary = New TextBox()
        txtJobRole = New TextBox()
        txtPhoneNumber = New TextBox()
        txtPassword = New TextBox()
        txtUsername = New TextBox()
        Label7 = New Label()
        CType(DataGridView2, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.DarkSeaGreen
        btnAdd.Location = New Point(12, 226)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 23)
        btnAdd.TabIndex = 12
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.RosyBrown
        btnDelete.Location = New Point(143, 226)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(75, 23)
        btnDelete.TabIndex = 13
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.DarkGoldenrod
        btnUpdate.Location = New Point(267, 226)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(75, 23)
        btnUpdate.TabIndex = 14
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' DataGridView2
        ' 
        DataGridView2.AutoGenerateColumns = False
        DataGridView2.BackgroundColor = SystemColors.Control
        DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView2.Columns.AddRange(New DataGridViewColumn() {EmployeeIDDataGridViewTextBoxColumn, UsernameDataGridViewTextBoxColumn, PasswordDataGridViewTextBoxColumn, PhoneNumberDataGridViewTextBoxColumn, JobRoleDataGridViewTextBoxColumn, SalaryDataGridViewTextBoxColumn, DateOfBirthDataGridViewTextBoxColumn})
        DataGridView2.DataSource = EmployeeBindingSource
        DataGridView2.Location = New Point(2, 3)
        DataGridView2.Name = "DataGridView2"
        DataGridView2.Size = New Size(767, 217)
        DataGridView2.TabIndex = 16
        ' 
        ' EmployeeIDDataGridViewTextBoxColumn
        ' 
        EmployeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID"
        EmployeeIDDataGridViewTextBoxColumn.HeaderText = "EmployeeID"
        EmployeeIDDataGridViewTextBoxColumn.Name = "EmployeeIDDataGridViewTextBoxColumn"
        ' 
        ' UsernameDataGridViewTextBoxColumn
        ' 
        UsernameDataGridViewTextBoxColumn.DataPropertyName = "Username"
        UsernameDataGridViewTextBoxColumn.HeaderText = "Username"
        UsernameDataGridViewTextBoxColumn.Name = "UsernameDataGridViewTextBoxColumn"
        ' 
        ' PasswordDataGridViewTextBoxColumn
        ' 
        PasswordDataGridViewTextBoxColumn.DataPropertyName = "Password"
        PasswordDataGridViewTextBoxColumn.HeaderText = "Password"
        PasswordDataGridViewTextBoxColumn.Name = "PasswordDataGridViewTextBoxColumn"
        PasswordDataGridViewTextBoxColumn.Visible = False
        ' 
        ' PhoneNumberDataGridViewTextBoxColumn
        ' 
        PhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber"
        PhoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber"
        PhoneNumberDataGridViewTextBoxColumn.Name = "PhoneNumberDataGridViewTextBoxColumn"
        ' 
        ' JobRoleDataGridViewTextBoxColumn
        ' 
        JobRoleDataGridViewTextBoxColumn.DataPropertyName = "JobRole"
        JobRoleDataGridViewTextBoxColumn.HeaderText = "JobRole"
        JobRoleDataGridViewTextBoxColumn.Name = "JobRoleDataGridViewTextBoxColumn"
        ' 
        ' SalaryDataGridViewTextBoxColumn
        ' 
        SalaryDataGridViewTextBoxColumn.DataPropertyName = "Salary"
        SalaryDataGridViewTextBoxColumn.HeaderText = "Salary"
        SalaryDataGridViewTextBoxColumn.Name = "SalaryDataGridViewTextBoxColumn"
        ' 
        ' DateOfBirthDataGridViewTextBoxColumn
        ' 
        DateOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DateOfBirth"
        DateOfBirthDataGridViewTextBoxColumn.HeaderText = "DateOfBirth"
        DateOfBirthDataGridViewTextBoxColumn.Name = "DateOfBirthDataGridViewTextBoxColumn"
        ' 
        ' EmployeeBindingSource
        ' 
        EmployeeBindingSource.DataSource = GetType(Employee)
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = SystemColors.ActiveCaption
        btnCancel.Location = New Point(396, 226)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 29
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(285, 323)
        Label6.Name = "Label6"
        Label6.Size = New Size(73, 15)
        Label6.TabIndex = 28
        Label6.Text = "Date of birth"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(285, 276)
        Label5.Name = "Label5"
        Label5.Size = New Size(38, 15)
        Label5.TabIndex = 27
        Label5.Text = "Salary"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 423)
        Label4.Name = "Label4"
        Label4.Size = New Size(48, 15)
        Label4.TabIndex = 26
        Label4.Text = "Job role"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 375)
        Label3.Name = "Label3"
        Label3.Size = New Size(86, 15)
        Label3.TabIndex = 25
        Label3.Text = "Phone number"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 323)
        Label2.Name = "Label2"
        Label2.Size = New Size(57, 15)
        Label2.TabIndex = 24
        Label2.Text = "Password"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 276)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 15)
        Label1.TabIndex = 23
        Label1.Text = "Username"
        ' 
        ' txtDateOfBirth
        ' 
        txtDateOfBirth.Location = New Point(369, 310)
        txtDateOfBirth.Name = "txtDateOfBirth"
        txtDateOfBirth.Size = New Size(131, 23)
        txtDateOfBirth.TabIndex = 22
        ' 
        ' txtSalary
        ' 
        txtSalary.Location = New Point(369, 268)
        txtSalary.Name = "txtSalary"
        txtSalary.Size = New Size(131, 23)
        txtSalary.TabIndex = 21
        ' 
        ' txtJobRole
        ' 
        txtJobRole.Location = New Point(118, 415)
        txtJobRole.Name = "txtJobRole"
        txtJobRole.Size = New Size(131, 23)
        txtJobRole.TabIndex = 20
        ' 
        ' txtPhoneNumber
        ' 
        txtPhoneNumber.Location = New Point(118, 367)
        txtPhoneNumber.Name = "txtPhoneNumber"
        txtPhoneNumber.Size = New Size(131, 23)
        txtPhoneNumber.TabIndex = 19
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(118, 315)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(131, 23)
        txtPassword.TabIndex = 18
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(118, 268)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(131, 23)
        txtUsername.TabIndex = 17
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(506, 315)
        Label7.Name = "Label7"
        Label7.Size = New Size(107, 15)
        Label7.TabIndex = 30
        Label7.Text = "e.g;-YYYY-MM-DD"
        ' 
        ' Form5
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(937, 490)
        Controls.Add(Label7)
        Controls.Add(btnCancel)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtDateOfBirth)
        Controls.Add(txtSalary)
        Controls.Add(txtJobRole)
        Controls.Add(txtPhoneNumber)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        Controls.Add(DataGridView2)
        Controls.Add(btnUpdate)
        Controls.Add(btnDelete)
        Controls.Add(btnAdd)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form5"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form5"
        CType(DataGridView2, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents EmployeeBindingSource As BindingSource
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDateOfBirth As TextBox
    Friend WithEvents txtSalary As TextBox
    Friend WithEvents txtJobRole As TextBox
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents EmployeeIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UsernameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PasswordDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PhoneNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobRoleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SalaryDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateOfBirthDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
