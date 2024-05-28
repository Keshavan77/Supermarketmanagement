Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class InventoryManagementForm
    Private connectionString As String = "Data Source=DESKTOP-6UG4BV5\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
    Private inventoryList As New List(Of Inventory)()

    Private Sub InventoryManagementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInventoryData()
    End Sub
    ' Public method to refresh the DataGridView
    Public Sub RefreshInventoryData()
        LoadInventoryData()
    End Sub
    ' Function to load inventory data into DataGridView
    Private Sub LoadInventoryData()
        ' Define the SQL query to select all columns from the Inventory table
        Dim query As String = "SELECT * FROM Inventory"

        Try
            ' Open a connection to the database
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' Create a DataTable to hold the query results
                Dim dataTable As New DataTable()

                ' Create a SqlDataAdapter to execute the query and fill the DataTable
                Using adapter As New SqlDataAdapter(query, connection)
                    adapter.Fill(dataTable)
                End Using

                ' Clear existing data in the inventory list
                inventoryList.Clear()

                ' Populate the inventory list with data from the DataTable
                For Each row As DataRow In dataTable.Rows
                    Dim inventoryItem As New Inventory() With {
                        .ProductID = Convert.ToInt32(row("product_id")),
                        .ProductName = row("product_name").ToString(),
                        .Category = row("category").ToString(),
                        .Price = If(row("price") IsNot DBNull.Value, Convert.ToDecimal(row("price")), 0),
                        .QuantityAvailable = If(row("quantity_available") IsNot DBNull.Value, Convert.ToInt32(row("quantity_available")), 0)
                    }
                    inventoryList.Add(inventoryItem)
                Next

                ' Bind the inventory list to the DataGridView
                DataGridView1.DataSource = Nothing
                DataGridView1.DataSource = inventoryList
            End Using
        Catch ex As Exception
            ' Display an error message if there's an exception
            MessageBox.Show("Error loading inventory data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim productName As String = txtProductName.Text
        Dim category As String = txtCategory.Text
        Dim price As Decimal
        Dim quantity As Integer

        If Not Decimal.TryParse(txtPrice.Text, price) Then
            MessageBox.Show("Invalid price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not Integer.TryParse(txtQuantity.Text, quantity) Then
            MessageBox.Show("Invalid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "INSERT INTO Inventory (product_name, category, price, quantity_available) VALUES (@ProductName, @Category, @Price, @Quantity)"

                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ProductName", productName)
                    command.Parameters.AddWithValue("@Category", category)
                    command.Parameters.AddWithValue("@Price", price)
                    command.Parameters.AddWithValue("@Quantity", quantity)
                    command.ExecuteNonQuery()
                End Using
            End Using

            LoadInventoryData()
            ClearInputFields()

            MessageBox.Show("Product added to inventory.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As SqlException
            MessageBox.Show("Error adding product to inventory: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error adding product to inventory: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim selectedRowIndex As Integer = DataGridView1.CurrentCell.RowIndex
        If selectedRowIndex >= 0 AndAlso selectedRowIndex < inventoryList.Count Then
            Dim productID As Integer = inventoryList(selectedRowIndex).ProductID
            Dim productName As String = txtProductName.Text
            Dim category As String = txtCategory.Text
            Dim price As Decimal
            Dim quantity As Integer

            If Not Decimal.TryParse(txtPrice.Text, price) Then
                MessageBox.Show("Invalid price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If Not Integer.TryParse(txtQuantity.Text, quantity) Then
                MessageBox.Show("Invalid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Try
                Using connection As New SqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "UPDATE Inventory SET product_name = @ProductName, category = @Category, price = @Price, quantity_available = @Quantity WHERE product_id = @ProductID"

                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@ProductName", productName)
                        command.Parameters.AddWithValue("@Category", category)
                        command.Parameters.AddWithValue("@Price", price)
                        command.Parameters.AddWithValue("@Quantity", quantity)
                        command.Parameters.AddWithValue("@ProductID", productID)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                LoadInventoryData()

                MessageBox.Show("Product details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error updating product details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please select a product to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim selectedRowIndex As Integer = DataGridView1.CurrentCell.RowIndex
        If selectedRowIndex >= 0 AndAlso selectedRowIndex < inventoryList.Count Then
            Dim productID As Integer = inventoryList(selectedRowIndex).ProductID

            Try
                Using connection As New SqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "DELETE FROM Inventory WHERE product_id = @ProductID"

                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@ProductID", productID)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                LoadInventoryData()

                MessageBox.Show("Product deleted from inventory successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error deleting product from inventory: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub DataGridView1_SelectionChange(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        ' Check if a row is selected
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the selected inventory item from the DataGridView
            Dim selectedInventory As Inventory = TryCast(DataGridView1.SelectedRows(0).DataBoundItem, Inventory)

            ' Display the selected inventory item's details in textboxes
            If selectedInventory IsNot Nothing Then
                txtProductName.Text = selectedInventory.ProductName
                txtCategory.Text = selectedInventory.Category
                txtPrice.Text = selectedInventory.Price.ToString()
                txtQuantity.Text = selectedInventory.QuantityAvailable.ToString()
            End If
        End If
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearInputFields()
    End Sub

    Private Sub ClearInputFields()
        txtProductName.Clear()
        txtCategory.Clear()
        txtPrice.Clear()
        txtQuantity.Clear()
    End Sub
End Class

Public Class Inventory
    Public Property ProductID As Integer
    Public Property ProductName As String
    Public Property Category As String
    Public Property Price As Decimal
    Public Property QuantityAvailable As Integer
End Class
