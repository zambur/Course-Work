'Zach Ambut
'CS 371
'Lab 2
Public Class Customer
    Friend WithEvents MyCustomerManager As New CustomerManager
    Dim customer As CustomerInfo

    'Checks that the user has entered info in all of the text boxes and then creates a new customer
    Private Sub createAccount_Button_Click(sender As Object, e As EventArgs) Handles createAccount_Button.Click
        If firstNameBox.Text IsNot "" And lastNameBox.Text IsNot "" And emailBox.Text IsNot "" And
                streetBox.Text IsNot "" And cityBox.Text IsNot "" And stateBox.Text IsNot "" And
                zipBox.Text IsNot "" And ccBox.Text IsNot "" And expBox.Text IsNot "" And secBox.Text IsNot "" Then
            MyCustomerManager.OnCreateCustomer(New CustomerInfo(firstNameBox.Text, lastNameBox.Text, emailBox.Text,
                                                                streetBox.Text, cityBox.Text, stateBox.Text, zipBox.Text, ccBox.Text))
            customer = New CustomerInfo(firstNameBox.Text, lastNameBox.Text, emailBox.Text,
                                                                streetBox.Text, cityBox.Text, stateBox.Text, zipBox.Text, ccBox.Text)
            Close()
        Else
            warningLabel.Visible = True
        End If
    End Sub

    Public Property enterCustomer As CustomerInfo
        Get
            Return customer
        End Get
        Set(value As CustomerInfo)
        End Set
    End Property
End Class