<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Exercise4
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
        Me.DataGridInput = New System.Windows.Forms.DataGridView()
        Me.mondayCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tuesdayCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wednesdayCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.thursdayCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fridayCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.empNameInput = New System.Windows.Forms.TextBox()
        Me.wageInput = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.hourOutput = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.wageOutput = New System.Windows.Forms.TextBox()
        Me.hoursButton = New System.Windows.Forms.Button()
        Me.wageButton = New System.Windows.Forms.Button()
        Me.clearButton = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.WarningLabel = New System.Windows.Forms.Label()
        Me.InputWarningLabel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        CType(Me.DataGridInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridInput
        '
        Me.DataGridInput.AllowUserToAddRows = False
        Me.DataGridInput.AllowUserToDeleteRows = False
        Me.DataGridInput.AllowUserToResizeColumns = False
        Me.DataGridInput.AllowUserToResizeRows = False
        Me.DataGridInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridInput.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.mondayCol, Me.tuesdayCol, Me.wednesdayCol, Me.thursdayCol, Me.fridayCol})
        Me.DataGridInput.Location = New System.Drawing.Point(12, 84)
        Me.DataGridInput.Name = "DataGridInput"
        Me.DataGridInput.RowHeadersWidth = 90
        Me.DataGridInput.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DataGridInput.Size = New System.Drawing.Size(592, 71)
        Me.DataGridInput.TabIndex = 0
        '
        'mondayCol
        '
        Me.mondayCol.HeaderText = "Monday"
        Me.mondayCol.Name = "mondayCol"
        '
        'tuesdayCol
        '
        Me.tuesdayCol.HeaderText = "Tuesday"
        Me.tuesdayCol.Name = "tuesdayCol"
        '
        'wednesdayCol
        '
        Me.wednesdayCol.HeaderText = "Wednesday"
        Me.wednesdayCol.Name = "wednesdayCol"
        '
        'thursdayCol
        '
        Me.thursdayCol.HeaderText = "Thursday"
        Me.thursdayCol.Name = "thursdayCol"
        '
        'fridayCol
        '
        Me.fridayCol.HeaderText = "Friday"
        Me.fridayCol.Name = "fridayCol"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Employee Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Hourly Wage"
        '
        'empNameInput
        '
        Me.empNameInput.Location = New System.Drawing.Point(124, 15)
        Me.empNameInput.Name = "empNameInput"
        Me.empNameInput.Size = New System.Drawing.Size(246, 20)
        Me.empNameInput.TabIndex = 3
        '
        'wageInput
        '
        Me.wageInput.Location = New System.Drawing.Point(124, 46)
        Me.wageInput.Name = "wageInput"
        Me.wageInput.Size = New System.Drawing.Size(79, 20)
        Me.wageInput.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(111, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "$"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Total Hours"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Total Wage"
        '
        'hourOutput
        '
        Me.hourOutput.BackColor = System.Drawing.SystemColors.Control
        Me.hourOutput.Enabled = False
        Me.hourOutput.Location = New System.Drawing.Point(96, 12)
        Me.hourOutput.Name = "hourOutput"
        Me.hourOutput.ReadOnly = True
        Me.hourOutput.Size = New System.Drawing.Size(62, 20)
        Me.hourOutput.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(83, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "$"
        '
        'wageOutput
        '
        Me.wageOutput.BackColor = System.Drawing.SystemColors.Control
        Me.wageOutput.Enabled = False
        Me.wageOutput.Location = New System.Drawing.Point(96, 46)
        Me.wageOutput.Name = "wageOutput"
        Me.wageOutput.ReadOnly = True
        Me.wageOutput.Size = New System.Drawing.Size(62, 20)
        Me.wageOutput.TabIndex = 11
        '
        'hoursButton
        '
        Me.hoursButton.Location = New System.Drawing.Point(233, 161)
        Me.hoursButton.Name = "hoursButton"
        Me.hoursButton.Size = New System.Drawing.Size(103, 23)
        Me.hoursButton.TabIndex = 13
        Me.hoursButton.Text = "Calculate Hours"
        Me.hoursButton.UseVisualStyleBackColor = True
        '
        'wageButton
        '
        Me.wageButton.Location = New System.Drawing.Point(353, 161)
        Me.wageButton.Name = "wageButton"
        Me.wageButton.Size = New System.Drawing.Size(103, 23)
        Me.wageButton.TabIndex = 14
        Me.wageButton.Text = "Calculate Wage"
        Me.wageButton.UseVisualStyleBackColor = True
        '
        'clearButton
        '
        Me.clearButton.Location = New System.Drawing.Point(473, 161)
        Me.clearButton.Name = "clearButton"
        Me.clearButton.Size = New System.Drawing.Size(103, 23)
        Me.clearButton.TabIndex = 15
        Me.clearButton.Text = "Clear"
        Me.clearButton.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(12, 158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(164, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "*Enter time in form of: HH:MMa/p"
        '
        'WarningLabel
        '
        Me.WarningLabel.AutoSize = True
        Me.WarningLabel.ForeColor = System.Drawing.Color.Red
        Me.WarningLabel.Location = New System.Drawing.Point(255, 51)
        Me.WarningLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.WarningLabel.Name = "WarningLabel"
        Me.WarningLabel.Size = New System.Drawing.Size(115, 13)
        Me.WarningLabel.TabIndex = 28
        Me.WarningLabel.Text = "Enter valid time stamps"
        Me.WarningLabel.Visible = False
        '
        'InputWarningLabel
        '
        Me.InputWarningLabel.AutoSize = True
        Me.InputWarningLabel.ForeColor = System.Drawing.Color.Red
        Me.InputWarningLabel.Location = New System.Drawing.Point(255, 38)
        Me.InputWarningLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.InputWarningLabel.Name = "InputWarningLabel"
        Me.InputWarningLabel.Size = New System.Drawing.Size(125, 13)
        Me.InputWarningLabel.TabIndex = 29
        Me.InputWarningLabel.Text = "Enter valid employee info"
        Me.InputWarningLabel.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label8.Location = New System.Drawing.Point(52, 171)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 13)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Example: 11:30a"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.wageOutput)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.hourOutput)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(433, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 76)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.empNameInput)
        Me.GroupBox2.Controls.Add(Me.InputWarningLabel)
        Me.GroupBox2.Controls.Add(Me.WarningLabel)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.wageInput)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(385, 76)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        '
        'Exercise4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(617, 196)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.clearButton)
        Me.Controls.Add(Me.wageButton)
        Me.Controls.Add(Me.hoursButton)
        Me.Controls.Add(Me.DataGridInput)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Exercise4"
        Me.Text = "Wage Calculator"
        CType(Me.DataGridInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridInput As DataGridView
    Friend WithEvents mondayCol As DataGridViewTextBoxColumn
    Friend WithEvents tuesdayCol As DataGridViewTextBoxColumn
    Friend WithEvents wednesdayCol As DataGridViewTextBoxColumn
    Friend WithEvents thursdayCol As DataGridViewTextBoxColumn
    Friend WithEvents fridayCol As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents empNameInput As TextBox
    Friend WithEvents wageInput As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents hourOutput As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents wageOutput As TextBox
    Friend WithEvents hoursButton As Button
    Friend WithEvents wageButton As Button
    Friend WithEvents clearButton As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents WarningLabel As Label
    Friend WithEvents InputWarningLabel As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
