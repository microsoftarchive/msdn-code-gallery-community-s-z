using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Controllers;
using MvcMusicStore.Models;

namespace MvcMusicStore.ViewModels {
    public class CountryViewModel {
        public List<string> Countries { get; set; }
        public MultiSelectList CountryList { get; private set; }

        public CountryViewModel() {
            this.CountryList = GetCountries(null);
        }

        public MultiSelectList GetCountries(string[] selectedValues) {
            List<Country> countrs = new List<Country>()
                {
                    new Country() { ID = 1, Name= "United States" },
                    new Country() { ID = 2, Name= "Canada" },
                    new Country() { ID = 3, Name= "UK" },
                    new Country() { ID = 4, Name= "China" },
                    new Country() { ID = 5, Name= "Japan" },
                    new Country() { ID = 6, Name= "France" },
                    new Country() { ID = 7, Name= "India" },
                    new Country() { ID = 8, Name= "South Korea" },
                };

            return new MultiSelectList(countrs, "ID", "Name", selectedValues);
        }
    }
}