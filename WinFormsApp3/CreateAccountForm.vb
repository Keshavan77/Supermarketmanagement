Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class CreateAccountForm
    Dim connectionString As String = "Data Source=DESKTOP-6UG4BV5\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True;TrustServerCertificate=True"

    Dim timer As New Timer()

    Public Sub New()
        InitializeComponent()

        ' Configure the timer
        timer.Interval = 1000 ' 1 second
        AddHandler timer.Tick, AddressOf Timer_Tick_HidePassword
    End Sub

    Private Sub Timer_Tick_HidePassword(sender As Object, e As EventArgs)
        ' Hide the password after 1 second
        txtConfirmPassword.UseSystemPasswordChar = True
        timer.Stop()
    End Sub

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged
        ' Show the password for 1 second when text is changed
        txtConfirmPassword.UseSystemPasswordChar = False
        timer.Stop()
        timer.Start()
    End Sub

    Private Sub btnCreateAccount_Click(sender As Object, e As EventArgs) Handles btnCreateAccount.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text
        Dim confirmPassword As String = txtConfirmPassword.Text

        ' Validate input
        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Username and password are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If password <> confirmPassword Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Prompt user for passkey
        Dim passkey As String = InputBox("Enter organization passkey:", "Passkey")

        If passkey <> "organization" Then ' Assuming "kesh" is the organization passkey
            MessageBox.Show("Invalid organization passkey.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If UsernameExists(username) Then
            MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Hash password
        Dim hashedPassword As String = HashPassword(password)

        ' Insert into database
        Dim query As String = "INSERT INTO Admins (username, password) VALUES (@Username, @Password)"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Username", username)
                command.Parameters.AddWithValue("@Password", hashedPassword)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    MessageBox.Show("Admin account created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim redirectTimer As New Timer()
                    redirectTimer.Interval = 1000 ' 1 second
                    AddHandler redirectTimer.Tick, AddressOf RedirectTimer_Tick
                    redirectTimer.Start()
                Catch ex As Exception
                    MessageBox.Show("Error creating admin account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub


    Private Sub RedirectTimer_Tick(sender As Object, e As EventArgs)
        Dim timer As Timer = CType(sender, Timer)
        timer.Stop()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Function UsernameExists(username As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM Admins WHERE username = @Username"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Username", username)
                connection.Open()
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim hashedBytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()

            For Each b As Byte In hashedBytes
                builder.Append(b.ToString("x2")) ' Convert byte to hexadecimal string
            Next

            Return builder.ToString()
        End Using
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
