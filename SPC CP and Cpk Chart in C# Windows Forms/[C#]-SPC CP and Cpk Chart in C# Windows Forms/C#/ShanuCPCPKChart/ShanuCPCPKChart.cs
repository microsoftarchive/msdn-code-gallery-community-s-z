using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

using System.Globalization;
using System.Drawing.Drawing2D;

using System.Windows.Forms;
//Author  : Syed Shanu
//Date    : 2015-02-09
//Description : SPC CP,CPk CHART

namespace ShanuCPCPKChart
{
    public partial class ShanuCPCPKChart : UserControl
    {
        #region Members

        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.Panel OuterPanel;
        private System.ComponentModel.Container components = null;
        private string m_sPicName = "";
        ContextMenuStrip docmenu = new System.Windows.Forms.ContextMenuStrip();
        ToolStripMenuItem saveimg = new ToolStripMenuItem();



        public DataTable dt = new DataTable();

        Font f12 = new Font("arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
        Pen B1pen = new Pen(Color.Black, 1);
        Pen B2pen = new Pen(Color.Black, 2);
        Double XDoublkeBAR = 0;
        Double RBAR = 0;
        Double XBARUCL = 0;
        Double XBARLCL = 0;

        Double RANGEUCL = 0;
        Double RANGELCL = 0;
        Double[] intMeanArrayVals;
        Double[] intRangeArrayVals;
        Double[] intSTDEVArrayVals;
        Double[] intXBARArrayVals;

        int First_chartDatarectHeight = 80;
        Font f10 = new Font("arial", 10, FontStyle.Bold, GraphicsUnit.Pixel);
        LinearGradientBrush a2 = new LinearGradientBrush(new RectangleF(0, 0, 100, 19), Color.DarkGreen, Color.Green, LinearGradientMode.Horizontal);
        LinearGradientBrush a3 = new LinearGradientBrush(new RectangleF(0, 0, 100, 19), Color.DarkRed, Color.Red, LinearGradientMode.Horizontal);
        LinearGradientBrush a1 = new LinearGradientBrush(new RectangleF(0, 0, 100, 19), Color.Blue, Color.DarkBlue, LinearGradientMode.Horizontal);

        #endregion

        #region Constants

        private double ZOOMFACTOR = 1.25;	// = 25% smaller or larger
        private int MINMAX = 2;				// 5 times bigger or smaller than the ctrl

        #endregion

        #region Designer generated code

        private void InitializeComponent()
        {
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.OuterPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.OuterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicBox
            // 
            this.PicBox.BackColor = System.Drawing.Color.White;
            this.PicBox.Location = new System.Drawing.Point(0, 0);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(1100, 550);
            this.PicBox.TabIndex = 3;
            this.PicBox.TabStop = false;
            // 
            // OuterPanel
            // 
            this.OuterPanel.AutoScroll = true;
            this.OuterPanel.BackColor = System.Drawing.Color.White;
            this.OuterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OuterPanel.Controls.Add(this.PicBox);
            this.OuterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterPanel.Location = new System.Drawing.Point(0, 0);
            this.OuterPanel.Name = "OuterPanel";
            this.OuterPanel.Size = new System.Drawing.Size(1135, 560);
            this.OuterPanel.TabIndex = 4;
            // 
            // ShanuCPCPKChart
            // 
            this.Controls.Add(this.OuterPanel);
            this.Name = "ShanuCPCPKChart";
            this.Size = new System.Drawing.Size(1135, 560);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.OuterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructors


        public ShanuCPCPKChart()
        {
            InitializeComponent();
            InitCtrl();
        }
        #endregion

        #region Properties
        public void Bindgrid(DataTable dtnew)
        {
            if (dtnew != null)
            {
                dt = dtnew;
                PicBox.Refresh();
            }
        }

        public Double USLs = 0.000;
        public Double LSLs = 0.000;
        public Double CpkPpKAcceptanceValue = 1.33;

        public String ChartWaterMarkText = "Shanu SPC CHART";

        public String cpcpkChartWaterMarkText
        {
            get
            {
                return this.ChartWaterMarkText;
            }
            set
            {
                this.ChartWaterMarkText = value;
            }
        }
        public Double CokPpkValue
        {
            get
            {
                return this.CpkPpKAcceptanceValue;
            }
            set
            {
                this.CpkPpKAcceptanceValue = value;
            }
        }
      
        public Double USL
        {
            get
            {
                return this.USLs;
            }
            set
            {
                this.USLs = value;
            }
        }

        public Double LSL
        {
            get
            {
                return this.LSLs;
            }
            set
            {
                this.LSLs = value;
            }
        }

        #endregion


        #region Other Methods

        /// <summary>
        /// Special settings for the picturebox ctrl
        /// </summary>
        private void InitCtrl()
        {
            PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PicBox.Location = new Point(0, 0);
            OuterPanel.Dock = DockStyle.Fill;
            OuterPanel.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            OuterPanel.AutoScroll = true;
            //////OuterPanel.MouseEnter += new EventHandler(PicBox_MouseEnter);
            //////PicBox.MouseEnter += new EventHandler(PicBox_MouseEnter);
            //////OuterPanel.MouseWheel += new MouseEventHandler(PicBox_MouseWheel);
            PicBox.Paint += new PaintEventHandler(PicBox_Paint);
            PicBox.DoubleClick += new EventHandler(PicBox_DoubleClick);

            saveimg.Text = "SaveImage";
            docmenu.Items.AddRange(new ToolStripMenuItem[] { saveimg });

            docmenu.Click += new EventHandler(docmenu_Click);
            PicBox.ContextMenuStrip = docmenu;
        }

        private void PicBox_DoubleClick(object sender, EventArgs e)
        {
            saveImages();
        }

        private void docmenu_Click(object sender, EventArgs e)
        {
            saveImages();
        }

        public void saveImages()
        {
            if (dt.Rows.Count <= 0)
            {
                return;
            }

            using (var bitmap = new Bitmap(PicBox.Width, PicBox.Height))
            {
                PicBox.DrawToBitmap(bitmap, PicBox.ClientRectangle);


                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "*";
                dlg.DefaultExt = "bmp";
                dlg.ValidateNames = true;

                dlg.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    bitmap.Save(dlg.FileName);
                }



            }
        }
        #region Zooming Methods
        /// <summary>
        /// Pictuerbox Paint where we draw.
        /// </summary>
        /// <remarks>Maximum 5 times bigger</remarks>
        /// 
        public void PicBox_Paint(object sender, PaintEventArgs e)
        {



            if (dt.Rows.Count <= 0)
            {
                return;
            }

            int opacity = 68; // 50% opaque (0 = invisible, 255 = fully opaque)

            e.Graphics.DrawString(ChartWaterMarkText,
                new Font("Arial", 72),
                new SolidBrush(Color.FromArgb(opacity, Color.OrangeRed)),
                80,
                  PicBox.Height / 2 - 15);


            int NoofTrials = dt.Rows.Count;
            int NoofParts = dt.Columns.Count - 1;


            intMeanArrayVals = new Double[NoofParts];
            intRangeArrayVals = new Double[NoofParts];
            intSTDEVArrayVals = new Double[NoofParts];
            intXBARArrayVals = new Double[NoofParts];

            if (dt.Rows.Count <= 0)
            {
                return;
            }

            PicBox.Width = dt.Columns.Count * 50 + 40;


            // 1) For the Chart Data Display ---------
            e.Graphics.DrawRectangle(Pens.Black, 10, 10, PicBox.Width - 20, First_chartDatarectHeight + 78);

            // for the chart data Horizontal Line Display
            e.Graphics.DrawLine(B1pen, 10, 25, PicBox.Width - 10, 25);
            e.Graphics.DrawLine(B1pen, 10, 45, PicBox.Width - 10, 45);
            e.Graphics.DrawLine(B1pen, 10, 65, PicBox.Width - 10, 65);
            e.Graphics.DrawLine(B1pen, 10, 85, PicBox.Width - 10, 85);
            e.Graphics.DrawLine(B1pen, 10, 105, PicBox.Width - 10, 105);
            e.Graphics.DrawLine(B1pen, 10, 125, PicBox.Width - 10, 125);

            e.Graphics.DrawLine(B1pen, 10, 145, PicBox.Width - 10, 145);
            // e.Graphics.DrawLine(B1pen, 10, 165, PicBox.Width - 10, 165);

            // for the chart data Vertical Line Display
            e.Graphics.DrawLine(B1pen, 60, 10, 60, First_chartDatarectHeight + 87);
            e.Graphics.DrawLine(B1pen, 110, 10, 110, First_chartDatarectHeight + 87);

            //-------------

            // DrawItemEventArgs String

            e.Graphics.DrawString("SUM", f12, a1, 14, 10);

            e.Graphics.DrawString("MEAN", f12, a1, 14, 30);

            e.Graphics.DrawString("Range", f12, a1, 14, 50);

            e.Graphics.DrawString("Cp", f12, a1, 14, 70);
            e.Graphics.DrawString("Cpk", f12, a1, 14, 90);
            e.Graphics.DrawString("Pp", f12, a1, 14, 110);
            e.Graphics.DrawString("Ppk", f12, a1, 14, 130);



            // load data 
            //Outer Loop for Columns count
            int xLineposition = 110;
            int xStringDrawposition = 14;
            Double[] locStdevarr;
            for (int iCol = 1; iCol <= dt.Columns.Count - 1; iCol++)
            {
                //inner Loop for Rows count
                Double Sumresult = 0;
                Double Meanresult = 0;
                Double Rangeresult = 0;
                Double minRangeValue = int.MaxValue;
                Double maxRangeValue = int.MinValue;

                locStdevarr = new Double[NoofTrials];

                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    Sumresult = Sumresult + System.Convert.ToDouble(dt.Rows[iRow][iCol].ToString());
                    Double accountLevel = System.Convert.ToDouble(dt.Rows[iRow][iCol].ToString());
                    minRangeValue = Math.Min(minRangeValue, accountLevel);
                    maxRangeValue = Math.Max(maxRangeValue, accountLevel);
                    locStdevarr[iRow] = System.Convert.ToDouble(dt.Rows[iRow][iCol].ToString());
                }
                xLineposition = xLineposition + 50;
                xStringDrawposition = xStringDrawposition + 50;

                e.Graphics.DrawLine(B1pen, xLineposition, 10, xLineposition, First_chartDatarectHeight + 87);
                //Sum Data Display
                e.Graphics.DrawString(Math.Round(Sumresult, 3).ToString(), f10, a2, xStringDrawposition, 12);

                //MEAN Data Display
                Meanresult = Sumresult / NoofTrials;
                e.Graphics.DrawString(Math.Round(Meanresult, 3).ToString(), f10, a2, xStringDrawposition, 30);
                //RANGE Data Display
                Rangeresult = maxRangeValue - minRangeValue;
                e.Graphics.DrawString(Math.Round(Rangeresult, 3).ToString(), f10, a2, xStringDrawposition, 50);

                //XDoubleBar used to display in chart
                XDoublkeBAR = XDoublkeBAR + Meanresult;

                //RBAR used to display in chart
                RBAR = RBAR + Rangeresult;

                intMeanArrayVals[iCol - 1] = Meanresult;
                intRangeArrayVals[iCol - 1] = Rangeresult;
                intSTDEVArrayVals[iCol - 1] = StandardDeviation(locStdevarr);

            }



            //End 1 ) -------------------

            // 2) -------------------------- 
            // XdoubleBAr/RBAR/UCL and LCL Calculation.

            //XDoubleBar used to display in chart
            XDoublkeBAR = XDoublkeBAR / NoofParts;

            //RBAR used to display in chart
            RBAR = RBAR / NoofParts;

            //XBARUCL to display in chart
            XBARUCL = XDoublkeBAR + UCLLCLTYPE("A2", RBAR, NoofTrials);
            //XBARLCL to display in chart
            XBARLCL = XDoublkeBAR - UCLLCLTYPE("A2", RBAR, NoofTrials);

            //XBARUCL to display in chart
            RANGEUCL = UCLLCLTYPE("D4", RBAR, NoofTrials);

            //XBARLCL to display in chart
            RANGELCL = UCLLCLTYPE("D3", RBAR, NoofTrials);

            //2.1) Status Display inside pic grid +++++++++++++++++++++++++++

            int XCirclegDrawposition = 24;
            int YCirclegDrawposition = 147;

            xStringDrawposition = 14;
            for (int i = 0; i < intMeanArrayVals.Length; i++)
            {

                Color pointColor = new Color();
                pointColor = Color.YellowGreen;
                XCirclegDrawposition = XCirclegDrawposition + 50;
                Point p1 = new Point();
                p1.X = XCirclegDrawposition;
                p1.Y = YCirclegDrawposition;

                if (intMeanArrayVals[i] < XBARLCL)
                {
                    pointColor = Color.Red;
                }
                else if (intMeanArrayVals[i] > XBARUCL)
                {
                    pointColor = Color.Red;
                }

                Pen pen = new Pen(Color.SeaGreen);
                e.Graphics.DrawPie(pen, p1.X, p1.Y, 18, 18, 0, 360);
                e.Graphics.FillPie(new SolidBrush(pointColor), p1.X, p1.Y, 18, 18, 10, 360);

                pen = new Pen(Color.Black);
                e.Graphics.DrawPie(pen, p1.X + 3, p1.Y + 4, 2, 2, 10, 360);

                e.Graphics.DrawPie(pen, p1.X + 11, p1.Y + 4, 2, 2, 10, 360);

                e.Graphics.DrawPie(pen, p1.X + 5, p1.Y + 12, 8, 4, 10, 180);

                // 1)
                //Cp Calculation (((((((((((((((((((((((((((
                //Cp=(USL-LSL/6SIGMA) -> USL-LSL/6*RBAR/d2

                Double d2 = d2Return(NoofTrials);
                Double USLResult = USLs - LSLs;
                Double RBARS = intRangeArrayVals[i] / NoofTrials;
                Double Sigma = RBARS / d2;

                Double CpResult = USLResult / 6 * Sigma;

                xStringDrawposition = xStringDrawposition + 50;
                e.Graphics.DrawString(Math.Round(CpResult, 3).ToString(), f10, a2, xStringDrawposition, 70);

                //End Cp Calculation  ))))))))))))))



                // 2)
                //Cpk Calculation \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                //Cpk=min(USL-XBAR/3Sigma,LSL-XBAR/3Sigma)
                Double CpU = USLs - intMeanArrayVals[i] / 3 * Sigma;
                Double CpL = intMeanArrayVals[i] - LSLs / 3 * Sigma;
                Double CpkResult = Math.Min(CpU, CpL);


                if (CpkResult < CpkPpKAcceptanceValue)
                {
                    e.Graphics.DrawString(Math.Round(CpkResult, 3).ToString(), f10, a3, xStringDrawposition, 90);
                }
                else
                {
                    e.Graphics.DrawString(Math.Round(CpkResult, 3).ToString(), f10, a2, xStringDrawposition, 90);
                }



                //End Cpk Calculation  \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


                // 3)
                //Pp Calculation {{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{
                //Pp=(USL-LSL/6SIGMA) -> USL-LSL/6 STDEV

                Double PpResult = USLResult / 6 * intSTDEVArrayVals[i];

                e.Graphics.DrawString(Math.Round(PpResult, 3).ToString(), f10, a2, xStringDrawposition, 110);

                //End Pp Calculation  }}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}


                // 4)
                //PpK Calculation ``````````````````````````````````````````````````````
                //PpK=min(USL-XBAR/3STDEV,LSL-XBAR/3STDEVa)
                Double PpU = USLs - intMeanArrayVals[i] / 3 * intSTDEVArrayVals[i];
                Double PpL = intMeanArrayVals[i] - LSLs / 3 * intSTDEVArrayVals[i];
                Double PpkResult = Math.Min(PpU, PpL);
                if (PpkResult < CpkPpKAcceptanceValue)
                {
                    e.Graphics.DrawString(Math.Round(PpkResult, 3).ToString(), f10, a3, xStringDrawposition, 130);
                }
                else
                {
                    e.Graphics.DrawString(Math.Round(PpkResult, 3).ToString(), f10, a2, xStringDrawposition, 130);
                }

                // end of Ppk `````````````````````````````````````````````````````````````
            }

            //end of 2.1) ++++++++++++++++

            //---------------------------------

            //3) Average chart Display ---------------
            //  e.Graphics.DrawRectangle(Pens.Black, 10, 10, picSpcChart.Width - 20, First_chartDatarectHeight);
            int chartAvarageDatarectHeight = 18;

            e.Graphics.DrawRectangle(Pens.Black, 10, First_chartDatarectHeight + 96, PicBox.Width - 20, chartAvarageDatarectHeight);

            e.Graphics.DrawLine(B2pen, 476, 194, 480, 176);
            e.Graphics.DrawString("MEAN CHART", f12, a1, 14, First_chartDatarectHeight + 98);

            e.Graphics.DrawString("XBarS:", f12, a1, 160, First_chartDatarectHeight + 98);
            e.Graphics.DrawString(Math.Round(XDoublkeBAR, 3).ToString(), f12, a2, 202, First_chartDatarectHeight + 98);

            e.Graphics.DrawString("UCL:", f12, a1, 300, First_chartDatarectHeight + 98);
            e.Graphics.DrawString(Math.Round(XBARUCL, 3).ToString(), f12, a2, 330, First_chartDatarectHeight + 98);

            e.Graphics.DrawString("LCL:", f12, a1, 400, First_chartDatarectHeight + 98);
            e.Graphics.DrawString(Math.Round(XBARLCL, 3).ToString(), f12, a2, 430, First_chartDatarectHeight + 98);

            e.Graphics.DrawString("RANGE CHART", f12, a1, 490, First_chartDatarectHeight + 98);


            e.Graphics.DrawString("RBar : ", f12, a1, 600, First_chartDatarectHeight + 98);
            e.Graphics.DrawString(Math.Round(RBAR, 3).ToString(), f12, a2, 638, First_chartDatarectHeight + 98);

            e.Graphics.DrawString("UCL : ", f12, a1, 700, First_chartDatarectHeight + 98);
            e.Graphics.DrawString(Math.Round(RANGEUCL, 3).ToString(), f12, a2, 734, First_chartDatarectHeight + 98);

            e.Graphics.DrawString("LCL : ", f12, a1, 800, First_chartDatarectHeight + 98);
            e.Graphics.DrawString(Math.Round(RANGELCL, 3).ToString(), f12, a2, 834, First_chartDatarectHeight + 98);

            // vertical Line
            e.Graphics.DrawLine(B2pen, 860, 194, 866, 176);

            e.Graphics.DrawString("USL : ", f12, a1, 880, First_chartDatarectHeight + 98);
            e.Graphics.DrawString(Math.Round(USLs, 3).ToString(), f12, a2, 910, First_chartDatarectHeight + 98);

            e.Graphics.DrawString("LSL : ", f12, a1, 960, First_chartDatarectHeight + 98);
            e.Graphics.DrawString(Math.Round(LSLs, 3).ToString(), f12, a2, 990, First_chartDatarectHeight + 98);

            //Mean Line Chart

            DrawLineChart(e.Graphics, intMeanArrayVals, XBARUCL, XBARLCL, PicBox.Width - 70, 154, 60, 170, "MEAN", XDoublkeBAR);

            DrawLineChart(e.Graphics, intRangeArrayVals, RANGEUCL, RANGELCL, PicBox.Width - 70, 154, 60, 340, "RANGE", RBAR);

            //End 3)---------------------

        }

