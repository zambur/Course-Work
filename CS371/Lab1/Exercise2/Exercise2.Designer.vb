<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Exercise2
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
        Me.InputWarningLabel = New System.Windows.Forms.Label()
        Me.WarningLabel = New System.Windows.Forms.Label()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.SubmitButton = New System.Windows.Forms.Button()
        Me.CultureTextBox = New System.Windows.Forms.TextBox()
        Me.ResultTextBox = New System.Windows.Forms.TextBox()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EnterButton = New System.Windows.Forms.Button()
        Me.NumberTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OutTextBox = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'InputWarningLabel
        '
        Me.InputWarningLabel.AutoSize = True
        Me.InputWarningLabel.ForeColor = System.Drawing.Color.Red
        Me.InputWarningLabel.Location = New System.Drawing.Point(329, 102)
        Me.InputWarningLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.InputWarningLabel.Name = "InputWarningLabel"
        Me.InputWarningLabel.Size = New System.Drawing.Size(47, 13)
        Me.InputWarningLabel.TabIndex = 28
        Me.InputWarningLabel.Text = "Fix Input"
        Me.InputWarningLabel.Visible = False
        '
        'WarningLabel
        '
        Me.WarningLabel.AutoSize = True
        Me.WarningLabel.ForeColor = System.Drawing.Color.Red
        Me.WarningLabel.Location = New System.Drawing.Point(183, 38)
        Me.WarningLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.WarningLabel.Name = "WarningLabel"
        Me.WarningLabel.Size = New System.Drawing.Size(82, 13)
        Me.WarningLabel.TabIndex = 27
        Me.WarningLabel.Text = "Enter a number!"
        Me.WarningLabel.Visible = False
        '
        'ResetButton
        '
        Me.ResetButton.Location = New System.Drawing.Point(298, 153)
        Me.ResetButton.Margin = New System.Windows.Forms.Padding(2)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(66, 21)
        Me.ResetButton.TabIndex = 26
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'ClearButton
        '
        Me.ClearButton.Location = New System.Drawing.Point(186, 153)
        Me.ClearButton.Margin = New System.Windows.Forms.Padding(2)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(66, 23)
        Me.ClearButton.TabIndex = 25
        Me.ClearButton.Text = "Clear"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'SubmitButton
        '
        Me.SubmitButton.Location = New System.Drawing.Point(72, 153)
        Me.SubmitButton.Margin = New System.Windows.Forms.Padding(2)
        Me.SubmitButton.Name = "SubmitButton"
        Me.SubmitButton.Size = New System.Drawing.Size(58, 24)
        Me.SubmitButton.TabIndex = 24
        Me.SubmitButton.Text = "Submit"
        Me.SubmitButton.UseVisualStyleBackColor = True
        '
        'CultureTextBox
        '
        Me.CultureTextBox.Enabled = False
        Me.CultureTextBox.Location = New System.Drawing.Point(202, 117)
        Me.CultureTextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.CultureTextBox.MaxLength = 2
        Me.CultureTextBox.Name = "CultureTextBox"
        Me.CultureTextBox.Size = New System.Drawing.Size(39, 20)
        Me.CultureTextBox.TabIndex = 23
        '
        'ResultTextBox
        '
        Me.ResultTextBox.Enabled = False
        Me.ResultTextBox.Location = New System.Drawing.Point(202, 86)
        Me.ResultTextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.ResultTextBox.MaxLength = 2
        Me.ResultTextBox.Name = "ResultTextBox"
        Me.ResultTextBox.Size = New System.Drawing.Size(40, 20)
        Me.ResultTextBox.TabIndex = 22
        '
        'NameTextBox
        '
        Me.NameTextBox.Enabled = False
        Me.NameTextBox.Location = New System.Drawing.Point(202, 57)
        Me.NameTextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(114, 20)
        Me.NameTextBox.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(82, 117)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Cultrue Score (1-10):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(82, 90)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Results Score (1-10):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(82, 59)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Manager's Name:"
        '
        'EnterButton
        '
        Me.EnterButton.Location = New System.Drawing.Point(298, 11)
        Me.EnterButton.Margin = New System.Windows.Forms.Padding(2)
        Me.EnterButton.Name = "EnterButton"
        Me.EnterButton.Size = New System.Drawing.Size(67, 27)
        Me.EnterButton.TabIndex = 17
        Me.EnterButton.Text = "Enter"
        Me.EnterButton.UseVisualStyleBackColor = True
        '
        'NumberTextBox
        '
        Me.NumberTextBox.Location = New System.Drawing.Point(202, 16)
        Me.NumberTextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.NumberTextBox.MaxLength = 3
        Me.NumberTextBox.Name = "NumberTextBox"
        Me.NumberTextBox.Size = New System.Drawing.Size(50, 20)
        Me.NumberTextBox.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(82, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Number of Managers:"
        '
        'OutTextBox
        '
        Me.OutTextBox.Enabled = False
        Me.OutTextBox.Location = New System.Drawing.Point(24, 192)
        Me.OutTextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.OutTextBox.Name = "OutTextBox"
        Me.OutTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.OutTextBox.Size = New System.Drawing.Size(384, 197)
        Me.OutTextBox.TabIndex = 29
        Me.OutTextBox.Text = ""
        '
        'Exercise2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 411)
        Me.Controls.Add(Me.OutTextBox)
        Me.Controls.Add(Me.InputWarningLabel)
        Me.Controls.Add(Me.WarningLabel)
        Me.Controls.Add(Me.ResetButton)
        Me.Controls.Add(Me.ClearButton)
        Me.Controls.Add(Me.SubmitButton)
        Me.Controls.Add(Me.CultureTextBox)
        Me.Controls.Add(Me.ResultTextBox)
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.EnterButton)
        Me.Controls.Add(Me.NumberTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Exercise2"
        Me.Text = "Tough Evaluations"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents InputWarningLabel As Label
    Friend WithEvents WarningLabel As Label
    Friend WithEvents ResetButton As Button
    Friend WithEvents ClearButton As Button
    Friend WithEvents SubmitButton As Button
    Friend WithEvents CultureTextBox As TextBox
    Friend WithEvents ResultTextBox As TextBox
    Friend WithEvents NameTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents EnterButton As Button
    Friend WithEvents NumberTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents OutTextBox As RichTextBox
End Class
