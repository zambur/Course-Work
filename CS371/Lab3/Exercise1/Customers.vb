'Zach Ambur
'Lab 3
'IS 371
Public Class Customers

    ' Opens up all windows when the initial customer window opens
    Private Sub Controller_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim employeeForm As New Employees
        employeeForm.Show()
        Dim suppliersForm As New Suppliers
        suppliersForm.Show()
        Dim itemsForm As New Items
        itemsForm.Show()
    End Sub

    Private Sub CustomerBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CustomerBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Exercise1DataSet)

    End Sub

    Private Sub LoadCustomers()
        Try
            Dim customerData As Exercise1DataSet.CustomerDataTable = CustomerTableAdapter.GetData()
            Dim customerRow As Exercise1DataSet.CustomerRow
            Dim customerList As New ArrayList

            ' For each row in the data table it iterates through them only adding customers that have visited the store,
            ' have a credit limit over 400, and have purchased more than $30 worth
            For Each customerRow In customerData
                If customerRow.CreditLimit >= 400 And customerRow.TotalVisits > 0 And customerRow.TotalSales > 30 Then
                    ' If it is the first customer add them to the beginning of the list
                    If customerList.Count = 0 Then
                        customerList.Add(customerRow)
                    Else
                        Dim index = customerList.Count
                        ' Iterates through the list of valid customers and places the current customer in its specific spot
                        ' This is so we can display the customers with the top ones first
                        For currItem As Integer = customerList.Count - 1 To 0 Step -1
                            If customerList.Item(currItem).TotalSales < customerRow.TotalSales Then
                                index = currItem
                            End If
                        Next
                        customerList.Insert(index, customerRow)
                    End If
                End If
            Next
            'Finally display each valid customer on the data table 
            For Each customerRow In customerList
                DataSetGridView.Rows.Add(customerRow.FirstName, customerRow.LastName, customerRow.ID, customerRow.Address, customerRow.City,
                                         customerRow.County, customerRow.State, customerRow.Zip, customerRow.CreditLimit, customerRow.TotalSales,
                                         customerRow.TotalVisits, customerRow.EmailAddress, customerRow.PhoneNumber)
            Next
        Catch ex As Exception
            My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
        End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Exercise1DataSet.Customer' table. You can move, or remove it, as needed.
        Try
            Me.CustomerTableAdapter.Fill(Me.Exercise1DataSet.Customer)
            LoadCustomers()
        Catch ex As Exception
            My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
        End Try
    End Sub
End Class
