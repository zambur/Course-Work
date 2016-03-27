'Zach Ambut
'CS 371
'Lab 2
Public Class CustomerManager
    'Manages event calls for new customers
    Public Event CreateCustomer(ByVal sender As Object, ByVal e As CustomerInfo)

    Public Overridable Sub OnCreateCustomer(ByVal e As CustomerInfo)
        RaiseEvent CreateCustomer(Me, e)
    End Sub
End Class
