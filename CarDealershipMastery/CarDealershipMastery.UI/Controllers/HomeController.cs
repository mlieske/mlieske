using CarDealershipMastery.Data;
using CarDealershipMastery.Data.Interfaces;
using CarDealershipMastery.Models.TableModels;
using CarDealershipMastery.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipMastery.UI.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;

        public HomeController()
        {
            _repo = RepositoryFactory.Create();
        }

        // GET: Home
        public ActionResult Index()
        {
            HomePageVM model = new HomePageVM();
            model.FeaturedVehicles = _repo.GetFeatured();
            model.AllSpecials = _repo.GetSpecials();
            return View(model);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            var model = _repo.GetSpecials();
            return View(model);
        }


        [HttpGet]
        public ActionResult ContactUs(DetailsVM details)
        {
            //need to check where coming from and attach that vehicle to the contact model
            var model = new Contact();
            if (details.VehicleDetails != null)
            {
                model.ContactMessage = details.VehicleDetails.VIN;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult ContactUs(Contact contact)
        {
            _repo.AddContact(contact);
            return RedirectToAction("Index");
        }
    }
}