'Zach Ambur
'zambur@wisc.edu
'CS 371
'Lab1
Public Class DepreciationCalc
    ' Declaring global variables
    Dim cost As Decimal
    Dim value As Decimal
    Dim years As Decimal
    Dim straitLine As Decimal
    Dim depList As List(Of Decimal)
    Dim bookValueList As List(Of Decimal)

    ' This constructor takes in the required data and validates it. If something is wrong, it throws
    ' an exception that gets checked in the main method
    Public Sub New(ByVal initialCost As Decimal, ByVal salvageValue As Decimal, ByVal lifeSpan As Decimal)
        If initialCost < 0 Then
            Throw New ArgumentOutOfRangeException()
        End If
        If salvageValue < 0 Then
            Throw New ArgumentOutOfRangeException()
        End If
        If lifeSpan <= 0 Then
            Throw New ArgumentOutOfRangeException
        End If

        ' set local variables to the parameters passed in
        cost = initialCost
        value = salvageValue
        years = lifeSpan

        ' calculates the straight line method
        straitLine = (cost - value) / years


        depList = New List(Of Decimal)
        bookValueList = New List(Of Decimal)

        Dim sumDigits = (years * (years + 1)) / 2
        Dim depValue = cost - value
        Dim yearCount = years
        Dim accumDep As Decimal
        Dim bookVal As Decimal
        Dim finalDepVal As Decimal
        ' calculates the Sum of the Years’ Digits Method
        For count = 0 To years - 1
            accumDep = accumDep + (yearCount / sumDigits) * depValue
            bookVal = cost - accumDep
            finalDepVal = (yearCount / sumDigits) * depValue
            yearCount = yearCount - 1
            ' Adds the depresiation value each year to a list
            depList.Add(finalDepVal)
            ' adds the book value of the product each year to a list
            bookValueList.Add(bookVal)
        Next count
    End Sub

    ' This property returns the depresiation value for the straight line method
    Public ReadOnly Property StaightLineMethod() As Decimal
        Get
            Return straitLine
        End Get
    End Property

    ' This property returns the list of depresiation values per year for the Sum of the Years’ Digits Method
    Public ReadOnly Property digitsDepList() As List(Of Decimal)
        Get
            Return depList
        End Get
    End Property

    ' This property returns the list of book values per year for the Sum of the Years’ Digits Method
    Public ReadOnly Property digitsBookList() As List(Of Decimal)
        Get
            Return bookValueList
        End Get
    End Property
End Class
