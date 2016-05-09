'Zach Ambur
'Ross Shohoney
'Drew Marx
'IS 371 
'Pilot Application
Public Class Service
    Private Sub PartsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.PartsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AvailableParts)

    End Sub

    Private Sub Service_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initially set the beginning pictures tag to 0 (starting image)
        ListViewPictureBox.Image.Tag = 0
        TreeViewPictureBox.Image.Tag = 0
        DataGridPictureBox.Image.Tag = 0

        Try
            Dim partsData As AvailableParts.PartsDataTable = PartsTableAdapter.GetData()
            Dim currRow As AvailableParts.PartsRow

            'Create root node for tree list view
            Dim root = New TreeNode("Available Parts")
            PartsTreeView.Nodes.Add(root)

            ' For each part add it to all 3 of the tabbed views
            For Each currRow In partsData
                ' Add new part to the list view menu
                Dim listItem = New ListViewItem
                listItem.SubItems(0).Text = currRow.PART_ID
                listItem.SubItems().Add(currRow.PART_NAME)
                listItem.SubItems().Add(currRow.PART_CAT_NAME)
                listItem.SubItems().Add(currRow.LABOR)
                listItem.SubItems().Add(currRow.PRICE)
                listItem.SubItems().Add(currRow.DESC)
                PartsListView.Items.Add(listItem)

                ' Add new part to the data grid view menu
                PartsDataGridView.Rows.Add(currRow.PART_ID, currRow.PART_NAME, currRow.PART_CAT_NAME, currRow.LABOR,
                                           currRow.PRICE, currRow.DESC)

                ' Add new part to the tree list view
                PartsTreeView.Nodes(0).Nodes.Add(currRow.PART_NAME)
                PartsTreeView.Nodes(0).Nodes(currRow.PART_ID - 1).Nodes.Add("ID")
                PartsTreeView.Nodes(0).Nodes(currRow.PART_ID - 1).Nodes(0).Nodes.Add(currRow.PART_ID)
                PartsTreeView.Nodes(0).Nodes(currRow.PART_ID - 1).Nodes.Add("Catagory")
                PartsTreeView.Nodes(0).Nodes(currRow.PART_ID - 1).Nodes(1).Nodes.Add(currRow.PART_CAT_NAME)
                PartsTreeView.Nodes(0).Nodes(currRow.PART_ID - 1).Nodes.Add("Labor Cost")
                PartsTreeView.Nodes(0).Nodes(currRow.PART_ID - 1).Nodes(2).Nodes.Add(currRow.LABOR)
                PartsTreeView.Nodes(0).Nodes(currRow.PART_ID - 1).Nodes.Add("Price")
                PartsTreeView.Nodes(0).Nodes(currRow.PART_ID - 1).Nodes(3).Nodes.Add(currRow.PRICE)
                PartsTreeView.Nodes(0).Nodes(currRow.PART_ID - 1).Nodes.Add("Description")
                PartsTreeView.Nodes(0).Nodes(currRow.PART_ID - 1).Nodes(4).Nodes.Add(currRow.DESC)
            Next
        Catch ex As Exception
            My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
        End Try

    End Sub

    ' Handles the event when the user selects a cell in the data grid view it will display the corresponding image
    Private Sub PartsDataGridView_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles PartsDataGridView.CellMouseClick
        If e.RowIndex >= 0 Then
            Try
                'Calls function to load the new image in the corresponding picture box
                LoadImage(DataGridPictureBox, PartsDataGridView.Rows(e.RowIndex).Cells(1).Value)
            Catch ex As Exception
                My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
            End Try
        End If
    End Sub

    ' Handles the event when the user selects a row in the list view it will display the corresponding image
    Private Sub PartsListView_MouseClick(ByVal sender As Object, ByVal e As EventArgs) Handles PartsListView.MouseClick
        Try
            'Calls function to load the new image in the corresponding picture box
            LoadImage(ListViewPictureBox, PartsListView.SelectedItems(0).SubItems(1).Text)
        Catch ex As Exception
            My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
        End Try
    End Sub

    ' Handles the event when the user selects a node in the tree list view it will display the corresponding image
    Private Sub PartsTreeView_MouseClick(ByVal sender As Object, ByVal e As EventArgs) Handles PartsTreeView.AfterSelect
        Try
            'Calls function to load the new image in the corresponding picture box
            LoadImage(TreeViewPictureBox, PartsTreeView.SelectedNode.Text)
        Catch ex As Exception
            My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest " & "with argument " & ex.ToString & ".")
        End Try
    End Sub

    ' This method is used to load new pictures into the picture box based on the name of the part
    Private Sub LoadImage(pictureBox As PictureBox, part As String)
        Select Case part
            Case "Motor"
                pictureBox.Image = My.Resources.Motor
                pictureBox.Image.Tag = 0
            Case "Axle"
                pictureBox.Image = My.Resources.Axle
                pictureBox.Image.Tag = 1
            Case "Interlocking assembly"
                pictureBox.Image = My.Resources.Interlocking_Assembly
                pictureBox.Image.Tag = 2
            Case "Flange"
                pictureBox.Image = My.Resources.Flange
                pictureBox.Image.Tag = 3
            Case "Wheel rim"
                pictureBox.Image = My.Resources.Wheel_Rim
                pictureBox.Image.Tag = 4
            Case "Engine timing module"
                pictureBox.Image = My.Resources.Engine_Timing_Module
                pictureBox.Image.Tag = 5
            Case "Electrical connector"
                pictureBox.Image = My.Resources.Electrical_Connector
                pictureBox.Image.Tag = 6
            Case "Catalytic Converter"
                pictureBox.Image = My.Resources.Catalytic_Converter
                pictureBox.Image.Tag = 7
            Case "Engine CPU"
                pictureBox.Image = My.Resources.Engine_CPU
                pictureBox.Image.Tag = 8
            Case "Dashboard Dials"
                pictureBox.Image = My.Resources.Dashboard_Dials
                pictureBox.Image.Tag = 9
            Case "Headlights Control Chip"
                pictureBox.Image = My.Resources.Headlights_Control_Chip
                pictureBox.Image.Tag = 10
            Case "Engine"
                pictureBox.Image = My.Resources.Engine
                pictureBox.Image.Tag = 11
            Case "Blueprint"
                pictureBox.Image = My.Resources.Blueprint
                pictureBox.Image.Tag = 12
            Case "Temperature Control"
                pictureBox.Image = My.Resources.Temperature_Control
                pictureBox.Image.Tag = 13
            Case "Radiator"
                pictureBox.Image = My.Resources.Radiator
                pictureBox.Image.Tag = 14
            Case "Door Fixture"
                pictureBox.Image = My.Resources.Door_Fixture
                pictureBox.Image.Tag = 15
        End Select
    End Sub

    ' This method will find the next image to display when the user presses the forward button, based on the current image tag
    Private Sub NextImage(pictureBox As PictureBox, part As Integer)
        Select Case part
            Case 15
                pictureBox.Image = My.Resources.Motor
                pictureBox.Image.Tag = 0
            Case 0
                pictureBox.Image = My.Resources.Axle
                pictureBox.Image.Tag = 1
            Case 1
                pictureBox.Image = My.Resources.Interlocking_Assembly
                pictureBox.Image.Tag = 2
            Case 2
                pictureBox.Image = My.Resources.Flange
                pictureBox.Image.Tag = 3
            Case 3
                pictureBox.Image = My.Resources.Wheel_Rim
                pictureBox.Image.Tag = 4
            Case 4
                pictureBox.Image = My.Resources.Engine_Timing_Module
                pictureBox.Image.Tag = 5
            Case 5
                pictureBox.Image = My.Resources.Electrical_Connector
                pictureBox.Image.Tag = 6
            Case 6
                pictureBox.Image = My.Resources.Catalytic_Converter
                pictureBox.Image.Tag = 7
            Case 7
                pictureBox.Image = My.Resources.Engine_CPU
                pictureBox.Image.Tag = 8
            Case 8
                pictureBox.Image = My.Resources.Dashboard_Dials
                pictureBox.Image.Tag = 9
            Case 9
                pictureBox.Image = My.Resources.Headlights_Control_Chip
                pictureBox.Image.Tag = 10
            Case 10
                pictureBox.Image = My.Resources.Engine
                pictureBox.Image.Tag = 11
            Case 11
                pictureBox.Image = My.Resources.Blueprint
                pictureBox.Image.Tag = 12
            Case 12
                pictureBox.Image = My.Resources.Temperature_Control
                pictureBox.Image.Tag = 13
            Case 13
                pictureBox.Image = My.Resources.Radiator
                pictureBox.Image.Tag = 14
            Case 14
                pictureBox.Image = My.Resources.Door_Fixture
                pictureBox.Image.Tag = 15
        End Select
    End Sub

    ' This method will find the previous image to display when the user presses the back button, based on the current image tag
    Private Sub PreviousImage(pictureBox As PictureBox, part As Integer)
        Select Case part
            Case 1
                pictureBox.Image = My.Resources.Motor
                pictureBox.Image.Tag = 0
            Case 2
                pictureBox.Image = My.Resources.Axle
                pictureBox.Image.Tag = 1
            Case 3
                pictureBox.Image = My.Resources.Interlocking_Assembly
                pictureBox.Image.Tag = 2
            Case 4
                pictureBox.Image = My.Resources.Flange
                pictureBox.Image.Tag = 3
            Case 5
                pictureBox.Image = My.Resources.Wheel_Rim
                pictureBox.Image.Tag = 4
            Case 6
                pictureBox.Image = My.Resources.Engine_Timing_Module
                pictureBox.Image.Tag = 5
            Case 7
                pictureBox.Image = My.Resources.Electrical_Connector
                pictureBox.Image.Tag = 6
            Case 8
                pictureBox.Image = My.Resources.Catalytic_Converter
                pictureBox.Image.Tag = 7
            Case 9
                pictureBox.Image = My.Resources.Engine_CPU
                pictureBox.Image.Tag = 8
            Case 10
                pictureBox.Image = My.Resources.Dashboard_Dials
                pictureBox.Image.Tag = 9
            Case 11
                pictureBox.Image = My.Resources.Headlights_Control_Chip
                pictureBox.Image.Tag = 10
            Case 12
                pictureBox.Image = My.Resources.Engine
                pictureBox.Image.Tag = 11
            Case 13
                pictureBox.Image = My.Resources.Blueprint
                pictureBox.Image.Tag = 12
            Case 14
                pictureBox.Image = My.Resources.Temperature_Control
                pictureBox.Image.Tag = 13
            Case 15
                pictureBox.Image = My.Resources.Radiator
                pictureBox.Image.Tag = 14
            Case 0
                pictureBox.Image = My.Resources.Door_Fixture
                pictureBox.Image.Tag = 15
        End Select
    End Sub

    'Handles all button presses for both forward and back buttons in each tabbed view

    Private Sub TreeForwardButton_Click(sender As Object, e As EventArgs) Handles TreeForwardButton.Click
        NextImage(TreeViewPictureBox, TreeViewPictureBox.Image.Tag)
    End Sub

    Private Sub TreeBackButton_Click(sender As Object, e As EventArgs) Handles TreeBackButton.Click
        PreviousImage(TreeViewPictureBox, TreeViewPictureBox.Image.Tag)
    End Sub

    Private Sub ListForwardButton_Click(sender As Object, e As EventArgs) Handles ListForwardButton.Click
        NextImage(ListViewPictureBox, ListViewPictureBox.Image.Tag)
    End Sub

    Private Sub ListBackButton_Click(sender As Object, e As EventArgs) Handles ListBackButton.Click
        PreviousImage(ListViewPictureBox, ListViewPictureBox.Image.Tag)
    End Sub

    Private Sub DataGridForwardButton_Click(sender As Object, e As EventArgs) Handles DataGridForwardButton.Click
        NextImage(DataGridPictureBox, DataGridPictureBox.Image.Tag)
    End Sub

    Private Sub DataGridBackButton_Click(sender As Object, e As EventArgs) Handles DataGridBackButton.Click
        PreviousImage(DataGridPictureBox, DataGridPictureBox.Image.Tag)
    End Sub
End Class
