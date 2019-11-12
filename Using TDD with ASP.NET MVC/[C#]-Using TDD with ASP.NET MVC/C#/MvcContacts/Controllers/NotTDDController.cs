using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcContacts.Models;

namespace MvcContacts.Controllers {
    // <snippet22>
    public class NotTDDController : Controller {

        ContactEntities _db = new ContactEntities();

        public ActionResult Index() {
            ViewData["ControllerName"] = this.ToString();
            var dn = _db.Contacts;
            return View(dn);
        }

        public ActionResult Edit(int id) {
            Contact prd = _db.Contacts.FirstOrDefault(d => d.Id == id);
            return View(prd);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            Contact prd = _db.Contacts.FirstOrDefault(d => d.Id == id);
            UpdateModel(prd);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    } 
    // </snippet22>
}
