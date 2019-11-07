using System.Collections.Generic;
namespace WPFReportTest
{
   public class BEmployee
   {
       private EmployeeDAL employeeDALObj = new EmployeeDAL();
       public List<EEmployee> GetAllEmployeeInfo()
       {
           return employeeDALObj.GetAllEmployeeInfo();
       }
   }
}
