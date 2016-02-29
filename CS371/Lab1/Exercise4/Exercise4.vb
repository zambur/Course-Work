'Zach Ambur
'zambur@wisc.edu
'CS 371
'Lab1

Public Class Exercise4
    Dim totalHours As Double
    Dim totalWage As Decimal
    Dim startTimes As List(Of String)
    Dim endTimes As List(Of String)
    Dim employee As Employee

    ' This method is for right when the form is loaded it will hide warning labels as well as add 2 rows to the data grid view
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WarningLabel.Visible = False
        InputWarningLabel.Visible = False
        DataGridInput.Rows.Add()
        DataGridInput.Rows.Add()

        ' Adds the start time and end time row to the data grid view
        For Each row As DataGridViewRow In DataGridInput.Rows
            If row.Index = 0 Then
                row.HeaderCell.Value = "Start Time"
            Else
                row.HeaderCell.Value = "End Time"
            End If
        Next
    End Sub

    ' This method makes sure that the data entered in the grid view is all accurate as well as creates a new employe object to calculate the
    ' hours worked
    Private Sub hoursButton_Click(sender As Object, e As EventArgs) Handles hoursButton.Click
        If IsNumeric(wageInput.Text) And empNameInput.Text IsNot "" Then
            startTimes = New List(Of String)
            endTimes = New List(Of String)
            Dim intRowCount As Integer
            Dim intColumnCount As Integer

            ' Reads the entire data grid view and adds the start and end times to a list
            For intColumnCount = 0 To DataGridInput.Columns.Count - 1
                For intRowCount = 0 To DataGridInput.Rows.Count - 1
                    If intRowCount = 0 Then
                        ' adds start times to list
                        startTimes.Add(DataGridInput.Rows(intRowCount).Cells(intColumnCount).Value)
                    Else
                        ' adds end times to list
                        endTimes.Add(DataGridInput.Rows(intRowCount).Cells(intColumnCount).Value)
                    End If
                Next intRowCount
            Next intColumnCount

            Try
                ' create a new object of an employee to calculate hours and wage
                employee = New Employee(empNameInput.Text, wageInput.Text, startTimes, endTimes)
                WarningLabel.Visible = False
                hourOutput.Text = FormatNumber(CDbl(Convert.ToString(employee.WorkHours)), 2)
                wageOutput.Text = ""
            Catch ArgumentOutOfRangeException As Exception
                ' If creating the employee failed display warning labels so user can fix errors
                WarningLabel.Visible = True
                hourOutput.Text = ""
                wageOutput.Text = ""
            End Try
        Else
            ' Shows warnings for invalid input
            InputWarningLabel.Visible = True
        End If
    End Sub

    ' This method makes sure that the data entered in the grid view is all accurate as well as creates a new employe object to calculate the
    ' wage earned
    Private Sub wageButton_Click(sender As Object, e As EventArgs) Handles wageButton.Click
        If IsNumeric(wageInput.Text) And empNameInput.Text IsNot "" Then
            startTimes = New List(Of String)
            endTimes = New List(Of String)
            Dim intRowCount As Integer
            Dim intColumnCount As Integer

            ' Reads the entire data grid view and adds the start and end times to a list
            For intColumnCount = 0 To DataGridInput.Columns.Count - 1
                For intRowCount = 0 To DataGridInput.Rows.Count - 1
                    If intRowCount = 0 Then
                        ' adds start times to list
                        startTimes.Add(DataGridInput.Rows(intRowCount).Cells(intColumnCount).Value)
                    Else
                        ' adds end times to list
                        endTimes.Add(DataGridInput.Rows(intRowCount).Cells(intColumnCount).Value)
                    End If
                Next intRowCount
            Next intColumnCount

            Try
                ' create a new object of an employee to calculate hours and wage
                employee = New Employee(empNameInput.Text, wageInput.Text, startTimes, endTimes)
                WarningLabel.Visible = False
                hourOutput.Text = ""
                wageOutput.Text = FormatNumber(CDbl(Convert.ToString(employee.Workwage)), 2)
            Catch ArgumentOutOfRangeException As Exception
                ' If creating the employee failed display warning labels so user can fix errors
                WarningLabel.Visible = True
                wageOutput.Text = ""
                hourOutput.Text = ""
            End Try
        Else
            ' Shows warnings for invalid input
            InputWarningLabel.Visible = True
        End If
    End Sub

    ' This method will clear all data from the data grid view as well as clear the text boxes
    Private Sub clearButton_Click(sender As Object, e As EventArgs) Handles clearButton.Click
        ' Goes through every cell in the data grid and clears the data
        For intColumnCount = 0 To DataGridInput.Columns.Count - 1
            For intRowCount = 0 To DataGridInput.Rows.Count - 1
                DataGridInput.Rows(intRowCount).Cells(intColumnCount).Value = ""
            Next intRowCount
        Next intColumnCount

        ' Clears text boxes
        hourOutput.Text = ""
        wageOutput.Text = ""
        empNameInput.Text = ""
        wageInput.Text = ""
    End Sub

End Class
