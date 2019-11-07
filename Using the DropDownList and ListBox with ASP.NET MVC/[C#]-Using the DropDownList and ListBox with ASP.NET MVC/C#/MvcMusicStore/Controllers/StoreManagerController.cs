using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;
using MvcMusicStore.ViewModels;

namespace MvcMusicStore.Controllers {
    public class StoreManagerController : Controller {
        private MusicStoreEntities db = new MusicStoreEntities();

private void SetGenreArtistViewBag(int? GenreID = null, int? ArtistID = null) {

    if (GenreID == null)
        ViewBag.Genres = new SelectList(db.Genres, "GenreId", "Name");
    else
        ViewBag.Genres = new SelectList(db.Genres.ToArray(), "GenreId", "Name", GenreID);

    if (ArtistID == null)
        ViewBag.Artists = new SelectList(db.Artists, "ArtistId", "Name");
    else
        ViewBag.Artists = new SelectList(db.Artists, "ArtistId", "Name", ArtistID);

}
        //
        // GET: /StoreManager/

        public ViewResult Index() {
            var albums = db.Albums.Include(a => a.Genre).Include(a => a.Artist)
                .OrderBy(a => a.Price);
            return View(albums.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ViewResult Details(int id) {
            Album album = db.Albums.Find(id);
            return View(album);
        }

//
// GET: /StoreManager/Create

public ActionResult Create() {
    SetGenreArtistViewBag();
    //var album = new Album { Price = 1.23M };
    return View();
}


//
// POST: /StoreManager/Create

[HttpPost]
public ActionResult Create(Album album) {
    if (ModelState.IsValid) {
        db.Albums.Add(album);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    SetGenreArtistViewBag(album.GenreId, album.ArtistId);
    return View(album);
}

//
// GET: /StoreManager/Edit/5

public ActionResult Edit(int id) {
    Album album = db.Albums.Find(id);
    SetGenreArtistViewBag(album.GenreId, album.ArtistId);
    return View(album);
}

//
// POST: /StoreManager/Edit/5

[HttpPost]
public ActionResult Edit(Album album) {
    if (ModelState.IsValid) {
        db.Entry(album).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    SetGenreArtistViewBag(album.GenreId, album.ArtistId);
    return View(album);
}

//
// GET: /StoreManager/EditVM/5

public ActionResult EditVM(int id) {
    Album album = db.Albums.Find(id);
    if (album == null)
        return HttpNotFound();

    AlbumSelectListViewModel aslvm = new AlbumSelectListViewModel(album, db.Artists, db.Genres);
    return View(aslvm);
}

        //
        // GET: /StoreManager/Delete/5

        public ActionResult Delete(int id) {
            Album album = db.Albums.Find(id);
            return View(album);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id) {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}