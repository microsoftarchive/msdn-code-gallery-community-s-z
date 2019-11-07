using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TranslateTextApp.Business_Layer;
using TranslateTextApp.Models;

namespace TranslateTextApp.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<LanguageMaster> _logger;

        TranslateTextService obj = new TranslateTextService();
        public HomeController(ILogger<LanguageMaster> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            LanguageMaster languageMaster = new LanguageMaster();
            return View(languageMaster);
        }
        [HttpPost]
        public async Task<JsonResult> Index(LanguageMaster languageMaster)
        {
            var result = string.Empty;

            if (languageMaster.LanguageCode != "NA")
            {
                try
                {
                    // Language code for selected language in the dropdown list.
                    string code = languageMaster.LanguageCode;
                    // NOTE: Replace this example key with a valid subscription key.
                    string key = "<Subscription Key>";
                    //host url
                    string host = "https://api.cognitive.microsofttranslator.com";
                    string path = "/translate?api-version=3.0";
                    // Translate to dropdown selected language.
                    string params_ = $"&to={code}";

                    string uri = host + path + params_;

                    string text = languageMaster.Text;
                    result = await obj.Translate(uri, text, key);
                }
                catch (Exception ex)
                {
                    _logger.LogError($" Translate text failure : {ex.Message} ");
                }

            }

            return Json(result);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
