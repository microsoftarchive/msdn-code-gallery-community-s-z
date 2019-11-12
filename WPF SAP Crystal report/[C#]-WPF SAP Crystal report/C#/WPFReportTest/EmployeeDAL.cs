using System.Collections.Generic;
namespace WPFReportTest
{
   public class EmployeeDAL
   {
       private ReportTestDataContextDataContext reportDataContextObj = new ReportTestDataContextDataContext();
       internal List<EEmployee> GetAllEmployeeInfo()
       {
           List<EEmployee> employees = new List<EEmployee>();
           foreach (var info in reportDataContextObj.EMPLOYEE_INFOs)
           {
               EEmployee eEmployeeObj = new EEmployee();
               eEmployeeObj.Id = info.Id;
               eEmployeeObj.Name = info.Name;
               eEmployeeObj.Age = (int) info.Age;
               eEmployeeObj.Address = info.Address;
               employees.Add(eEmployeeObj);
           }
           return employees;
       }
   }
}
