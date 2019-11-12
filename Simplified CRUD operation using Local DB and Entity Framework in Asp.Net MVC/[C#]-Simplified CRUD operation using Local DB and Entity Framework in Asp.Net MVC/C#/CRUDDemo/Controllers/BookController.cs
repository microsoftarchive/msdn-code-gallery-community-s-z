using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDDemo.Models;
using System.Net;
using System.Data.Entity;
namespace CRUDDemo.Controllers
{
    public class BookController : Controller
    {
        private BookDBContext objBookDb = new BookDBContext();
        // GET: /Book/
        public ActionResult Index()
        {
            return View(objBookDb.BookLst.ToList());
        }
        //GET:/Create/
        public ActionResult Create()
        {
            return View();
        }

        //POST:/Create/
        [HttpPost]
        public ActionResult Create(BookModel model)
        {
            if (ModelState.IsValid)
            {
                objBookDb.Entry(model).State = EntityState.Added;
                objBookDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        //GET:/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = objBookDb.BookLst.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //POST:/Edit/
        [HttpPost]
        public ActionResult Edit(BookModel model)
        {
            if (ModelState.IsValid)
            {
                objBookDb.Entry(model).State = EntityState.Modified;
                objBookDb.SaveChanges();
                return RedirectToAction("Index");

            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        //Get:/Details/
        public ActionResult Details(int id)
        {
            var model = objBookDb.BookLst.Find(id);
            return View(model);
        }
        //GET:/Delete/

        public ActionResult Delete(int id)
        {
            var model = objBookDb.BookLst.Find(id);
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objBookDb.BookLst.Remove(model);
            objBookDb.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}