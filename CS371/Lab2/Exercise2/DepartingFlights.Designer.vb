<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DepartingFlights
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
        Me.departingFlightData = New System.Windows.Forms.DataGridView()
        Me.departingLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.airline = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.departingFlightData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'departingFlightData
        '
        Me.departingFlightData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.departingFlightData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.departingLocation, Me.airline, Me.time, Me.gate, Me.status})
        Me.departingFlightData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.departingFlightData.Location = New System.Drawing.Point(0, 0)
        Me.departingFlightData.Name = "departingFlightData"
        Me.departingFlightData.Size = New System.Drawing.Size(542, 394)
        Me.departingFlightData.TabIndex = 0
        '
        'departingLocation
        '
        Me.departingLocation.HeaderText = "Departing To"
        Me.departingLocation.Name = "departingLocation"
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
        'DepartingFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 394)
        Me.Controls.Add(Me.departingFlightData)
        Me.Name = "DepartingFlights"
        Me.Text = "Departing Flights"
        CType(Me.departingFlightData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents departingFlightData As DataGridView
    Friend WithEvents departingLocation As DataGridViewTextBoxColumn
    Friend WithEvents airline As DataGridViewTextBoxColumn
    Friend WithEvents time As DataGridViewTextBoxColumn
    Friend WithEvents gate As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
End Class
