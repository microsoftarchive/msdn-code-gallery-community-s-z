using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Tools.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net;


namespace TablesAndCharts
{
    public partial class TableAndChartPane : UserControl
    {
        public TableAndChartPane()
        {
            InitializeComponent();
            PopulateListObjectHeaderCheckBoxList();
        }

        Worksheet _vstoWorkSheet;
        Excel.Worksheet _worksheetInteropObject;
        ListObject _listObject = null;
        Chart _chart = null;
        
        public Worksheet VstoWorksheet
        {
            get
            {
                if (_vstoWorkSheet == null)
                {
                    if (_worksheetInteropObject == null)
                    {
                        _vstoWorkSheet = Globals.Factory.GetVstoObject(((Excel.Worksheet)Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[1]));
                    }
                    else
                    {
                        _vstoWorkSheet = Globals.Factory.GetVstoObject(_worksheetInteropObject);
                    }
                }

                _vstoWorkSheet.Activate();
                return _vstoWorkSheet;
            }
        }
        public void SetWorksheet(Excel.Worksheet worksheetInteropObject)
        {
            _worksheetInteropObject = worksheetInteropObject;
            _vstoWorkSheet = null;
        }

        private void PopulateListObjectHeaderCheckBoxList()
        {
            ListObjectHeaders.Items.Add("Date", true);
            ListObjectHeaders.Items.Add("Open", true);
            ListObjectHeaders.Items.Add("High", true);
            ListObjectHeaders.Items.Add("Low", true);
            ListObjectHeaders.Items.Add("Close", true);
            ListObjectHeaders.Items.Add("Volume", true);
            ListObjectHeaders.Items.Add("Adj Close", true);
        }
        // When user chooses the checkbox, generate a new sheet, a table of data, and a chart.
        // If the sheet, table, and chart already exist, delete them.
        private void ListObject_Check(object sender, EventArgs e)
        {
            string listObjectName = "stockHistoryListObject";
            string chartName = "stockHistoryChart";         
            
            if (((CheckBox)sender).Checked)
            {
                if (dateTimePicker1.Value.Date >= DateTime.Now.Date)
                {
                    MessageBox.Show("Please choose a starting date before today's date");
                    ((CheckBox)sender).Checked = false;
                }
                else
                {
                    Excel.Range selection = SelectedRange;
                    string tickerSymbol = selection.Value2;

                    List<HistoricalStock> data = null;
                    try
                    {                       
                        data = GetDataUpdatesFoOneDataSource(tickerSymbol, dateTimePicker1.Value.Date.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Unable to return data. Please ensure that you select a valid stock ticker symbol" +
                        " in your worksheet and then try again");
                        ((CheckBox)sender).Checked = false;
                        return;
                    }

                    CreateNewSheet();

                    if (selection != null)
                    {
                        _listObject = VstoWorksheet.Controls.AddListObject(Globals.ThisAddIn.Application.get_Range("A1"), listObjectName);
                        groupBox1.Enabled = true;
                        groupBox2.Enabled = true;
                        groupBox3.Enabled = true;

                        _listObject.DataBindings.Clear();
                        _listObject.SetDataBinding(data);

                        int counter = 0;

                        foreach (Excel.Range range in _listObject.HeaderRowRange.Cells)
                        {
                            range.Value2 = ListObjectHeaders.Items[counter];
                            counter++;
                        }

                        AddChart(chartName);
                }

                }
            }
            else
            {
                VstoWorksheet.Controls.Remove(listObjectName);
                VstoWorksheet.Controls.Remove(chartName);
                VstoWorksheet.Delete();
                SetWorksheet(Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[1]);

                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
        }

        private void CreateNewSheet()
        {
            
            Excel.Worksheet newWorksheet;
            newWorksheet = (Excel.Worksheet)Globals.ThisAddIn.Application.Worksheets.Add();
            newWorksheet.Name = "Price history";
            SetWorksheet(newWorksheet);
        }
        private Excel.Range SelectedRange
        {
            get
            {
                Excel.Range selection = VstoWorksheet.Application.Selection as Excel.Range;

                if (selection != null &&
                    selection.Worksheet.Name == VstoWorksheet.Name)
                {
                    return selection;
                }

                return null;
            }
        }
        // Define a class to hold information from the stock service.
        public class HistoricalStock
        {
            public DateTime Date
            { get; set; }
            public double Open
            { get; set; }
            public double High
            { get; set; }
            public double Low
            { get; set; }
            public double Close
            { get; set; }
            public double Volume
            { get; set; }
            public double AdjClose
            { get; set; }
        }
        // Query the stock service.
        public List<HistoricalStock> GetDataUpdatesFoOneDataSource
            (string ticker, string mostRecentDate)
        {
            DateTime _startDate = DateTime.Now.Date;
            DateTime _endDate;
            _endDate = Convert.ToDateTime(mostRecentDate);

            List<HistoricalStock> retval = new List<HistoricalStock>();

            if (_startDate.Date != _endDate.Date)
            {
                int _startMonthTemp = _startDate.Month - 1;
                string _startMonth = _startMonthTemp.ToString();
                string _startDay = _startDate.Day.ToString();
                string _startYear = _startDate.Year.ToString();

                _endDate = _endDate.AddDays(1);
                int _endMonthTemp = _endDate.Month - 1;
                string _endMonth = _endMonthTemp.ToString();
                string _endDay = _endDate.Day.ToString();
                string _endYear = _endDate.Year.ToString();

                using (WebClient web = new WebClient())
                {
                    string _inputString = "http://ichart.finance.yahoo.com/table.csv?s=" +
                        ticker + "&d=" + _startMonth + "&e=" + _startDay + "&f=" + _startYear +
                        "&g=d&a=" + _endMonth + "&b=" + _endDay + "&c=" + _endYear + "&ignore=.csv";

                    string data = web.DownloadString(_inputString);

                    data = data.Replace("r", "");
                    string[] rows = data.Split('\n');

                    //First row is headers so Ignore it                
                    for (int i = 1; i < rows.Length; i++)
                    {
                        if (rows[i].Replace("n", "").Trim() == "") continue;
                        string[] cols = rows[i].Split(',');
                        HistoricalStock hs = new HistoricalStock();
                        hs.Date = Convert.ToDateTime(cols[0]);
                        hs.Open = Convert.ToDouble(cols[1]);
                        hs.High = Convert.ToDouble(cols[2]);
                        hs.Low = Convert.ToDouble(cols[3]);
                        hs.Close = Convert.ToDouble(cols[4]);
                        hs.Volume = Convert.ToDouble(cols[5]);
                        hs.AdjClose = Convert.ToDouble(cols[6]);
                        retval.Add(hs);
                    }

                    if (retval.Count > 1)
                    {
                        if (retval[0].Date == retval[1].Date)
                        {
                            retval.RemoveAt(0);
                        }
                    }
                }
            }
            return retval;
        }

        private void AddChart(string chartName)
        {
            Worksheet worksheet = Globals.Factory.GetVstoObject(
                Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet);

            Excel.Range cells = worksheet.Range["I1", "O22"];
            Chart chart = worksheet.Controls.AddChart(cells, chartName);
            chart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;
            chart.SetSourceData(_listObject.ListColumns[5].Range.EntireColumn);
            _chart = chart;
        }     

        private void ListObjectHeaders_Click(object sender, EventArgs e)
        {
            Excel.Range columnToHide = null;
            
            switch (ListObjectHeaders.SelectedItem.ToString())
            {
                case "Date":
                    columnToHide = _listObject.ListColumns[1].Range.EntireColumn;
                    break;
                case "Open":
                    columnToHide = _listObject.ListColumns[2].Range.EntireColumn;
                    break;
                case "High":
                    columnToHide = _listObject.ListColumns[3].Range.EntireColumn;
                    break;
                case "Low":
                    columnToHide = _listObject.ListColumns[4].Range.EntireColumn;
                    break;
                case "Close":
                    columnToHide = _listObject.ListColumns[5].Range.EntireColumn;
                    break;
                case "Volume":
                    columnToHide = _listObject.ListColumns[6].Range.EntireColumn;
                    break;
                case "Adj Close":
                    columnToHide = _listObject.ListColumns[7].Range.EntireColumn;
                    break;           
            }

            if (columnToHide.Hidden == false)
                columnToHide.Hidden = true;
            else
                columnToHide.Hidden = false;
            
        }

        private void BlackStyle_CheckedChanged(object sender, EventArgs e)
        {
            _listObject.TableStyle = "TableStyleMedium1";
        }

        private void BlueStyle_CheckedChanged(object sender, EventArgs e)
        {
            _listObject.TableStyle = "TableStyleMedium2";
        }

        private void OrangeStyle_CheckedChanged(object sender, EventArgs e)
        {
            _listObject.TableStyle = "TableStyleMedium3";
        }

        private void Gray_CheckedChanged(object sender, EventArgs e)
        {
            _listObject.TableStyle = "TableStyleMedium4";
        }

        private void Green_CheckedChanged(object sender, EventArgs e)
        {
            _listObject.TableStyle = "TableStyleMedium7";
        }

        private void chartDataSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (chartDataSourceComboBox.Text)
            {
                case "Open":
                    _chart.SetSourceData(_listObject.ListColumns[2].Range.EntireColumn);
                    break;
                case "High":
                    _chart.SetSourceData(_listObject.ListColumns[3].Range.EntireColumn);
                    break;
                case "Low":
                    _chart.SetSourceData(_listObject.ListColumns[4].Range.EntireColumn);
                    break;
                case "Close":
                    _chart.SetSourceData(_listObject.ListColumns[5].Range.EntireColumn);
                    break;
                case "Volume":
                    _chart.SetSourceData(_listObject.ListColumns[6].Range.EntireColumn);
                    break;
                case "Adj_Close":
                    _chart.SetSourceData(_listObject.ListColumns[7].Range.EntireColumn);
                    break;              
                default:
                    MessageBox.Show("Invalid Selection");
                    break;
            }
        }

        private void ChartStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ChartStyleComboBox.Text)
            {
                case "Line":
                    _chart.ChartType = Excel.XlChartType.xlLine;
                    break;
                case "Column":
                    _chart.ChartType = Excel.XlChartType.xlColumnClustered;
                    break;
                case "Area":
                    _chart.ChartType = Excel.XlChartType.xlArea;
                    break;
                default:
                    MessageBox.Show("Invalid Selection");
                    break;
            }
        }
        private void ChartColorThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ChartColorThemeComboBox.Text)
            {
                case "White background":
                    _chart.ChartStyle = 227;
                    break;
                case "Blue background":
                    _chart.ChartStyle = 229;
                    break;
                case "Gray background":
                    _chart.ChartStyle = 236;
                    break;
                default:
                    MessageBox.Show("Invalid Selection");
                    break;
            }
        }

    }
}
