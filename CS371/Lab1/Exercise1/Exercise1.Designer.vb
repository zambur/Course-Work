<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Exercise1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.UserEnterText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OutputText = New System.Windows.Forms.RichTextBox()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.WarningLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Button1.Location = New System.Drawing.Point(71, 171)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Calculate"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UserEnterText
        '
        Me.UserEnterText.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.UserEnterText.Location = New System.Drawing.Point(178, 18)
        Me.UserEnterText.Name = "UserEnterText"
        Me.UserEnterText.Size = New System.Drawing.Size(100, 20)
        Me.UserEnterText.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(22, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Rate of Tax-free Yield:"
        '
        'OutputText
        '
        Me.OutputText.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.OutputText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OutputText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.OutputText.Location = New System.Drawing.Point(15, 57)
        Me.OutputText.Name = "OutputText"
        Me.OutputText.ReadOnly = True
        Me.OutputText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.OutputText.Size = New System.Drawing.Size(321, 96)
        Me.OutputText.TabIndex = 4
        Me.OutputText.Text = ""
        '
        'ClearButton
        '
        Me.ClearButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ClearButton.Location = New System.Drawing.Point(214, 171)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(75, 23)
        Me.ClearButton.TabIndex = 5
        Me.ClearButton.Text = "Clear"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'WarningLabel
        '
        Me.WarningLabel.AutoSize = True
        Me.WarningLabel.ForeColor = System.Drawing.Color.Red
        Me.WarningLabel.Location = New System.Drawing.Point(185, 41)
        Me.WarningLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.WarningLabel.Name = "WarningLabel"
        Me.WarningLabel.Size = New System.Drawing.Size(82, 13)
        Me.WarningLabel.TabIndex = 14
        Me.WarningLabel.Text = "Enter a number!"
        Me.WarningLabel.Visible = False
        '
        'Exercise1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(348, 206)
        Me.Controls.Add(Me.WarningLabel)
        Me.Controls.Add(Me.ClearButton)
        Me.Controls.Add(Me.OutputText)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UserEnterText)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Exercise1"
        Me.Text = "Yield on Tax-Free Investments"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents UserEnterText As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents OutputText As RichTextBox
    Friend WithEvents ClearButton As Button
    Friend WithEvents WarningLabel As Label
End Class
