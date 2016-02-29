<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Exercise3
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
        Me.MortgageInput = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.InterestInput = New System.Windows.Forms.TextBox()
        Me.CalculateButton = New System.Windows.Forms.Button()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.WarningLabel = New System.Windows.Forms.Label()
        Me.OutputGridView = New System.Windows.Forms.DataGridView()
        Me.yearCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.interestCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.paymentCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.OutputGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mortgage Amount"
        '
        'MortgageInput
        '
        Me.MortgageInput.Location = New System.Drawing.Point(167, 12)
        Me.MortgageInput.Name = "MortgageInput"
        Me.MortgageInput.Size = New System.Drawing.Size(100, 20)
        Me.MortgageInput.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Annual Interest Rate"
        '
        'InterestInput
        '
        Me.InterestInput.Location = New System.Drawing.Point(167, 48)
        Me.InterestInput.Name = "InterestInput"
        Me.InterestInput.Size = New System.Drawing.Size(100, 20)
        Me.InterestInput.TabIndex = 3
        '
        'CalculateButton
        '
        Me.CalculateButton.Location = New System.Drawing.Point(60, 248)
        Me.CalculateButton.Margin = New System.Windows.Forms.Padding(2)
        Me.CalculateButton.Name = "CalculateButton"
        Me.CalculateButton.Size = New System.Drawing.Size(81, 24)
        Me.CalculateButton.TabIndex = 31
        Me.CalculateButton.Text = "Calculate"
        Me.CalculateButton.UseVisualStyleBackColor = True
        '
        'ResetButton
        '
        Me.ResetButton.Location = New System.Drawing.Point(208, 248)
        Me.ResetButton.Margin = New System.Windows.Forms.Padding(2)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(81, 24)
        Me.ResetButton.TabIndex = 32
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'WarningLabel
        '
        Me.WarningLabel.AutoSize = True
        Me.WarningLabel.ForeColor = System.Drawing.Color.Red
        Me.WarningLabel.Location = New System.Drawing.Point(174, 32)
        Me.WarningLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.WarningLabel.Name = "WarningLabel"
        Me.WarningLabel.Size = New System.Drawing.Size(82, 13)
        Me.WarningLabel.TabIndex = 33
        Me.WarningLabel.Text = "Enter a number!"
        Me.WarningLabel.Visible = False
        '
        'OutputGridView
        '
        Me.OutputGridView.AllowUserToAddRows = False
        Me.OutputGridView.AllowUserToDeleteRows = False
        Me.OutputGridView.AllowUserToResizeColumns = False
        Me.OutputGridView.AllowUserToResizeRows = False
        Me.OutputGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OutputGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.yearCol, Me.interestCol, Me.paymentCol})
        Me.OutputGridView.Location = New System.Drawing.Point(12, 75)
        Me.OutputGridView.Name = "OutputGridView"
        Me.OutputGridView.ReadOnly = True
        Me.OutputGridView.RowHeadersVisible = False
        Me.OutputGridView.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.OutputGridView.Size = New System.Drawing.Size(322, 154)
        Me.OutputGridView.TabIndex = 34
        '
        'yearCol
        '
        Me.yearCol.HeaderText = "Years"
        Me.yearCol.Name = "yearCol"
        Me.yearCol.ReadOnly = True
        Me.yearCol.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'interestCol
        '
        Me.interestCol.HeaderText = "Total Interest"
        Me.interestCol.Name = "interestCol"
        Me.interestCol.ReadOnly = True
        Me.interestCol.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'paymentCol
        '
        Me.paymentCol.HeaderText = "Monthly Payment"
        Me.paymentCol.Name = "paymentCol"
        Me.paymentCol.ReadOnly = True
        Me.paymentCol.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.paymentCol.Width = 120
        '
        'Exercise3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(346, 291)
        Me.Controls.Add(Me.OutputGridView)
        Me.Controls.Add(Me.WarningLabel)
        Me.Controls.Add(Me.ResetButton)
        Me.Controls.Add(Me.CalculateButton)
        Me.Controls.Add(Me.InterestInput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MortgageInput)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Exercise3"
        Me.Text = "Mortgage Calculator"
        CType(Me.OutputGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MortgageInput As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents InterestInput As TextBox
    Friend WithEvents CalculateButton As Button
    Friend WithEvents ResetButton As Button
    Friend WithEvents WarningLabel As Label
    Friend WithEvents OutputGridView As DataGridView
    Friend WithEvents yearCol As DataGridViewTextBoxColumn
    Friend WithEvents interestCol As DataGridViewTextBoxColumn
    Friend WithEvents paymentCol As DataGridViewTextBoxColumn
End Class
