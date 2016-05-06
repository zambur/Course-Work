'Zach Ambur
'Lab 3
'IS 371
Public Class ATM
    Public pinEntered As Boolean = False
    Public withdrawEntered As Boolean = False

    Private Sub ATM_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ATMTableTableAdapter.Fill(Me.ATMDataSet.ATMTable)
        Catch ex As System.Data.DBConcurrencyException
            My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
        End Try
        AccountNumCombo.SelectedIndex = -1
    End Sub

    Private Sub ATMTableBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ATMTableBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ATMDataSet)

    End Sub

    ' Enable the user to enter in thier pin as soon as they have selected a account number
    Private Sub AccountNumCombo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles AccountNumCombo.SelectedIndexChanged
        If AccountNumCombo.SelectedIndex <> -1 Then
            OneButton.Enabled = True
            TwoButton.Enabled = True
            ThreeButton.Enabled = True
            FourButton.Enabled = True
            FiveButton.Enabled = True
            SixButton.Enabled = True
            SevenButton.Enabled = True
            EightButton.Enabled = True
            NineButton.Enabled = True
            ZeroButton.Enabled = True
            DoneButton.Enabled = True
            HeadsUpLabel.Text = "Enter your pin number on the pad."
            PinText.Clear()
        End If
    End Sub

    ' The following appends the selected number to the text box
    Private Sub OneButton_Click(sender As System.Object, e As System.EventArgs) Handles OneButton.Click
        PinText.AppendText("1")
    End Sub

    Private Sub TwoButton_Click(sender As System.Object, e As System.EventArgs) Handles TwoButton.Click
        PinText.AppendText("2")
    End Sub

    Private Sub ThreeButton_Click(sender As System.Object, e As System.EventArgs) Handles ThreeButton.Click
        PinText.AppendText("3")
    End Sub

    Private Sub FourButton_Click(sender As System.Object, e As System.EventArgs) Handles FourButton.Click
        PinText.AppendText("4")
    End Sub

    Private Sub FiveButton_Click(sender As System.Object, e As System.EventArgs) Handles FiveButton.Click
        PinText.AppendText("5")
    End Sub

    Private Sub SixButton_Click(sender As System.Object, e As System.EventArgs) Handles SixButton.Click
        PinText.AppendText("6")
    End Sub

    Private Sub SevenButton_Click(sender As System.Object, e As System.EventArgs) Handles SevenButton.Click
        PinText.AppendText("7")
    End Sub

    Private Sub EightButton_Click(sender As System.Object, e As System.EventArgs) Handles EightButton.Click
        PinText.AppendText("8")
    End Sub

    Private Sub NineButton_Click(sender As System.Object, e As System.EventArgs) Handles NineButton.Click
        PinText.AppendText("9")
    End Sub

    Private Sub ZeroButton_Click(sender As System.Object, e As System.EventArgs) Handles ZeroButton.Click
        PinText.AppendText("0")
    End Sub

    ' returns the application to the start state
    Private Sub DoneButton_Click(sender As System.Object, e As System.EventArgs) Handles DoneButton.Click
        OneButton.Enabled = False
        TwoButton.Enabled = False
        ThreeButton.Enabled = False
        FourButton.Enabled = False
        FiveButton.Enabled = False
        SixButton.Enabled = False
        SevenButton.Enabled = False
        EightButton.Enabled = False
        NineButton.Enabled = False
        ZeroButton.Enabled = False
        DoneButton.Enabled = False
        DoneButton.Enabled = False
        OkayButton.Enabled = False
        BalanceButton.Enabled = False
        WithdrawButton.Enabled = False
        PinText.Enabled = False
        HeadsUpLabel.Text = "Please select your account number."
        PinText.Clear()
        AccountNumCombo.Enabled = True
        AccountNumCombo.SelectedIndex = -1
        pinEntered = False
        withdrawEntered = False
    End Sub

    ' Enable other buttons once pin has been entered
    Private Sub PinText_TextChanged(sender As System.Object, e As System.EventArgs) Handles PinText.TextChanged
        If pinEntered = False Then
            OkayButton.Enabled = True
        ElseIf withdrawEntered = True Then
            OkayButton.Enabled = True
        End If
    End Sub

    ' Depending on what state the machine is in, either accept/reject pin, or validate withdrawal
    Private Sub OkayButton_Click(sender As System.Object, e As System.EventArgs) Handles OkayButton.Click
        If HeadsUpLabel.Text = "Please enter an amount for withdrawal." Then
            Dim custAccout = AccountNumCombo.SelectedValue.ToString
            Try
                Dim actualCust =
                    From customer In ATMDataSet.ATMTable
                    Where customer.acctNum = custAccout
                    Select customer
                Try
                    If Val(PinText.Text) <= Val(actualCust(0).balance) Then
                        actualCust(0).balance = Val(actualCust(0).balance) - Val(PinText.Text)
                        BalanceButton.Enabled = True
                        OkayButton.Enabled = False
                        HeadsUpLabel.Text = "New balance is: $" + actualCust(0).balance.ToString
                        WithdrawButton.Enabled = True
                        withdrawEntered = False
                        Try
                            Me.Validate()
                            Me.ATMTableBindingSource.EndEdit()
                        Catch ex As System.Data.DBConcurrencyException
                            My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
                        End Try
                    Else
                        HeadsUpLabel.Text = "Amount too high!"
                        PinText.Clear()
                        OkayButton.Enabled = False
                        WithdrawButton.Enabled = True
                        withdrawEntered = False
                        BalanceButton.Enabled = True
                    End If
                Catch ex As ArgumentException
                    My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
                End Try
            Catch ex As System.Data.DBConcurrencyException
                My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
            End Try
        Else
            Dim custPin = PinText.Text
            Dim custAccout = AccountNumCombo.SelectedValue.ToString
            Try
                Dim actualCust =
                    From customer In ATMDataSet.ATMTable
                    Where customer.acctNum = custAccout
                    Select customer
                If custPin = actualCust(0).pin Then
                    PinText.Clear()
                    PinText.Enabled = False
                    WithdrawButton.Enabled = True
                    BalanceButton.Enabled = True
                    HeadsUpLabel.Text = "Your balance is: $" + actualCust(0).balance.ToString
                    AccountNumCombo.Enabled = False
                    pinEntered = True
                    OkayButton.Enabled = False
                Else
                    PinText.Clear()
                    HeadsUpLabel.Text = "Your pin was incorrect. Please try again."
                End If
            Catch ex As System.Data.DBConcurrencyException
                My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
            End Try
        End If

    End Sub

    ' Puts the app into a state for withdrawing funds
    Private Sub WithdrawButton_Click(sender As System.Object, e As System.EventArgs) Handles WithdrawButton.Click
        PinText.Clear()
        PinText.Enabled = False
        HeadsUpLabel.Text = "Please enter an amount for withdrawal."
        BalanceButton.Enabled = False
        WithdrawButton.Enabled = False
        withdrawEntered = True
    End Sub

    ' Display the current account balance
    Private Sub BalanceButton_Click(sender As System.Object, e As System.EventArgs) Handles BalanceButton.Click
        Dim custAccout = AccountNumCombo.SelectedValue.ToString
        Try
            Dim actualCust =
                From customer In ATMDataSet.ATMTable
                Where customer.acctNum = custAccout
                Select customer
            HeadsUpLabel.Text = "Your balance is: $" + actualCust(0).balance.ToString
        Catch ex As System.Data.DBConcurrencyException
            My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
        End Try
    End Sub
End Class
