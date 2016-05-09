'Zach Ambur
'Ross Shohoney
'Drew Marx
'IS 371 
'Pilot Application
Public Class Help

    ' Fill the help labels when the window first opens
    Private Sub Help_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = "This window is provided to display all the available" & vbNewLine &
            "parts for order. By selecting between the different" & vbNewLine &
            "tabs on the top of the window you can view the" & vbNewLine &
            "list of parts in 3 different views. Once you select" & vbNewLine &
            "a view you like you can then view the details and" & vbNewLine &
            "pictures of each part by selecting it in the list" & vbNewLine &
            "or by iterating through the list with the forward" & vbNewLine &
            "and backward buttons."

        Label4.Text = "This form is provided to display the order status" & vbNewLine &
            "and cost of each current order. By selecting between" & vbNewLine &
            "the options in the drop down menu, you will either" & vbNewLine &
            "be able to see the status or cost of each order."
    End Sub
End Class