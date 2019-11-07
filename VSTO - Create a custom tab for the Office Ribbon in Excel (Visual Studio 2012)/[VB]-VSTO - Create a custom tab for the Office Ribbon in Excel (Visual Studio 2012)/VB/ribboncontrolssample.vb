' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports Microsoft.Office.Tools.Ribbon

Public Class RibbonControlsSample

    Dim AP1 As New ActionsPaneControl1

    '  Load event fires when the Ribbon loads
    '  Actions Pane is added to the project but remains hidden until the user chooses to show it
    Private Sub RibbonControls_Load(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs) Handles MyBase.Load
        Globals.ThisWorkbook.ActionsPane.Controls.Add(AP1)
        AP1.Hide()
        Globals.ThisWorkbook.Application.DisplayDocumentActionTaskPane = False
    End Sub

    '  ToggleButton click event shows/hides the Actions Pane
    Private Sub btnActionsPane_Click(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles btnActionsPane.Click
        Globals.ThisWorkbook.Application.DisplayDocumentActionTaskPane = btnActionsPane.Checked
        AP1.Visible = btnActionsPane.Checked
    End Sub

    Private Sub btnHappy_Click(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles btnHappy.Click
        If btnHappy.Checked Then
            ChangeFace("J")
            btnNeutral.Checked = False
            btnSad.Checked = False
        Else
            ChangeFace("")
        End If
    End Sub


    Private Sub btnNeutral_Click(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles btnNeutral.Click
        If btnNeutral.Checked Then
            ChangeFace("K")
            btnHappy.Checked = False
            btnSad.Checked = False
        Else
            ChangeFace("")
        End If
    End Sub


    Private Sub btnSad_Click(ByVal sender As Object, ByVal e As RibbonControlEventArgs) Handles btnSad.Click
        If btnSad.Checked Then
            ChangeFace("L")
            btnHappy.Checked = False
            btnNeutral.Checked = False
        Else
            ChangeFace("")
        End If
    End Sub

    Private Sub ChangeFace(ByVal faceLetter As String)
        Dim xlCell = Globals.Sheet1.Range("a1")
        xlCell.FormulaR1C1 = faceLetter
        With xlCell.Font
            .Name = "Wingdings"
            .FontStyle = "Regular"
            .Size = 24
            .Color = -16776361
        End With
        xlCell.Select()
    End Sub

    Private Sub btnLeft_Click(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles btnLeft.Click
        Dim xlcell = Globals.Sheet1.Range("a3")
        xlcell.Value = "Left"
        xlcell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
        xlcell.Select()
    End Sub

    Private Sub btnCenter_Click(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles sbtnAlign.Click, btnCenter.Click
        Dim xlcell = Globals.Sheet1.Range("a3")
        xlcell.Value = "Center"
        xlcell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
        xlcell.Select()
    End Sub

    Private Sub btnRight_Click(ByVal sender As Object, ByVal e As RibbonControlEventArgs) Handles btnRight.Click
        Dim xlcell = Globals.Sheet1.Range("a3")
        xlcell.Value = "Right"
        xlcell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
        xlcell.Select()
    End Sub

    '  The Text Changed event fires when the user selects an item 
    '  from the combo box drop down or enters a new item in the edit box.  The event handler
    '  does two things.  First, it performs a Find on the sheet for the text string.
    '  Next, it looks to see if the string exists in the combo box drop down.  If it 
    '  does not, the string will be added to the list.
    Private Sub cbMRUFind_TextChanged(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles cbMRUFind.TextChanged
        Dim xlcell = Globals.ThisWorkbook.Application.Cells.Find(cbMRUFind.Text)
        If xlcell Is Nothing Then
            MsgBox("Text Not Found")
        Else
            xlcell.Select()
            MsgBox("Search text: " & cbMRUFind.Text & " found in cell " & xlcell.Address)
        End If

        Dim newSearchText = True
        For Each ddI In cbMRUFind.Items
            If cbMRUFind.Text = ddI.Label Then
                newSearchText = False
            End If
        Next
        If newSearchText Then
            Dim item = Globals.Factory.GetRibbonFactory.CreateRibbonDropDownItem()
            item.Label = cbMRUFind.Text
            cbMRUFind.Items.Add(item)
            MsgBox("New item: " & item.Label & " added to ComboBox")
        End If
    End Sub

    '  The drop down select changed event fires when the user selects an item
    '  from the drop down.  
    Private Sub ddFormatChart_SelectionChanged(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles ddFormatChart.SelectionChanged

        Dim xlChart As Microsoft.Office.Tools.Excel.Chart

        xlChart = Globals.Sheet1.Controls("Chart_1")

        Select Case ddFormatChart.SelectedItem.Label
            Case "Bar"
                xlChart.ChartType = Excel.XlChartType.xl3DBarClustered
            Case "Column"
                xlChart.ChartType = Excel.XlChartType.xl3DColumnClustered
            Case "Area"
                xlChart.ChartType = Excel.XlChartType.xl3DArea
            Case "Pie"
                xlChart.ChartType = Excel.XlChartType.xl3DPie
        End Select
    End Sub

    Private Function makeRibbonDropDownItem(ByVal Label As String, ByVal Image As System.Drawing.Image) As RibbonDropDownItem
        Dim tmp As RibbonDropDownItem
        tmp = Globals.Factory.GetRibbonFactory.CreateRibbonDropDownItem()
        tmp.Label = Label
        tmp.Image = Image
        Return tmp
    End Function

    '  The gallery items loading event fires each time the user clicks 
    '  the gallery drop down.  This allows for the gallery items to be loaded
    '  dynamically at runtime.
    Private Sub galShapes_ItemsLoading(ByVal sender As Object, ByVal e As RibbonControlEventArgs) Handles galShapes.ItemsLoading
        If galShapes.Items.Count = 0 Then
            Dim galleryItems = galShapes.Items
            galleryItems.Add(makeRibbonDropDownItem("Avocado", My.Resources.AvocadoGreen))
            galleryItems.Add(makeRibbonDropDownItem("Berry", My.Resources.Berry))
            galleryItems.Add(makeRibbonDropDownItem("BurntRed", My.Resources.BurntRed))
            galleryItems.Add(makeRibbonDropDownItem("Gold", My.Resources.Gold))
            galleryItems.Add(makeRibbonDropDownItem("Gray", My.Resources.Gray))
            galleryItems.Add(makeRibbonDropDownItem("Green", My.Resources.Green))
            galleryItems.Add(makeRibbonDropDownItem("Orange", My.Resources.Orange))
            galleryItems.Add(makeRibbonDropDownItem("Purple", My.Resources.Purple))
            galleryItems.Add(makeRibbonDropDownItem("Red", My.Resources.Red))
            galleryItems.Add(makeRibbonDropDownItem("Sapphire", My.Resources.Sapphire))
            galleryItems.Add(makeRibbonDropDownItem("SkyBlue", My.Resources.SkyBlue))
            galleryItems.Add(makeRibbonDropDownItem("Teal", My.Resources.Teal))
            galleryItems.Add(makeRibbonDropDownItem("Turquiose", My.Resources.Turquoise))
            galleryItems.Add(makeRibbonDropDownItem("Violet", My.Resources.Violet))
        End If
    End Sub

    '  The gallery click event fires when the user selects a gallery item
    Private Sub galShapes_Click(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles galShapes.Click

        galShapes.Image = galShapes.SelectedItem.Image

        Dim oldShape = Globals.Sheet1.Shapes.Item("Picture 1")

        Dim tempImageName As String = System.IO.Path.GetTempFileName()
        galShapes.SelectedItem.Image.Save(tempImageName)

        Dim newShape = Globals.Sheet1.Shapes.AddPicture(tempImageName, _
                                     Microsoft.Office.Core.MsoTriState.msoFalse, _
                                     Microsoft.Office.Core.MsoTriState.msoTrue, _
                                     oldShape.Left, oldShape.Top, oldShape.Width, oldShape.Height)

        oldShape.Delete()
        newShape.Name = "Picture 1"

    End Sub

    '  The menu items loading event fires when a menu has the dynamic property 
    '  set to true and the user clicks on the menu drop down.  This allows menu
    '  items to be added dynamically at run time.
    Private Sub mDynamicMenu_ItemsLoading(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles mDynamicMenu.ItemsLoading

        mDynamicMenu.Items.Clear()

        If cbButton.Checked Then
            Dim tmp As RibbonButton
            tmp = Globals.Factory.GetRibbonFactory.CreateRibbonButton()
            tmp.Label = "Button"
            mDynamicMenu.Items.Add(tmp)
        End If

        If cbSeparator.Checked Then
            Dim tmp As RibbonSeparator
            tmp = Globals.Factory.GetRibbonFactory.CreateRibbonSeparator()
            tmp.Title = "Button"
            mDynamicMenu.Items.Add(tmp)
        End If

        If cbSubMenu.Checked Then
            Dim subButton As RibbonButton
            subButton = Globals.Factory.GetRibbonFactory.CreateRibbonButton()
            With subButton
                .Label = "SubMenu Button"
                .OfficeImageId = "_3DMaterialMetal"
                .Description = "Large Button in a Sub Menu"
            End With

            Dim mSubMenu As RibbonMenu
            mSubMenu = Globals.Factory.GetRibbonFactory.CreateRibbonMenu()
            With mSubMenu
                .Items.Add(subButton)
                .ItemSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
                .Label = "Sub Menu"
            End With
            mDynamicMenu.Items.Add(mSubMenu)
        End If

    End Sub
End Class
