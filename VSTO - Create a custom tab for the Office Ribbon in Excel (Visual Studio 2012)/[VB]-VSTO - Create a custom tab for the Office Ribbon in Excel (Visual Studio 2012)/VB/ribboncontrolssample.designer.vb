Partial Class RibbonControlsSample
    Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New(Globals.Factory.GetRibbonFactory())

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim RibbonDropDownItem1 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem()
        Dim RibbonDropDownItem2 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem()
        Dim RibbonDropDownItem3 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem()
        Dim RibbonDropDownItem4 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem()
        Dim RibbonDropDownItem5 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem()
        Dim RibbonDropDownItem6 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem()
        Dim RibbonDropDownItem7 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem()
        Dim RibbonDropDownItem8 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem()
        Me.tControls = Me.Factory.CreateRibbonTab()
        Me.gButtons = Me.Factory.CreateRibbonGroup()
        Me.btnActionsPane = Me.Factory.CreateRibbonToggleButton()
        Me.bgMoodFace = Me.Factory.CreateRibbonButtonGroup()
        Me.btnHappy = Me.Factory.CreateRibbonToggleButton()
        Me.btnNeutral = Me.Factory.CreateRibbonToggleButton()
        Me.btnSad = Me.Factory.CreateRibbonToggleButton()
        Me.sbtnAlign = Me.Factory.CreateRibbonSplitButton()
        Me.btnLeft = Me.Factory.CreateRibbonButton()
        Me.btnCenter = Me.Factory.CreateRibbonButton()
        Me.btnRight = Me.Factory.CreateRibbonButton()
        Me.Separator1 = Me.Factory.CreateRibbonSeparator()
        Me.ddFormatChart = Me.Factory.CreateRibbonDropDown()
        Me.cbMRUFind = Me.Factory.CreateRibbonComboBox()
        Me.galShapes = Me.Factory.CreateRibbonGallery()
        Me.gDynamicMenu = Me.Factory.CreateRibbonGroup()
        Me.mDynamicMenu = Me.Factory.CreateRibbonMenu()
        Me.cbButton = Me.Factory.CreateRibbonCheckBox()
        Me.cbSeparator = Me.Factory.CreateRibbonCheckBox()
        Me.cbSubMenu = Me.Factory.CreateRibbonCheckBox()
        Me.tControls.SuspendLayout()
        Me.gButtons.SuspendLayout()
        Me.bgMoodFace.SuspendLayout()
        Me.gDynamicMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tControls
        '
        Me.tControls.Groups.Add(Me.gButtons)
        Me.tControls.Groups.Add(Me.gDynamicMenu)
        Me.tControls.Label = "Ribbon Control Sample"
        Me.tControls.Name = "tControls"
        '
        'gButtons
        '
        Me.gButtons.Items.Add(Me.btnActionsPane)
        Me.gButtons.Items.Add(Me.bgMoodFace)
        Me.gButtons.Items.Add(Me.sbtnAlign)
        Me.gButtons.Items.Add(Me.Separator1)
        Me.gButtons.Items.Add(Me.ddFormatChart)
        Me.gButtons.Items.Add(Me.cbMRUFind)
        Me.gButtons.Items.Add(Me.galShapes)
        Me.gButtons.Label = "Working with Sheets"
        Me.gButtons.Name = "gButtons"
        '
        'btnActionsPane
        '
        Me.btnActionsPane.Label = "Show Actions Pane"
        Me.btnActionsPane.Name = "btnActionsPane"
        Me.btnActionsPane.ScreenTip = "Toggle Button"
        Me.btnActionsPane.SuperTip = "A ToggleButton that appears pressed or unpressed.  Click the ToggleButton to show" & _
            "/hide the Actions Pane."
        '
        'bgMoodFace
        '
        Me.bgMoodFace.Items.Add(Me.btnHappy)
        Me.bgMoodFace.Items.Add(Me.btnNeutral)
        Me.bgMoodFace.Items.Add(Me.btnSad)
        Me.bgMoodFace.Name = "bgMoodFace"
        '
        'btnHappy
        '
        Me.btnHappy.Checked = True
        Me.btnHappy.Image = Global.RibbonControlsExcelWorkbook.My.Resources.Resources.happy
        Me.btnHappy.Label = "ToggleButton1"
        Me.btnHappy.Name = "btnHappy"
        Me.btnHappy.ShowImage = True
        Me.btnHappy.ShowLabel = False
        '
        'btnNeutral
        '
        Me.btnNeutral.Image = Global.RibbonControlsExcelWorkbook.My.Resources.Resources.Neutral
        Me.btnNeutral.Label = "ToggleButton2"
        Me.btnNeutral.Name = "btnNeutral"
        Me.btnNeutral.ShowImage = True
        Me.btnNeutral.ShowLabel = False
        '
        'btnSad
        '
        Me.btnSad.Image = Global.RibbonControlsExcelWorkbook.My.Resources.Resources.sad
        Me.btnSad.Label = "ToggleButton3"
        Me.btnSad.Name = "btnSad"
        Me.btnSad.ShowImage = True
        Me.btnSad.ShowLabel = False
        '
        'sbtnAlign
        '
        Me.sbtnAlign.Items.Add(Me.btnLeft)
        Me.sbtnAlign.Items.Add(Me.btnCenter)
        Me.sbtnAlign.Items.Add(Me.btnRight)
        Me.sbtnAlign.Label = "Alignment"
        Me.sbtnAlign.Name = "sbtnAlign"
        Me.sbtnAlign.OfficeImageId = "AlignCenter"
        Me.sbtnAlign.ScreenTip = "Split Button"
        Me.sbtnAlign.SuperTip = "A Split Button is a button with a menu.  Click the button to center align text in" & _
            " cell A4 or select the menu for other alignment options."
        '
        'btnLeft
        '
        Me.btnLeft.Label = "Left Align"
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.OfficeImageId = "AlignLeft"
        Me.btnLeft.ScreenTip = "Button"
        Me.btnLeft.ShowImage = True
        Me.btnLeft.SuperTip = "Button in a Split Button."
        '
        'btnCenter
        '
        Me.btnCenter.Label = "Center Align"
        Me.btnCenter.Name = "btnCenter"
        Me.btnCenter.OfficeImageId = "AlignCenter"
        Me.btnCenter.ScreenTip = "Button"
        Me.btnCenter.ShowImage = True
        Me.btnCenter.SuperTip = "Button in a Split Button."
        '
        'btnRight
        '
        Me.btnRight.Label = "Right Align"
        Me.btnRight.Name = "btnRight"
        Me.btnRight.OfficeImageId = "AlignRight"
        Me.btnRight.ScreenTip = "Button"
        Me.btnRight.ShowImage = True
        Me.btnRight.SuperTip = "Button in a Split Button."
        '
        'Separator1
        '
        Me.Separator1.Name = "Separator1"
        '
        'ddFormatChart
        '
        RibbonDropDownItem1.Label = "Bar"
        RibbonDropDownItem1.OfficeImageId = "ChartTypeBarInsertGallery"
        RibbonDropDownItem1.ScreenTip = "DropDown Item"
        RibbonDropDownItem1.SuperTip = "Select DropDown Item to format the chart."
        RibbonDropDownItem2.Label = "Column"
        RibbonDropDownItem2.OfficeImageId = "ChartTypeColumnInsertGallery"
        RibbonDropDownItem2.ScreenTip = "DropDown Item"
        RibbonDropDownItem2.SuperTip = "Select DropDown Item to format the chart."
        RibbonDropDownItem3.Label = "Area"
        RibbonDropDownItem3.OfficeImageId = "ChartTypeAreaInsertGallery"
        RibbonDropDownItem3.ScreenTip = "DropDown Item"
        RibbonDropDownItem3.SuperTip = "Select DropDown Item to format the chart."
        RibbonDropDownItem4.Label = "Pie"
        RibbonDropDownItem4.OfficeImageId = "ChartTypePieInsertGallery"
        RibbonDropDownItem4.ScreenTip = "DropDown Item"
        RibbonDropDownItem4.SuperTip = "Select DropDown Item to format the chart."
        Me.ddFormatChart.Items.Add(RibbonDropDownItem1)
        Me.ddFormatChart.Items.Add(RibbonDropDownItem2)
        Me.ddFormatChart.Items.Add(RibbonDropDownItem3)
        Me.ddFormatChart.Items.Add(RibbonDropDownItem4)
        Me.ddFormatChart.Label = "Format Chart"
        Me.ddFormatChart.Name = "ddFormatChart"
        Me.ddFormatChart.ScreenTip = "Drop Down"
        Me.ddFormatChart.SuperTip = "A drop down list of options.  Select a chart type to format the chart on Sheet1."
        '
        'cbMRUFind
        '
        RibbonDropDownItem5.Label = "Q1"
        RibbonDropDownItem6.Label = "Q2"
        RibbonDropDownItem7.Label = "Q3"
        RibbonDropDownItem8.Label = "Q4"
        Me.cbMRUFind.Items.Add(RibbonDropDownItem5)
        Me.cbMRUFind.Items.Add(RibbonDropDownItem6)
        Me.cbMRUFind.Items.Add(RibbonDropDownItem7)
        Me.cbMRUFind.Items.Add(RibbonDropDownItem8)
        Me.cbMRUFind.Label = "MRU Find"
        Me.cbMRUFind.Name = "cbMRUFind"
        Me.cbMRUFind.ScreenTip = "Combo Box"
        Me.cbMRUFind.SizeString = "Enter or select search text."
        Me.cbMRUFind.SuperTip = "ComboBox is a EditBox with a DropDown.  Select text from the list to find it in t" & _
            "he spreadsheet.  Or, enter your own search string to add to the list."
        Me.cbMRUFind.Text = "Enter or select search text."
        '
        'galShapes
        '
        Me.galShapes.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.galShapes.Image = Global.RibbonControlsExcelWorkbook.My.Resources.Resources.AvocadoGreen
        Me.galShapes.Label = "Color"
        Me.galShapes.Name = "galShapes"
        Me.galShapes.ScreenTip = "Gallery"
        Me.galShapes.ShowImage = True
        Me.galShapes.SuperTip = "A gallery is a multi-dimensional dropdown.  This gallery will format insert a dif" & _
            "ferent colored sphere on to Sheet1."
        '
        'gDynamicMenu
        '
        Me.gDynamicMenu.Items.Add(Me.mDynamicMenu)
        Me.gDynamicMenu.Items.Add(Me.cbButton)
        Me.gDynamicMenu.Items.Add(Me.cbSeparator)
        Me.gDynamicMenu.Items.Add(Me.cbSubMenu)
        Me.gDynamicMenu.Label = "Build Dynamic Menu"
        Me.gDynamicMenu.Name = "gDynamicMenu"
        '
        'mDynamicMenu
        '
        Me.mDynamicMenu.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.mDynamicMenu.Dynamic = True
        Me.mDynamicMenu.Label = "Dynamic Menu"
        Me.mDynamicMenu.Name = "mDynamicMenu"
        Me.mDynamicMenu.OfficeImageId = "QueryAppend"
        Me.mDynamicMenu.ScreenTip = "Dynamic Menu"
        Me.mDynamicMenu.ShowImage = True
        Me.mDynamicMenu.SuperTip = "This is a dynamic menu.  Use the checkboxes at the right to determine which contr" & _
            "ols to add at runtime."
        '
        'cbButton
        '
        Me.cbButton.Label = "Button"
        Me.cbButton.Name = "cbButton"
        Me.cbButton.ScreenTip = "Check Box"
        Me.cbButton.SuperTip = "Select to add control to Dynamic Menu."
        '
        'cbSeparator
        '
        Me.cbSeparator.Label = "Separator"
        Me.cbSeparator.Name = "cbSeparator"
        Me.cbSeparator.ScreenTip = "Check Box"
        Me.cbSeparator.SuperTip = "Select to add control to Dynamic Menu."
        '
        'cbSubMenu
        '
        Me.cbSubMenu.Label = "SubMenu"
        Me.cbSubMenu.Name = "cbSubMenu"
        Me.cbSubMenu.ScreenTip = "Check Box"
        Me.cbSubMenu.SuperTip = "Select to add control to Dynamic Menu."
        '
        'RibbonControlsSample
        '
        Me.Name = "RibbonControlsSample"
        Me.RibbonType = "Microsoft.Excel.Workbook"
        Me.StartFromScratch = True
        Me.Tabs.Add(Me.tControls)
        Me.tControls.ResumeLayout(False)
        Me.tControls.PerformLayout()
        Me.gButtons.ResumeLayout(False)
        Me.gButtons.PerformLayout()
        Me.bgMoodFace.ResumeLayout(False)
        Me.bgMoodFace.PerformLayout()
        Me.gDynamicMenu.ResumeLayout(False)
        Me.gDynamicMenu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tControls As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents gButtons As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents gDynamicMenu As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnActionsPane As Microsoft.Office.Tools.Ribbon.RibbonToggleButton
    Friend WithEvents bgMoodFace As Microsoft.Office.Tools.Ribbon.RibbonButtonGroup
    Friend WithEvents sbtnAlign As Microsoft.Office.Tools.Ribbon.RibbonSplitButton
    Friend WithEvents btnLeft As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnCenter As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnRight As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents cbMRUFind As Microsoft.Office.Tools.Ribbon.RibbonComboBox
    Friend WithEvents Separator1 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
    Friend WithEvents ddFormatChart As Microsoft.Office.Tools.Ribbon.RibbonDropDown
    Friend WithEvents galShapes As Microsoft.Office.Tools.Ribbon.RibbonGallery
    Friend WithEvents mDynamicMenu As Microsoft.Office.Tools.Ribbon.RibbonMenu
    Friend WithEvents cbButton As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents cbSubMenu As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents cbSeparator As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents btnHappy As Microsoft.Office.Tools.Ribbon.RibbonToggleButton
    Friend WithEvents btnNeutral As Microsoft.Office.Tools.Ribbon.RibbonToggleButton
    Friend WithEvents btnSad As Microsoft.Office.Tools.Ribbon.RibbonToggleButton
End Class

Partial Class ThisRibbonCollection


    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property RibbonControlsSample() As RibbonControlsSample
        Get
            Return Me.GetRibbon(Of RibbonControlsSample)()
        End Get
    End Property
End Class