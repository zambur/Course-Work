'Zach Ambur
'Ross Shohoney
'Drew Marx
'IS 371 
'Pilot Application
Public Class CRMform

    Private Sub OrderCostBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.OrderCostBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AvailableParts)

    End Sub

    Private Sub CRMform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AvailableParts.OrderStatus' table. You can move, or remove it, as needed.
        Me.OrderStatusTableAdapter.Fill(Me.AvailableParts.OrderStatus)
        'TODO: This line of code loads data into the 'AvailableParts.OrderCost' table. You can move, or remove it, as needed.
        Me.OrderCostTableAdapter.Fill(Me.AvailableParts.OrderCost)

        ' Add options to the combo box
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Order Status")
        ComboBox1.Items.Add("Order Cost")
    End Sub

    ' Event called when the user makes a new selection in the drop down menu
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            ' When order status is selected load the data grid view with the contents of the database
            Try
                Dim orderStatusData As AvailableParts.OrderStatusDataTable = OrderStatusTableAdapter.GetData()
                Dim currRow As AvailableParts.OrderStatusRow
                ' First clear the data grid and then add the columns related to order status
                DataGridView1.Columns.Clear()
                DataGridView1.Columns.Add("orderID", "Order ID")
                DataGridView1.Columns.Add("workOrderID", "Work Order ID")
                DataGridView1.Columns.Add("lastName", "Last Name")
                DataGridView1.Columns.Add("firstName", "First Name")
                DataGridView1.Columns.Add("statusName", "Status Name")
                DataGridView1.Columns.Add("modelName", "Model Name")
                DataGridView1.Columns.Add("notes", "Notes")
                DataGridView1.Columns.Add("repaireDate", "Repair Date")

                ' For every order status in the database add it to the data grid view
                For Each currRow In orderStatusData
                    DataGridView1.Rows.Add(currRow.ORDER_ID, currRow.WORK_ORDER_ID, currRow.LAST_NAME, currRow.FIRST_NAME,
                                           currRow.STATUS_NAME, currRow.MODEL_NAME, currRow.NOTES, currRow.REPAIR_DATE)
                Next
            Catch ex As Exception
                My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
            End Try
        End If
        If ComboBox1.SelectedIndex = 1 Then
            ' When order cost is selected load the data grid view with the contents of the database
            Try
                Dim orderCostData As AvailableParts.OrderCostDataTable = OrderCostTableAdapter.GetData()
                Dim currRow As AvailableParts.OrderCostRow
                ' First clear the data grid and then add the columns related to order cost
                DataGridView1.Columns.Clear()
                DataGridView1.Columns.Add("workOrderID", "Work Order ID")
                DataGridView1.Columns.Add("partName", "Part Name")
                DataGridView1.Columns.Add("price", "Price")
                DataGridView1.Columns.Add("quantity", "Quantity")

                ' For every order cost in the database add it to the data grid view
                For Each currRow In orderCostData
                    DataGridView1.Rows.Add(currRow.WORK_ORDER_ID, currRow.PART_NAME, currRow.PRICE, currRow.QTY)
                Next
            Catch ex As Exception
                My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
            End Try
        End If
    End Sub
End Class