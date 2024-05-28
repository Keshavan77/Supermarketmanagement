<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaleForm
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        btnThisWeek = New Button()
        btnCustomMonth = New Button()
        btnCustomYear = New Button()
        Chart1 = New DataVisualization.Charting.Chart()
        ListBox1 = New ListBox()
        DateTimePicker1 = New DateTimePicker()
        ComboBox1 = New ComboBox()
        btnFetchAll = New Button()
        btnYesterday = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        CType(Chart1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnThisWeek
        ' 
        btnThisWeek.BackColor = Color.Orange
        btnThisWeek.Location = New Point(123, 292)
        btnThisWeek.Name = "btnThisWeek"
        btnThisWeek.Size = New Size(75, 23)
        btnThisWeek.TabIndex = 2
        btnThisWeek.Text = "week"
        btnThisWeek.UseVisualStyleBackColor = False
        ' 
        ' btnCustomMonth
        ' 
        btnCustomMonth.BackColor = Color.IndianRed
        btnCustomMonth.Location = New Point(222, 292)
        btnCustomMonth.Name = "btnCustomMonth"
        btnCustomMonth.Size = New Size(75, 23)
        btnCustomMonth.TabIndex = 3
        btnCustomMonth.Text = "month"
        btnCustomMonth.UseVisualStyleBackColor = False
        ' 
        ' btnCustomYear
        ' 
        btnCustomYear.BackColor = Color.LightGreen
        btnCustomYear.Location = New Point(331, 292)
        btnCustomYear.Name = "btnCustomYear"
        btnCustomYear.Size = New Size(75, 23)
        btnCustomYear.TabIndex = 4
        btnCustomYear.Text = "year"
        btnCustomYear.UseVisualStyleBackColor = False
        ' 
        ' Chart1
        ' 
        Chart1.BorderlineDashStyle = DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.Area3DStyle.PointGapDepth = 10
        ChartArea1.Name = "ChartArea1"
        Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Chart1.Legends.Add(Legend1)
        Chart1.Location = New Point(1, 1)
        Chart1.Margin = New Padding(1)
        Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.MarkerSize = 4
        Series1.Name = "Series1"
        Chart1.Series.Add(Series1)
        Chart1.Size = New Size(731, 278)
        Chart1.TabIndex = 1
        Chart1.Text = "Chart1"
        ' 
        ' ListBox1
        ' 
        ListBox1.BackColor = SystemColors.ControlLightLight
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 15
        ListBox1.Location = New Point(736, 19)
        ListBox1.Name = "ListBox1"
        ListBox1.ScrollAlwaysVisible = True
        ListBox1.Size = New Size(195, 259)
        ListBox1.TabIndex = 6
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(697, 299)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(200, 23)
        DateTimePicker1.TabIndex = 7
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(285, 335)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(121, 23)
        ComboBox1.TabIndex = 8
        ' 
        ' btnFetchAll
        ' 
        btnFetchAll.BackColor = Color.SteelBlue
        btnFetchAll.Location = New Point(539, 296)
        btnFetchAll.Name = "btnFetchAll"
        btnFetchAll.Size = New Size(75, 23)
        btnFetchAll.TabIndex = 9
        btnFetchAll.Text = "Over all"
        btnFetchAll.UseVisualStyleBackColor = False
        ' 
        ' btnYesterday
        ' 
        btnYesterday.BackColor = Color.DarkTurquoise
        btnYesterday.Location = New Point(26, 292)
        btnYesterday.Name = "btnYesterday"
        btnYesterday.Size = New Size(75, 23)
        btnYesterday.TabIndex = 1
        btnYesterday.Text = "yesterday"
        btnYesterday.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(82, 343)
        Label1.Name = "Label1"
        Label1.Size = New Size(165, 15)
        Label1.TabIndex = 10
        Label1.Text = "Select a option for graph view"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(777, 281)
        Label2.Name = "Label2"
        Label2.Size = New Size(110, 15)
        Label2.TabIndex = 11
        Label2.Text = "Custome sales view"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(458, 299)
        Label3.Name = "Label3"
        Label3.Size = New Size(75, 15)
        Label3.TabIndex = 12
        Label3.Text = "Over all sales"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(810, 1)
        Label4.Name = "Label4"
        Label4.Size = New Size(54, 15)
        Label4.TabIndex = 13
        Label4.Text = "Products"
        ' 
        ' SaleForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SeaShell
        ClientSize = New Size(934, 490)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnFetchAll)
        Controls.Add(ComboBox1)
        Controls.Add(DateTimePicker1)
        Controls.Add(ListBox1)
        Controls.Add(Chart1)
        Controls.Add(btnCustomYear)
        Controls.Add(btnCustomMonth)
        Controls.Add(btnThisWeek)
        Controls.Add(btnYesterday)
        FormBorderStyle = FormBorderStyle.None
        Location = New Point(1, 1)
        Name = "SaleForm"
        Text = "SaleForm"
        CType(Chart1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnThisWeek As Button
    Friend WithEvents btnCustomMonth As Button
    Friend WithEvents btnCustomYear As Button
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnFetchAll As Button
    Friend WithEvents btnYesterday As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
