'Zach Ambur
'Lab 3
'IS 371
Public Class Details

    Private Sub TblPropertiesBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.TblPropertiesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DataSet1)

    End Sub

    Private Sub Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.tblRent' table. You can move, or remove it, as needed.
        Me.TblRentTableAdapter.Fill(Me.DataSet1.tblRent)

        'When the user selects Property > Show All display all the properties
        If MenuForm.showAll = True Then
            MenuForm.showAll = False
            TitleLabel.Text = "Viewing All Properties"
            TblDataGridView.DataSource = TblPropertiesBindingSource
            Me.TblPropertiesTableAdapter.Fill(Me.DataSet1.tblProperties)
        End If

        'When the user selects Finances > Rent Receipts display the rent history for all tenants
        If MenuForm.showRent = True Then
            MenuForm.showRent = False
            TitleLabel.Text = "Rent History For All Tenants"
            TblDataGridView.DataSource = TblRentBindingSource
            Me.TblRentTableAdapter.Fill(Me.DataSet1.tblRent)
        End If

        'When the user selects Finances > Unpaid Rent display all rent defaulters
        If MenuForm.showDefaults = True Then
            MenuForm.showDefaults = False
            TitleLabel.Text = "Rent Defaulters"
            TblDataGridView.DataSource = TblRentBindingSource
            Me.TblRentTableAdapter.Fill(Me.DataSet1.tblRent)
        End If

        'When the user selects view renters histery display just that renters history
        If Tenant.showCurrTenant = True Then
            Tenant.showCurrTenant = False
            TitleLabel.Text = "Rent History"
            TblDataGridView.DataSource = TblRentBindingSource
            Me.TblRentTableAdapter.FillByTenantID(Me.DataSet1.tblRent, Tenant.showCurrTenantNumber)
        End If
    End Sub

    ' When the user double clicks on a property inside of the data table save the property information and open up the unit details
    Private Sub TblPropertiesDataGridView_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles TblDataGridView.CellMouseDoubleClick
        If e.RowIndex >= 0 Then
            Dim propertyData As DataSet1.tblPropertiesDataTable = TblPropertiesTableAdapter.GetData()
            Dim currPropertyRow As DataSet1.tblPropertiesRow
            Dim propertyID = TblDataGridView.Rows(e.RowIndex).Cells(0).Value
            ' Cross check the property id with the one clicked and the one in the database
            For Each currPropertyRow In propertyData
                If currPropertyRow.PropertyID = propertyID Then
                    'Save the property for later use in a drifferent form
                    Search.rentalProperty = currPropertyRow
                    Exit For
                End If
            Next
            Unit.Show()
        End If
    End Sub

    ' When File > Exit is selected exit the program
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class