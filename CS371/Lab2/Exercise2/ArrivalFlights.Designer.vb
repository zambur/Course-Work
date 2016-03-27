<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArrivalFlights
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
        Me.arrivingFlightData = New System.Windows.Forms.DataGridView()
        Me.arrivingFlights = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.airline = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.arrivingFlightData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'arrivingFlightData
        '
        Me.arrivingFlightData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.arrivingFlightData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.arrivingFlights, Me.airline, Me.time, Me.gate, Me.status})
        Me.arrivingFlightData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.arrivingFlightData.Location = New System.Drawing.Point(0, 0)
        Me.arrivingFlightData.Name = "arrivingFlightData"
        Me.arrivingFlightData.Size = New System.Drawing.Size(544, 359)
        Me.arrivingFlightData.TabIndex = 1
        '
        'arrivingFlights
        '
        Me.arrivingFlights.HeaderText = "Arriving From"
        Me.arrivingFlights.Name = "arrivingFlights"
        '
        'airline
        '
        Me.airline.HeaderText = "Airline"
        Me.airline.Name = "airline"
        '
        'time
        '
        Me.time.HeaderText = "Time"
        Me.time.Name = "time"
        '
        'gate
        '
        Me.gate.HeaderText = "Gate"
        Me.gate.Name = "gate"
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        '
        'ArrivalFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 359)
        Me.Controls.Add(Me.arrivingFlightData)
        Me.Name = "ArrivalFlights"
        Me.Text = "Arriving Flights"
        CType(Me.arrivingFlightData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents arrivingFlightData As DataGridView
    Friend WithEvents arrivingFlights As DataGridViewTextBoxColumn
    Friend WithEvents airline As DataGridViewTextBoxColumn
    Friend WithEvents time As DataGridViewTextBoxColumn
    Friend WithEvents gate As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
End Class
