namespace RibbonControlsExcelWorkbook
{
    partial class RibbonControls
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItem1 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItem2 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItem3 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItem4 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItem5 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItem6 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItem7 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItem8 = this.Factory.CreateRibbonDropDownItem();
            this.tControls = this.Factory.CreateRibbonTab();
            this.gButtons = this.Factory.CreateRibbonGroup();
            this.btnActionsPane = this.Factory.CreateRibbonToggleButton();
            this.bgMoodFace = this.Factory.CreateRibbonButtonGroup();
            this.btnHappy = this.Factory.CreateRibbonToggleButton();
            this.btnNeutral = this.Factory.CreateRibbonToggleButton();
            this.btnSad = this.Factory.CreateRibbonToggleButton();
            this.sbtnAlign = this.Factory.CreateRibbonSplitButton();
            this.btnLeft = this.Factory.CreateRibbonButton();
            this.btnCenter = this.Factory.CreateRibbonButton();
            this.btnRight = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.ddFormatChart = this.Factory.CreateRibbonDropDown();
            this.cbMRUFind = this.Factory.CreateRibbonComboBox();
            this.galShapes = this.Factory.CreateRibbonGallery();
            this.gDynamicMenu = this.Factory.CreateRibbonGroup();
            this.mDynamicMenu = this.Factory.CreateRibbonMenu();
            this.cbButton = this.Factory.CreateRibbonCheckBox();
            this.cbSeparator = this.Factory.CreateRibbonCheckBox();
            this.cbSubMenu = this.Factory.CreateRibbonCheckBox();
            this.tControls.SuspendLayout();
            this.gButtons.SuspendLayout();
            this.bgMoodFace.SuspendLayout();
            this.gDynamicMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tControls
            // 
            this.tControls.Groups.Add(this.gButtons);
            this.tControls.Groups.Add(this.gDynamicMenu);
            this.tControls.Label = "Ribbon Control Sample";
            this.tControls.Name = "tControls";
            // 
            // gButtons
            // 
            this.gButtons.Items.Add(this.btnActionsPane);
            this.gButtons.Items.Add(this.bgMoodFace);
            this.gButtons.Items.Add(this.sbtnAlign);
            this.gButtons.Items.Add(this.separator1);
            this.gButtons.Items.Add(this.ddFormatChart);
            this.gButtons.Items.Add(this.cbMRUFind);
            this.gButtons.Items.Add(this.galShapes);
            this.gButtons.Label = "Working with Sheets";
            this.gButtons.Name = "gButtons";
            // 
            // btnActionsPane
            // 
            this.btnActionsPane.Label = "Show Actions Pane";
            this.btnActionsPane.Name = "btnActionsPane";
            this.btnActionsPane.ScreenTip = "Toggle Button";
            this.btnActionsPane.ShowImage = true;
            this.btnActionsPane.SuperTip = "A ToggleButton that appears pressed or unpressed.  Click the ToggleButton to show" +
                "/hide the Actions Pane.";
            this.btnActionsPane.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnActionsPane_Click);
            // 
            // bgMoodFace
            // 
            this.bgMoodFace.Items.Add(this.btnHappy);
            this.bgMoodFace.Items.Add(this.btnNeutral);
            this.bgMoodFace.Items.Add(this.btnSad);
            this.bgMoodFace.Name = "bgMoodFace";
            // 
            // btnHappy
            // 
            this.btnHappy.Image = global::RibbonControlsExcelWorkbook.Properties.Resources.happy;
            this.btnHappy.Label = "toggleButton1";
            this.btnHappy.Name = "btnHappy";
            this.btnHappy.ShowImage = true;
            this.btnHappy.ShowLabel = false;
            this.btnHappy.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnHappy_Click);
            // 
            // btnNeutral
            // 
            this.btnNeutral.Image = global::RibbonControlsExcelWorkbook.Properties.Resources.Neutral;
            this.btnNeutral.Label = "toggleButton2";
            this.btnNeutral.Name = "btnNeutral";
            this.btnNeutral.ShowImage = true;
            this.btnNeutral.ShowLabel = false;
            this.btnNeutral.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnNeutral_Click);
            // 
            // btnSad
            // 
            this.btnSad.Image = global::RibbonControlsExcelWorkbook.Properties.Resources.sad;
            this.btnSad.Label = "toggleButton3";
            this.btnSad.Name = "btnSad";
            this.btnSad.ShowImage = true;
            this.btnSad.ShowLabel = false;
            this.btnSad.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSad_Click);
            // 
            // sbtnAlign
            // 
            this.sbtnAlign.Items.Add(this.btnLeft);
            this.sbtnAlign.Items.Add(this.btnCenter);
            this.sbtnAlign.Items.Add(this.btnRight);
            this.sbtnAlign.Label = "Alignment";
            this.sbtnAlign.Name = "sbtnAlign";
            this.sbtnAlign.OfficeImageId = "AlignCenter";
            this.sbtnAlign.ScreenTip = "Split Button";
            this.sbtnAlign.SuperTip = "A Split Button is a button with a menu.  Click the button to center align text in" +
                " cell A4 or select the menu for other alignment options.";
            this.sbtnAlign.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.sbtnAlign_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Label = "Left Align";
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.OfficeImageId = "AlignLeft";
            this.btnLeft.ScreenTip = "Button";
            this.btnLeft.ShowImage = true;
            this.btnLeft.SuperTip = "Button in a Split Button.";
            this.btnLeft.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnLeft_Click);
            // 
            // btnCenter
            // 
            this.btnCenter.Label = "Center Align";
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.OfficeImageId = "AlignCenter";
            this.btnCenter.ScreenTip = "Button";
            this.btnCenter.ShowImage = true;
            this.btnCenter.SuperTip = "Button in a Split Button.";
            this.btnCenter.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCenter_Click);
            // 
            // btnRight
            // 
            this.btnRight.Label = "Right Align";
            this.btnRight.Name = "btnRight";
            this.btnRight.OfficeImageId = "AlignRight";
            this.btnRight.ScreenTip = "Button";
            this.btnRight.ShowImage = true;
            this.btnRight.SuperTip = "Button in a Split Button.";
            this.btnRight.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnRight_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // ddFormatChart
            // 
            ribbonDropDownItem1.Label = "Bar";
            ribbonDropDownItem1.OfficeImageId = "ChartTypeBarInsertGallery";
            ribbonDropDownItem1.ScreenTip = "DropDown Item";
            ribbonDropDownItem1.SuperTip = "Select DropDown Item to format the chart.";
            ribbonDropDownItem2.Label = "Column";
            ribbonDropDownItem2.OfficeImageId = "ChartTypeColumnInsertGallery";
            ribbonDropDownItem2.ScreenTip = "DropDown Item";
            ribbonDropDownItem2.SuperTip = "Select DropDown Item to format the chart.";
            ribbonDropDownItem3.Label = "Area";
            ribbonDropDownItem3.OfficeImageId = "ChartTypeAreaInsertGallery";
            ribbonDropDownItem3.ScreenTip = "DropDown Item";
            ribbonDropDownItem3.SuperTip = "Select DropDown Item to format the chart.";
            ribbonDropDownItem4.Label = "Pie";
            ribbonDropDownItem4.OfficeImageId = "ChartTypePieInsertGallery";
            ribbonDropDownItem4.ScreenTip = "DropDown Item";
            ribbonDropDownItem4.SuperTip = "Select DropDown Item to format the chart.";
            this.ddFormatChart.Items.Add(ribbonDropDownItem1);
            this.ddFormatChart.Items.Add(ribbonDropDownItem2);
            this.ddFormatChart.Items.Add(ribbonDropDownItem3);
            this.ddFormatChart.Items.Add(ribbonDropDownItem4);
            this.ddFormatChart.Label = "Format Chart";
            this.ddFormatChart.Name = "ddFormatChart";
            this.ddFormatChart.ScreenTip = "Drop Down";
            this.ddFormatChart.SuperTip = "A drop down list of options.  Select a chart type to format the chart on Sheet1.";
            this.ddFormatChart.SelectionChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ddFormatChart_SelectionChanged);
            // 
            // cbMRUFind
            // 
            ribbonDropDownItem5.Label = "Q1";
            ribbonDropDownItem6.Label = "Q2";
            ribbonDropDownItem7.Label = "Q3";
            ribbonDropDownItem8.Label = "Q4";
            this.cbMRUFind.Items.Add(ribbonDropDownItem5);
            this.cbMRUFind.Items.Add(ribbonDropDownItem6);
            this.cbMRUFind.Items.Add(ribbonDropDownItem7);
            this.cbMRUFind.Items.Add(ribbonDropDownItem8);
            this.cbMRUFind.Label = "MRU Find";
            this.cbMRUFind.Name = "cbMRUFind";
            this.cbMRUFind.ScreenTip = "Combo Box";
            this.cbMRUFind.SizeString = "Enter or select search text.";
            this.cbMRUFind.SuperTip = "ComboBox is a EditBox with a DropDown.  Select text from the list to find it in t" +
                "he spreadsheet.  Or, enter your own search string to add to the list.";
            this.cbMRUFind.Text = "Enter or select search text.";
            this.cbMRUFind.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.cbMRUFind_TextChanged);
            // 
            // galShapes
            // 
            this.galShapes.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.galShapes.Image = global::RibbonControlsExcelWorkbook.Properties.Resources.AvocadoGreen;
            this.galShapes.Label = "Color";
            this.galShapes.Name = "galShapes";
            this.galShapes.ScreenTip = "Gallery";
            this.galShapes.ShowImage = true;
            this.galShapes.SuperTip = "A gallery is a multi-dimensional dropdown.  This gallery will format insert a dif" +
                "ferent colored sphere on to Sheet1.";
            this.galShapes.ItemsLoading += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.galShapes_ItemsLoading);
            this.galShapes.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.galShapes_Click);
            // 
            // gDynamicMenu
            // 
            this.gDynamicMenu.Items.Add(this.mDynamicMenu);
            this.gDynamicMenu.Items.Add(this.cbButton);
            this.gDynamicMenu.Items.Add(this.cbSeparator);
            this.gDynamicMenu.Items.Add(this.cbSubMenu);
            this.gDynamicMenu.Label = "Build Dynamic Menu";
            this.gDynamicMenu.Name = "gDynamicMenu";
            // 
            // mDynamicMenu
            // 
            this.mDynamicMenu.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.mDynamicMenu.Dynamic = true;
            this.mDynamicMenu.Label = "Dynamic Menu";
            this.mDynamicMenu.Name = "mDynamicMenu";
            this.mDynamicMenu.OfficeImageId = "QueryAppend";
            this.mDynamicMenu.ScreenTip = "Dynamic Menu";
            this.mDynamicMenu.ShowImage = true;
            this.mDynamicMenu.SuperTip = "This is a dynamic menu.  Use the checkboxes at the right to determine which contr" +
                "ols to add at runtime.";
            this.mDynamicMenu.ItemsLoading += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.mDynamicMenu_ItemsLoading);
            // 
            // cbButton
            // 
            this.cbButton.Label = "Button";
            this.cbButton.Name = "cbButton";
            this.cbButton.ScreenTip = "Check Box";
            this.cbButton.SuperTip = "Select to add control to Dynamic Menu.";
            // 
            // cbSeparator
            // 
            this.cbSeparator.Label = "Separator";
            this.cbSeparator.Name = "cbSeparator";
            this.cbSeparator.ScreenTip = "Check Box";
            this.cbSeparator.SuperTip = "Select to add control to Dynamic Menu.";
            // 
            // cbSubMenu
            // 
            this.cbSubMenu.Label = "SubMenu";
            this.cbSubMenu.Name = "cbSubMenu";
            this.cbSubMenu.ScreenTip = "Check Box";
            this.cbSubMenu.SuperTip = "Select to add control to Dynamic Menu.";
            // 
            // RibbonControls
            // 
            this.Name = "RibbonControls";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.StartFromScratch = true;
            this.Tabs.Add(this.tControls);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonControls_Load);
            this.tControls.ResumeLayout(false);
            this.tControls.PerformLayout();
            this.gButtons.ResumeLayout(false);
            this.gButtons.PerformLayout();
            this.bgMoodFace.ResumeLayout(false);
            this.bgMoodFace.PerformLayout();
            this.gDynamicMenu.ResumeLayout(false);
            this.gDynamicMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tControls;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup gButtons;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton btnActionsPane;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup bgMoodFace;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton btnHappy;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton btnNeutral;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton btnSad;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton sbtnAlign;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnLeft;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCenter;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRight;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown ddFormatChart;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox cbMRUFind;
        internal Microsoft.Office.Tools.Ribbon.RibbonGallery galShapes;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup gDynamicMenu;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu mDynamicMenu;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox cbButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox cbSeparator;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox cbSubMenu;
    }

    partial class ThisRibbonCollection : Microsoft.Office.Tools.Ribbon.RibbonReadOnlyCollection
    {
        internal RibbonControls RibbonControls
        {
            get { return this.GetRibbon<RibbonControls>(); }
        }
    }
}
