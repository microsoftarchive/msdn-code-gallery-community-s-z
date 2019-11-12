using System;
using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers {
    // [Authorize(Roles = "Administrator")]   // Commented out for development
    // TODO: remove comments on Authorize
    public class GenreController : Controller {
        private MusicStoreEntities db = new MusicStoreEntities();

        [HttpGet]
        public ActionResult Create() {
            // Don't allow this method to be called directly.
            if (this.HttpContext.Request.IsAjaxRequest() != true)
                return RedirectToAction("Index", "StoreManager");

            return PartialView("_CreateGenre");
        }

        [HttpPost]
        public ActionResult Create(Genre genre) {
            try {
                if (ModelState.IsValid) {
                    db.Genres.Add(genre);
                    db.SaveChanges();

                    var dbGenre = db.Genres.Where(g => g.Name == genre.Name).SingleOrDefault();
                    return Json(new { Genre = dbGenre, Error = string.Empty });
                } else {
                    //TODO: better error messages
                    string errMsg = "Something failed, probably validation";
                    var er = ModelState.Values.FirstOrDefault();
                    if (er != null && er.Value != null && !String.IsNullOrEmpty(er.Value.AttemptedValue))
                        errMsg = "\"" + er.Value.AttemptedValue + "\" Does not validate";
                    // return Json(new { Error = ModelState.Values.FirstOrDefault() });
                    return Json(new { Error = errMsg });
                }
            } catch (InvalidOperationException ioex) {
                if (ioex.Message.Contains("Sequence contains more than one element"))
                    return Json(new { Error = "Value provided exists in DB, enter a unique value" });
#if DEBUG
                return Json(new { Error = ioex.Message });
#else
                return Json(new { Error = "Internal Error with input provided" });
#endif

            } catch (Exception ex) {
#if DEBUG
                return Json(new { Error = ex.Message });
#else
                return Json(new { Error = "Internal Error with input provided" });
#endif

            }
        }
    }
}
