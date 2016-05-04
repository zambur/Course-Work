'Zach Ambur
'Lab 3
'IS 371
Public Class Items

    Private Sub ItemBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles ItemBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ItemBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Exercise1DataSet)

    End Sub

    Private Sub Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Exercise1DataSet.Item' table. You can move, or remove it, as needed.
        Try
            'Fill only by the items that need restocking (query)
            Me.ItemTableAdapter.FillByNeededItems(Me.Exercise1DataSet.Item)
        Catch ex As Exception
            My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
        End Try

    End Sub
End Class