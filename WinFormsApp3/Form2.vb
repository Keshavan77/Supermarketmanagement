Imports System.Reflection.Emit

Public Class Form2
    ' Fields to store username and role
    Private ReadOnly username As String
    Private ReadOnly role As String

    ' Constructor to receive the username and role
    Public Sub New(username As String, role As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Set the username and role fields
        Me.username = username
        Me.role = role

        ' Display the username and role in separate labels
        Label1.Text = "Welcome, " & username & "!"
        Label2.Text = "Logged in as " & role & "."

        ' Customize dashboard based on the user's role
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Check if Form5 is already instantiated and visible
        Dim form5 As Form5 = TryCast(Panel5.Controls("Form5"), Form5)

        If form5 IsNot Nothing AndAlso form5.Visible Then
            ' Form5 is already visible, no need to do anything
            Return
        End If

        ' Close any currently displayed form within Panel5
        For Each ctrl As Control In Panel5.Controls
            If TypeOf ctrl Is Form AndAlso ctrl.Visible Then
                ctrl.Hide() ' Hide the currently displayed form
            End If
        Next

        If form5 Is Nothing Then
            ' Instantiate Form5
            form5 = New Form5()

            ' Set the TopLevel property to false
            form5.TopLevel = False

            ' Set the Parent property to the panel control
            form5.Parent = Panel5

            ' Adjust the size and position of Form5 within panel5
            form5.Size = Panel5.Size
            form5.Location = New Point(0, 0)

            ' Add Form5 to Panel5 controls
            Panel5.Controls.Add(form5)
        End If

        ' Show Form5
        form5.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Check if InventoryManagementForm is already instantiated and visible
        Dim inventoryForm As InventoryManagementForm = TryCast(Panel5.Controls("InventoryManagementForm"), InventoryManagementForm)

        If inventoryForm IsNot Nothing AndAlso inventoryForm.Visible Then
            ' InventoryManagementForm is already visible, no need to do anything
            Return
        End If

        ' Close any currently displayed form within Panel5
        For Each ctrl As Control In Panel5.Controls
            If TypeOf ctrl Is Form AndAlso ctrl.Visible Then
                ctrl.Hide() ' Hide the currently displayed form
            End If
        Next

        If inventoryForm Is Nothing Then
            ' Instantiate InventoryManagementForm
            inventoryForm = New InventoryManagementForm()

            ' Set the TopLevel property to false
            inventoryForm.TopLevel = False

            ' Set the Parent property to the panel control
            inventoryForm.Parent = Panel5

            ' Adjust the size and position of InventoryManagementForm within panel5
            inventoryForm.Size = Panel5.Size
            inventoryForm.Location = New Point(0, 0)

            ' Add InventoryManagementForm to Panel5 controls
            Panel5.Controls.Add(inventoryForm)
        End If

        ' Show InventoryManagementForm
        inventoryForm.Show()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Check if PurchasesForm2 is already instantiated and visible
        Dim purchasesForm As PurchasesForm2 = TryCast(Panel5.Controls("PurchasesForm2"), PurchasesForm2)

        If purchasesForm IsNot Nothing AndAlso purchasesForm.Visible Then
            ' PurchasesForm2 is already visible, no need to do anything
            Return
        End If

        ' Close any currently displayed form within Panel5
        For Each ctrl As Control In Panel5.Controls
            If TypeOf ctrl Is Form AndAlso ctrl.Visible Then
                ctrl.Hide() ' Hide the currently displayed form
            End If
        Next

        If purchasesForm Is Nothing Then
            ' Instantiate PurchasesForm2
            purchasesForm = New PurchasesForm2()

            ' Set the TopLevel property to false
            purchasesForm.TopLevel = False

            ' Set the Parent property to the panel control
            purchasesForm.Parent = Panel5

            ' Adjust the size and position of PurchasesForm2 within panel5
            purchasesForm.Size = Panel5.Size
            purchasesForm.Location = New Point(0, 0)

            ' Add PurchasesForm2 to Panel5 controls
            Panel5.Controls.Add(purchasesForm)
        End If

        ' Show PurchasesForm2
        purchasesForm.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Check if SaleForm is already instantiated and visible
        Dim saleForm As SaleForm = TryCast(Panel5.Controls("SaleForm"), SaleForm)

        If saleForm IsNot Nothing AndAlso saleForm.Visible Then
            ' SaleForm is already visible, no need to do anything
            Return
        End If

        ' Close any currently displayed form within Panel5
        For Each ctrl As Control In Panel5.Controls
            If TypeOf ctrl Is Form AndAlso ctrl.Visible Then
                ctrl.Hide() ' Hide the currently displayed form
            End If
        Next

        If saleForm Is Nothing Then
            ' Instantiate SaleForm
            saleForm = New SaleForm()

            ' Set the TopLevel property to false
            saleForm.TopLevel = False

            ' Set the Parent property to the panel control
            saleForm.Parent = Panel5

            ' Adjust the size and position of SaleForm within panel5
            saleForm.Size = Panel5.Size
            saleForm.Location = New Point(0, 0)

            ' Add SaleForm to Panel5 controls
            Panel5.Controls.Add(saleForm)
        End If

        ' Show SaleForm
        saleForm.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ' Close the dashboard form
        Me.Close()
        ' Optionally, you can return to the login form or perform any other actions
        Dim loginForm As New Form1()
        loginForm.Show()
    End Sub
End Class
