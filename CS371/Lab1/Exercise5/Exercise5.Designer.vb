<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Exercise5
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lifeInput = New System.Windows.Forms.TextBox()
        Me.valueInput = New System.Windows.Forms.TextBox()
        Me.straightMethodButton = New System.Windows.Forms.RadioButton()
        Me.DigitsMethodButton = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridOutput = New System.Windows.Forms.DataGridView()
        Me.yearCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bookCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.depCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costInput = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        CType(Me.DataGridOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cost:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(46, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Salvage Value:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Life Time:"
        '
        'lifeInput
        '
        Me.lifeInput.Location = New System.Drawing.Point(150, 79)
        Me.lifeInput.Name = "lifeInput"
        Me.lifeInput.Size = New System.Drawing.Size(135, 20)
        Me.lifeInput.TabIndex = 4
        '
        'valueInput
        '
        Me.valueInput.Location = New System.Drawing.Point(150, 54)
        Me.valueInput.Name = "valueInput"
        Me.valueInput.Size = New System.Drawing.Size(135, 20)
        Me.valueInput.TabIndex = 5
        '
        'straightMethodButton
        '
        Me.straightMethodButton.AutoSize = True
        Me.straightMethodButton.Location = New System.Drawing.Point(44, 19)
        Me.straightMethodButton.Name = "straightMethodButton"
        Me.straightMethodButton.Size = New System.Drawing.Size(123, 17)
        Me.straightMethodButton.TabIndex = 6
        Me.straightMethodButton.TabStop = True
        Me.straightMethodButton.Text = "Straight Line Method"
        Me.straightMethodButton.UseVisualStyleBackColor = True
        '
        'DigitsMethodButton
        '
        Me.DigitsMethodButton.AutoSize = True
        Me.DigitsMethodButton.Location = New System.Drawing.Point(44, 42)
        Me.DigitsMethodButton.Name = "DigitsMethodButton"
        Me.DigitsMethodButton.Size = New System.Drawing.Size(177, 17)
        Me.DigitsMethodButton.TabIndex = 7
        Me.DigitsMethodButton.TabStop = True
        Me.DigitsMethodButton.Text = "Sum of the Years’ Digits Method"
        Me.DigitsMethodButton.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(131, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "$"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(131, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "$"
        '
        'DataGridOutput
        '
        Me.DataGridOutput.AllowUserToAddRows = False
        Me.DataGridOutput.AllowUserToDeleteRows = False
        Me.DataGridOutput.AllowUserToResizeColumns = False
        Me.DataGridOutput.AllowUserToResizeRows = False
        Me.DataGridOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridOutput.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.yearCol, Me.bookCol, Me.depCol})
        Me.DataGridOutput.Location = New System.Drawing.Point(12, 195)
        Me.DataGridOutput.Name = "DataGridOutput"
        Me.DataGridOutput.ReadOnly = True
        Me.DataGridOutput.RowHeadersVisible = False
        Me.DataGridOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridOutput.Size = New System.Drawing.Size(308, 189)
        Me.DataGridOutput.TabIndex = 35
        '
        'yearCol
        '
        Me.yearCol.HeaderText = "Year"
        Me.yearCol.Name = "yearCol"
        Me.yearCol.ReadOnly = True
        '
        'bookCol
        '
        Me.bookCol.HeaderText = "Book Value"
        Me.bookCol.Name = "bookCol"
        Me.bookCol.ReadOnly = True
        '
        'depCol
        '
        Me.depCol.HeaderText = "Depreciation"
        Me.depCol.Name = "depCol"
        Me.depCol.ReadOnly = True
        '
        'costInput
        '
        Me.costInput.Location = New System.Drawing.Point(150, 29)
        Me.costInput.Name = "costInput"
        Me.costInput.Size = New System.Drawing.Size(135, 20)
        Me.costInput.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(23, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(284, 100)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.straightMethodButton)
        Me.GroupBox2.Controls.Add(Me.DigitsMethodButton)
        Me.GroupBox2.Location = New System.Drawing.Point(23, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(284, 71)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Depreciation Method"
        '
        'Exercise5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 416)
        Me.Controls.Add(Me.DataGridOutput)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.valueInput)
        Me.Controls.Add(Me.lifeInput)
        Me.Controls.Add(Me.costInput)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Exercise5"
        Me.Text = "Depreciation of an Asset"
        CType(Me.DataGridOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lifeInput As TextBox
    Friend WithEvents valueInput As TextBox
    Friend WithEvents straightMethodButton As RadioButton
    Friend WithEvents DigitsMethodButton As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DataGridOutput As DataGridView
    Friend WithEvents yearCol As DataGridViewTextBoxColumn
    Friend WithEvents bookCol As DataGridViewTextBoxColumn
    Friend WithEvents depCol As DataGridViewTextBoxColumn
    Friend WithEvents costInput As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
