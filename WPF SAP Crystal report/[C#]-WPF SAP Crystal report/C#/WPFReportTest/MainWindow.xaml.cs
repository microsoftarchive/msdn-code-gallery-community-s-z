using System.Collections.Generic;
using System.Windows;
namespace WPFReportTest
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private BEmployee bEmployeeObj = new BEmployee();
        private void showAllEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            List<EEmployee> employeeInfoList = bEmployeeObj.GetAllEmployeeInfo();
            if (employeeInfoList.Count > 0)
            {
                EmployeeInfoCrystalReport employeeInfoCrystalReport = new EmployeeInfoCrystalReport();
                ReportUtility.Display_report(employeeInfoCrystalReport, employeeInfoList, this);
            }
            else
            {
                MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
