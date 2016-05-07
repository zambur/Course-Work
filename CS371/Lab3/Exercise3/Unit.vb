'Zach Ambur
'Lab 3
'IS 371
Public Class Unit
    Private Sub Controller_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim row = Search.rentalProperty
        ' Load form depending on what property was clicked
        propID.Text = row.PropertyID
        Street.Text = row.Street
        unitTextbox.Text = row.Unit
        city.Text = row.City
        state.Text = row.State
        zip.Text = row.Zip
        type.Text = row.Type
        bedrooms.Text = row.Bedrooms
        bathrooms.Text = row.Bathrooms
        area.Text = row.Area
        floors.Checked = row.HardwoodFloors
        furnished.Checked = row.Furninshed
        laundry.Checked = row.OnsiteLaundry
        fireplace.Checked = row.Fireplace
        fridge.Checked = row.Fridge
        cable.Checked = row.CableReady
        breakfast.Checked = row.BreakfastCounter
        microwave.Checked = row.Microwave
        airconditioning.Checked = row.AirConditioned
        carpeting.Checked = row.Carpeting
        garbage.Checked = row.GarbageDisposal
        pets.Checked = row.PetsAllowed
        description.Text = row.Description
        rent.Text = row.MonthlyRent
        deposit.Text = row.SecurityDeposit
        heat.Checked = row.HeatIncluded
        electricity.Checked = row.ElectricityIncluded
        water.Checked = row.UtilitiesIncluded

        'If the property is available enable rent button
        If row.Vacancy = True Then
            TenantButton.Enabled = False
            RentButton.Enabled = True
        Else
            ' If the property already has tenants living there, display tenant button
            TenantButton.Enabled = True
            RentButton.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles TenantButton.Click
        Tenant.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub RentButton_Click(sender As Object, e As EventArgs) Handles RentButton.Click
        Close()
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Close()
    End Sub
End Class