        private void DrawLineChart(Graphics e, Double[] alWeight, Double UCLs, Double LCLs, int lengthArea, int heightArea, int topX, int topY, String ChartType, double XRBARVALUE)
        {
            int numberOfSections = alWeight.Length;
            // int lengthArea = picSpcChart.Width-40;
            // int heightArea = 184;
            //int topX = 64;
            //int topY = 160;
            Double maxWeight = MaxValue(alWeight);
            Double minWeight = MinValue(alWeight);
            int[] height = new int[numberOfSections];
            Double total = SumOfArray(alWeight);
            Random rnd = new Random();
            SolidBrush brush = new SolidBrush(Color.Aquamarine);
            Pen pen = new Pen(Color.Gray);

            topY = topY + 40;

            Rectangle rec1 = new Rectangle(topX - 40, topY-10, 40, heightArea - 10);
            e.DrawRectangle(pen, rec1);

            Font f22 = new Font("arial", 26, FontStyle.Bold, GraphicsUnit.Pixel);

            LinearGradientBrush a3 = new LinearGradientBrush(new RectangleF(0, 0, 100, 19), Color.DarkBlue, Color.RoyalBlue, LinearGradientMode.Horizontal);

            if (ChartType == "MEAN")
            {
                e.DrawString("M", f22, a3, topX - 35, topY + 16);

                e.DrawString("E", f22, a3, topX - 35, topY + 46);

                e.DrawString("A", f22, a3, topX - 35, topY + 72);

                e.DrawString("N", f22, a3, topX - 35, topY + 100);

            }
            else if (ChartType == "RANGE")
            {
                e.DrawString("R", f22, a3, topX - 35, topY-6 );

                e.DrawString("A", f22, a3, topX - 35, topY + 22);

                e.DrawString("N", f22, a3, topX - 35, topY + 50);

                e.DrawString("G", f22, a3, topX - 35, topY + 78);

                e.DrawString("E", f22, a3, topX - 35, topY + 104);
            }

            Rectangle rec = new Rectangle(topX, topY, lengthArea, heightArea - 10);
            //   e.DrawRectangle(pen, rec);
            pen.Color = Color.Black;
            int smallX = topX;
            int smallY = 0;
            int smallLength = (lengthArea / (alWeight.Length + 1));

            Double smallHeight = 0;

            Point p1 = new Point();
            Point p2 = new Point();
            smallLength = smallLength + 15;
            topX = topX + 10;
            topY = topY + 14;

            // USLLSL Line ------------------------
            Point pU1 = new Point();
            Point pU2 = new Point();
            Double smallHeight_USL = 0;
            Font f8 = new Font("arial", 10, FontStyle.Bold, GraphicsUnit.Pixel);

            LinearGradientBrush a4 = new LinearGradientBrush(new RectangleF(0, 0, 100, 19), Color.Red, Color.OrangeRed, LinearGradientMode.Horizontal);

            pU1.X = topX;
            pU1.Y = topY;
            pU2.X = topX;
            if (LCLs <= 0)
            {
                LCLs = 0.1;
            }
            //pY2.Y = Convert.ToInt32((UCLs * heightArea) / LCLs);

            //if (ChartType == "MEAN")
            //{
            //    smallHeight_USL = Convert.ToInt32((LCLs * heightArea) / UCLs) + 10;
            //}
            //else
            //{
            //    smallHeight_USL = Convert.ToInt32((LCLs * heightArea) / UCLs) ;
            //}

            smallHeight_USL = Convert.ToInt32((LCLs * heightArea) / UCLs);
            int topY_new = topY - 10;

            smallHeight_USL = topY_new + heightArea - Convert.ToInt32(smallHeight_USL);
            pU2.Y = Convert.ToInt32(smallHeight_USL);

            //For LCL
            String LCLstr = "0.0";
            e.DrawLine(pen, pU1.X, Convert.ToInt32(smallHeight_USL), Convert.ToInt32(lengthArea), Convert.ToInt32(smallHeight_USL));
            if ((Math.Round(LCLs, 3)).ToString() == "0.1")
            {
                LCLstr = "LCL: 0.0";
            }
            else
            {
                LCLstr = "LCL: " + (Math.Round(LCLs, 3)).ToString();
            }
            e.DrawString(LCLstr, f8, a4, Convert.ToInt32(lengthArea), Convert.ToInt32(smallHeight_USL - 10));


            //For UCL
            e.DrawLine(pen, pU1.X, topY_new - 10, Convert.ToInt32(lengthArea + 6), topY_new - 10);
            e.DrawString("UCL: " + (Math.Round(UCLs, 3)).ToString(), f8, a4, Convert.ToInt32(lengthArea), topY_new - 10);

            //for Middle Line
            e.DrawLine(pen, pU1.X, ((Convert.ToInt32(smallHeight_USL) + topY_new) / 2) - 14, Convert.ToInt32(lengthArea), ((Convert.ToInt32(smallHeight_USL) + topY_new) / 2) - 14);

            a4 = new LinearGradientBrush(new RectangleF(0, 0, 100, 19), Color.DarkBlue, Color.CornflowerBlue, LinearGradientMode.Horizontal);
            String XRBAR = "XBAR";
            if (ChartType == "MEAN")
            {
                XRBAR = "XBAR: " + (Math.Round(XRBARVALUE, 3)).ToString();
            }
            else
            {
                XRBAR = "RBAR: " + (Math.Round(XRBARVALUE, 3)).ToString();
            }

            e.DrawString(XRBAR, f8, a4, Convert.ToInt32(lengthArea - 6), ((Convert.ToInt32(smallHeight_USL) + topY_new) / 2));


            //For the Vertical Line Display at starting 
            e.DrawLine(pen, pU1.X, topY_new - 10, pU1.X, Convert.ToInt32(smallHeight_USL));

            //-------------------------

            for (int i = 0; i < numberOfSections; i++)
            {
                brush.Color = Color.FromArgb(rnd.Next(200, 255), rnd.Next(255),
             rnd.Next(255), rnd.Next(255));
                p1 = p2;

                if (i == 0)
                {
                    p2.X = p2.X + smallLength + 40;
                }
                else
                {
                    p2.X = p2.X + smallLength;
                }

                smallHeight = ((alWeight[i] * heightArea) / maxWeight);
                p2.Y = topY + heightArea - Convert.ToInt32(smallHeight);
                if (p1.X != 0 && p1.Y != 0)
                {
                    e.DrawLine(pen, p1, p2);

                }
                Color pointColor = new Color();
                pointColor = Color.Green;

                if (alWeight[i] < LCLs)
                {
                    pointColor = Color.Red;
                }
                else if (alWeight[i] > UCLs)
                {
                    pointColor = Color.Red;
                }

                ////if (LCLs <= alWeight[i] && alWeight[i] <= UCLs)
                ////{
                ////    pointColor = Color.Green;
                ////}
                ////else
                ////{

                ////    pointColor = Color.Red;
                ////}
                DrawDots(e, p2, pointColor);
                if (i == 0)
                {
                    smallLength = smallLength - 15;
                }
                smallX = smallX + smallLength;
            }
        }


