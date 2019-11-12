using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MsSqlCe.Models;

namespace MsSqlCe.Controllers
{
    public class MangaController : Controller
    {
        private DataContex db = new DataContex();

        //
        // GET: /Manga/

        public ActionResult Index()
        {
            return View(db.mangas.ToList());
        }

        //
        // GET: /Manga/Details/5

        public ActionResult Details(int id = 0)
        {
            Manga manga = db.mangas.Find(id);
            if (manga == null)
            {
                return HttpNotFound();
            }
            return View(manga);
        }

        //
        // GET: /Manga/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manga/Create

        [HttpPost]
        public ActionResult Create(Manga manga)
        {
            if (ModelState.IsValid)
            {
                db.mangas.Add(manga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manga);
        }

        //
        // GET: /Manga/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Manga manga = db.mangas.Find(id);
            if (manga == null)
            {
                return HttpNotFound();
            }
            return View(manga);
        }

        //
        // POST: /Manga/Edit/5

        [HttpPost]
        public ActionResult Edit(Manga manga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manga);
        }

        //
        // GET: /Manga/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Manga manga = db.mangas.Find(id);
            if (manga == null)
            {
                return HttpNotFound();
            }
            return View(manga);
        }

        //
        // POST: /Manga/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Manga manga = db.mangas.Find(id);
            db.mangas.Remove(manga);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}