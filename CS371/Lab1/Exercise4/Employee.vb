'Zach Ambur
'zambur@wisc.edu
'CS 371
'Lab1

Public Class Employee
    ' Declares global variables
    Dim name As String
    Dim hourlyWage As Decimal
    Dim startTimes As List(Of String)
    Dim endTimes As List(Of String)
    Dim hoursWorked As Decimal

    ' This constructor takes in the required data and validates it. If something is wrong, it throws
    ' an exception that gets checked in the main method
    Public Sub New(ByVal employeeName As String, ByVal employeeWage As Decimal, ByVal openingTimes As List(Of String), ByVal closingTimes As List(Of String))
        If employeeName = String.Empty Or Val(employeeName) > 0 Then
            Throw New ArgumentOutOfRangeException()
        End If
        If employeeWage < 0 Then
            Throw New ArgumentOutOfRangeException()
        End If
        If openingTimes.Count < 5 And openingTimes.Count <> closingTimes.Count Then
            Throw New ArgumentOutOfRangeException
        End If
        If closingTimes.Count < 5 Then
            Throw New ArgumentOutOfRangeException
        End If

        ' Establish global variables with parameters passed in
        name = employeeName
        hourlyWage = employeeWage
        startTimes = openingTimes
        endTimes = closingTimes
        Dim arrayIndex As Integer

        hoursWorked = 0.0
        Dim firstTime As Decimal
        Dim secondTime As Decimal
        Dim startContents As String
        Dim endContents As String
        Dim startAM = False
        Dim endAM = False

        ' Interates through every index of the start times list
        For arrayIndex = 0 To startTimes.Count - 1
            ' If start time contains nothing but end time has a time throw an error
            If startTimes.ElementAt(arrayIndex) Is Nothing Then
                If endTimes.ElementAt(arrayIndex) IsNot Nothing Then
                    Throw New ArgumentOutOfRangeException
                End If

            Else
                startContents = startTimes.ElementAt(arrayIndex)
                ' Make sure cell is in the right format otherwise throw an error
                If startContents.Contains(":") Then
                    ' Check and record if it is an am or pm time then remove the letter from the string
                    If startContents.Contains("a") Then
                        startContents = startContents.Replace("a", "")
                        startAM = True
                    ElseIf startContents.Contains("p") Then
                        startContents = startContents.Replace("p", "")
                        startAM = False
                    Else
                        Throw New ArgumentOutOfRangeException
                    End If
                    Dim index As Integer
                    ' Split the time by hour and mins
                    index = startContents.IndexOf(":")
                    Dim hours = startContents.Substring(0, index)
                    Dim mins = startContents.Substring(index + 1)
                    ' Check that the input is correct
                    If IsNumeric(hours) And IsNumeric(mins) Then
                        Dim workMins = Convert.ToDecimal(mins)
                        ' Make sure the min is not over 59 mins
                        If workMins > 59 Then
                            Throw New ArgumentOutOfRangeException
                        End If
                        ' Make sure the hour is not over 12 hours and if it is 12 set it to 0 (starting time)
                        Dim workHours = Convert.ToDecimal(hours * 60)
                        If workHours > 720 Then
                            Throw New ArgumentOutOfRangeException
                        End If
                        If workHours = 720 Then
                            workHours = 0
                        End If
                        ' Save time as only mins
                        firstTime = workHours + workMins
                    Else
                        Throw New ArgumentOutOfRangeException
                    End If
                End If

                ''Do the same for the ending time of day

                endContents = endTimes.ElementAt(arrayIndex)
                ' Make sure cell is in the right format otherwise throw an error
                If endContents.Contains(":") Then
                    ' Check and record if it is an am or pm time then remove the letter from the string
                    If endContents.Contains("a") Then
                        endContents = endContents.Replace("a", "")
                        endAM = True
                    ElseIf endContents.Contains("p") Then
                        endContents = endContents.Replace("p", "")
                        endAM = False
                    Else
                        Throw New ArgumentOutOfRangeException
                    End If
                    Dim index As Integer
                    ' Split the time by hour and mins
                    index = endContents.IndexOf(":")
                    Dim hours = endContents.Substring(0, index)
                    Dim mins = endContents.Substring(index + 1)
                    ' Check that the input is correct
                    If IsNumeric(hours) And IsNumeric(mins) Then
                        Dim workMins = Convert.ToDecimal(mins)
                        ' Make sure the min is not over 59 mins
                        If workMins > 59 Then
                            Throw New ArgumentOutOfRangeException
                        End If
                        ' Make sure the hour is not over 12 hours and if it is 12 set it to 0 (starting time)
                        Dim workHours = Convert.ToDecimal(hours * 60)
                        If workHours > 720 Then
                            Throw New ArgumentOutOfRangeException
                        End If
                        If workHours = 720 Then
                            workHours = 0
                        End If
                        ' Save time as only mins
                        secondTime = workHours + workMins
                    Else
                        Throw New ArgumentOutOfRangeException
                    End If
                End If

                ' Calculate the total worked time based on 4 cases:
                ' If the start time is am and the end time is also am
                If startAM = True And endAM = True Then
                    hoursWorked = hoursWorked + (secondTime - firstTime)
                    ' If the start time is pm and the end time is also pm
                ElseIf startAM = False And endAM = False Then
                    hoursWorked = hoursWorked + (secondTime - firstTime)
                    ' If the start time is am but the end time is pm
                ElseIf startAM = True And endAM = False Then
                    hoursWorked = hoursWorked + (secondTime + (720 - firstTime))
                    ' If the start time is pm and the end time is am 
                    ' Cant happen in 1 day so throws an error
                ElseIf startAM = False And endAM = True Then
                    Throw New ArgumentOutOfRangeException
                End If
            End If
        Next arrayIndex

    End Sub

    ' This property returns the totals number of hours worked in hours
    Public ReadOnly Property WorkHours() As Decimal
        Get
            Return (hoursWorked / 60)
        End Get
    End Property

    ' This property return the total wage earned based on hours worked and hourly wage of employee
    Public ReadOnly Property Workwage() As Decimal
        Get
            Return (hoursWorked / 60) * hourlyWage
        End Get
    End Property

End Class