        //Code for Drawing Dots

        private void DrawDots(Graphics e, Point p1, Color c1)
        {
            Pen pen = new Pen(Color.SeaGreen);
            e.DrawPie(pen, p1.X - 5, p1.Y - 5, 10, 10, 0, 360);
            e.FillPie(new SolidBrush(c1), p1.X - 5, p1.Y - 5, 10, 10, 0, 360);
        }


        //Code for Calculating Max and min Value and Sum of Array
        private static Double MinValue(Double[] intArray)
        {
            Double minVal = intArray[0];
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] < minVal)
                    minVal = intArray[i];
            }
            return minVal;
        }

        private static Double MaxValue(Double[] intArray)
        {
            Double maxVal = intArray[0];
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] > maxVal)
                    maxVal = intArray[i];
            }
            return maxVal;
        }


        private static Double SumOfArray(Double[] intArray)
        {
            Double sum = 0;
            for (int i = 0; i < intArray.Length; i++)
            {

                sum += intArray[i];
            }
            return sum;
        }
        private static double StandardDeviation(double[] data)
        {

            double ret = 0;
            double DataAverage = 0;
            double TotalVariance = 0;
            int Max = 0;

            try
            {

                Max = data.Length;

                if (Max == 0) { return ret; }

                DataAverage = Average(data);

                for (int i = 0; i < Max; i++)
                {
                    TotalVariance += Math.Pow(data[i] - DataAverage, 2);
                }

                ret = Math.Sqrt(SafeDivide(TotalVariance, Max));

            }
            catch (Exception) { throw; }
            return ret;
        }

        private static double Average(double[] data)
        {

            double ret = 0;
            double DataTotal = 0;

            try
            {

                for (int i = 0; i < data.Length; i++)
                {
                    DataTotal += data[i];
                }

                return SafeDivide(DataTotal, data.Length);

            }
            catch (Exception) { throw; }
            return ret;
        }

        private static double SafeDivide(double value1, double value2)
        {

            double ret = 0;

            try
            {

                if ((value1 == 0) || (value2 == 0)) { return ret; }

                ret = value1 / value2;

            }
            catch { }
            return ret;
        }
        public Double d2Return(int NoofTrials)
        {
            Double d2val = 0;

            switch (NoofTrials)
            {
                case 2:
                    d2val = 1.128;
                    break;
                case 3:
                    d2val = 1.693;
                    break;
                case 4:
                    d2val = 2.059;
                    break;
                case 5:
                    d2val = 2.326;
                    break;
                case 6:
                    d2val = 2.534;
                    break;
                case 7:
                    d2val = 2.704;
                    break;
                case 8:
                    d2val = 2.847;
                    break;
                case 9:
                    d2val = 2.970;
                    break;
                case 10:
                    d2val = 3.078;
                    break;
                case 11:
                    d2val = 3.173;
                    break;
                case 12:
                    d2val = 3.258;
                    break;
                case 13:
                    d2val = 3.336;
                    break;
                case 14:
                    d2val = 3.407;
                    break;
                case 15:
                    d2val = 3.472;
                    break;
                case 16:
                    d2val = 3.532;
                    break;
                case 17:
                    d2val = 3.588;
                    break;
                case 18:
                    d2val = 3.640;
                    break;
                case 19:
                    d2val = 3.689;
                    break;
                case 20:
                    d2val = 3.735;
                    break;

                case 21:
                    d2val = 3.778;
                    break;
                case 22:
                    d2val = 3.819;
                    break;
                case 23:
                    d2val = 3.858;
                    break;
                case 24:
                    d2val = 3.895;
                    break;
                case 25:
                    d2val = 3.931;
                    break;


            }
            return d2val;
        }

        public double UCLLCLTYPE(String ControlUCLLCLType, Double RBAR, int NoofTrials)
        {
            Double Result = 0;
            Double A2Val = 0;
            Double D3val = 0;
            Double D4val = 0;

            //Constant value for the UCL and LCL calculation.
            if (ControlUCLLCLType == "A2")
            {
                switch (NoofTrials)
                {
                    case 2:
                        A2Val = 1.880;
                        break;
                    case 3:
                        A2Val = 1.023;
                        break;
                    case 4:
                        A2Val = 0.729;
                        break;
                    case 5:
                        A2Val = 0.577;
                        break;
                    case 6:
                        A2Val = 0.483;
                        break;
                    case 7:
                        A2Val = 0.419;
                        break;
                    case 8:
                        A2Val = 0.373;
                        break;
                    case 9:
                        A2Val = 0.337;
                        break;
                    case 10:
                        A2Val = 0.308;
                        break;
                    case 11:
                        A2Val = 0.285;
                        break;
                    case 12:
                        A2Val = 0.266;
                        break;
                    case 13:
                        A2Val = 0.249;
                        break;
                    case 14:
                        A2Val = 0.235;
                        break;
                    case 15:
                        A2Val = 0.223;
                        break;
                    case 16:
                        A2Val = 0.212;
                        break;
                    case 17:
                        A2Val = 0.203;
                        break;
                    case 18:
                        A2Val = 0.194;
                        break;
                    case 19:
                        A2Val = 0.187;
                        break;
                    case 20:
                        A2Val = 0.180;
                        break;

                    case 21:
                        A2Val = 0.173;
                        break;
                    case 22:
                        A2Val = 0.167;
                        break;
                    case 23:
                        A2Val = 0.162;
                        break;
                    case 24:
                        A2Val = 0.157;
                        break;
                    case 25:
                        A2Val = 0.153;
                        break;


                }
                Result = A2Val * RBAR;
            }
            else if (ControlUCLLCLType == "D3")
            {
                switch (NoofTrials)
                {
                    case 2:
                        D3val = 0;
                        break;
                    case 3:
                        D3val = 0;
                        break;
                    case 4:
                        D3val = 0;
                        break;
                    case 5:
                        D3val = 0;
                        break;
                    case 6:
                        D3val = 0;
                        break;
                    case 7:
                        D3val = 0.076;
                        break;
                    case 8:
                        D3val = 0.136;
                        break;
                    case 9:
                        D3val = 0.184;
                        break;
                    case 10:
                        D3val = 0.223;
                        break;
                    case 11:
                        D3val = 0.256;
                        break;
                    case 12:
                        D3val = 0.283;
                        break;
                    case 13:
                        D3val = 0.307;
                        break;
                    case 14:
                        D3val = 0.328;
                        break;
                    case 15:
                        D3val = 0.347;
                        break;
                    case 16:
                        D3val = 0.363;
                        break;
                    case 17:
                        D3val = 0.378;
                        break;
                    case 18:
                        D3val = 0.391;
                        break;
                    case 19:
                        D3val = 0.403;
                        break;
                    case 20:
                        D3val = 0.415;
                        break;

                    case 21:
                        D3val = 0.425;
                        break;
                    case 22:
                        D3val = 0.434;
                        break;
                    case 23:
                        D3val = 0.443;
                        break;
                    case 24:
                        D3val = 0.451;
                        break;
                    case 25:
                        D3val = 0.459;
                        break;


                }
                Result = D3val * RBAR;

            }
            else if (ControlUCLLCLType == "D4")
            {
                switch (NoofTrials)
                {
                    case 2:
                        D4val = 3.268;
                        break;
                    case 3:
                        D4val = 2.574;
                        break;
                    case 4:
                        D4val = 2.282;
                        break;
                    case 5:
                        D4val = 2.114;
                        break;
                    case 6:
                        D4val = 2.004;
                        break;
                    case 7:
                        D4val = 1.924;
                        break;
                    case 8:
                        D4val = 1.864;
                        break;
                    case 9:
                        D4val = 1.816;
                        break;
                    case 10:
                        D4val = 1.777;
                        break;
                    case 11:
                        D4val = 1.744;
                        break;
                    case 12:
                        D4val = 1.717;
                        break;
                    case 13:
                        D4val = 1.693;
                        break;
                    case 14:
                        D4val = 1.672;
                        break;
                    case 15:
                        D4val = 1.653;
                        break;
                    case 16:
                        D4val = 1.637;
                        break;
                    case 17:
                        D4val = 1.622;
                        break;
                    case 18:
                        D4val = 1.608;
                        break;
                    case 19:
                        D4val = 1.597;
                        break;
                    case 20:
                        D4val = 1.585;
                        break;

                    case 21:
                        D4val = 1.575;
                        break;
                    case 22:
                        D4val = 1.566;
                        break;
                    case 23:
                        D4val = 1.557;
                        break;
                    case 24:
                        D4val = 1.548;
                        break;
                    case 25:
                        D4val = 1.541;
                        break;


                }
                Result = D4val * RBAR;

            }


            return Result;
        }
        #endregion

        //End of Pic Box Painting of Chart


        /////// <summary>
        /////// Create a simple red cross as a bitmap and display it in the picturebox
        /////// </summary>
        ////private void RedCross()
        ////{
        ////    Bitmap bmp = new Bitmap(OuterPanel.Width, OuterPanel.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
        ////    Graphics gr;
        ////    gr = Graphics.FromImage(bmp);
        ////    Pen pencil = new Pen(Color.Red, 5);
        ////    gr.DrawLine(pencil, 0, 0, OuterPanel.Width, OuterPanel.Height);
        ////    gr.DrawLine(pencil, 0, OuterPanel.Height, OuterPanel.Width, 0);
        ////    PicBox.Image = bmp;
        ////    gr.Dispose();
        ////}

        #endregion

        #region Zooming Methods

        /// <summary>
        /// Make the PictureBox dimensions larger to effect the Zoom.
        /// </summary>
        /// <remarks>Maximum 5 times bigger</remarks>
        private void ZoomIn()
        {
            if ((PicBox.Width < (MINMAX * OuterPanel.Width)) &&
                (PicBox.Height < (MINMAX * OuterPanel.Height)))
            {
                PicBox.Width = Convert.ToInt32(PicBox.Width * ZOOMFACTOR);
                PicBox.Height = Convert.ToInt32(PicBox.Height * ZOOMFACTOR);
                PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        /// <summary>
        /// Make the PictureBox dimensions smaller to effect the Zoom.
        /// </summary>
        /// <remarks>Minimum 5 times smaller</remarks>
        private void ZoomOut()
        {
            if ((PicBox.Width > (OuterPanel.Width / MINMAX)) &&
                (PicBox.Height > (OuterPanel.Height / MINMAX)))
            {
                PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                PicBox.Width = Convert.ToInt32(PicBox.Width / ZOOMFACTOR);
                PicBox.Height = Convert.ToInt32(PicBox.Height / ZOOMFACTOR);
            }
        }

        #endregion

        #region Mouse events

        /// <summary>
        /// We use the mousewheel to zoom the picture in or out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }

        /// <summary>
        /// Make sure that the PicBox have the focus, otherwise it doesn큧 receive 
        /// mousewheel events !.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBox_MouseEnter(object sender, EventArgs e)
        {
            if (PicBox.Focused == false)
            {
                PicBox.Focus();
            }
        }

        #endregion

        #region Disposing

        /// <summary>
        /// Die verwendeten Ressourcen bereinigen.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}
