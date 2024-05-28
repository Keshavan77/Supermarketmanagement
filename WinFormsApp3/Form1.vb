Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class Form1
    ' Database connection string - Replace placeholders with actual connection details
    Dim connectionString As String = "Data Source=DESKTOP-6UG4BV5\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True;TrustServerCertificate=True"

    ' Variable to store the logged-in user's ID
    Private loggedInUserID As Integer = -1

    ' Event handler for the Login button click
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Get username and password from textboxes
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        ' Hash the password
        Dim hashedPassword As String = HashPassword(password)

        ' Check if the entered username and hashed password match an admin
        If AuthenticateAdmin(username, hashedPassword) Then
            ' Set the logged-in user ID (assuming 1 is the admin's ID)
            loggedInUserID = 1
            ' Display success message for admin login
            MessageBox.Show("Admin login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Redirect to the admin dashboard or module
            Dim adminDashboardForm As New Form2(username, "admin")
            ' Show the admin dashboard form (Form2)
            adminDashboardForm.Show()
            ' Play welcome sound
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Asterisk)
            Me.Hide() ' Optionally, hide the login form
        ElseIf AuthenticateEmployee(username, password) Then
            ' Retrieve the authenticated employee's ID and set the logged-in user ID
            loggedInUserID = GetAuthenticatedEmployeeID(username)
            ' Get the role of the authenticated employee
            Dim role As String = GetEmployeeRole(loggedInUserID)
            ' Display success message for employee login
            MessageBox.Show("Employee login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Redirect to the employee dashboard or module
            Dim employeeDashboardForm As New Form3(loggedInUserID, role, username)
            employeeDashboardForm.Show()
            ' Play welcome sound
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Asterisk)
            Me.Hide()
        Else
            ' Display error message for invalid username or password
            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Function to authenticate an admin
    Private Function AuthenticateAdmin(username As String, hashedPassword As String) As Boolean
        ' SQL query to check if the provided username and password match an admin
        Dim query As String = "SELECT COUNT(*) FROM Admins WHERE username = @Username AND password = @Password"

        ' Using statement to ensure proper disposal of resources
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query
                command.Parameters.AddWithValue("@Username", username)
                command.Parameters.AddWithValue("@Password", hashedPassword)

                Try
                    ' Open the database connection
                    connection.Open()
                    ' Execute the SQL query and get the count of matching admins
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    ' Return true if there is at least one matching admin, indicating successful authentication
                    Return count > 0
                Catch ex As Exception
                    ' Display error message if an exception occurs during authentication
                    MessageBox.Show("Error authenticating admin: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ' Return false to indicate authentication failure
                    Return False
                End Try
            End Using
        End Using
    End Function

    ' Function to authenticate an employee
    Private Function AuthenticateEmployee(username As String, password As String) As Boolean
        ' SQL query to check if the provided username and password match an employee
        Dim query As String = "SELECT COUNT(*) FROM Employees WHERE username = @Username AND password = @Password"

        ' Using statement to ensure proper disposal of resources
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query
                command.Parameters.AddWithValue("@Username", username)
                command.Parameters.AddWithValue("@Password", password)

                Try
                    ' Open the database connection
                    connection.Open()
                    ' Execute the SQL query and get the count of matching employees
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    ' Return true if there is at least one matching employee, indicating successful authentication
                    Return count > 0
                Catch ex As Exception
                    ' Display error message if an exception occurs during authentication
                    MessageBox.Show("Error authenticating employee: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ' Return false to indicate authentication failure
                    Return False
                End Try
            End Using
        End Using
    End Function

    ' Function to retrieve the authenticated employee's ID
    Private Function GetAuthenticatedEmployeeID(username As String) As Integer
        ' SQL query to retrieve the employee's ID based on the username
        Dim query As String = "SELECT employee_id FROM Employees WHERE username = @Username"

        ' Variable to store the employee's ID
        Dim employeeID As Integer = -1

        ' Using statement to ensure proper disposal of resources
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameter to the SQL query
                command.Parameters.AddWithValue("@Username", username)

                Try
                    ' Open the database connection
                    connection.Open()
                    ' Execute the SQL query and retrieve the employee's ID
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        employeeID = Convert.ToInt32(result)
                    End If
                Catch ex As Exception
                    ' Display error message if an exception occurs during database access
                    MessageBox.Show("Error retrieving employee ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        ' Return the retrieved employee's ID
        Return employeeID
    End Function

    ' Function to retrieve the role of the authenticated employee
    Private Function GetEmployeeRole(employeeID As Integer) As String
        Dim role As String = String.Empty
        ' Query to retrieve the role of the employee based on their ID
        Dim query As String = "SELECT job_role FROM Employees WHERE employee_id = @EmployeeID"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@EmployeeID", employeeID)

                Try
                    connection.Open()
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        role = Convert.ToString(result)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error retrieving employee role: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Return role
    End Function

    ' Function to hash the password
    Private Function HashPassword(password As String) As String
        ' Convert the password string to byte array
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)

        ' Create a SHA256 hash algorithm instance
        Using sha256 As SHA256 = SHA256.Create()
            ' Compute the hash
            Dim hashBytes As Byte() = sha256.ComputeHash(bytes)
            ' Convert the byte array to a hexadecimal string
            Dim hashStringBuilder As New StringBuilder()
            For Each b As Byte In hashBytes
                hashStringBuilder.Append(b.ToString("x2"))
            Next
            ' Return the hashed password
            Return hashStringBuilder.ToString()
        End Using
    End Function

    ' Event handler for the checkbox to show or hide the password
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        ' Toggle the password visibility in the password TextBox
        TextBox2.UseSystemPasswordChar = Not CheckBox1.Checked
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim createAccountForm As New CreateAccountForm()
        createAccountForm.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        End
    End Sub
End Class
