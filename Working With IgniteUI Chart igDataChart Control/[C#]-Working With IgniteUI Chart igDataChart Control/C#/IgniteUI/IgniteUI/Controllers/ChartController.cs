using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

namespace IgniteUI.Controllers
{
    public class ChartController : Controller
    {
        private IgniteUI.Models.TrialsDBEntities db = new IgniteUI.Models.TrialsDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Getproducts()
        {
            var model = db.Products.AsQueryable().GroupBy(g => g.Name, g => g.ReorderPoint, (key, g) => new
            {
                Name = key,
                ReorderPoint = g.Take(1)
            }).Take(10);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}