'Zach Ambur
'Lab 3
'IS 371
Public Class Suppliers

    Private Sub SupplierBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles SupplierBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.SupplierBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Exercise1DataSet)

    End Sub

    Private Sub Suppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Exercise1DataSet.Supplier' table. You can move, or remove it, as needed.
        Try
            ' Fill only by the suppliers located in the United States (query)
            Dim countryValue As String = "USA"
            SupplierTableAdapter.FillByCountry(Exercise1DataSet.Supplier, countryValue)
        Catch ex As Exception
            My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
        End Try
    End Sub
End Class