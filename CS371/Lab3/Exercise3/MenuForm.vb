'Zach Ambur
'Lab 3
'IS 371
Public Class MenuForm
    Dim showPropertiesWindow As Boolean
    Dim showAllRentReceipts As Boolean
    Dim showRentDefaults As Boolean

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        Search.MdiParent = Me
        Search.Show()
    End Sub

    Private Sub ShowAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowAllToolStripMenuItem.Click
        showPropertiesWindow = True
        Details.MdiParent = Me
        Details.Show()
    End Sub

    Private Sub RentReceiptsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RentReceiptsToolStripMenuItem.Click
        showRent = True
        Details.MdiParent = Me
        Details.Show()
    End Sub

    Private Sub UnpaidRentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnpaidRentToolStripMenuItem.Click
        showRentDefaults = True
        Details.MdiParent = Me
        Details.Show()
    End Sub



    Public Property showAll As Boolean
        Get
            Return showPropertiesWindow
        End Get
        Set(value As Boolean)
            showPropertiesWindow = value
        End Set
    End Property

    Public Property showRent As Boolean
        Get
            Return showAllRentReceipts
        End Get
        Set(value As Boolean)
            showAllRentReceipts = value
        End Set
    End Property

    Public Property showDefaults As Boolean
        Get
            Return showRentDefaults
        End Get
        Set(value As Boolean)
            showRentDefaults = value
        End Set
    End Property



End Class
