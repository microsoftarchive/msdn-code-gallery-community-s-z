using Microsoft.AspNetCore.Mvc;

namespace RealTimeDataEditor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
