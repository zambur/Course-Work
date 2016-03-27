<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlPanel
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
        Me.locationBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.airlineBox = New System.Windows.Forms.ComboBox()
        Me.label11 = New System.Windows.Forms.Label()
        Me.timeBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ampmBox = New System.Windows.Forms.ComboBox()
        Me.gateBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.statusBox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.departFlightButton = New System.Windows.Forms.Button()
        Me.arrivingFlightButton = New System.Windows.Forms.Button()
        Me.warningLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(110, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(288, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Add a Flight to the display boards"
        '
        'locationBox
        '
        Me.locationBox.FormattingEnabled = True
        Me.locationBox.Items.AddRange(New Object() {"Atlanta, GA", "Anchorage, AK", "Austin, TX", "Baltimore, MD", "Boston, MA", "Charlotte, NC", "Chicago, IL", "Cincinnati, OH", "Cleveland, OH", "Dallas, TX", "Dencer, CO", "Detroit, MI", "Fort Myers, FL", "Hartford, CT", "Honolulu, HI", "Houston, TX", "Indianapolis, IN", "Kansas City, MO", "Las Vegas, NV", "Los Angeles, CA", "Madison, WI", "Memphis, TN", "Miami, FL", "Minneapolis, MN", "Nashville, TN", "New York, NY", "Orlando, FL", "San Diego, CA", "Salt Lake City, UT", "San Francisco, CA", "San Jose, CA", "Seattle, WA", "Tampa, FL", "Washington D.C., WA"})
        Me.locationBox.Location = New System.Drawing.Point(12, 80)
        Me.locationBox.Name = "locationBox"
        Me.locationBox.Size = New System.Drawing.Size(144, 21)
        Me.locationBox.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Location:"
        '
        'airlineBox
        '
        Me.airlineBox.FormattingEnabled = True
        Me.airlineBox.Items.AddRange(New Object() {"Alaska Airlines", "Allegiant Air", "American Airlines", "Delta Airlines", "Frontier Airlines", "Hawaiian Airlines", "JetBlue Airways", "Southwest Airlines", "Spirit Airlines", "Sun Country Airlines", "United Airlines", "Virgin America"})
        Me.airlineBox.Location = New System.Drawing.Point(177, 80)
        Me.airlineBox.Name = "airlineBox"
        Me.airlineBox.Size = New System.Drawing.Size(121, 21)
        Me.airlineBox.TabIndex = 3
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(174, 60)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(38, 13)
        Me.label11.TabIndex = 4
        Me.label11.Text = "Airline:"
        '
        'timeBox
        '
        Me.timeBox.FormattingEnabled = True
        Me.timeBox.Items.AddRange(New Object() {"12:00", "12:30", "1:00", "1:30", "2:00", "2:30", "3:00", "3:30", "4:00", "4:30", "5:00", "5:30", "6:00", "6:30", "7:00", "7:30", "8:00", "8:30", "9:00", "9:30", "10:00", "10:30", "11:00", "11:30"})
        Me.timeBox.Location = New System.Drawing.Point(328, 80)
        Me.timeBox.Name = "timeBox"
        Me.timeBox.Size = New System.Drawing.Size(70, 21)
        Me.timeBox.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(325, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Time:"
        '
        'ampmBox
        '
        Me.ampmBox.FormattingEnabled = True
        Me.ampmBox.Items.AddRange(New Object() {"AM", "PM"})
        Me.ampmBox.Location = New System.Drawing.Point(404, 80)
        Me.ampmBox.Name = "ampmBox"
        Me.ampmBox.Size = New System.Drawing.Size(54, 21)
        Me.ampmBox.TabIndex = 7
        '
        'gateBox
        '
        Me.gateBox.Location = New System.Drawing.Point(12, 144)
        Me.gateBox.Name = "gateBox"
        Me.gateBox.Size = New System.Drawing.Size(115, 20)
        Me.gateBox.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Gate:"
        '
        'statusBox
        '
        Me.statusBox.FormattingEnabled = True
        Me.statusBox.Items.AddRange(New Object() {"On Time", "Boarding", "Delayed", "Closed", "Departed", "Arrived"})
        Me.statusBox.Location = New System.Drawing.Point(177, 144)
        Me.statusBox.Name = "statusBox"
        Me.statusBox.Size = New System.Drawing.Size(121, 21)
        Me.statusBox.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(177, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Status:"
        '
        'departFlightButton
        '
        Me.departFlightButton.Location = New System.Drawing.Point(262, 184)
        Me.departFlightButton.Name = "departFlightButton"
        Me.departFlightButton.Size = New System.Drawing.Size(136, 29)
        Me.departFlightButton.TabIndex = 12
        Me.departFlightButton.Text = "Departing Flight"
        Me.departFlightButton.UseVisualStyleBackColor = True
        '
        'arrivingFlightButton
        '
        Me.arrivingFlightButton.Location = New System.Drawing.Point(81, 184)
        Me.arrivingFlightButton.Name = "arrivingFlightButton"
        Me.arrivingFlightButton.Size = New System.Drawing.Size(136, 29)
        Me.arrivingFlightButton.TabIndex = 13
        Me.arrivingFlightButton.Text = "Arriving Flight"
        Me.arrivingFlightButton.UseVisualStyleBackColor = True
        '
        'warningLabel
        '
        Me.warningLabel.AutoSize = True
        Me.warningLabel.ForeColor = System.Drawing.Color.Red
        Me.warningLabel.Location = New System.Drawing.Point(315, 144)
        Me.warningLabel.Name = "warningLabel"
        Me.warningLabel.Size = New System.Drawing.Size(143, 13)
        Me.warningLabel.TabIndex = 14
        Me.warningLabel.Text = "*Make sure all fields are filled"
        Me.warningLabel.Visible = False
        '
        'ControlPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 230)
        Me.Controls.Add(Me.warningLabel)
        Me.Controls.Add(Me.arrivingFlightButton)
        Me.Controls.Add(Me.departFlightButton)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.statusBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gateBox)
        Me.Controls.Add(Me.ampmBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.timeBox)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.airlineBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.locationBox)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ControlPanel"
        Me.Text = "Control Panel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents locationBox As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents label11 As Label
    Friend WithEvents timeBox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ampmBox As ComboBox
    Public WithEvents airlineBox As ComboBox
    Friend WithEvents gateBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents statusBox As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents departFlightButton As Button
    Friend WithEvents arrivingFlightButton As Button
    Friend WithEvents warningLabel As Label
End Class
