using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using UserManagement.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Controllers
{
    [Authorize(Roles = "Staff")]
    public class ScheduleController : Controller
    {
        private List<Schedule> schedules = new List<Schedule>
            {
                new Schedule
                {
                    Department = "Sales",
                    Manager = "Alan",
                    Assistant = "Bob"
                },
                new Schedule
                {
                    Department = "Finance",
                    Manager = "David",
                    Assistant = "Shirley"
                }
            };

        private IAuthorizationService authorizationService;

        public ScheduleController(IAuthorizationService authService)
        {
            authorizationService = authService;
        }

        public IActionResult Index()
        {
            return View(schedules);
        }

        // Apply policy "Schedule"
        public async Task<IActionResult> Edit(string department)
        {
            Schedule schedule = schedules.FirstOrDefault(s => s.Department == department);

            bool isAuthorized = await authorizationService.AuthorizeAsync(User, schedule, "Schedule");

            if (isAuthorized)
            {
                return View(schedule);
            }

            return new ChallengeResult();
        }

    }
}
