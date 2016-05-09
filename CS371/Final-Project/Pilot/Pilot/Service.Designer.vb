<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Service
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Service))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PartsListView = New System.Windows.Forms.ListView()
        Me.idCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.nameCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.catagoryCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.laborCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.priceCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.descCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListForwardButton = New System.Windows.Forms.Button()
        Me.ListBackButton = New System.Windows.Forms.Button()
        Me.ListViewPictureBox = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PartsTreeView = New System.Windows.Forms.TreeView()
        Me.TreeForwardButton = New System.Windows.Forms.Button()
        Me.TreeBackButton = New System.Windows.Forms.Button()
        Me.TreeViewPictureBox = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.PartsDataGridView = New System.Windows.Forms.DataGridView()
        Me.dataGridIDcol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridNameCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataGridCatagoryCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataGridLaborCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataGridPriceCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridDescCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridForwardButton = New System.Windows.Forms.Button()
        Me.DataGridBackButton = New System.Windows.Forms.Button()
        Me.DataGridPictureBox = New System.Windows.Forms.PictureBox()
        Me.AvailableParts = New Pilot.AvailableParts()
        Me.PartsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PartsTableAdapter = New Pilot.AvailablePartsTableAdapters.PartsTableAdapter()
        Me.TableAdapterManager = New Pilot.AvailablePartsTableAdapters.TableAdapterManager()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.ListViewPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.TreeViewPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.PartsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AvailableParts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PartsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(822, 356)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PartsListView)
        Me.TabPage1.Controls.Add(Me.ListForwardButton)
        Me.TabPage1.Controls.Add(Me.ListBackButton)
        Me.TabPage1.Controls.Add(Me.ListViewPictureBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(814, 330)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "List View Parts"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PartsListView
        '
        Me.PartsListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idCol, Me.nameCol, Me.catagoryCol, Me.laborCol, Me.priceCol, Me.descCol})
        Me.PartsListView.FullRowSelect = True
        Me.PartsListView.GridLines = True
        Me.PartsListView.Location = New System.Drawing.Point(6, 6)
        Me.PartsListView.MultiSelect = False
        Me.PartsListView.Name = "PartsListView"
        Me.PartsListView.Size = New System.Drawing.Size(445, 318)
        Me.PartsListView.TabIndex = 4
        Me.PartsListView.UseCompatibleStateImageBehavior = False
        Me.PartsListView.View = System.Windows.Forms.View.Details
        '
        'idCol
        '
        Me.idCol.Text = "ID"
        Me.idCol.Width = 30
        '
        'nameCol
        '
        Me.nameCol.Text = "Name"
        Me.nameCol.Width = 130
        '
        'catagoryCol
        '
        Me.catagoryCol.Text = "Catagory"
        Me.catagoryCol.Width = 100
        '
        'laborCol
        '
        Me.laborCol.Text = "Labor Cost"
        Me.laborCol.Width = 70
        '
        'priceCol
        '
        Me.priceCol.Text = "Price"
        '
        'descCol
        '
        Me.descCol.Text = "Description"
        Me.descCol.Width = 300
        '
        'ListForwardButton
        '
        Me.ListForwardButton.Location = New System.Drawing.Point(717, 286)
        Me.ListForwardButton.Name = "ListForwardButton"
        Me.ListForwardButton.Size = New System.Drawing.Size(91, 28)
        Me.ListForwardButton.TabIndex = 3
        Me.ListForwardButton.Text = "Forward"
        Me.ListForwardButton.UseVisualStyleBackColor = True
        '
        'ListBackButton
        '
        Me.ListBackButton.Location = New System.Drawing.Point(457, 286)
        Me.ListBackButton.Name = "ListBackButton"
        Me.ListBackButton.Size = New System.Drawing.Size(91, 28)
        Me.ListBackButton.TabIndex = 2
        Me.ListBackButton.Text = "Back"
        Me.ListBackButton.UseVisualStyleBackColor = True
        '
        'ListViewPictureBox
        '
        Me.ListViewPictureBox.Image = CType(resources.GetObject("ListViewPictureBox.Image"), System.Drawing.Image)
        Me.ListViewPictureBox.Location = New System.Drawing.Point(457, 6)
        Me.ListViewPictureBox.Name = "ListViewPictureBox"
        Me.ListViewPictureBox.Size = New System.Drawing.Size(351, 264)
        Me.ListViewPictureBox.TabIndex = 1
        Me.ListViewPictureBox.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PartsTreeView)
        Me.TabPage2.Controls.Add(Me.TreeForwardButton)
        Me.TabPage2.Controls.Add(Me.TreeBackButton)
        Me.TabPage2.Controls.Add(Me.TreeViewPictureBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(814, 330)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Tree View Parts"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'PartsTreeView
        '
        Me.PartsTreeView.Location = New System.Drawing.Point(6, 6)
        Me.PartsTreeView.Name = "PartsTreeView"
        Me.PartsTreeView.Size = New System.Drawing.Size(448, 318)
        Me.PartsTreeView.TabIndex = 7
        '
        'TreeForwardButton
        '
        Me.TreeForwardButton.Location = New System.Drawing.Point(717, 280)
        Me.TreeForwardButton.Name = "TreeForwardButton"
        Me.TreeForwardButton.Size = New System.Drawing.Size(91, 28)
        Me.TreeForwardButton.TabIndex = 6
        Me.TreeForwardButton.Text = "Forward"
        Me.TreeForwardButton.UseVisualStyleBackColor = True
        '
        'TreeBackButton
        '
        Me.TreeBackButton.Location = New System.Drawing.Point(460, 280)
        Me.TreeBackButton.Name = "TreeBackButton"
        Me.TreeBackButton.Size = New System.Drawing.Size(91, 28)
        Me.TreeBackButton.TabIndex = 5
        Me.TreeBackButton.Text = "Back"
        Me.TreeBackButton.UseVisualStyleBackColor = True
        '
        'TreeViewPictureBox
        '
        Me.TreeViewPictureBox.Image = CType(resources.GetObject("TreeViewPictureBox.Image"), System.Drawing.Image)
        Me.TreeViewPictureBox.Location = New System.Drawing.Point(460, 6)
        Me.TreeViewPictureBox.Name = "TreeViewPictureBox"
        Me.TreeViewPictureBox.Size = New System.Drawing.Size(348, 268)
        Me.TreeViewPictureBox.TabIndex = 4
        Me.TreeViewPictureBox.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.PartsDataGridView)
        Me.TabPage3.Controls.Add(Me.DataGridForwardButton)
        Me.TabPage3.Controls.Add(Me.DataGridBackButton)
        Me.TabPage3.Controls.Add(Me.DataGridPictureBox)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(814, 330)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "DataGrid Parts"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'PartsDataGridView
        '
        Me.PartsDataGridView.AllowUserToAddRows = False
        Me.PartsDataGridView.AllowUserToDeleteRows = False
        Me.PartsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PartsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dataGridIDcol, Me.DataGridNameCol, Me.dataGridCatagoryCol, Me.dataGridLaborCol, Me.dataGridPriceCol, Me.DataGridDescCol})
        Me.PartsDataGridView.Location = New System.Drawing.Point(6, 6)
        Me.PartsDataGridView.MultiSelect = False
        Me.PartsDataGridView.Name = "PartsDataGridView"
        Me.PartsDataGridView.ReadOnly = True
        Me.PartsDataGridView.RowHeadersVisible = False
        Me.PartsDataGridView.Size = New System.Drawing.Size(446, 318)
        Me.PartsDataGridView.TabIndex = 7
        '
        'dataGridIDcol
        '
        Me.dataGridIDcol.HeaderText = "ID"
        Me.dataGridIDcol.Name = "dataGridIDcol"
        Me.dataGridIDcol.ReadOnly = True
        Me.dataGridIDcol.Width = 30
        '
        'DataGridNameCol
        '
        Me.DataGridNameCol.HeaderText = "Name"
        Me.DataGridNameCol.Name = "DataGridNameCol"
        Me.DataGridNameCol.ReadOnly = True
        Me.DataGridNameCol.Width = 120
        '
        'dataGridCatagoryCol
        '
        Me.dataGridCatagoryCol.HeaderText = "Catagory"
        Me.dataGridCatagoryCol.Name = "dataGridCatagoryCol"
        Me.dataGridCatagoryCol.ReadOnly = True
        '
        'dataGridLaborCol
        '
        Me.dataGridLaborCol.HeaderText = "Labor Cost"
        Me.dataGridLaborCol.Name = "dataGridLaborCol"
        Me.dataGridLaborCol.ReadOnly = True
        '
        'dataGridPriceCol
        '
        Me.dataGridPriceCol.HeaderText = "Price"
        Me.dataGridPriceCol.Name = "dataGridPriceCol"
        Me.dataGridPriceCol.ReadOnly = True
        '
        'DataGridDescCol
        '
        Me.DataGridDescCol.HeaderText = "Description"
        Me.DataGridDescCol.Name = "DataGridDescCol"
        Me.DataGridDescCol.ReadOnly = True
        Me.DataGridDescCol.Width = 300
        '
        'DataGridForwardButton
        '
        Me.DataGridForwardButton.Location = New System.Drawing.Point(717, 287)
        Me.DataGridForwardButton.Name = "DataGridForwardButton"
        Me.DataGridForwardButton.Size = New System.Drawing.Size(91, 28)
        Me.DataGridForwardButton.TabIndex = 6
        Me.DataGridForwardButton.Text = "Forward"
        Me.DataGridForwardButton.UseVisualStyleBackColor = True
        '
        'DataGridBackButton
        '
        Me.DataGridBackButton.Location = New System.Drawing.Point(458, 287)
        Me.DataGridBackButton.Name = "DataGridBackButton"
        Me.DataGridBackButton.Size = New System.Drawing.Size(91, 28)
        Me.DataGridBackButton.TabIndex = 5
        Me.DataGridBackButton.Text = "Back"
        Me.DataGridBackButton.UseVisualStyleBackColor = True
        '
        'DataGridPictureBox
        '
        Me.DataGridPictureBox.Image = CType(resources.GetObject("DataGridPictureBox.Image"), System.Drawing.Image)
        Me.DataGridPictureBox.Location = New System.Drawing.Point(458, 6)
        Me.DataGridPictureBox.Name = "DataGridPictureBox"
        Me.DataGridPictureBox.Size = New System.Drawing.Size(350, 266)
        Me.DataGridPictureBox.TabIndex = 4
        Me.DataGridPictureBox.TabStop = False
        '
        'AvailableParts
        '
        Me.AvailableParts.DataSetName = "AvailableParts"
        Me.AvailableParts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PartsBindingSource
        '
        Me.PartsBindingSource.DataMember = "Parts"
        Me.PartsBindingSource.DataSource = Me.AvailableParts
        '
        'PartsTableAdapter
        '
        Me.PartsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.OrderCostTableAdapter = Nothing
        Me.TableAdapterManager.OrderStatusTableAdapter = Nothing
        Me.TableAdapterManager.PartsTableAdapter = Me.PartsTableAdapter
        Me.TableAdapterManager.UpdateOrder = Pilot.AvailablePartsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Service
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 380)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Service"
        Me.Text = "Service"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.ListViewPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.TreeViewPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.PartsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AvailableParts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PartsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ListForwardButton As System.Windows.Forms.Button
    Friend WithEvents ListBackButton As System.Windows.Forms.Button
    Friend WithEvents ListViewPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents PartsTreeView As System.Windows.Forms.TreeView
    Friend WithEvents TreeForwardButton As System.Windows.Forms.Button
    Friend WithEvents TreeBackButton As System.Windows.Forms.Button
    Friend WithEvents TreeViewPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents PartsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridForwardButton As System.Windows.Forms.Button
    Friend WithEvents DataGridBackButton As System.Windows.Forms.Button
    Friend WithEvents DataGridPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AvailableParts As Pilot.AvailableParts
    Friend WithEvents PartsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PartsTableAdapter As Pilot.AvailablePartsTableAdapters.PartsTableAdapter
    Friend WithEvents TableAdapterManager As Pilot.AvailablePartsTableAdapters.TableAdapterManager
    Friend WithEvents PartsListView As System.Windows.Forms.ListView
    Friend WithEvents idCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents nameCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents catagoryCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents laborCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents priceCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents descCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents dataGridIDcol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridNameCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataGridCatagoryCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataGridLaborCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataGridPriceCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridDescCol As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
