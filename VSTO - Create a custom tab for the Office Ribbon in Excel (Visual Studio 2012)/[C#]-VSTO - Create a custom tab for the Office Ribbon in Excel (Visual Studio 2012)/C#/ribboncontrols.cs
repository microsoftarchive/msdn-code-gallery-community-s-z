// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;


namespace RibbonControlsExcelWorkbook
{
    public partial class RibbonControls : RibbonBase
    {
        ActionsPaneControl1 AP1 = new ActionsPaneControl1();

        public RibbonControls()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        // Load event fires when the Ribbon loads
        // Actions Pane is added to the project but remains hidden until the user chooses to show it
        private void RibbonControls_Load(object sender, RibbonUIEventArgs e)
        {
            Globals.ThisWorkbook.ActionsPane.Controls.Add(AP1);
            AP1.Hide();
            Globals.ThisWorkbook.Application.DisplayDocumentActionTaskPane = false;
        }

        // ToggleButton click event shows/hides the Actions Pane
        private void btnActionsPane_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisWorkbook.Application.DisplayDocumentActionTaskPane = btnActionsPane.Checked;
            AP1.Visible = btnActionsPane.Checked;
        }

        private void btnHappy_Click(object sender, RibbonControlEventArgs e)
        {
            if (btnHappy.Checked)
            {
                ChangeFace("J");
                btnNeutral.Checked = false;
                btnSad.Checked = false;
            }
            else
            {
                ChangeFace("");
            }
        }

        private void btnNeutral_Click(object sender, RibbonControlEventArgs e)
        {
            if (btnNeutral.Checked)
            {
                ChangeFace("K");
                btnHappy.Checked = false;
                btnSad.Checked = false;
            }
            else
            {
                ChangeFace("");
            }
        }

        private void btnSad_Click(object sender, RibbonControlEventArgs e)
        {
            if (btnSad.Checked)
            {
                ChangeFace("L");
                btnHappy.Checked = false;
                btnNeutral.Checked = false;
            }
            else
            {
                ChangeFace("");
            }
        }

        private void ChangeFace(string faceLetter)
        {
            var xlCell = Globals.Sheet1.Range["A1", "A1"];
            xlCell.FormulaR1C1 = faceLetter;
            xlCell.Font.Name = "Wingdings";
            xlCell.Font.FontStyle = "Regular";
            xlCell.Font.Size = 24;
            xlCell.Font.Color = -16776361;
            xlCell.Select();
        }

        private void btnLeft_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Range xlcell;

            xlcell = Globals.Sheet1.Range["A3", "A3"];
            xlcell.Value2 = "Left";
            xlcell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
            xlcell.Select();
        }

        private void btnCenter_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Range xlcell;

            xlcell = Globals.Sheet1.Range["A3", "A3"];
            xlcell.Value2 = "Center";
            xlcell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            xlcell.Select();
        }

        private void btnRight_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Range xlcell;

            xlcell = Globals.Sheet1.Range["A3", "A3"];
            xlcell.Value2 = "Right";
            xlcell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
            xlcell.Select();
        }

        private void sbtnAlign_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Range xlcell;

            xlcell = Globals.Sheet1.Range["A3", "A3"];
            xlcell.Value2 = "Center";
            xlcell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            xlcell.Select();
        }

        // The drop down select changed event fires when the user selects an item
        // from the drop down.  
        private void ddFormatChart_SelectionChanged(object sender, RibbonControlEventArgs e)
        {
            var xlChart = (Microsoft.Office.Tools.Excel.Chart)Globals.Sheet1.Controls["Chart_1"];

            switch (ddFormatChart.SelectedItem.Label)
            {
                case "Bar":
                    xlChart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xl3DBarClustered;
                    break;
                case "Column":
                    xlChart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xl3DColumnClustered;
                    break;
                case "Area":
                    xlChart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xl3DArea;
                    break;
                case "Pie":
                    xlChart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xl3DPie;
                    break;
            }
        }

        // The Text Changed event fires when the user selects an item 
        // from the combo box drop down or enters a new item in the edit box.  The event handler
        // does two things.  First, it performs a Find on the sheet for the text string.
        // Next, it looks to see if the string exists in the combo box drop down.  If it 
        // does not, the string will be added to the list.
        private void cbMRUFind_TextChanged(object sender, RibbonControlEventArgs e)
        {
            var xlcell = Globals.ThisWorkbook.Application.Cells.Find(cbMRUFind.Text, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext, Type.Missing, Type.Missing, Type.Missing);
            if (xlcell == null)
            {
                System.Windows.Forms.MessageBox.Show("Text Not Found");
            }
            else
            {
                xlcell.Select();
                System.Windows.Forms.MessageBox.Show("Search text: " + cbMRUFind.Text + " found in cell "
                    + xlcell.get_Address(Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString());
            }

            bool newSearchText = true;
            foreach (RibbonDropDownItem ddI in cbMRUFind.Items)
            {
                if (cbMRUFind.Text == ddI.Label)
                {
                    newSearchText = false;
                }
            }
            if (newSearchText)
            {
                var item = makeRibbonDropDownItem(cbMRUFind.Text, null);
                cbMRUFind.Items.Add(item);
                System.Windows.Forms.MessageBox.Show("New item: " + item.Label + " added to ComboBox");
            }
        }

        private RibbonDropDownItem makeRibbonDropDownItem(string Label, System.Drawing.Image Image)
        {
            RibbonDropDownItem tmp = this.Factory.CreateRibbonDropDownItem();
            tmp.Label = Label;
            tmp.Image = Image;
            return tmp;
        }

        //  The gallery items loading event fires each time the user clicks 
        //  the gallery drop down.  This allows for the gallery items to be loaded
        //  dynamically at runtime.
        private void galShapes_ItemsLoading(object sender, RibbonControlEventArgs e)
        {
            if (galShapes.Items.Count == 0)
            {
                var galleryItems = galShapes.Items;
                galleryItems.Add(makeRibbonDropDownItem("Avocado", Properties.Resources.AvocadoGreen));
                galleryItems.Add(makeRibbonDropDownItem("Berry", Properties.Resources.Berry));
                galleryItems.Add(makeRibbonDropDownItem("BurntRed", Properties.Resources.BurntRed));
                galleryItems.Add(makeRibbonDropDownItem("Gold", Properties.Resources.Gold));
                galleryItems.Add(makeRibbonDropDownItem("Gray", Properties.Resources.Gray));
                galleryItems.Add(makeRibbonDropDownItem("Green", Properties.Resources.Green));
                galleryItems.Add(makeRibbonDropDownItem("Orange", Properties.Resources.Orange));
                galleryItems.Add(makeRibbonDropDownItem("Purple", Properties.Resources.Purple));
                galleryItems.Add(makeRibbonDropDownItem("Red", Properties.Resources.Red));
                galleryItems.Add(makeRibbonDropDownItem("Sapphire", Properties.Resources.Sapphire));
                galleryItems.Add(makeRibbonDropDownItem("SkyBlue", Properties.Resources.SkyBlue));
                galleryItems.Add(makeRibbonDropDownItem("Teal", Properties.Resources.Teal));
                galleryItems.Add(makeRibbonDropDownItem("Turquiose", Properties.Resources.Turquoise));
                galleryItems.Add(makeRibbonDropDownItem("Violet", Properties.Resources.Violet));
            }
        }

        // The gallery click event fires when the user selects a gallery item
        private void galShapes_Click(object sender, RibbonControlEventArgs e)
        {
            galShapes.Image = galShapes.SelectedItem.Image;

            var oldShape = Globals.Sheet1.Shapes.Item("Picture 1");

            string tempImageName = System.IO.Path.GetTempFileName();
            galShapes.SelectedItem.Image.Save(tempImageName);

            var newShape = Globals.Sheet1.Shapes.AddPicture(tempImageName,
                Microsoft.Office.Core.MsoTriState.msoFalse,
                Microsoft.Office.Core.MsoTriState.msoTrue,
                oldShape.Left, oldShape.Top, oldShape.Width, oldShape.Height);

            oldShape.Delete();
            newShape.Name = "Picture 1";
        }

        // The menu items loading event fires when a menu has the dynamic property 
        // set to true and the user clicks on the menu drop down.  This allows menu
        // items to be added dynamically at run time.
        private void mDynamicMenu_ItemsLoading(object sender, RibbonControlEventArgs e)
        {
            mDynamicMenu.Items.Clear();

            if (cbButton.Checked)
            {
                RibbonButton tmp = this.Factory.CreateRibbonButton();
                tmp.Label = "Button";
                mDynamicMenu.Items.Add(tmp);
            }

            if (cbSeparator.Checked)
            {
                RibbonSeparator tmp = this.Factory.CreateRibbonSeparator();
                tmp.Title = "Menu Separator";
                mDynamicMenu.Items.Add(tmp);
            }

            if (cbSubMenu.Checked)
            {
                RibbonButton subButton = this.Factory.CreateRibbonButton();
                subButton.Label = "SubMenu Button";
                subButton.OfficeImageId = "_3DMaterialMetal";
                subButton.Description = "Large Button in a Sub Menu";

                RibbonMenu mSubMenu = this.Factory.CreateRibbonMenu();
                mSubMenu.ItemSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
                mSubMenu.Label = "Sub Menu";

                mSubMenu.Items.Add(subButton);
                mDynamicMenu.Items.Add(mSubMenu);
            }
        }
    }
}
