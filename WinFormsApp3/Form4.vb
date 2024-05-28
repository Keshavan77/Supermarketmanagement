Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Form4
    ' Connection string for the database
    Private connectionString As String = "Data Source=DESKTOP-6UG4BV5\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    ' Declare a private field to store the authenticated employee's ID
    Private ReadOnly authenticatedEmployeeID As Integer

    ' Constructor to receive the authenticated employee's ID
    Public Sub New(authenticatedEmployeeID As Integer)
        InitializeComponent()
        Me.authenticatedEmployeeID = authenticatedEmployeeID
    End Sub

    ' Method to handle the purchase operation
    Public Sub PurchaseProduct(productName As String, quantity As Integer, price As Decimal, authenticatedEmployeeID As Integer)
        ' Retrieve employee ID and purchase date
        Dim employeeID As Integer = authenticatedEmployeeID
        Dim purchaseDate As DateTime = DateTime.Now

        ' Calculate the total price
        Dim totalPrice As Decimal = quantity * price

        ' Check if authentication is successful
        If employeeID <> -1 Then
            Try
                ' Insert a new record into the Purchases table
                Using connection As New SqlConnection(connectionString)
                    connection.Open()
                    Dim purchaseQuery As String = "INSERT INTO Purchases (product_name, employee_id, purchase_date, quantity, unit_price, total_price) VALUES (@ProductName, @EmployeeID, @PurchaseDate, @Quantity, @Price, @TotalPrice)"
                    Using command As New SqlCommand(purchaseQuery, connection)
                        command.Parameters.AddWithValue("@ProductName", productName)
                        command.Parameters.AddWithValue("@EmployeeID", employeeID)
                        command.Parameters.AddWithValue("@PurchaseDate", purchaseDate)
                        command.Parameters.AddWithValue("@Quantity", quantity)
                        command.Parameters.AddWithValue("@Price", price)
                        command.Parameters.AddWithValue("@TotalPrice", totalPrice)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                ' Update the Inventory table with the purchased product
                UpdateInventory(productName, quantity, price)

                MessageBox.Show("Purchase completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error purchasing product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Authentication failed. Please provide valid credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    ' Method to update the Inventory table with the purchased product
    Private Sub UpdateInventory(productName As String, quantity As Integer, price As Decimal)
        Try
            ' Check if the product exists in the Inventory table
            Dim existingQuantity As Integer = 0

            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim checkProductQuery As String = "SELECT quantity_available FROM Inventory WHERE product_name = @ProductName"

                Using command As New SqlCommand(checkProductQuery, connection)
                    command.Parameters.AddWithValue("@ProductName", productName)
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        existingQuantity = Convert.ToInt32(result)
                    End If
                End Using
            End Using

            ' Calculate the total quantity after the purchase
            Dim totalQuantity As Integer = existingQuantity + quantity

            If existingQuantity > 0 Then
                ' If the product exists, update its quantity
                Using connection As New SqlConnection(connectionString)
                    connection.Open()
                    Dim updateQuantityQuery As String = "UPDATE Inventory SET quantity_available = @TotalQuantity WHERE product_name = @ProductName"
                    Using command As New SqlCommand(updateQuantityQuery, connection)
                        command.Parameters.AddWithValue("@TotalQuantity", totalQuantity)
                        command.Parameters.AddWithValue("@ProductName", productName)
                        command.ExecuteNonQuery()
                    End Using
                End Using
            Else
                ' If the product does not exist, insert a new record
                Using connection As New SqlConnection(connectionString)
                    connection.Open()
                    Dim insertProductQuery As String = "INSERT INTO Inventory (product_name, quantity_available, price) VALUES (@ProductName, @Quantity, @Price)"
                    Using command As New SqlCommand(insertProductQuery, connection)
                        command.Parameters.AddWithValue("@ProductName", productName)
                        command.Parameters.AddWithValue("@Quantity", quantity)
                        command.Parameters.AddWithValue("@Price", price)
                        command.ExecuteNonQuery()
                    End Using
                End Using
            End If
        Catch ex As Exception
            ' Handle update error
            MessageBox.Show("Error updating inventory: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' Method to get the employee ID of the authenticated employee
    Private Function GetAuthenticatedEmployeeID() As Integer
        ' implementation to retrieve the authenticated employee's ID 
        Return 1
    End Function

    ' Button click event handler to initiate the purchase process
    Private Sub btnPurchase_Click(sender As Object, e As EventArgs) Handles btnPurchase.Click
        ' Retrieve product name, quantity, and price from text boxes
        Dim productName As String = txtProductName.Text
        Dim quantity As Integer
        Dim price As Decimal

        If Integer.TryParse(txtQuantity.Text, quantity) AndAlso Decimal.TryParse(txtPrice.Text, price) Then
            ' Get the authenticated employee's ID
            Dim authenticatedEmployeeID As Integer = Me.authenticatedEmployeeID

            ' Call the PurchaseProduct method with the provided details
            Dim form4 As New Form4(authenticatedEmployeeID)
            form4.PurchaseProduct(productName, quantity, price, authenticatedEmployeeID)
        Else
            MessageBox.Show("Invalid quantity or price. Please enter valid values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        ' After completing a purchase, refresh the inventory data
        Dim inventoryForm As InventoryManagementForm = TryCast(Application.OpenForms("InventoryManagementForm"), InventoryManagementForm)
        If inventoryForm IsNot Nothing Then
            inventoryForm.RefreshInventoryData()
        End If
    End Sub
End Class


