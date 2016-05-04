<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Customers
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
        Me.components = New System.ComponentModel.Container()
        Me.DataSetGridView = New System.Windows.Forms.DataGridView()
        Me.FirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.City = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.County = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.State = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Zip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreditLimit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalSales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalVisits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmailAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PhoneNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Exercise1DataSet = New Exercise1.Exercise1DataSet()
        Me.CustomerTableAdapter = New Exercise1.Exercise1DataSetTableAdapters.CustomerTableAdapter()
        Me.TableAdapterManager = New Exercise1.Exercise1DataSetTableAdapters.TableAdapterManager()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataSetGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Exercise1DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataSetGridView
        '
        Me.DataSetGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataSetGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FirstName, Me.LastName, Me.ID, Me.Address, Me.City, Me.County, Me.State, Me.Zip, Me.CreditLimit, Me.TotalSales, Me.TotalVisits, Me.EmailAddress, Me.PhoneNumber})
        Me.DataSetGridView.Location = New System.Drawing.Point(12, 32)
        Me.DataSetGridView.Name = "DataSetGridView"
        Me.DataSetGridView.Size = New System.Drawing.Size(622, 280)
        Me.DataSetGridView.TabIndex = 2
        '
        'FirstName
        '
        Me.FirstName.HeaderText = "FirstName"
        Me.FirstName.Name = "FirstName"
        '
        'LastName
        '
        Me.LastName.HeaderText = "LastName"
        Me.LastName.Name = "LastName"
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        '
        'Address
        '
        Me.Address.HeaderText = "Address"
        Me.Address.Name = "Address"
        '
        'City
        '
        Me.City.HeaderText = "City"
        Me.City.Name = "City"
        '
        'County
        '
        Me.County.HeaderText = "County"
        Me.County.Name = "County"
        '
        'State
        '
        Me.State.HeaderText = "State"
        Me.State.Name = "State"
        '
        'Zip
        '
        Me.Zip.HeaderText = "Zip"
        Me.Zip.Name = "Zip"
        '
        'CreditLimit
        '
        Me.CreditLimit.HeaderText = "Credit Limit"
        Me.CreditLimit.Name = "CreditLimit"
        '
        'TotalSales
        '
        Me.TotalSales.HeaderText = "Total Sales"
        Me.TotalSales.Name = "TotalSales"
        '
        'TotalVisits
        '
        Me.TotalVisits.HeaderText = "Total Visits"
        Me.TotalVisits.Name = "TotalVisits"
        '
        'EmailAddress
        '
        Me.EmailAddress.HeaderText = "EmailAddress"
        Me.EmailAddress.Name = "EmailAddress"
        '
        'PhoneNumber
        '
        Me.PhoneNumber.HeaderText = "PhoneNumber"
        Me.PhoneNumber.Name = "PhoneNumber"
        '
        'CustomerBindingSource
        '
        Me.CustomerBindingSource.DataMember = "Customer"
        Me.CustomerBindingSource.DataSource = Me.Exercise1DataSet
        '
        'Exercise1DataSet
        '
        Me.Exercise1DataSet.DataSetName = "Exercise1DataSet"
        Me.Exercise1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CustomerTableAdapter
        '
        Me.CustomerTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.CustomerTableAdapter = Nothing
        Me.TableAdapterManager.EmployeeTableAdapter = Nothing
        Me.TableAdapterManager.ItemTableAdapter = Nothing
        Me.TableAdapterManager.SupplierTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Exercise1.Exercise1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Top listed Customers:"
        '
        'Customers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 324)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataSetGridView)
        Me.Name = "Customers"
        Me.Text = "Customers"
        CType(Me.DataSetGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Exercise1DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Exercise1DataSet As Exercise1.Exercise1DataSet
    Friend WithEvents CustomerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerTableAdapter As Exercise1.Exercise1DataSetTableAdapters.CustomerTableAdapter
    Friend WithEvents TableAdapterManager As Exercise1.Exercise1DataSetTableAdapters.TableAdapterManager
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataSetGridView As System.Windows.Forms.DataGridView
    Friend WithEvents FirstName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents City As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents County As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents State As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Zip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditLimit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalVisits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmailAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PhoneNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
