<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Details
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
        Me.DataSet1 = New Exercise3.DataSet1()
        Me.TblPropertiesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TblPropertiesTableAdapter = New Exercise3.DataSet1TableAdapters.tblPropertiesTableAdapter()
        Me.TableAdapterManager = New Exercise3.DataSet1TableAdapters.TableAdapterManager()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TblRentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TblRentTableAdapter = New Exercise3.DataSet1TableAdapters.tblRentTableAdapter()
        Me.TblDataGridView = New System.Windows.Forms.DataGridView()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblPropertiesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblRentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TblPropertiesBindingSource
        '
        Me.TblPropertiesBindingSource.DataMember = "tblProperties"
        Me.TblPropertiesBindingSource.DataSource = Me.DataSet1
        '
        'TblPropertiesTableAdapter
        '
        Me.TblPropertiesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.sysdiagramsTableAdapter = Nothing
        Me.TableAdapterManager.tblPropertiesTableAdapter = Me.TblPropertiesTableAdapter
        Me.TableAdapterManager.tblRentTableAdapter = Nothing
        Me.TableAdapterManager.tblTenantTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Exercise3.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(13, 13)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(221, 25)
        Me.TitleLabel.TabIndex = 2
        Me.TitleLabel.Text = "Viewing All Properties"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(587, 368)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TblRentBindingSource
        '
        Me.TblRentBindingSource.DataMember = "tblRent"
        Me.TblRentBindingSource.DataSource = Me.DataSet1
        '
        'TblRentTableAdapter
        '
        Me.TblRentTableAdapter.ClearBeforeFill = True
        '
        'TblDataGridView
        '
        Me.TblDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TblDataGridView.Location = New System.Drawing.Point(12, 43)
        Me.TblDataGridView.Name = "TblDataGridView"
        Me.TblDataGridView.Size = New System.Drawing.Size(682, 319)
        Me.TblDataGridView.TabIndex = 3
        '
        'Details
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 401)
        Me.Controls.Add(Me.TblDataGridView)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TitleLabel)
        Me.Name = "Details"
        Me.Text = "Details"
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblPropertiesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblRentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataSet1 As Exercise3.DataSet1
    Friend WithEvents TblPropertiesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblPropertiesTableAdapter As Exercise3.DataSet1TableAdapters.tblPropertiesTableAdapter
    Friend WithEvents TableAdapterManager As Exercise3.DataSet1TableAdapters.TableAdapterManager
    Friend WithEvents TitleLabel As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TblRentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblRentTableAdapter As Exercise3.DataSet1TableAdapters.tblRentTableAdapter
    Friend WithEvents TblDataGridView As System.Windows.Forms.DataGridView
End Class
