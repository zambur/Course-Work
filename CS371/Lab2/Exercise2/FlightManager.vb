'Zach Ambut
'CS 371
'Lab 2
Public Class FlightManager
    'Manages event calls for arriving flights
    Public Event Arrive(ByVal sender As Object, ByVal e As FlightInfo)

    Public Overridable Sub OnArrive(ByVal e As FlightInfo)
        RaiseEvent Arrive(Me, e)
    End Sub

    'Manages event calls for departing flights
    Public Event Depart(ByVal sender As Object, ByVal e As FlightInfo)

    Public Overridable Sub OnDepart(ByVal e As FlightInfo)
        RaiseEvent Depart(Me, e)
    End Sub
End Class
