'Zach Ambur
'zambur@wisc.edu
'CS 371
'Lab1

Public Class Exercise3
    ' Declaire global variables
    Dim mortgageAmount As Decimal
    Dim interestRate As Decimal
    Dim totalInterest As Decimal
    Dim monthlyPayment As Decimal

    ' This method checks that the user input is valid and then takes the mortgage amount and calculates it with the interest rate
    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click
        ' Checks for valid user input
        If (MortgageInput.Text IsNot "" And InterestInput.Text IsNot "") Then
            If IsNumeric(MortgageInput.Text) And IsNumeric(InterestInput.Text) And Val(MortgageInput.Text) > 0 And Val(InterestInput.Text) Then
                ' Hides warning labels
                WarningLabel.Visible = False
                mortgageAmount = Convert.ToDecimal(MortgageInput.Text)
                interestRate = Convert.ToDecimal(InterestInput.Text)

                ' Displays each year with monthly payment and total interest in their individual row in the dataGridView
                For year As Integer = 5 To 30 Step +5
                    totalInterest = (mortgageAmount * year * interestRate) / 100
                    monthlyPayment = (mortgageAmount + totalInterest) / (year * 12)
                    OutputGridView.Rows.Add(Convert.ToString(year), "$" + Convert.ToString(FormatNumber(CDbl(totalInterest), 2)), "$" + Convert.ToString(FormatNumber(CDbl(monthlyPayment), 2)))
                Next
            Else
                ' Displays warning label for invalid input
                WarningLabel.Visible = True
            End If
        Else
            ' Displays warning label for invalid input
            WarningLabel.Visible = True
        End If
    End Sub

    ' This method resets all textboxes and the dataGridView to the initial state
    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        MortgageInput.Text = ""
        InterestInput.Text = ""
        WarningLabel.Visible = False
        ' Removes every row from the data Grid View
        For i As Integer = OutputGridView.RowCount - 1 To 0 Step -1
            OutputGridView.Rows.RemoveAt(i)
        Next
    End Sub
End Class
