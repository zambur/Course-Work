'Zach Ambut
'CS 371
'Lab 2
Public Class ItemView
    'Declares local variables
    Dim subtotal As Decimal
    Dim tax As Decimal
    Dim total As Decimal
    Dim itemTuple As Tuple(Of String(), Decimal(), Integer())
    Dim customer As CustomerInfo
    Dim addedCustomer = False

    'When log in button is pressed open a new window for user to enter in info
    Private Sub logInButton_Click(sender As Object, e As EventArgs) Handles logInButton.Click
        Dim dialog As Customer
        dialog = New Customer()
        Dim result As DialogResult = dialog.ShowDialog(Me)
        If result = Windows.Forms.DialogResult.Yes Then
            customer = dialog.enterCustomer
            addedCustomer = True
        End If
    End Sub

    'Check that the user has logged in and then open a window displaying final results
    Private Sub checkOutButton_Click(sender As Object, e As EventArgs) Handles checkOutButton.Click
        If addedCustomer Then
            MessageBox.Show("Thank you " + customer.CustFirstName + "!" + Environment.NewLine +
                            Environment.NewLine +
                            "Your products will be sent to:" + Environment.NewLine +
                            customer.CustStreet + Environment.NewLine +
                            customer.CustCity + ", " + customer.CustState + customer.CustZip + Environment.NewLine +
                            Environment.NewLine +
                            "Your total will be: $" + Convert.ToString(Format(Val(total), "0.00")))
        Else
            warningLabel.Visible = True
        End If
    End Sub

    'Fills tuple with all values from the item view
    Private Sub fillTuple()
        Dim names() As String = {baseballLabel.Text, baseballLabel.Text, bowlingLabel.Text, footballLabel.Text, volleyballLabel.Text, tennisLabel.Text, soccerLabel.Text}
        Dim price() As Decimal = {9.99, 29.99, 69.99, 25.99, 14.99, 4.99, 24.99}
        Dim quantity() As Integer = {baseballCounter.Value, basketballCounter.Value, bowlingCounter.Value, footballCounter.Value, volleyballCounter.Value, tennisCounter.Value, soccerCounter.Value}
        itemTuple = New Tuple(Of String(), Decimal(), Integer())(names, price, quantity)
    End Sub

    'Update the totals if the user has updated quantities
    Private Sub updateButton_Click(sender As Object, e As EventArgs) Handles updateButton.Click
        subtotal = 0
        tax = 0
        total = 0
        fillTuple()
        For index As Integer = 0 To 6
            subtotal += (itemTuple.Item2(index) * itemTuple.Item3(index))
        Next
        tax = subtotal * 0.055
        total = subtotal + tax
        subtotalLabel.Text = "$" + Convert.ToString(Format(Val(subtotal), "0.00"))
        taxLabel.Text = "$" + Convert.ToString(Format(Val(tax), "0.00"))
        totalLabel.Text = "$" + Convert.ToString(Format(Val(total), "0.00"))
    End Sub

    'Info for the logged in customer
    Public Property finalCustomer As CustomerInfo
        Get
            Return customer
        End Get
        Set(value As CustomerInfo)
        End Set
    End Property
End Class
