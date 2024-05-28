Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Form5
    ' Employee object to hold current employee details
    Private currentEmployee As New Employee()

    ' Database operations object
    Private dbOperations As New DatabaseOperations()

    ' Event handler for form load
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load employee details into the DataGridView
        LoadEmployeeDataGridView()
    End Sub

    ' Function to load employee details into the DataGridView
    Private Sub LoadEmployeeDataGridView()
        ' Retrieve all employees from the database
        Dim employees As List(Of Employee) = dbOperations.GetAllEmployees()

        ' Bind employee data to the DataGridView
        DataGridView2.DataSource = employees

        ' Hide certain columns if needed

    End Sub

    ' Event handler for DataGridView selection change
    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged
        ' Check if a row is selected
        If DataGridView2.SelectedRows.Count > 0 Then
            ' Get the selected employee
            currentEmployee = TryCast(DataGridView2.SelectedRows(0).DataBoundItem, Employee)

            ' Display employee details in the text boxes
            DisplayEmployeeDetails()
        End If
    End Sub

    ' Function to display employee details in text boxes
    Private Sub DisplayEmployeeDetails()
        txtUsername.Text = currentEmployee.Username
        txtPassword.Text = currentEmployee.Password
        txtPhoneNumber.Text = currentEmployee.PhoneNumber
        txtJobRole.Text = currentEmployee.JobRole
        txtSalary.Text = currentEmployee.Salary.ToString()
        txtDateOfBirth.Text = currentEmployee.DateOfBirth.ToString("yyy-MM-dd")

    End Sub

    ' Event handler for Add button click
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Check if any of the text boxes are empty
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
       String.IsNullOrWhiteSpace(txtPassword.Text) OrElse
       String.IsNullOrWhiteSpace(txtPhoneNumber.Text) OrElse
       String.IsNullOrWhiteSpace(txtJobRole.Text) OrElse
       String.IsNullOrWhiteSpace(txtSalary.Text) OrElse
       String.IsNullOrWhiteSpace(txtDateOfBirth.Text) Then
            MessageBox.Show("Please fill in all fields to add the employee.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Create a new employee object with data from the form
        Dim newEmployee As New Employee() With {
        .Username = txtUsername.Text,
        .Password = txtPassword.Text,
        .PhoneNumber = txtPhoneNumber.Text,
        .JobRole = txtJobRole.Text,
        .Salary = Decimal.Parse(txtSalary.Text),
        .DateOfBirth = txtDateOfBirth.Text
    }

        ' Calculate age
        Dim age As Integer = DateTime.Now.Year - newEmployee.DateOfBirth.Year

        ' Check if the age of the new employee is within the valid range
        If age < 16 Then
            MessageBox.Show("Employee must be at least 16 years old.", "Age Requirement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        ElseIf age > 70 Then
            MessageBox.Show("Invalid date of birth. Employee age cannot be above 70 years.", "Invalid Date of Birth", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Confirmation message for adding an employee
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to add this employee?", "Confirm Addition", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check user response
        If result = DialogResult.Yes Then
            ' Add employee to the database
            dbOperations.AddEmployee(newEmployee)

            ' Refresh DataGridView to reflect changes
            LoadEmployeeDataGridView()

            ' Display success message
            MessageBox.Show("New employee added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' Display a message indicating the employee is not added
            MessageBox.Show("Employee was not added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



    ' Event handler for Update button click
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Update employee details from the form
        UpdateCurrentEmployeeDetails()

        ' Update employee details in the database
        dbOperations.UpdateEmployeeDetails(currentEmployee)

        ' Refresh DataGridView to reflect changes
        LoadEmployeeDataGridView()

        ' Display success message
        MessageBox.Show("Employee details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Event handler for Delete button click
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Confirm deletion with user
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Delete employee from the database
            dbOperations.DeleteEmployee(currentEmployee.EmployeeID)

            ' Refresh DataGridView to reflect changes
            LoadEmployeeDataGridView()

            ' Display success message
            MessageBox.Show("Employee deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Function to update current employee details from form controls
    Private Sub UpdateCurrentEmployeeDetails()
        currentEmployee.Username = txtUsername.Text
        currentEmployee.Password = txtPassword.Text
        currentEmployee.PhoneNumber = txtPhoneNumber.Text
        currentEmployee.JobRole = txtJobRole.Text
        currentEmployee.Salary = Decimal.Parse(txtSalary.Text)
        currentEmployee.DateOfBirth = txtDateOfBirth.Text
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearEmployeeDetails()
    End Sub

    Private Sub ClearEmployeeDetails()
        ' Clear all textboxes
        For Each control As Control In Controls
            If TypeOf control Is TextBox Then
                CType(control, TextBox).Clear()
            End If
        Next
    End Sub
    Private Sub txtDateOfBirth_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDateOfBirth.KeyPress
        ' Allowing only numeric digits and hyphen (-) to be entered
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "-" AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDateOfBirth_TextChanged(sender As Object, e As EventArgs) Handles txtDateOfBirth.TextChanged
        Dim formattedDate As String = FormatDateInput(txtDateOfBirth.Text)
        txtDateOfBirth.Text = formattedDate
        txtDateOfBirth.SelectionStart = txtDateOfBirth.Text.Length
    End Sub

    Private Function FormatDateInput(input As String) As String
        ' Remove non-numeric characters
        Dim numericInput As String = New String(input.Where(Function(c) Char.IsDigit(c) OrElse c = "-").ToArray())

        ' Limit length to 10 characters
        If numericInput.Length > 10 Then
            numericInput = numericInput.Substring(0, 10)
        End If

        ' Apply formatting for YYYY-MM-DD
        If numericInput.Length >= 5 AndAlso numericInput(4) <> "-" Then
            numericInput = numericInput.Insert(4, "-")
        End If
        If numericInput.Length >= 8 AndAlso numericInput(7) <> "-" Then
            numericInput = numericInput.Insert(7, "-")
        End If

        Return numericInput
    End Function
End Class

' Employee class to represent employee details
Public Class Employee
    Public Property EmployeeID As Integer
    Public Property Username As String
    Public Property Password As String
    Public Property PhoneNumber As String
    Public Property JobRole As String
    Public Property Salary As Decimal
    Public Property DateOfBirth As Date
End Class



' Database operations class to handle database interactions
Public Class DatabaseOperations
    ' Connection string for connecting to the database
    Private connectionString As String = "Data Source=DESKTOP-6UG4BV5\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    Public Function GetAllEmployees() As List(Of Employee)
        Dim employees As New List(Of Employee)()

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT * FROM Employees"
                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim employee As New Employee() With {
                            .EmployeeID = Convert.ToInt32(reader("employee_id")),
                            .Username = reader("username").ToString(),
                            .Password = reader("password").ToString(),
                            .PhoneNumber = reader("phone_number").ToString(),
                            .JobRole = reader("job_role").ToString(),
                            .Salary = Convert.ToDecimal(reader("salary")),
                            .DateOfBirth = Convert.ToDateTime(reader("date_of_birth"))
                        }
                            employees.Add(employee)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As SqlException
            MessageBox.Show("Error retrieving employees from the database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return employees
    End Function

    ' Method to add a new employee to the database
    Public Sub AddEmployee(newEmployee As Employee)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "INSERT INTO Employees (username, password, phone_number, job_role, salary, date_of_birth) VALUES (@Username, @Password, @PhoneNumber, @JobRole, @Salary, @DateOfBirth)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Username", newEmployee.Username)
                command.Parameters.AddWithValue("@Password", newEmployee.Password)
                command.Parameters.AddWithValue("@PhoneNumber", newEmployee.PhoneNumber)
                command.Parameters.AddWithValue("@JobRole", newEmployee.JobRole)
                command.Parameters.AddWithValue("@Salary", newEmployee.Salary)
                command.Parameters.AddWithValue("@DateOfBirth", newEmployee.DateOfBirth)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' Method to update employee details in the database
    Public Sub UpdateEmployeeDetails(employee As Employee)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "UPDATE Employees SET username = @Username, password = @Password, phone_number = @PhoneNumber, job_role = @JobRole, salary = @Salary, date_of_birth = @DateOfBirth WHERE employee_id = @EmployeeID"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Username", employee.Username)
                command.Parameters.AddWithValue("@Password", employee.Password)
                command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber)
                command.Parameters.AddWithValue("@JobRole", employee.JobRole)
                command.Parameters.AddWithValue("@Salary", employee.Salary)
                command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth)
                command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' Method to delete an employee from the database
    Public Sub DeleteEmployee(employeeID As Integer)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "DELETE FROM Employees WHERE employee_id = @EmployeeID"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@EmployeeID", employeeID)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
