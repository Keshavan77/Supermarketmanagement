<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillingForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        txtSearchTerm = New TextBox()
        txtProductID = New TextBox()
        txtProductName = New TextBox()
        txtPrice = New TextBox()
        txtQuantityAvailable = New TextBox()
        btnSearch = New Button()
        btnAddToCart = New Button()
        enteridname = New Label()
        btnBill = New Button()
        dgvCart = New DataGridView()
        Label3 = New Label()
        txtQuantity = New TextBox()
        cmbPaymentMethod = New ComboBox()
        btnRemoveItem = New Button()
        btnCancel = New Button()
        Label6 = New Label()
        CType(dgvCart, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(23, 74)
        Label1.Name = "Label1"
        Label1.Size = New Size(62, 15)
        Label1.TabIndex = 0
        Label1.Text = "Product id"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(23, 114)
        Label2.Name = "Label2"
        Label2.Size = New Size(82, 15)
        Label2.TabIndex = 1
        Label2.Text = "Product name"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(334, 21)
        Label4.Name = "Label4"
        Label4.Size = New Size(33, 15)
        Label4.TabIndex = 3
        Label4.Text = "Price"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(567, 21)
        Label5.Name = "Label5"
        Label5.Size = New Size(102, 15)
        Label5.TabIndex = 4
        Label5.Text = "Quantity available"
        ' 
        ' txtSearchTerm
        ' 
        txtSearchTerm.BackColor = Color.FloralWhite
        txtSearchTerm.Location = New Point(123, 12)
        txtSearchTerm.Name = "txtSearchTerm"
        txtSearchTerm.Size = New Size(100, 23)
        txtSearchTerm.TabIndex = 5
        ' 
        ' txtProductID
        ' 
        txtProductID.BackColor = Color.FloralWhite
        txtProductID.Location = New Point(123, 65)
        txtProductID.Name = "txtProductID"
        txtProductID.Size = New Size(119, 23)
        txtProductID.TabIndex = 6
        ' 
        ' txtProductName
        ' 
        txtProductName.BackColor = Color.FloralWhite
        txtProductName.Location = New Point(123, 106)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(119, 23)
        txtProductName.TabIndex = 7
        ' 
        ' txtPrice
        ' 
        txtPrice.BackColor = Color.FloralWhite
        txtPrice.Location = New Point(448, 18)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(100, 23)
        txtPrice.TabIndex = 8
        ' 
        ' txtQuantityAvailable
        ' 
        txtQuantityAvailable.BackColor = Color.Gainsboro
        txtQuantityAvailable.Location = New Point(678, 13)
        txtQuantityAvailable.Name = "txtQuantityAvailable"
        txtQuantityAvailable.Size = New Size(100, 23)
        txtQuantityAvailable.TabIndex = 9
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.BurlyWood
        btnSearch.Location = New Point(52, 169)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 23)
        btnSearch.TabIndex = 10
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' btnAddToCart
        ' 
        btnAddToCart.BackColor = Color.PaleGoldenrod
        btnAddToCart.Location = New Point(167, 169)
        btnAddToCart.Name = "btnAddToCart"
        btnAddToCart.Size = New Size(75, 23)
        btnAddToCart.TabIndex = 11
        btnAddToCart.Text = "Add to cart"
        btnAddToCart.UseVisualStyleBackColor = False
        ' 
        ' enteridname
        ' 
        enteridname.AutoSize = True
        enteridname.Location = New Point(23, 20)
        enteridname.Name = "enteridname"
        enteridname.Size = New Size(94, 15)
        enteridname.TabIndex = 12
        enteridname.Text = "Enter id or name"
        ' 
        ' btnBill
        ' 
        btnBill.BackColor = Color.YellowGreen
        btnBill.Location = New Point(401, 169)
        btnBill.Name = "btnBill"
        btnBill.Size = New Size(75, 23)
        btnBill.TabIndex = 13
        btnBill.Text = "Bill"
        btnBill.UseVisualStyleBackColor = False
        ' 
        ' dgvCart
        ' 
        dgvCart.BackgroundColor = Color.Gainsboro
        dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCart.Location = New Point(69, 215)
        dgvCart.Name = "dgvCart"
        dgvCart.Size = New Size(598, 223)
        dgvCart.TabIndex = 14
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(334, 65)
        Label3.Name = "Label3"
        Label3.Size = New Size(81, 15)
        Label3.TabIndex = 15
        Label3.Text = "Enter quantity"
        ' 
        ' txtQuantity
        ' 
        txtQuantity.BackColor = Color.FloralWhite
        txtQuantity.Location = New Point(448, 62)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(100, 23)
        txtQuantity.TabIndex = 16
        ' 
        ' cmbPaymentMethod
        ' 
        cmbPaymentMethod.BackColor = Color.FloralWhite
        cmbPaymentMethod.FormattingEnabled = True
        cmbPaymentMethod.Location = New Point(448, 106)
        cmbPaymentMethod.Name = "cmbPaymentMethod"
        cmbPaymentMethod.Size = New Size(121, 23)
        cmbPaymentMethod.TabIndex = 17
        ' 
        ' btnRemoveItem
        ' 
        btnRemoveItem.BackColor = Color.PeachPuff
        btnRemoveItem.Location = New Point(268, 169)
        btnRemoveItem.Name = "btnRemoveItem"
        btnRemoveItem.Size = New Size(99, 23)
        btnRemoveItem.TabIndex = 18
        btnRemoveItem.Text = "Remove items"
        btnRemoveItem.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.LightSalmon
        btnCancel.Location = New Point(509, 169)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 19
        btnCancel.Text = "cancel bill"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(334, 109)
        Label6.Name = "Label6"
        Label6.Size = New Size(99, 15)
        Label6.TabIndex = 20
        Label6.Text = "Payment method"
        ' 
        ' BillingForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(800, 450)
        Controls.Add(Label6)
        Controls.Add(btnCancel)
        Controls.Add(btnRemoveItem)
        Controls.Add(cmbPaymentMethod)
        Controls.Add(txtQuantity)
        Controls.Add(Label3)
        Controls.Add(dgvCart)
        Controls.Add(btnBill)
        Controls.Add(enteridname)
        Controls.Add(btnAddToCart)
        Controls.Add(btnSearch)
        Controls.Add(txtQuantityAvailable)
        Controls.Add(txtPrice)
        Controls.Add(txtProductName)
        Controls.Add(txtProductID)
        Controls.Add(txtSearchTerm)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "BillingForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "BillingForm"
        CType(dgvCart, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSearchTerm As TextBox
    Friend WithEvents txtProductID As TextBox
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtQuantityAvailable As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnAddToCart As Button
    Friend WithEvents enteridname As Label
    Friend WithEvents btnBill As Button
    Friend WithEvents dgvCart As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents cmbPaymentMethod As ComboBox
    Friend WithEvents btnRemoveItem As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label6 As Label
End Class
