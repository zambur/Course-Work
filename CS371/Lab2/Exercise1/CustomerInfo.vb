'Zach Ambut
'CS 371
'Lab 2
Public Class CustomerInfo
    Inherits EventArgs

    'Declares local variables
    Private firstName As String
    Private lastName As String
    Private email As String
    Private street As String
    Private city As String
    Private state As String
    Private zip As String
    Private ccNumber As String

    'Method for creating a new customers and adding all of the information about the customer
    Sub New(FirstName_param As String, LastName_param As String, Email_param As String, Street_param As String, City_param As String,
            State_param As String, Zip_param As String, CCNumber_param As String)
        'Saving parameters to local variables
        firstName = FirstName_param
        lastName = LastName_param
        email = Email_param
        street = Street_param
        city = City_param
        state = State_param
        zip = Zip_param
        ccNumber = CCNumber_param
    End Sub

    Public Property CustFirstName As String
        Get
            Return firstName
        End Get
        Set(value As String)
            firstName = value
        End Set
    End Property

    Public Property CustLastName As String
        Get
            Return lastName
        End Get
        Set(value As String)
            lastName = value
        End Set
    End Property

    Public Property CustEmail As String
        Get
            Return email
        End Get
        Set(value As String)
            email = value
        End Set
    End Property

    Public Property CustStreet As String
        Get
            Return street
        End Get
        Set(value As String)
            street = value
        End Set
    End Property

    Public Property CustCity As String
        Get
            Return city
        End Get
        Set(value As String)
            city = value
        End Set
    End Property

    Public Property CustState As String
        Get
            Return state
        End Get
        Set(value As String)
            state = value
        End Set
    End Property

    Public Property CustZip As String
        Get
            Return zip
        End Get
        Set(value As String)
            zip = value
        End Set
    End Property

    Public Property CustCCNumber As String
        Get
            Return ccNumber
        End Get
        Set(value As String)
            ccNumber = value
        End Set
    End Property
End Class
