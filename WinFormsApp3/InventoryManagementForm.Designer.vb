<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryManagementForm
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
        components = New ComponentModel.Container()
        txtProductId = New TextBox()
        txtProductName = New TextBox()
        txtCategory = New TextBox()
        txtPrice = New TextBox()
        txtQuantity = New TextBox()
        productid = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label1 = New Label()
        InventoryBindingSource = New BindingSource(components)
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        InventoryBindingSource1 = New BindingSource(components)
        DataGridView1 = New DataGridView()
        DataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        ProductNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CategoryDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PriceDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        QuantityAvailableDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        btnClear = New Button()
        CType(InventoryBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(InventoryBindingSource1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtProductId
        ' 
        txtProductId.Location = New Point(157, 264)
        txtProductId.Name = "txtProductId"
        txtProductId.Size = New Size(100, 23)
        txtProductId.TabIndex = 0
        ' 
        ' txtProductName
        ' 
        txtProductName.Location = New Point(157, 322)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(100, 23)
        txtProductName.TabIndex = 1
        ' 
        ' txtCategory
        ' 
        txtCategory.Location = New Point(157, 382)
        txtCategory.Name = "txtCategory"
        txtCategory.Size = New Size(100, 23)
        txtCategory.TabIndex = 2
        ' 
        ' txtPrice
        ' 
        txtPrice.Location = New Point(392, 264)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(100, 23)
        txtPrice.TabIndex = 3
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Location = New Point(392, 322)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(100, 23)
        txtQuantity.TabIndex = 4
        ' 
        ' productid
        ' 
        productid.AutoSize = True
        productid.Location = New Point(25, 272)
        productid.Name = "productid"
        productid.Size = New Size(62, 15)
        productid.TabIndex = 5
        productid.Text = "Product id"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(25, 330)
        Label2.Name = "Label2"
        Label2.Size = New Size(37, 15)
        Label2.TabIndex = 6
        Label2.Text = "name"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(25, 390)
        Label3.Name = "Label3"
        Label3.Size = New Size(55, 15)
        Label3.TabIndex = 7
        Label3.Text = "Category"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(300, 272)
        Label4.Name = "Label4"
        Label4.Size = New Size(33, 15)
        Label4.TabIndex = 8
        Label4.Text = "Price"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(300, 325)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 15)
        Label1.TabIndex = 9
        Label1.Text = "Quntity"
        ' 
        ' InventoryBindingSource
        ' 
        InventoryBindingSource.DataSource = GetType(Inventory)
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.PaleGoldenrod
        btnAdd.Location = New Point(36, 214)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 23)
        btnAdd.TabIndex = 11
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.NavajoWhite
        btnUpdate.Location = New Point(144, 214)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(75, 23)
        btnUpdate.TabIndex = 12
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Bisque
        btnDelete.Location = New Point(258, 214)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(75, 23)
        btnDelete.TabIndex = 13
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' InventoryBindingSource1
        ' 
        InventoryBindingSource1.DataSource = GetType(Inventory)
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.BackgroundColor = Color.FloralWhite
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {DataGridViewTextBoxColumn1, ProductNameDataGridViewTextBoxColumn, CategoryDataGridViewTextBoxColumn, PriceDataGridViewTextBoxColumn, QuantityAvailableDataGridViewTextBoxColumn})
        DataGridView1.DataSource = InventoryBindingSource1
        DataGridView1.Location = New Point(12, 12)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(626, 196)
        DataGridView1.TabIndex = 14
        ' 
        ' DataGridViewTextBoxColumn1
        ' 
        DataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewTextBoxColumn1.DataPropertyName = "ProductID"
        DataGridViewTextBoxColumn1.HeaderText = "ProductID"
        DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        DataGridViewTextBoxColumn1.Width = 85
        ' 
        ' ProductNameDataGridViewTextBoxColumn
        ' 
        ProductNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName"
        ProductNameDataGridViewTextBoxColumn.HeaderText = "ProductName"
        ProductNameDataGridViewTextBoxColumn.Name = "ProductNameDataGridViewTextBoxColumn"
        ' 
        ' CategoryDataGridViewTextBoxColumn
        ' 
        CategoryDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        CategoryDataGridViewTextBoxColumn.DataPropertyName = "Category"
        CategoryDataGridViewTextBoxColumn.HeaderText = "Category"
        CategoryDataGridViewTextBoxColumn.Name = "CategoryDataGridViewTextBoxColumn"
        CategoryDataGridViewTextBoxColumn.Width = 80
        ' 
        ' PriceDataGridViewTextBoxColumn
        ' 
        PriceDataGridViewTextBoxColumn.DataPropertyName = "Price"
        PriceDataGridViewTextBoxColumn.HeaderText = "Price"
        PriceDataGridViewTextBoxColumn.Name = "PriceDataGridViewTextBoxColumn"
        ' 
        ' QuantityAvailableDataGridViewTextBoxColumn
        ' 
        QuantityAvailableDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        QuantityAvailableDataGridViewTextBoxColumn.DataPropertyName = "QuantityAvailable"
        QuantityAvailableDataGridViewTextBoxColumn.HeaderText = "QuantityAvailable"
        QuantityAvailableDataGridViewTextBoxColumn.Name = "QuantityAvailableDataGridViewTextBoxColumn"
        QuantityAvailableDataGridViewTextBoxColumn.Width = 126
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.BurlyWood
        btnClear.Location = New Point(370, 214)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(75, 23)
        btnClear.TabIndex = 15
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' InventoryManagementForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Gainsboro
        ClientSize = New Size(771, 432)
        Controls.Add(btnClear)
        Controls.Add(DataGridView1)
        Controls.Add(btnDelete)
        Controls.Add(btnUpdate)
        Controls.Add(btnAdd)
        Controls.Add(Label1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(productid)
        Controls.Add(txtQuantity)
        Controls.Add(txtPrice)
        Controls.Add(txtCategory)
        Controls.Add(txtProductName)
        Controls.Add(txtProductId)
        FormBorderStyle = FormBorderStyle.None
        Name = "InventoryManagementForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "InventoryManagementForm"
        CType(InventoryBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(InventoryBindingSource1, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtProductId As TextBox
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents productid As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents InventoryBindingSource As BindingSource
    Friend WithEvents ProductIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InventoryBindingSource1 As BindingSource
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnClear As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents ProductNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CategoryDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PriceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QuantityAvailableDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
