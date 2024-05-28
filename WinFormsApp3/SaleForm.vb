Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms.DataVisualization.Charting

Public Class SaleForm

    ' Connection string to connect to the database
    Private connectionString As String = "Data Source=DESKTOP-6UG4BV5\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    ' This event is triggered when the form is loaded
    Private Sub SaleForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Set the DateTimePicker value to the current date
            DateTimePicker1.Value = DateTime.Today

            ' Display product quantities from the beginning to the current date
            DisplayProductQuantities()

            ' Populate ComboBox with options
            ComboBox1.Items.AddRange({"None", "Other option", "5", "10", "15", "20", "30"})

            ' Default to showing top 10 products in chart
            DisplayProductQuantitiesChart(10)
        Catch ex As Exception
            ' Display error message if an exception occurs
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnFetchAll_Click(sender As Object, e As EventArgs) Handles btnFetchAll.Click
        Try
            ' Call DisplayProductQuantities without specifying a date
            DisplayProductQuantities()
        Catch ex As Exception
            ' Display error message if an exception occurs
            MessageBox.Show("An error occurred while fetching product quantities from all dates: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Function to display product quantities in ListBox
    Private Sub DisplayProductQuantities(Optional ByVal selectedDate As Date = Nothing)
        Try
            ' Dictionary to store product names and quantities
            Dim productQuantities As New Dictionary(Of String, Integer)()

            ' Establish connection to the database
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' SQL query to retrieve product names and quantities from the Billing table
                Dim query As String
                If selectedDate = Nothing Then
                    ' If no date is specified, retrieve all records
                    query = "SELECT product_name, quantity FROM Billing"
                Else
                    ' If a date is specified, retrieve records for that date
                    query = "SELECT product_name, quantity FROM Billing WHERE CONVERT(date, billing_date) = @SelectedDate"
                End If

                ' Execute the SQL command
                Using command As New SqlCommand(query, connection)
                    If selectedDate <> Nothing Then
                        ' Add parameter for selected date
                        command.Parameters.AddWithValue("@SelectedDate", selectedDate)
                    End If

                    Using reader As SqlDataReader = command.ExecuteReader()
                        ' Iterate through the result set
                        While reader.Read()
                            Dim productNames As String = reader("product_name").ToString()
                            Dim quantities As String = reader("quantity").ToString()

                            ' Split product names and quantities
                            Dim productNameList As List(Of String) = productNames.Split(","c).ToList()
                            Dim quantityList As List(Of String) = quantities.Split(","c).ToList()

                            ' Update product quantities dictionary
                            For i As Integer = 0 To Math.Min(productNameList.Count - 1, quantityList.Count - 1)
                                Dim productName As String = productNameList(i).Trim()
                                Dim quantity As String = quantityList(i).Trim()

                                If Not String.IsNullOrEmpty(productName) AndAlso Not String.IsNullOrEmpty(quantity) Then
                                    If Not productQuantities.ContainsKey(productName) Then
                                        productQuantities.Add(productName, 0)
                                    End If

                                    Dim parsedQuantity As Integer
                                    If Integer.TryParse(quantity, parsedQuantity) Then
                                        productQuantities(productName) += parsedQuantity
                                    End If
                                End If
                            Next
                        End While
                    End Using
                End Using
            End Using

            ' Clear ListBox
            ListBox1.Items.Clear()

            ' Populate ListBox with product names and quantities
            For Each entry As KeyValuePair(Of String, Integer) In productQuantities.OrderByDescending(Function(x) x.Value)
                ListBox1.Items.Add($"{entry.Key}: {entry.Value}")
            Next
        Catch ex As Exception
            ' Display error message if an exception occurs
            MessageBox.Show("An error occurred while displaying product quantities in ListBox: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Function to display product quantities in the Chart
    Private Sub DisplayProductQuantitiesChart(ByVal numberOfItemsToShow As Integer)
        Try
            ' Clear existing series and chart areas
            Chart1.Series.Clear()
            Chart1.ChartAreas.Clear()
            Chart1.ChartAreas.Add("ChartArea")

            ' If number of items to show is 0, clear the chart and return
            If numberOfItemsToShow = 0 Then
                Return
            End If

            ' Take only the specified number of items if not "None"
            Dim topItems = If(numberOfItemsToShow > 0,
                              ListBox1.Items.Cast(Of String).Take(numberOfItemsToShow),
                              Enumerable.Empty(Of String)())

            ' Populate chart with specified number of product quantities
            Dim xValue As Double = 0 ' Start with the initial x-value
            For Each item As String In topItems
                Dim parts As String() = item.Split(":")
                If parts.Length = 2 Then
                    Dim productName As String = parts(0).Trim()
                    Dim quantity As String = parts(1).Trim()
                    Dim parsedQuantity As Integer
                    If Integer.TryParse(quantity, parsedQuantity) Then
                        ' Create a new series for each product
                        Dim series As New Series()
                        series.Name = productName
                        series.ChartType = SeriesChartType.Column ' Set chart type to Column
                        series.BorderWidth = 0 ' Remove the border
                        series.Points.AddXY(xValue, parsedQuantity)
                        series("PointWidth") = "0.4" ' Adjust column width as needed
                        Chart1.Series.Add(series)
                        xValue += 1 ' Increment the x-value for the next series
                    End If
                End If
            Next

            ' Set chart titles
            Chart1.ChartAreas(0).AxisX.Title = "Product Name"
            Chart1.ChartAreas(0).AxisY.Title = "Quantity"

            ' Set the label format of the X-axis to empty (to display only whole numbers)
            Chart1.ChartAreas(0).AxisX.LabelStyle.Format = ""

            ' Set the minimum value of the Y-axis to 0
            Chart1.ChartAreas(0).AxisY.Minimum = 0

            ' Remove inner gridlines
            Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
            Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False

            ' Set interval between labels on the X-axis and disable auto-fitting of labels
            Chart1.ChartAreas(0).AxisX.LabelStyle.Interval = 1 ' Set interval to 1
            Chart1.ChartAreas(0).AxisX.IsLabelAutoFit = False ' Disable auto-fitting

            ' Reduce the space between product names on the X-axis
            Chart1.ChartAreas(0).AxisX.IntervalOffset = 0 ' Adjust the offset as needed

        Catch ex As Exception
            ' Display error message if an exception occurs
            MessageBox.Show("An error occurred while displaying product quantities chart: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Event handler for ComboBox selection change
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim selectedNumberOfItems As Integer
        ' Determine the selected number of items based on the ComboBox selection
        If ComboBox1.SelectedItem.ToString().ToLower() = "none" Then
            ' If "None" is selected, set the selected number of items to 0
            selectedNumberOfItems = 0
        ElseIf ComboBox1.SelectedItem.ToString().ToLower() = "other option" Then
            ' If "Other" is selected, prompt the user for a custom value
            Dim customValue As String = InputBox("Enter the number of items to display:", "Custom Value")
            If Integer.TryParse(customValue, selectedNumberOfItems) Then
                ' If user input is valid, proceed
                If selectedNumberOfItems > ListBox1.Items.Count Then
                    ' If the entered value exceeds the number of items in the ListBox, show a message
                    MessageBox.Show("There are not enough items in the ListBox to display.", "Insufficient Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            Else
                ' If user input is invalid, return
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Else
            ' If a numeric value is selected, parse it
            selectedNumberOfItems = CInt(ComboBox1.SelectedItem)
        End If
        ' Update the chart with the selected number of items
        DisplayProductQuantitiesChart(selectedNumberOfItems)
    End Sub

    ' Event handler for DateTimePicker value change
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Try
            ' Call DisplayProductQuantities with the selected date
            DisplayProductQuantities(DateTimePicker1.Value.Date)
        Catch ex As Exception
            ' Display error message if an exception occurs
            MessageBox.Show("An error occurred while updating product quantities: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Event handler for the Yesterday button click
    Private Sub btnYesterday_Click(sender As Object, e As EventArgs) Handles btnYesterday.Click
        Dim yesterdayDate As Date = DateTime.Today.AddDays(-1)
        DisplayProductQuantities(yesterdayDate)
        DisplayProductQuantitiesChart(10)
    End Sub

    ' Event handler for the Last Week button click
    Private Sub btnThisWeek_Click(sender As Object, e As EventArgs) Handles btnThisWeek.Click
        Try
            ' Calculate the start and end dates for the current week
            Dim currentDate As Date = DateTime.Today
            Dim currentDayOfWeek As DayOfWeek = currentDate.DayOfWeek
            Dim daysUntilStartOfWeek As Integer = currentDayOfWeek - DayOfWeek.Monday
            If daysUntilStartOfWeek < 0 Then
                daysUntilStartOfWeek += 7 ' Adjust for negative values
            End If
            Dim startOfWeek As Date = currentDate.AddDays(-daysUntilStartOfWeek)
            Dim endOfWeek As Date = startOfWeek.AddDays(6)

            ' Call the function to display product quantities for the current week
            DisplayProductQuantitiesForDateRange(startOfWeek, endOfWeek)
        Catch ex As Exception
            ' Display error message if an exception occurs
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayProductQuantitiesForDateRange(ByVal startDate As Date, ByVal endDate As Date)
        Try
            ' Dictionary to store product names and quantities
            Dim productQuantities As New Dictionary(Of String, Integer)()

            ' Establish connection to the database
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' SQL query to retrieve product names and quantities for the date range
                Dim query As String = "SELECT product_name, quantity FROM Billing WHERE billing_date BETWEEN @StartDate AND @EndDate"

                ' Execute the SQL command
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@StartDate", startDate)
                    command.Parameters.AddWithValue("@EndDate", endDate)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        ' Iterate through the result set
                        While reader.Read()
                            Dim productNames As String = reader("product_name").ToString()
                            Dim quantities As String = reader("quantity").ToString()

                            ' Split product names and quantities
                            Dim productNameList As List(Of String) = productNames.Split(","c).ToList()
                            Dim quantityList As List(Of String) = quantities.Split(","c).ToList()

                            ' Update product quantities dictionary
                            For i As Integer = 0 To Math.Min(productNameList.Count - 1, quantityList.Count - 1)
                                Dim productName As String = productNameList(i).Trim()
                                Dim quantity As String = quantityList(i).Trim()

                                If Not String.IsNullOrEmpty(productName) AndAlso Not String.IsNullOrEmpty(quantity) Then
                                    If Not productQuantities.ContainsKey(productName) Then
                                        productQuantities.Add(productName, 0)
                                    End If

                                    Dim parsedQuantity As Integer
                                    If Integer.TryParse(quantity, parsedQuantity) Then
                                        productQuantities(productName) += parsedQuantity
                                    End If
                                End If
                            Next
                        End While
                    End Using
                End Using
            End Using

            ' Clear ListBox
            ListBox1.Items.Clear()

            ' Populate ListBox with product names and total quantities for the date range
            For Each entry As KeyValuePair(Of String, Integer) In productQuantities.OrderByDescending(Function(x) x.Value)
                ListBox1.Items.Add($"{entry.Key}: {entry.Value}")
            Next
        Catch ex As Exception
            ' Display error message if an exception occurs
            MessageBox.Show("An error occurred while displaying product quantities for the date range: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        DisplayProductQuantitiesChart(10)
    End Sub


    ' Event handler for the Custom Month button click
    Private Sub btnCustomMonth_Click(sender As Object, e As EventArgs) Handles btnCustomMonth.Click
        Try
            ' Array containing the names of the months
            Dim months() As String = {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        }

            ' Build the message to display in the message box
            Dim message As String = "Select the month:" & Environment.NewLine
            For Each month As String In months
                message &= month & Environment.NewLine
            Next

            ' Prompt the user to select the month from a message box
            Dim selectedMonth As String = InputBox(message, "Custom Month")

            ' Ensure that the selected month is not empty
            If Not String.IsNullOrEmpty(selectedMonth) Then
                ' Convert the selected month to title case to handle case differences
                selectedMonth = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(selectedMonth.ToLower())

                ' Validate the selected month
                If Array.IndexOf(months, selectedMonth) <> -1 Then
                    ' Fetch data for the selected month
                    Dim monthIndex As Integer = Array.IndexOf(months, selectedMonth) + 1 ' Month index is 1-based
                    Dim currentYear As Integer = DateTime.Today.Year

                    ' Call the function to display product quantities for the custom month
                    DisplayProductQuantitiesForCustomMonth(monthIndex, currentYear)
                Else
                    MessageBox.Show("Invalid month selected. Please select a valid month from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As SqlException
            MessageBox.Show("Database error occurred: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Display general error message if an exception occurs
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub DisplayProductQuantitiesForCustomMonth(ByVal month As Integer, ByVal year As Integer)
        Try
            ' Dictionary to store product names and quantities
            Dim productQuantities As New Dictionary(Of String, Integer)()

            ' Establish connection to the database
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' SQL query to retrieve product names and quantities for the custom month
                Dim query As String = "SELECT product_name, quantity FROM Billing WHERE YEAR(billing_date) = @Year AND MONTH(billing_date) = @Month"

                ' Execute the SQL command
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Year", year)
                    command.Parameters.AddWithValue("@Month", month)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        ' Iterate through the result set
                        While reader.Read()
                            Dim productNames As String = reader("product_name").ToString()
                            Dim quantities As String = reader("quantity").ToString()

                            ' Split product names and quantities
                            Dim productNameList As List(Of String) = productNames.Split(","c).ToList()
                            Dim quantityList As List(Of String) = quantities.Split(","c).ToList()

                            ' Update product quantities dictionary
                            For i As Integer = 0 To Math.Min(productNameList.Count - 1, quantityList.Count - 1)
                                Dim productName As String = productNameList(i).Trim()
                                Dim quantity As String = quantityList(i).Trim()

                                If Not String.IsNullOrEmpty(productName) AndAlso Not String.IsNullOrEmpty(quantity) Then
                                    If Not productQuantities.ContainsKey(productName) Then
                                        productQuantities.Add(productName, 0)
                                    End If

                                    Dim parsedQuantity As Integer
                                    If Integer.TryParse(quantity, parsedQuantity) Then
                                        productQuantities(productName) += parsedQuantity
                                    End If
                                End If
                            Next
                        End While
                    End Using
                End Using
            End Using

            ' Clear ListBox
            ListBox1.Items.Clear()

            ' Populate ListBox with product names and total quantities for the custom month
            For Each entry As KeyValuePair(Of String, Integer) In productQuantities.OrderByDescending(Function(x) x.Value)
                ListBox1.Items.Add($"{entry.Key}: {entry.Value}")
            Next
        Catch ex As Exception
            ' Display error message if an exception occurs
            MessageBox.Show("An error occurred while displaying product quantities for the custom month: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        DisplayProductQuantitiesChart(10)
    End Sub

    ' Event handler for the Custom Year button click
    Private Sub btnCustomYear_Click(sender As Object, e As EventArgs) Handles btnCustomYear.Click
        Try
            ' Prompt the user to enter the year
            Dim selectedYear As String = InputBox("Enter the year (e.g., 2023):", "Custom Year")

            ' Parse the entered year
            Dim parsedYear As Integer
            If Integer.TryParse(selectedYear, parsedYear) Then
                ' Call the function to display product quantities for the custom year
                DisplayProductQuantitiesForCustomYear(parsedYear)
            Else
                MessageBox.Show("Invalid input. Please enter a valid year.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ' Display error message if an exception occurs
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayProductQuantitiesForCustomYear(ByVal year As Integer)
        Try
            ' Dictionary to store product names and quantities
            Dim productQuantities As New Dictionary(Of String, Integer)()

            ' Establish connection to the database
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' SQL query to retrieve product names and quantities for the custom year
                Dim query As String = "SELECT product_name, quantity FROM Billing WHERE YEAR(billing_date) = @Year"

                ' Execute the SQL command
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Year", year)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        ' Iterate through the result set
                        While reader.Read()
                            Dim productNames As String = reader("product_name").ToString()
                            Dim quantities As String = reader("quantity").ToString()

                            ' Split product names and quantities
                            Dim productNameList As List(Of String) = productNames.Split(","c).ToList()
                            Dim quantityList As List(Of String) = quantities.Split(","c).ToList()

                            ' Update product quantities dictionary
                            For i As Integer = 0 To Math.Min(productNameList.Count - 1, quantityList.Count - 1)
                                Dim productName As String = productNameList(i).Trim()
                                Dim quantity As String = quantityList(i).Trim()

                                If Not String.IsNullOrEmpty(productName) AndAlso Not String.IsNullOrEmpty(quantity) Then
                                    If Not productQuantities.ContainsKey(productName) Then
                                        productQuantities.Add(productName, 0)
                                    End If

                                    Dim parsedQuantity As Integer
                                    If Integer.TryParse(quantity, parsedQuantity) Then
                                        productQuantities(productName) += parsedQuantity
                                    End If
                                End If
                            Next
                        End While
                    End Using
                End Using
            End Using

            ' Clear ListBox
            ListBox1.Items.Clear()

            ' Populate ListBox with product names and total quantities for the custom year
            For Each entry As KeyValuePair(Of String, Integer) In productQuantities.OrderByDescending(Function(x) x.Value)
                ListBox1.Items.Add($"{entry.Key}: {entry.Value}")
            Next
        Catch ex As Exception
            ' Display error message if an exception occurs
            MessageBox.Show("An error occurred while displaying product quantities for the custom year: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        DisplayProductQuantitiesChart(10)
    End Sub
End Class


