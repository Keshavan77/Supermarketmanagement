Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class PurchasesForm2
    ' Connection string for the database
    Private connectionString As String = "Data Source=DESKTOP-6UG4BV5\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    ' Load purchases data and bind it to DataGridView
    Private Sub LoadPurchasesData()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT * FROM Purchases"

                Dim adapter As New SqlDataAdapter(query, connection)
                Dim dataSet As New DataSet()
                adapter.Fill(dataSet, "Purchases")

                DataGridView1.DataSource = dataSet.Tables("Purchases")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading purchases data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Load purchases data when the admin dashboard form loads
    Private Sub PurchasesForm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPurchasesData()
    End Sub
End Class
