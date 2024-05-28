Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class InventoryManagementForm2
    ' Connection string for the database
    Private connectionString As String = "Data Source=DESKTOP-6UG4BV5\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    ' Load inventory data and bind it to DataGridView
    Private Sub LoadInventoryData()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT * FROM Inventory"

                Dim adapter As New SqlDataAdapter(query, connection)
                Dim dataSet As New DataSet()
                adapter.Fill(dataSet, "Inventory")

                DataGridView1.DataSource = dataSet.Tables("Inventory")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading inventory data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Load inventory data when the form loads
    Private Sub InventoryManagementForm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInventoryData()
    End Sub
End Class
