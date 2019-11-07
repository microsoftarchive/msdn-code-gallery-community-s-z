using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Models;
using System;
using MvcMusicStore.ViewModels;

namespace MvcMusicStore.Controllers {
    public class HomeController : Controller {

        MusicStoreEntities storeDB = new MusicStoreEntities();
        public enum eMovieCategories { Action, Drama, Comedy, Science_Fiction };

        private void SetViewBagMovieType(eMovieCategories selectedMovie) {

            IEnumerable<eMovieCategories> values =
                              Enum.GetValues(typeof(eMovieCategories))
                              .Cast<eMovieCategories>();

            IEnumerable<SelectListItem> items =
                from value in values
                select new SelectListItem
                {
                    Text = value.ToString(),
                    Value = value.ToString(),
                    Selected = value == selectedMovie,
                };

            ViewBag.MovieType = items;
        }

        public ActionResult SelectCategoryEnum() {
            SetViewBagMovieType(eMovieCategories.Drama);
            return View("SelectCategory");
        }

        public ActionResult Index() {
            var albums = GetTopSellingAlbums(3);

            return View(albums);
        }

        private List<Album> GetTopSellingAlbums(int count) {

            return storeDB.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        public ViewResult Test() {
            return View();
        }


        public ActionResult SelectCategory() {

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Action", Value = "0" });
            items.Add(new SelectListItem { Text = "Drama", Value = "1" });
            items.Add(new SelectListItem { Text = "Comedy", Value = "2", Selected = true });
            items.Add(new SelectListItem { Text = "Science Fiction", Value = "3" });

            ViewBag.MovieType = items;
            return View();
        }



        public ActionResult SelectCategoryEnumPost() {
            SetViewBagMovieType(eMovieCategories.Comedy);
            return View();
        }

        [HttpPost]
        public ActionResult SelectCategoryEnumPost(eMovieCategories MovieType) {
            ViewBag.messageString = MovieType.ToString() +
                                    " val = " + (int)MovieType;
            return View("Information");
        }


        public ViewResult CategoryChosen(string MovieType) {
            ViewBag.messageString = MovieType;
            return View("Information");
        }

        private MultiSelectList GetCountries(string[] selectedValues) {
            List<Country> Countries = new List<Country>()
                {
                    new Country() { ID = 1, Name= "United States" },
                    new Country() { ID = 2, Name= "Canada" },
                    new Country() { ID = 3, Name= "UK" },
                    new Country() { ID = 4, Name= "China" },
                    new Country() { ID = 5, Name= "Japan" }
                };

            return new MultiSelectList(Countries, "ID", "Name", selectedValues);
        }

        public ActionResult MultiSelectCountry() {
            ViewBag.Countrieslist = GetCountries(null);
            return View();
        }

        [HttpPost]
        public ActionResult MultiSelectCountry(FormCollection form) {
            ViewBag.YouSelected = form["Countries"];
            string selectedValues = form["Countries"];
            ViewBag.Countrieslist = GetCountries(selectedValues.Split(','));
            return View();
        }

        public ActionResult MultiCountryVM() {
            return View(new CountryViewModel());
        }

        [HttpPost]
        public ActionResult MultiCountryVM(CountryViewModel vm) {
            ViewBag.YouSelected = "";
            if (vm.Countries != null)
                foreach (string s in vm.Countries)
                    ViewBag.YouSelected += s + " ";

            return View(vm);
        }
    }
}