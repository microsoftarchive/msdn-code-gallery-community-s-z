using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MasaSam.Data;
using MvcSample.Models;

namespace MvcSample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(new ContactModel[0]);
        }

        [HttpPost]
        public ActionResult Index(ContactModel[] contacts)
        {
            //// create unique ids
            foreach (var contact in contacts)
            {
                contact.ContactID = Guid.NewGuid();
            }

            //// save using procedure with table value parameter
            using (var context = new ContactingContext())
            {
                context.ExecuteTableValueProcedure<ContactModel>(contacts, "InsertContacts", "@contacts", "ContactStruct");
            }

            TempData["saved"] = "Contacts saved.";

            return View(contacts);
        }
    }
}
