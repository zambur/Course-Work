'Zach Ambur
'Lab 3
'IS 371
Public Class Employees

    Private Sub Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Exercise1DataSet.Employee' table. You can move, or remove it, as needed.
        Try
            Me.EmployeeTableAdapter.Fill(Me.Exercise1DataSet.Employee)
        Catch ex As Exception
            My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
        End Try

    End Sub

    Private Sub EmployeeBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles EmployeeBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.EmployeeBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Exercise1DataSet)

    End Sub
End Class