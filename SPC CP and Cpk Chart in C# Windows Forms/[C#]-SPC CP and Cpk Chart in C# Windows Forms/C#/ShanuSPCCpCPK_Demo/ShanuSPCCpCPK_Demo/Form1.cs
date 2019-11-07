using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Author  : Syed Shanu
//Date    : 2015-02-09
//Description : SPC CP,CPk CHART
namespace ShanuSPCCpCPK_Demo
{
    public partial class Form1 : Form
    {
        #region Local Vairables
        DataTable dt = new DataTable();
        private static readonly Random random = new Random();
        Double gridMinvalue = 1.2;
        Double gridMaxvalue = 2.4;
        int totalColumntoDisplay = 20;
        Double USLs = 2.27;
        Double LSLs = 1.26;
        Double CpkPpkAcceptanceValue = 1.33;

        #endregion

        #region Form Load
        public Form1()
        {
            InitializeComponent();
        }
        
      
        private void Form1_Load(object sender, EventArgs e)
        {
            loadGridColums();
            loadgrid();
            USLs = Convert.ToDouble(txtusl.Text);
            LSLs = Convert.ToDouble(txtLSL.Text);
            CpkPpkAcceptanceValue = Convert.ToDouble(txtData.Text);
            shanuCPCPKChart.ChartWaterMarkText = txtWaterMark.Text.Trim();
            shanuCPCPKChart.USL = USLs;
            shanuCPCPKChart.LSL = LSLs;
            shanuCPCPKChart.CpkPpKAcceptanceValue = CpkPpkAcceptanceValue;
            shanuCPCPKChart.Bindgrid(dt);   
        }
        #endregion

        #region Methods
        //Create Datatable  Colums.
        public void loadGridColums()
        {
            dt.Columns.Add("No");
            for (int jval = 1; jval <= totalColumntoDisplay; jval++)
            {
                dt.Columns.Add(jval.ToString());
            }
          
        }


        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return Math.Round(minValue + (next * (maxValue - minValue)), 3);
        }
        public void loadgrid()
        {
            dt.Clear();
            dt.Rows.Clear();
            for (int i = 1; i <= 5; i++)
            {
                DataRow row = dt.NewRow();
                row["NO"] = i.ToString();
                for (int jval = 1; jval <= totalColumntoDisplay; jval++)
                {
                    row[jval.ToString()] = RandomNumberBetween(gridMinvalue, gridMaxvalue);
                }
                
                dt.Rows.Add(row);
            }
            dataGridView1.AutoResizeColumns();
            dataGridView1.DataSource = dt;
            // dataGridView1.DataBindings();
            dataGridView1.AutoResizeColumns();
        }
        #endregion


        #region Events
        private void button1_Click(object sender, EventArgs e)
        {
            gridMinvalue = 2.7;
            gridMaxvalue = 8.4;
            loadgrid();
            USLs = Convert.ToDouble(txtusl.Text);
            LSLs = Convert.ToDouble(txtLSL.Text);
            CpkPpkAcceptanceValue = Convert.ToDouble(txtData.Text);
            shanuCPCPKChart.ChartWaterMarkText = txtWaterMark.Text.Trim();
            shanuCPCPKChart.USL = USLs;
            shanuCPCPKChart.LSL = LSLs;
            shanuCPCPKChart.CpkPpKAcceptanceValue = CpkPpkAcceptanceValue;
            shanuCPCPKChart.Bindgrid(dt);   
        }

        private void btnRealTime_Click(object sender, EventArgs e)
        {
            gridMinvalue = 1.2;
            gridMaxvalue = 4.8;

            if (btnRealTime.Text == "Real Time Data ON")
            {
                btnRealTime.Text = "Real Time Data OFF";
                btnRealTime.ForeColor = Color.Red;
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                btnRealTime.Text = "Real Time Data ON";
                btnRealTime.ForeColor = Color.DarkGreen;
                timer1.Enabled = false;
                timer1.Stop();
            }
        }

    

        private void timer1_Tick(object sender, EventArgs e)
        {
            loadgrid();
            USLs = Convert.ToDouble(txtusl.Text);
            LSLs = Convert.ToDouble(txtLSL.Text);
            CpkPpkAcceptanceValue = Convert.ToDouble(txtData.Text);
            shanuCPCPKChart.ChartWaterMarkText = txtWaterMark.Text.Trim();
            shanuCPCPKChart.USL = USLs;
            shanuCPCPKChart.LSL = LSLs;
            shanuCPCPKChart.CpkPpKAcceptanceValue = CpkPpkAcceptanceValue;
            shanuCPCPKChart.Bindgrid(dt);   
        }
        #endregion
    }
}
