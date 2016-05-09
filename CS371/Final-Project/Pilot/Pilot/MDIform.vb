'Zach Ambur
'Ross Shohoney
'Drew Marx
'IS 371 
'Pilot Application
Public Class MDIform

    'Display the Service window inside of the mdi form
    Private Sub ServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiceToolStripMenuItem.Click
        Service.MdiParent = Me
        Service.Show()
    End Sub

    ' Close all windows that are open in the mdi form
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Service.Close()
        CRMform.Close()
        Help.Close()
        About.Close()
    End Sub

    ' Safely exit the entire program
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    ' Display the CRM window inside of the mdi form
    Private Sub OrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdersToolStripMenuItem.Click
        CRMform.MdiParent = Me
        CRMform.Show()
    End Sub

    ' Display the help window inside of the mdi form
    Private Sub HelpTopicsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpTopicsToolStripMenuItem.Click
        Help.MdiParent = Me
        Help.Show()
    End Sub

    ' Display the about window inside of the mdi form
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.MdiParent = Me
        About.Show()
    End Sub
End Class