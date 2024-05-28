Public Class Form3
    Private AuthenticatedEmployeeID As Integer
    Private Role As String
    Private Username As String

    ' Constructor to receive the authenticated employee's ID, role, and username
    Public Sub New(authenticatedEmployeeID As Integer, role As String, username As String)
        InitializeComponent()
        Me.AuthenticatedEmployeeID = authenticatedEmployeeID
        Me.Role = role
        Me.Username = username

        ' Display the role and username in labels
        LblRole.Text = "Logged in as " & role
        lblUsername.Text = "Welcome, " & username & "!"
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Check if the user has the appropriate role to access this feature
        If Not (Role = "Manager" OrElse Role = "Purchases Manager") Then
            MessageBox.Show("You do not have access to this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if Form4 is already instantiated and visible
        Dim form4 As Form4 = TryCast(Panel5.Controls("Form4"), Form4)

        If form4 IsNot Nothing AndAlso form4.Visible Then
            ' Form4 is already visible, no need to do anything
            Return
        End If

        ' Close any currently displayed form within Panel5
        For Each ctrl As Control In Panel5.Controls
            If TypeOf ctrl Is Form AndAlso ctrl.Visible Then
                ctrl.Hide() ' Hide the currently displayed form
            End If
        Next

        If form4 Is Nothing Then
            ' Instantiate Form4 with the authenticated employee's ID
            form4 = New Form4(AuthenticatedEmployeeID)

            ' Set the TopLevel property to false
            form4.TopLevel = False

            ' Set the Parent property to the panel control
            form4.Parent = Panel5

            ' Adjust the size and position of Form4 within panel5
            form4.Size = Panel5.Size
            form4.Location = New Point(0, 0)

            ' Add Form4 to Panel5 controls
            Panel5.Controls.Add(form4)
        End If
        ' Show Form4
        form4.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Check if BillingForm is already instantiated and visible
        Dim billingForm As BillingForm = TryCast(Panel5.Controls("BillingForm"), BillingForm)

        If billingForm IsNot Nothing AndAlso billingForm.Visible Then
            ' BillingForm is already visible, no need to do anything
            Return
        End If

        ' Close any currently displayed form within Panel5
        For Each ctrl As Control In Panel5.Controls
            If TypeOf ctrl Is Form AndAlso ctrl.Visible Then
                ctrl.Hide() ' Hide the currently displayed form
            End If
        Next

        If billingForm Is Nothing Then
            ' Instantiate BillingForm
            billingForm = New BillingForm()

            ' Set the TopLevel property to false
            billingForm.TopLevel = False

            ' Set the Parent property to the panel control
            billingForm.Parent = Panel5

            ' Adjust the size and position of BillingForm within Panel5
            billingForm.Size = Panel5.Size
            billingForm.Location = New Point(0, 0)

            ' Add BillingForm to Panel5 controls
            Panel5.Controls.Add(billingForm)
        End If

        ' Show BillingForm
        billingForm.Show()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Check if InventoryManagementForm is already instantiated and visible
        Dim inventoryForm As Form = TryCast(Panel5.Controls("InventoryManagementForm"), Form)

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

        If Role = "Manager" OrElse Role = "Inventory Manager" Then
            inventoryForm = New InventoryManagementForm()
        Else
            inventoryForm = New InventoryManagementForm2()
        End If

        ' Set the TopLevel property to false
        inventoryForm.TopLevel = False

        ' Set the Parent property to the panel control
        inventoryForm.Parent = Panel5

        ' Adjust the size and position of InventoryManagementForm within panel5
        inventoryForm.Size = Panel5.Size
        inventoryForm.Location = New Point(0, 0)

        ' Add InventoryManagementForm to Panel5 controls
        Panel5.Controls.Add(inventoryForm)

        ' Show the appropriate form
        inventoryForm.Show()
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        ' Optionally, you can return to the login form or perform any other actions
        Dim loginForm As New Form1()
        loginForm.Show()
    End Sub
End Class

