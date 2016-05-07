<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Unit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.propID = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.state = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.zip = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.unitTextbox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.city = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Street = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.description = New System.Windows.Forms.RichTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.garbage = New System.Windows.Forms.CheckBox()
        Me.pets = New System.Windows.Forms.CheckBox()
        Me.carpeting = New System.Windows.Forms.CheckBox()
        Me.microwave = New System.Windows.Forms.CheckBox()
        Me.airconditioning = New System.Windows.Forms.CheckBox()
        Me.breakfast = New System.Windows.Forms.CheckBox()
        Me.fridge = New System.Windows.Forms.CheckBox()
        Me.cable = New System.Windows.Forms.CheckBox()
        Me.fireplace = New System.Windows.Forms.CheckBox()
        Me.furnished = New System.Windows.Forms.CheckBox()
        Me.laundry = New System.Windows.Forms.CheckBox()
        Me.floors = New System.Windows.Forms.CheckBox()
        Me.area = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.bedrooms = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.bathrooms = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.type = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RentButton = New System.Windows.Forms.Button()
        Me.TenantButton = New System.Windows.Forms.Button()
        Me.dateTo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dateFrom = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.water = New System.Windows.Forms.CheckBox()
        Me.electricity = New System.Windows.Forms.CheckBox()
        Me.heat = New System.Windows.Forms.CheckBox()
        Me.deposit = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.rent = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Property ID:"
        '
        'propID
        '
        Me.propID.Location = New System.Drawing.Point(82, 10)
        Me.propID.Name = "propID"
        Me.propID.ReadOnly = True
        Me.propID.Size = New System.Drawing.Size(100, 20)
        Me.propID.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.state)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.zip)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.unitTextbox)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.city)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Street)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(489, 81)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Address"
        '
        'state
        '
        Me.state.Location = New System.Drawing.Point(285, 44)
        Me.state.Name = "state"
        Me.state.Size = New System.Drawing.Size(49, 20)
        Me.state.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(244, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "State:"
        '
        'zip
        '
        Me.zip.Location = New System.Drawing.Point(375, 44)
        Me.zip.Name = "zip"
        Me.zip.Size = New System.Drawing.Size(100, 20)
        Me.zip.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(340, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Zip:"
        '
        'unitTextbox
        '
        Me.unitTextbox.Location = New System.Drawing.Point(375, 13)
        Me.unitTextbox.Name = "unitTextbox"
        Me.unitTextbox.Size = New System.Drawing.Size(100, 20)
        Me.unitTextbox.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(340, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Unit:"
        '
        'city
        '
        Me.city.Location = New System.Drawing.Point(61, 44)
        Me.city.Name = "city"
        Me.city.Size = New System.Drawing.Size(177, 20)
        Me.city.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "City:"
        '
        'Street
        '
        Me.Street.Location = New System.Drawing.Point(61, 13)
        Me.Street.Name = "Street"
        Me.Street.Size = New System.Drawing.Size(273, 20)
        Me.Street.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Street:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.description)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.area)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.bedrooms)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.bathrooms)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.type)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 129)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(489, 279)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Details:"
        '
        'description
        '
        Me.description.Location = New System.Drawing.Point(20, 192)
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(455, 72)
        Me.description.TabIndex = 22
        Me.description.Text = ""
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 175)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Description:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.garbage)
        Me.GroupBox3.Controls.Add(Me.pets)
        Me.GroupBox3.Controls.Add(Me.carpeting)
        Me.GroupBox3.Controls.Add(Me.microwave)
        Me.GroupBox3.Controls.Add(Me.airconditioning)
        Me.GroupBox3.Controls.Add(Me.breakfast)
        Me.GroupBox3.Controls.Add(Me.fridge)
        Me.GroupBox3.Controls.Add(Me.cable)
        Me.GroupBox3.Controls.Add(Me.fireplace)
        Me.GroupBox3.Controls.Add(Me.furnished)
        Me.GroupBox3.Controls.Add(Me.laundry)
        Me.GroupBox3.Controls.Add(Me.floors)
        Me.GroupBox3.Location = New System.Drawing.Point(20, 57)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 115)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Features:"
        '
        'garbage
        '
        Me.garbage.AutoSize = True
        Me.garbage.Location = New System.Drawing.Point(178, 88)
        Me.garbage.Name = "garbage"
        Me.garbage.Size = New System.Drawing.Size(110, 17)
        Me.garbage.TabIndex = 11
        Me.garbage.Text = "Garbage Disposal"
        Me.garbage.UseVisualStyleBackColor = True
        '
        'pets
        '
        Me.pets.AutoSize = True
        Me.pets.Location = New System.Drawing.Point(339, 88)
        Me.pets.Name = "pets"
        Me.pets.Size = New System.Drawing.Size(87, 17)
        Me.pets.TabIndex = 10
        Me.pets.Text = "Pets Allowed"
        Me.pets.UseVisualStyleBackColor = True
        '
        'carpeting
        '
        Me.carpeting.AutoSize = True
        Me.carpeting.Location = New System.Drawing.Point(20, 88)
        Me.carpeting.Name = "carpeting"
        Me.carpeting.Size = New System.Drawing.Size(71, 17)
        Me.carpeting.TabIndex = 9
        Me.carpeting.Text = "Carpeting"
        Me.carpeting.UseVisualStyleBackColor = True
        '
        'microwave
        '
        Me.microwave.AutoSize = True
        Me.microwave.Location = New System.Drawing.Point(178, 65)
        Me.microwave.Name = "microwave"
        Me.microwave.Size = New System.Drawing.Size(78, 17)
        Me.microwave.TabIndex = 8
        Me.microwave.Text = "Microwave"
        Me.microwave.UseVisualStyleBackColor = True
        '
        'airconditioning
        '
        Me.airconditioning.AutoSize = True
        Me.airconditioning.Location = New System.Drawing.Point(339, 65)
        Me.airconditioning.Name = "airconditioning"
        Me.airconditioning.Size = New System.Drawing.Size(99, 17)
        Me.airconditioning.TabIndex = 7
        Me.airconditioning.Text = "Air Conditioning"
        Me.airconditioning.UseVisualStyleBackColor = True
        '
        'breakfast
        '
        Me.breakfast.AutoSize = True
        Me.breakfast.Location = New System.Drawing.Point(20, 65)
        Me.breakfast.Name = "breakfast"
        Me.breakfast.Size = New System.Drawing.Size(111, 17)
        Me.breakfast.TabIndex = 6
        Me.breakfast.Text = "Breakfast Counter"
        Me.breakfast.UseVisualStyleBackColor = True
        '
        'fridge
        '
        Me.fridge.AutoSize = True
        Me.fridge.Location = New System.Drawing.Point(178, 42)
        Me.fridge.Name = "fridge"
        Me.fridge.Size = New System.Drawing.Size(55, 17)
        Me.fridge.TabIndex = 5
        Me.fridge.Text = "Fridge"
        Me.fridge.UseVisualStyleBackColor = True
        '
        'cable
        '
        Me.cable.AutoSize = True
        Me.cable.Location = New System.Drawing.Point(339, 42)
        Me.cable.Name = "cable"
        Me.cable.Size = New System.Drawing.Size(87, 17)
        Me.cable.TabIndex = 4
        Me.cable.Text = "Cable Ready"
        Me.cable.UseVisualStyleBackColor = True
        '
        'fireplace
        '
        Me.fireplace.AutoSize = True
        Me.fireplace.Location = New System.Drawing.Point(20, 42)
        Me.fireplace.Name = "fireplace"
        Me.fireplace.Size = New System.Drawing.Size(69, 17)
        Me.fireplace.TabIndex = 3
        Me.fireplace.Text = "Fireplace"
        Me.fireplace.UseVisualStyleBackColor = True
        '
        'furnished
        '
        Me.furnished.AutoSize = True
        Me.furnished.Location = New System.Drawing.Point(178, 19)
        Me.furnished.Name = "furnished"
        Me.furnished.Size = New System.Drawing.Size(69, 17)
        Me.furnished.TabIndex = 2
        Me.furnished.Text = "Funished"
        Me.furnished.UseVisualStyleBackColor = True
        '
        'laundry
        '
        Me.laundry.AutoSize = True
        Me.laundry.Location = New System.Drawing.Point(339, 19)
        Me.laundry.Name = "laundry"
        Me.laundry.Size = New System.Drawing.Size(99, 17)
        Me.laundry.TabIndex = 1
        Me.laundry.Text = "OnSite Laundry"
        Me.laundry.UseVisualStyleBackColor = True
        '
        'floors
        '
        Me.floors.AutoSize = True
        Me.floors.Location = New System.Drawing.Point(20, 19)
        Me.floors.Name = "floors"
        Me.floors.Size = New System.Drawing.Size(106, 17)
        Me.floors.TabIndex = 0
        Me.floors.Text = "Hardwood Floors"
        Me.floors.UseVisualStyleBackColor = True
        '
        'area
        '
        Me.area.Location = New System.Drawing.Point(407, 19)
        Me.area.Name = "area"
        Me.area.Size = New System.Drawing.Size(68, 20)
        Me.area.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(372, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Area:"
        '
        'bedrooms
        '
        Me.bedrooms.Location = New System.Drawing.Point(212, 19)
        Me.bedrooms.Name = "bedrooms"
        Me.bedrooms.Size = New System.Drawing.Size(35, 20)
        Me.bedrooms.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(153, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Bedrooms:"
        '
        'bathrooms
        '
        Me.bathrooms.Location = New System.Drawing.Point(319, 19)
        Me.bathrooms.Name = "bathrooms"
        Me.bathrooms.Size = New System.Drawing.Size(46, 20)
        Me.bathrooms.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(253, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Bathrooms:"
        '
        'type
        '
        Me.type.Location = New System.Drawing.Point(61, 19)
        Me.type.Name = "type"
        Me.type.Size = New System.Drawing.Size(84, 20)
        Me.type.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Type:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RentButton)
        Me.GroupBox4.Controls.Add(Me.TenantButton)
        Me.GroupBox4.Controls.Add(Me.dateTo)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.dateFrom)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Location = New System.Drawing.Point(521, 41)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 193)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Availability:"
        '
        'RentButton
        '
        Me.RentButton.Location = New System.Drawing.Point(26, 160)
        Me.RentButton.Name = "RentButton"
        Me.RentButton.Size = New System.Drawing.Size(143, 23)
        Me.RentButton.TabIndex = 11
        Me.RentButton.Text = "Rent"
        Me.RentButton.UseVisualStyleBackColor = True
        '
        'TenantButton
        '
        Me.TenantButton.Location = New System.Drawing.Point(26, 128)
        Me.TenantButton.Name = "TenantButton"
        Me.TenantButton.Size = New System.Drawing.Size(143, 23)
        Me.TenantButton.TabIndex = 10
        Me.TenantButton.Text = "Tenant Details"
        Me.TenantButton.UseVisualStyleBackColor = True
        '
        'dateTo
        '
        Me.dateTo.Location = New System.Drawing.Point(67, 92)
        Me.dateTo.Name = "dateTo"
        Me.dateTo.Size = New System.Drawing.Size(102, 20)
        Me.dateTo.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(23, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(23, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "To:"
        '
        'dateFrom
        '
        Me.dateFrom.Location = New System.Drawing.Point(67, 61)
        Me.dateFrom.Name = "dateFrom"
        Me.dateFrom.Size = New System.Drawing.Size(102, 20)
        Me.dateFrom.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(23, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "From:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.water)
        Me.GroupBox5.Controls.Add(Me.electricity)
        Me.GroupBox5.Controls.Add(Me.heat)
        Me.GroupBox5.Controls.Add(Me.deposit)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.rent)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Location = New System.Drawing.Point(521, 240)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(200, 168)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Rental Information:"
        '
        'water
        '
        Me.water.AutoSize = True
        Me.water.Location = New System.Drawing.Point(42, 140)
        Me.water.Name = "water"
        Me.water.Size = New System.Drawing.Size(143, 17)
        Me.water.TabIndex = 14
        Me.water.Text = "Water/Sewage Included"
        Me.water.UseVisualStyleBackColor = True
        '
        'electricity
        '
        Me.electricity.AutoSize = True
        Me.electricity.Location = New System.Drawing.Point(42, 117)
        Me.electricity.Name = "electricity"
        Me.electricity.Size = New System.Drawing.Size(115, 17)
        Me.electricity.TabIndex = 13
        Me.electricity.Text = "Electricity Included"
        Me.electricity.UseVisualStyleBackColor = True
        '
        'heat
        '
        Me.heat.AutoSize = True
        Me.heat.Location = New System.Drawing.Point(42, 94)
        Me.heat.Name = "heat"
        Me.heat.Size = New System.Drawing.Size(93, 17)
        Me.heat.TabIndex = 12
        Me.heat.Text = "Heat Included"
        Me.heat.UseVisualStyleBackColor = True
        '
        'deposit
        '
        Me.deposit.Location = New System.Drawing.Point(64, 57)
        Me.deposit.Name = "deposit"
        Me.deposit.Size = New System.Drawing.Size(118, 20)
        Me.deposit.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 60)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Deposit:"
        '
        'rent
        '
        Me.rent.Location = New System.Drawing.Point(64, 26)
        Me.rent.Name = "rent"
        Me.rent.Size = New System.Drawing.Size(118, 20)
        Me.rent.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Rent:"
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(521, 414)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(95, 23)
        Me.SaveButton.TabIndex = 6
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(622, 414)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(99, 23)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Close"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Unit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 442)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.propID)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Unit"
        Me.Text = "Unit"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents propID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents state As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents zip As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents unitTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents city As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Street As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents description As System.Windows.Forms.RichTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents garbage As System.Windows.Forms.CheckBox
    Friend WithEvents pets As System.Windows.Forms.CheckBox
    Friend WithEvents carpeting As System.Windows.Forms.CheckBox
    Friend WithEvents microwave As System.Windows.Forms.CheckBox
    Friend WithEvents airconditioning As System.Windows.Forms.CheckBox
    Friend WithEvents breakfast As System.Windows.Forms.CheckBox
    Friend WithEvents fridge As System.Windows.Forms.CheckBox
    Friend WithEvents cable As System.Windows.Forms.CheckBox
    Friend WithEvents fireplace As System.Windows.Forms.CheckBox
    Friend WithEvents furnished As System.Windows.Forms.CheckBox
    Friend WithEvents laundry As System.Windows.Forms.CheckBox
    Friend WithEvents floors As System.Windows.Forms.CheckBox
    Friend WithEvents area As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents bedrooms As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bathrooms As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents type As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RentButton As System.Windows.Forms.Button
    Friend WithEvents TenantButton As System.Windows.Forms.Button
    Friend WithEvents dateTo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dateFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents water As System.Windows.Forms.CheckBox
    Friend WithEvents electricity As System.Windows.Forms.CheckBox
    Friend WithEvents heat As System.Windows.Forms.CheckBox
    Friend WithEvents deposit As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents rent As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
