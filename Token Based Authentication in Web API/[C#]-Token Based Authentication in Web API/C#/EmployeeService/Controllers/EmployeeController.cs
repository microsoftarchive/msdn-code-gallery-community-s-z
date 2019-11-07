using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmployeeService.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Authorize]        
        public List<Employee> GetEmployees()
        {
            using (var db = new TESTEntities())
            {
                var employees = db.Employees.ToList();
                return employees;
            }
        }
    }
}
