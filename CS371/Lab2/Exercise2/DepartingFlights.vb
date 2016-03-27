'Zach Ambut
'CS 371
'Lab 2
Public Class DepartingFlights
    'Update departing flight data grid view when a new flight is added
    Private Sub Flight_Departing(sender As Object, e As FlightInfo)
        Dim dgvRow As New DataGridViewRow
        Dim dgvCell As DataGridViewCell

        dgvCell = New DataGridViewTextBoxCell()
        dgvCell.Value = e.FlightLocation
        dgvRow.Cells.Add(dgvCell)

        dgvCell = New DataGridViewTextBoxCell()
        dgvCell.Value = e.FlightAirline
        dgvRow.Cells.Add(dgvCell)

        dgvCell = New DataGridViewTextBoxCell()
        dgvCell.Value = e.FlightTime
        dgvRow.Cells.Add(dgvCell)

        dgvCell = New DataGridViewTextBoxCell()
        dgvCell.Value = e.FlightGate
        dgvRow.Cells.Add(dgvCell)

        dgvCell = New DataGridViewTextBoxCell()
        dgvCell.Value = e.FlightStatus
        dgvRow.Cells.Add(dgvCell)

        departingFlightData.Rows.Add(dgvRow)

    End Sub

    Private Sub ArrivalFlights_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Call function to update data grid view when a new flight is added
        AddHandler ControlPanel.MyFlightManager.Depart, AddressOf Me.Flight_Departing
    End Sub

    'Exit the entire program if just this window is closed
    Private Sub TrainBoard_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
End Class