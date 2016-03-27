'Zach Ambut
'CS 371
'Lab 2
Public Class ControlPanel
    Friend WithEvents MyFlightManager As New FlightManager
    'When form loads it also opens up the the arive and depart windows
    Private Sub Controller_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim arrivingBoard As New ArrivalFlights
        arrivingBoard.Show()
        Dim departingBoard As New DepartingFlights
        departingBoard.StartPosition = FormStartPosition.CenterScreen
        departingBoard.Show()
    End Sub

    'After the user enters in the required data for the flight it will then send the data to update the arrive window
    Private Sub arrivingFlightButton_Click(sender As Object, e As EventArgs) Handles arrivingFlightButton.Click
        'Checks to make sure every text box is full
        If locationBox.Text IsNot "" And airlineBox.Text IsNot "" And timeBox.Text IsNot "" And
                ampmBox.Text IsNot "" And gateBox.Text IsNot "" And statusBox.Text IsNot "" Then
            'Sends info to the arrive event handler
            MyFlightManager.OnArrive(New FlightInfo(locationBox.Text, airlineBox.Text, timeBox.Text + " " & ampmBox.Text, gateBox.Text, statusBox.Text))
            'Clears the text boxes
            locationBox.Text = ""
            airlineBox.Text = ""
            timeBox.Text = ""
            ampmBox.Text = ""
            gateBox.Text = ""
            statusBox.Text = ""
        Else
            warningLabel.Visible = True
        End If
    End Sub

    'After the user enters in the required data for the flight it will then send the data to update the depart window
    Private Sub departFlightButton_Click(sender As Object, e As EventArgs) Handles departFlightButton.Click
        'Checks to make sure every text box is full
        If locationBox.Text IsNot "" And airlineBox.Text IsNot "" And timeBox.Text IsNot "" And
                ampmBox.Text IsNot "" And gateBox.Text IsNot "" And statusBox.Text IsNot "" Then
            'Sends info to the arrive event handler
            MyFlightManager.OnDepart(New FlightInfo(locationBox.Text, airlineBox.Text, timeBox.Text + " " & ampmBox.Text, gateBox.Text, statusBox.Text))
            'Clears the text boxes
            locationBox.Text = ""
            airlineBox.Text = ""
            timeBox.Text = ""
            ampmBox.Text = ""
            gateBox.Text = ""
            statusBox.Text = ""
        Else
            warningLabel.Visible = True
        End If
    End Sub
End Class
