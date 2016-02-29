'Zach Ambur
'zambur@wisc.edu
'CS 371
'Lab1

' This class represents the object of a Manager
Public Class Manager
    Private name As String
    Private cultureScore As Integer
    Private resultScore As Integer
    Private outcome As String
    Private totalScore As Integer

    ' This constructor takes in the required data and validates it. If something is wrong, it throws
    ' an exception that gets checked in the main method
    Public Sub New(ByVal managerName As String, ByVal managerCultureScore As Integer, ByVal managerResultScore As Integer)
        If managerName = String.Empty Or Val(managerName) > 0 Then
            Throw New ArgumentOutOfRangeException()
        End If
        If managerCultureScore < 1 Or managerCultureScore > 10 Then
            Throw New ArgumentOutOfRangeException()
        End If
        If managerResultScore < 1 Or managerResultScore > 10 Then
            Throw New ArgumentOutOfRangeException
        End If

        ' Set local variables
        name = managerName
        cultureScore = managerCultureScore
        resultScore = managerResultScore
        totalScore = resultScore + cultureScore

        ' Use the total score to label an outcome
        Select Case totalScore
            Case Is > 16
                outcome = "Bonus and Stock Options"
            Case 7 To 16
                outcome = "Limited Bonus"
            Case Else
                outcome = "Fired"
        End Select
    End Sub

    ' This property returns the outcome of a manager given their score
    Public ReadOnly Property ManagerOutcome() As String
        Get
            Return outcome
        End Get
    End Property

    ' this property returns the name of the manager
    Public ReadOnly Property ManagerName() As String
        Get
            Return name
        End Get
    End Property

    ' This property returns the total score of a manager
    Public ReadOnly Property ManagerScore() As Integer
        Get
            Return totalScore
        End Get
    End Property
End Class
