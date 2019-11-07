using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DemoUoW.DAL.Repositories;
using DemoUoW.DAL.UnitOfWork;
using DemoUoW.Model;

namespace DemoUoW.UI.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var peopleRepository = new PeopleRepository(uow);

                List<People> peoples = peopleRepository.ShowPeoples().ToList();


                return View(peoples);
            }
        }

        // GET: People/Details/5
        public ActionResult Details(long id)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var peopleRepository = new PeopleRepository(uow);

                People p = peopleRepository.GetPeopleById(id);

                return View(p);
            }
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id, UpdateDate", Include = ("Name, Age, Address"))] People people)
        {
            try
            {
                // TODO: Add insert logic here

                using (var uow = UnitOfWorkFactory.Create())
                {
                    var peopleRepository = new PeopleRepository(uow);

                    peopleRepository.CreatePeople(people);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Edit/5
        public ActionResult Edit(long id)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var peopleRepository = new PeopleRepository(uow);

                People p = peopleRepository.GetPeopleById(id);
                return View(p);
            }
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(People people)
        {
            try
            {
                using (var uow = UnitOfWorkFactory.Create())
                {
                    var peopleRepository = new PeopleRepository(uow);

                    peopleRepository.UpdatePeople(people);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var peopleRepository = new PeopleRepository(uow);

                People p = peopleRepository.GetPeopleById(id);

                return View(p);
            }
        }

        // POST: People/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (var uow = UnitOfWorkFactory.Create())
                {
                    var peopleRepository = new PeopleRepository(uow);

                    peopleRepository.DeletePeople(id);

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
