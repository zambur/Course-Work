<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMform
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.AvailableParts = New Pilot.AvailableParts()
        Me.OrderCostBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrderCostTableAdapter = New Pilot.AvailablePartsTableAdapters.OrderCostTableAdapter()
        Me.TableAdapterManager = New Pilot.AvailablePartsTableAdapters.TableAdapterManager()
        Me.OrderStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrderStatusTableAdapter = New Pilot.AvailablePartsTableAdapters.OrderStatusTableAdapter()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AvailableParts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderCostBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(161, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(13, 40)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(646, 286)
        Me.DataGridView1.TabIndex = 1
        '
        'AvailableParts
        '
        Me.AvailableParts.DataSetName = "AvailableParts"
        Me.AvailableParts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OrderCostBindingSource
        '
        Me.OrderCostBindingSource.DataMember = "OrderCost"
        Me.OrderCostBindingSource.DataSource = Me.AvailableParts
        '
        'OrderCostTableAdapter
        '
        Me.OrderCostTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.OrderCostTableAdapter = Me.OrderCostTableAdapter
        Me.TableAdapterManager.OrderStatusTableAdapter = Me.OrderStatusTableAdapter
        Me.TableAdapterManager.PartsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Pilot.AvailablePartsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'OrderStatusBindingSource
        '
        Me.OrderStatusBindingSource.DataMember = "OrderStatus"
        Me.OrderStatusBindingSource.DataSource = Me.AvailableParts
        '
        'OrderStatusTableAdapter
        '
        Me.OrderStatusTableAdapter.ClearBeforeFill = True
        '
        'CRMform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 346)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Name = "CRMform"
        Me.Text = "CRMform"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AvailableParts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderCostBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents AvailableParts As Pilot.AvailableParts
    Friend WithEvents OrderCostBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrderCostTableAdapter As Pilot.AvailablePartsTableAdapters.OrderCostTableAdapter
    Friend WithEvents TableAdapterManager As Pilot.AvailablePartsTableAdapters.TableAdapterManager
    Friend WithEvents OrderStatusTableAdapter As Pilot.AvailablePartsTableAdapters.OrderStatusTableAdapter
    Friend WithEvents OrderStatusBindingSource As System.Windows.Forms.BindingSource
End Class
