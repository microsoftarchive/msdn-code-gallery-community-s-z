using System;
using System.Web.Mvc;
using MvcContacts.Models;

namespace MvcContacts.Controllers {
    [HandleError]
    public class HomeController : Controller {

        IContactRepository _repository;

        public HomeController() : this(new EF_ContactRepository()) { }

        public HomeController(IContactRepository repository) {
            _repository = repository;
        }

        public ViewResult Index() {
            ViewData["ControllerName"] = this.ToString();
            return View("Index", _repository.GetAllContacts());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int? id) {
            int idx = id.HasValue ? (int) id : 0;
            Contact cnt = _repository.GetContactByID(idx);
            return View("Details", cnt);
        }

        //
        // GET: /Home/Create

        public ActionResult Create() {
            return View("Create");
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Contact contactToCreate) {
            try {
                if (ModelState.IsValid) {
                    _repository.CreateNewContact(contactToCreate);
                    return RedirectToAction("Index");
                }
            } catch (Exception ex) {
                ModelState.AddModelError("", ex);
                ViewData["CreateError"] = "Unable to create; view innerexception";
            }

            return View("Create");

        }


        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id) {
            var contactToEdit = _repository.GetContactByID(id);

            return View(contactToEdit);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {

            Contact cnt = _repository.GetContactByID(id);

            try {
                if (TryUpdateModel(cnt)) {
                    _repository.SaveChanges();

                    return RedirectToAction("Index");
                }
            } catch (Exception ex) {   // For Demo purpose only
                // Production apps should not display exception data.
                if (ex.InnerException != null)
                    ViewData["EditError"] = ex.InnerException.ToString();
                else
                    ViewData["EditError"] = ex.ToString();
            }

            // For security reasons, only throw model errors in debug/development.
            // To test this, 
            // see the sample download Walkthrough: Using Templated Helpers to Display Data in ASP.NET MVC
            // at http://msdn.microsoft.com/en-us/library/ee308450.aspx
#if DEBUG
            foreach (var modelState in ModelState.Values) {
                foreach (var error in modelState.Errors) {
                    if (error.Exception != null) {
                        throw modelState.Errors[0].Exception;
                    }
                }
            }
#endif

            return View(cnt);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id) {
            var conToDel = _repository.GetContactByID(id);
            return View(conToDel);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                _repository.DeleteContact(id);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
