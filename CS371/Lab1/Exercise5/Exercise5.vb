'Zach Ambur
'zambur@wisc.edu
'CS 371
'Lab1
Public Class Exercise5
    ' Declare global variables
    Dim depresiation As DepreciationCalc
    Dim depValue As Decimal
    Dim bookValue As Decimal
    Dim digitsBookValue As List(Of Decimal)
    Dim digitsDepValue As List(Of Decimal)

    ' This method will check if the user has entered the correct values and then calculate the deresiation of an asset based on the straight line method
    Private Sub StraightMethodButton_CheckedChanged(sender As Object, e As EventArgs) Handles straightMethodButton.CheckedChanged
        ' Checks for valid user input
        If IsNumeric(costInput.Text) And IsNumeric(valueInput.Text) And IsNumeric(lifeInput.Text) Then
            ' Clears old data from the data grid view
            DataGridOutput.Rows.Clear()

            ' Creates a new depresiation object to calculate the depresiation of the assest
            depresiation = New DepreciationCalc(Convert.ToDecimal(costInput.Text), Convert.ToDecimal(valueInput.Text), Convert.ToDecimal(lifeInput.Text))

            depValue = depresiation.StaightLineMethod
            bookValue = Convert.ToDecimal(costInput.Text)
            ' Iterates for each year of the lifespan of the product
            For years = 1 To Convert.ToDecimal(lifeInput.Text)
                ' subtracts the depresiation value from the total value each year
                bookValue = bookValue - depValue
                ' prints information to the data grid view
                DataGridOutput.Rows.Add(Convert.ToString(years), "$" + Convert.ToString(FormatNumber(CDbl(bookValue), 2)), "$" + Convert.ToString(FormatNumber(CDbl(depValue), 2)))
            Next years
        End If
    End Sub

    ' This method will check if the user has entered the correct values and then calculate the deresiation of an asset based on the Sum of the Years’ Digits Method
    Private Sub DigitsMethodButton_CheckedChanged(sender As Object, e As EventArgs) Handles DigitsMethodButton.CheckedChanged
        ' Checks for valid user input
        If IsNumeric(costInput.Text) And IsNumeric(valueInput.Text) And IsNumeric(lifeInput.Text) Then
            ' Clears old data from the data grid view
            DataGridOutput.Rows.Clear()
            ' Creates a new depresiation object to calculate the depresiation of the assest
            depresiation = New DepreciationCalc(Convert.ToDecimal(costInput.Text), Convert.ToDecimal(valueInput.Text), Convert.ToDecimal(lifeInput.Text))
            digitsDepValue = depresiation.digitsDepList
            digitsBookValue = depresiation.digitsBookList

            ' Iterates for each year of the lifespan of the product
            For years = 0 To Convert.ToDecimal(lifeInput.Text) - 1
                ' prints the data from the 2 lists of information onto the data grid view for each year
                DataGridOutput.Rows.Add(Convert.ToString(years + 1), "$" + Convert.ToString(FormatNumber(CDbl(digitsBookValue.Item(years)), 2)), "$" + Convert.ToString(FormatNumber(CDbl(digitsDepValue.Item(years)), 2)))
            Next years
        End If
    End Sub
End Class
