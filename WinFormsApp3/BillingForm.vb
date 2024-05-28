Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms

Public Class BillingForm
    ' Connection string for the database
    Private connectionString As String = "Data Source=DESKTOP-6UG4BV5\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    ' List to store cart items
    Private cartItems As New List(Of CartItem)()

    ' Flag to track if billing is done
    Private billingDone As Boolean = False

    ' Method to search products by ID or name
    Private Sub SearchProducts(searchTerm As String)
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT * FROM Inventory WHERE product_id = @SearchTerm OR product_name LIKE @ProductName"
                Using command As New SqlCommand(query, connection)
                    ' Check if the search term is numeric (product ID) or alphanumeric (product name)
                    If Integer.TryParse(searchTerm, Nothing) Then
                        ' Set parameter value for product ID
                        command.Parameters.AddWithValue("@SearchTerm", searchTerm)
                        ' No need to search by product name in this case
                        command.Parameters.AddWithValue("@ProductName", DBNull.Value)
                    Else
                        ' Set parameter value for product name
                        command.Parameters.AddWithValue("@SearchTerm", DBNull.Value)
                        ' Set parameter value for product name with wildcard for LIKE comparison
                        command.Parameters.AddWithValue("@ProductName", "%" & searchTerm & "%")
                    End If

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' Populate textboxes with product details
                            txtProductID.Text = reader("product_id").ToString()
                            txtProductName.Text = reader("product_name").ToString()
                            txtPrice.Text = reader("price").ToString()
                            txtQuantityAvailable.Text = reader("quantity_available").ToString()
                        Else
                            MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error searching products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Button click event handler for searching products
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = txtSearchTerm.Text.Trim()
        If Not String.IsNullOrEmpty(searchTerm) Then
            SearchProducts(searchTerm)
        Else
            MessageBox.Show("Please enter a search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Method to handle adding product to the cart
    Private Sub AddToCart()
        ' Retrieve product ID, name, price, and quantity from the textboxes
        Dim productID As Integer
        Dim productName As String = txtProductName.Text
        Dim price As Decimal
        Dim quantity As Integer

        If Integer.TryParse(txtProductID.Text, productID) AndAlso
       Decimal.TryParse(txtPrice.Text, price) AndAlso
       Integer.TryParse(txtQuantity.Text, quantity) Then
            ' Check if quantity available is sufficient
            Dim quantityAvailable As Integer = Integer.Parse(txtQuantityAvailable.Text)
            If quantity <= quantityAvailable Then
                ' Check if the product already exists in the cart
                Dim existingCartItem As CartItem = cartItems.FirstOrDefault(Function(item) item.ProductID = productID)
                If existingCartItem IsNot Nothing Then
                    ' Update the quantity of the existing item
                    existingCartItem.Quantity += quantity
                    existingCartItem.TotalPrice = existingCartItem.Quantity * existingCartItem.Price
                Else
                    ' Update inventory to reflect reduced quantity
                    Try
                        Using connection As New SqlConnection(connectionString)
                            connection.Open()
                            Dim updateQuery As String = "UPDATE Inventory SET quantity_available = quantity_available - @Quantity WHERE product_id = @ProductID;"
                            Using command As New SqlCommand(updateQuery, connection)
                                command.Parameters.AddWithValue("@Quantity", quantity)
                                command.Parameters.AddWithValue("@ProductID", productID)
                                command.ExecuteNonQuery()
                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show("Error updating inventory: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End Try

                    ' Add item to cart
                    Dim total_price As Decimal = quantity * price
                    Dim cartItem As New CartItem(productID, productName, price, quantity, total_price)
                    cartItems.Add(cartItem)
                End If

                ' Update cart DataGridView
                UpdateCartDataGridView()

                ' Clear input fields
                ClearInputFields()
            Else
                MessageBox.Show("Insufficient quantity available in inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Invalid input. Please enter valid values for product ID, price, and quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Method to remove a product from the cart
    Private Sub RemoveFromCart(productID As Integer)
        ' Find the item in the cart with the given product ID
        Dim itemToRemove As CartItem = cartItems.Find(Function(item) item.ProductID = productID)

        If itemToRemove IsNot Nothing Then
            ' Ask the user if they want to remove the entire product or just decrease the quantity
            Dim promptMessage As String = "Do you want to remove the entire product from the cart?" & vbCrLf & vbCrLf &
                                      "Click 'Yes' to remove the entire product." & vbCrLf &
                                      "Click 'No' to decrease the quantity." & vbCrLf &
                                      "Click 'Cancel' to cancel the operation."

            Dim result As DialogResult = MessageBox.Show(promptMessage, "Remove Product", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Yes ' Remove the entire product
                    ' Update inventory to reflect increased quantity
                    Try
                        Using connection As New SqlConnection(connectionString)
                            connection.Open()
                            Dim updateQuery As String = "UPDATE Inventory SET quantity_available = quantity_available + @Quantity WHERE product_id = @ProductID;"
                            Using command As New SqlCommand(updateQuery, connection)
                                command.Parameters.AddWithValue("@Quantity", itemToRemove.Quantity)
                                command.Parameters.AddWithValue("@ProductID", productID)
                                command.ExecuteNonQuery()
                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show("Error updating inventory: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End Try

                    ' Remove the item from the cart
                    cartItems.Remove(itemToRemove)

                    ' Update cart DataGridView
                    UpdateCartDataGridView()

                    ' Clear input fields
                    ClearInputFields()

                    ' Show a message indicating the removal
                    MessageBox.Show("Product removed from the cart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Case DialogResult.No ' Decrease the quantity
                    Dim quantityToRemove As String = InputBox("Enter the quantity you want to remove:", "Remove Quantity", "1")
                    Dim quantityToRemoveInt As Integer

                    If Integer.TryParse(quantityToRemove, quantityToRemoveInt) Then
                        If quantityToRemoveInt >= itemToRemove.Quantity Then
                            ' If the quantity to remove is greater than or equal to the current quantity, remove the entire product
                            ' Update inventory to reflect increased quantity
                            Try
                                Using connection As New SqlConnection(connectionString)
                                    connection.Open()
                                    Dim updateQuery As String = "UPDATE Inventory SET quantity_available = quantity_available + @Quantity WHERE product_id = @ProductID;"
                                    Using command As New SqlCommand(updateQuery, connection)
                                        command.Parameters.AddWithValue("@Quantity", itemToRemove.Quantity)
                                        command.Parameters.AddWithValue("@ProductID", productID)
                                        command.ExecuteNonQuery()
                                    End Using
                                End Using
                            Catch ex As Exception
                                MessageBox.Show("Error updating inventory: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End Try

                            ' Remove the item from the cart
                            cartItems.Remove(itemToRemove)

                            ' Update cart DataGridView
                            UpdateCartDataGridView()

                            ' Clear input fields
                            ClearInputFields()

                            ' Show a message indicating the removal
                            MessageBox.Show("Product removed from the cart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            ' Decrease the quantity by the specified amount
                            itemToRemove.Quantity -= quantityToRemoveInt
                            itemToRemove.TotalPrice = itemToRemove.Quantity * itemToRemove.Price

                            ' Update cart DataGridView
                            UpdateCartDataGridView()

                            ' Show a message indicating the decrease in quantity
                            MessageBox.Show("Quantity decreased.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("Invalid quantity. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Case DialogResult.Cancel ' Do nothing
                    ' User canceled the operation
                    Return
            End Select
        Else
            ' Show a message if the product is not found in the cart
            MessageBox.Show("Product not found in the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        ' Check if a row is selected in the DataGridView
        If dgvCart.SelectedRows.Count > 0 Then
            ' Get the selected product ID from the DataGridView
            Dim selectedProductID As Integer = Convert.ToInt32(dgvCart.SelectedRows(0).Cells("ProductID").Value)
            ' Call the RemoveFromCart method with the selected product ID
            RemoveFromCart(selectedProductID)
        Else
            MessageBox.Show("Please select a product to remove from the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    ' Button click event handler for adding product to the cart
    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
        AddToCart()
    End Sub

    ' Method to update cart DataGridView
    Private Sub UpdateCartDataGridView()
        dgvCart.Rows.Clear()
        For Each item In cartItems
            dgvCart.Rows.Add({item.ProductID, item.ProductName, item.Price, item.Quantity, item.TotalPrice})
        Next
    End Sub

    ' Method to clear input fields
    Private Sub ClearInputFields()
        txtProductID.Clear()
        txtProductName.Clear()
        txtPrice.Clear()
        txtQuantity.Clear()
        txtQuantityAvailable.Clear()
    End Sub

    ' Button click event handler for billing

    Private Sub btnBill_Click(sender As Object, e As EventArgs) Handles btnBill.Click
        ' Check if there are items in the cart
        If cartItems.Count > 0 Then
            ' Retrieve the billing date (current date and time)
            Dim billingDate As DateTime = DateTime.Now

            ' Retrieve the selected payment method from the ComboBox
            Dim paymentMethod As String = If(cmbPaymentMethod.SelectedItem IsNot Nothing, cmbPaymentMethod.SelectedItem.ToString(), "")

            ' Check if a payment method is selected
            If String.IsNullOrWhiteSpace(paymentMethod) Then
                MessageBox.Show("Please select a payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Check payment method and prompt for card number or UPI ID accordingly
            If paymentMethod = "Credit Card" OrElse paymentMethod = "Debit Card" Then
                ' Prompt for card number
                Dim cardNumber As String = InputBox("Enter your 12-digit card number:", "Card Number")
                If cardNumber.Length = 12 AndAlso IsNumeric(cardNumber) Then
                    ' Card number is valid, proceed with billing
                    ProcessBilling(billingDate, paymentMethod)
                Else
                    MessageBox.Show("Invalid card number. Please enter a 12-digit numeric card number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf paymentMethod = "Online Payment" Then
                ' Prompt for UPI ID
                Dim upiID As String = InputBox("Enter your 10-digit UPI ID:", "UPI ID")
                If upiID.Length = 10 AndAlso IsNumeric(upiID) Then
                    ' UPI ID is valid, proceed with billing
                    ProcessBilling(billingDate, paymentMethod)
                Else
                    MessageBox.Show("Invalid UPI ID. Please enter a 10-digit numeric UPI ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ' Other payment methods don't require additional information, proceed with billing
                ProcessBilling(billingDate, paymentMethod)
            End If
        Else
            MessageBox.Show("No items in the cart. Please add items before billing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ProcessBilling(billingDate As DateTime, paymentMethod As String)
        ' Calculate the total bill amount
        Dim billAmount As Decimal = cartItems.Sum(Function(item) item.TotalPrice)

        ' Build the bill preview message
        Dim billPreview As New StringBuilder()
        billPreview.AppendLine("---------- Invoice ----------")
        billPreview.AppendLine($"Billing Date: {billingDate}")
        billPreview.AppendLine("Products Purchased:")
        For Each item In cartItems
            billPreview.AppendLine($"{item.ProductName} - Quantity: {item.Quantity} - Price: {item.Price:C} - Total: {item.TotalPrice:C}")
        Next
        billPreview.AppendLine($"Payment Method: {paymentMethod}")
        billPreview.AppendLine($"Total Bill Amount: {billAmount:C}")
        billPreview.AppendLine("----------------------------")

        ' Show the bill preview with buttons for confirmation and cancellation
        Dim result As DialogResult = MessageBox.Show(billPreview.ToString(), "Bill Preview", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)

        ' Handle the user's choice
        Select Case result
            Case DialogResult.Yes ' Proceed with billing
                Try
                    ' Insert billing data into the database
                    InsertBillingData(billingDate, paymentMethod, billAmount, GetProductIDs(), GetProductNames(), GetQuantity())

                    MessageBox.Show("Billing process completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Clear the cart
                    cartItems.Clear()
                    UpdateCartDataGridView()
                Catch ex As Exception
                    MessageBox.Show("Error during billing process: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Case DialogResult.No ' Cancel billing and update inventory
                ' Update inventory
                For Each item In cartItems
                    Try
                        Using connection As New SqlConnection(connectionString)
                            connection.Open()
                            Dim updateQuery As String = "UPDATE Inventory SET quantity_available = quantity_available + @Quantity WHERE product_id = @ProductID;"
                            Using command As New SqlCommand(updateQuery, connection)
                                command.Parameters.AddWithValue("@Quantity", item.Quantity)
                                command.Parameters.AddWithValue("@ProductID", item.ProductID)
                                command.ExecuteNonQuery()
                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show("Error updating inventory: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End Try
                Next

                ' Clear the cart
                cartItems.Clear()
                UpdateCartDataGridView()

                MessageBox.Show("Billing process canceled. Inventory updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Case DialogResult.Cancel ' Do nothing
                ' User canceled the operation
                Return
        End Select
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Update inventory
        For Each item In cartItems
            Try
                Using connection As New SqlConnection(connectionString)
                    connection.Open()
                    Dim updateQuery As String = "UPDATE Inventory SET quantity_available = quantity_available + @Quantity WHERE product_id = @ProductID;"
                    Using command As New SqlCommand(updateQuery, connection)
                        command.Parameters.AddWithValue("@Quantity", item.Quantity)
                        command.Parameters.AddWithValue("@ProductID", item.ProductID)
                        command.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error updating inventory: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        Next

        ' Clear the cart
        cartItems.Clear()
        UpdateCartDataGridView()

        MessageBox.Show("Billing process canceled. Inventory updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Method to get a comma-separated string of product IDs
    Private Function GetProductIDs() As String
        Return String.Join(",", cartItems.Select(Function(item) item.ProductID.ToString()).ToArray())
    End Function

    ' Method to get a comma-separated string of product names
    Private Function GetProductNames() As String
        Return String.Join(",", cartItems.Select(Function(item) item.ProductName).ToArray())
    End Function

    Private Function GetQuantity() As String
        Return String.Join(",", cartItems.Select(Function(item) item.Quantity.ToString()).ToArray())
    End Function

    ' Method to insert billing data into the database
    Private Sub InsertBillingData(billingDate As DateTime, paymentMethod As String, billAmount As Decimal, productIDs As String, productNames As String, quantity As String)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim insertQuery As String = "INSERT INTO Billing (billing_date, payment_method, product_ids, product_name, quantity, total_price, bill_amount) " &
                                        "VALUES (@BillingDate, @PaymentMethod, @ProductIDs, @ProductNames, @Quantity, @TotalPrice, @BillAmount)"

            Using command As New SqlCommand(insertQuery, connection)
                command.Parameters.AddWithValue("@BillingDate", billingDate)
                command.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                command.Parameters.AddWithValue("@ProductIDs", productIDs)
                command.Parameters.AddWithValue("@ProductNames", productNames)
                command.Parameters.AddWithValue("@Quantity", quantity)
                command.Parameters.AddWithValue("@TotalPrice", cartItems.Sum(Function(item) item.TotalPrice))
                command.Parameters.AddWithValue("@BillAmount", billAmount)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' Form load event handler
    Private Sub BillingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Add payment methods to the ComboBox
        cmbPaymentMethod.Items.AddRange({"Cash", "Credit Card", "Debit Card", "Online Payment"})
        ' Define columns for dgvCart programmatically
        dgvCart.Columns.Add("ProductID", "Product ID")
        dgvCart.Columns.Add("ProductName", "Product Name")
        dgvCart.Columns.Add("Price", "Price")
        dgvCart.Columns.Add("Quantity", "Quantity")
        dgvCart.Columns.Add("TotalPrice", "Total Price")
    End Sub

    ' Class to represent an item in the cart
    Private Class CartItem
        Public Property ProductID As Integer
        Public Property ProductName As String
        Public Property Price As Decimal
        Public Property Quantity As Integer
        Public Property TotalPrice As Decimal

        Public Sub New(productID As Integer, productName As String, price As Decimal, quantity As Integer, totalPrice As Decimal)
            Me.ProductID = productID
            Me.ProductName = productName
            Me.Price = price
            Me.Quantity = quantity
            Me.TotalPrice = totalPrice
        End Sub
    End Class

    ' Method to check if the billing process is done
    Private Function IsBillingDone() As Boolean
        ' Return the value of the billingDone flag
        Return billingDone
    End Function

    ' Form closing event handler
    Private Sub BillingForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Check if the billing process is not done
        If Not IsBillingDone() Then
            ' Prompt the user to finish billing before closing
            Dim result As DialogResult = MessageBox.Show("Billing process is not completed. Are you sure you want to exit without finishing?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            ' If the user chooses not to exit, cancel the form closing event
            If result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class


