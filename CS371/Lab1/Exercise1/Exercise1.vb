'Zach Ambur
'zambur@wisc.edu
'CS 371
'Lab1

Public Class Exercise1


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim yield, rate As Decimal
        OutputText.Text = ""
        ' Checks for valid input
        If (UserEnterText.Text IsNot "") Then
            If IsNumeric(UserEnterText.Text) And Val(UserEnterText.Text) > 0 Then
                ' Once input is valid it will calculate investment rate and hide warning labels
                WarningLabel.Visible = False
                rate = Convert.ToDecimal(UserEnterText.Text)
                yield = (rate / (1 - 0.31))
                ' Prints investment rate 
                OutputText.Text = "You need to invest at a rate of " & FormatNumber(CDbl(yield), 2) & "  in a taxable investment to yield the same amount that you will yield from a tax free investment with a rate of " & UserEnterText.Text & "%"
            Else
                ' Warning message to user to re-enter a correct value
                WarningLabel.Visible = True
            End If
        Else
            ' Warning message to user to re-enter a correct value
            OutputText.Text = "Please enter a valid Rate of Tax-free Yield."
        End If
    End Sub

    ' Clears all input and output as well as hides any warning labels
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        UserEnterText.Text = ""
        OutputText.Text = ""
        WarningLabel.Visible = False
    End Sub
End Class
