'Zach Ambut
'CS 371
'Lab 2
Public Class FlightInfo
    Inherits EventArgs

    'Declares local variables
    Private location As String
    Private airline As String
    Private time As String
    Private gate As String
    Private status As String

    'Method for creating a new flight and adding all of the information about the flight
    Sub New(Location_param As String, Airline_param As String, Time_param As String, Gate_param As String, Status_param As String)
        'Saving parameters to local variables
        location = Location_param
        airline = Airline_param
        time = Time_param
        gate = Gate_param
        status = Status_param
    End Sub

    'Gets and sets the location of the flight
    Public Property FlightLocation As String
        Get
            Return location
        End Get
        Set(value As String)
            location = value
        End Set
    End Property

    'Gets and sets the airline fo the flight
    Public Property FlightAirline As String
        Get
            Return airline
        End Get
        Set(value As String)
            airline = value
        End Set
    End Property

    'Gets and sets the time of the flight
    Public Property FlightTime As String
        Get
            Return time
        End Get
        Set(value As String)
            time = value
        End Set
    End Property

    'Gets and sets the gate of the flight
    Public Property FlightGate As String
        Get
            Return gate
        End Get
        Set(value As String)
            gate = value
        End Set
    End Property

    'Gets and sets the status of the flight
    Public Property FlightStatus As String
        Get
            Return status
        End Get
        Set(value As String)
            status = value
        End Set
    End Property
End Class
