<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuForm
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinancesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RentReceiptsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnpaidRentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.PropertyToolStripMenuItem, Me.FinancesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1008, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'PropertyToolStripMenuItem
        '
        Me.PropertyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchToolStripMenuItem, Me.ShowAllToolStripMenuItem})
        Me.PropertyToolStripMenuItem.Name = "PropertyToolStripMenuItem"
        Me.PropertyToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.PropertyToolStripMenuItem.Text = "Property"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SearchToolStripMenuItem.Text = "Search"
        '
        'ShowAllToolStripMenuItem
        '
        Me.ShowAllToolStripMenuItem.Name = "ShowAllToolStripMenuItem"
        Me.ShowAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ShowAllToolStripMenuItem.Text = "Show All"
        '
        'FinancesToolStripMenuItem
        '
        Me.FinancesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RentReceiptsToolStripMenuItem, Me.UnpaidRentToolStripMenuItem})
        Me.FinancesToolStripMenuItem.Name = "FinancesToolStripMenuItem"
        Me.FinancesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.FinancesToolStripMenuItem.Text = "Finances"
        '
        'RentReceiptsToolStripMenuItem
        '
        Me.RentReceiptsToolStripMenuItem.Name = "RentReceiptsToolStripMenuItem"
        Me.RentReceiptsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RentReceiptsToolStripMenuItem.Text = "Rent Receipts"
        '
        'UnpaidRentToolStripMenuItem
        '
        Me.UnpaidRentToolStripMenuItem.Name = "UnpaidRentToolStripMenuItem"
        Me.UnpaidRentToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.UnpaidRentToolStripMenuItem.Text = "Unpaid Rent"
        '
        'MenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 530)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MenuForm"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropertyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FinancesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RentReceiptsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnpaidRentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
