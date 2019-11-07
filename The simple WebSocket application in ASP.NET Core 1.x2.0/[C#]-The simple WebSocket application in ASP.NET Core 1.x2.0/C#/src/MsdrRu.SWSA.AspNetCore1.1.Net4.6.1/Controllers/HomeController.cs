using Microsoft.AspNetCore.Mvc;

namespace MsdrRu.SimpleWebSocketApp.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
