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
    public class InventoryController : Controller
    {
        private IRepository _repo;

        public InventoryController()
        {
            _repo = RepositoryFactory.Create();
        }

        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            SearchType searchType = new SearchType();
            searchType.SearchCategory = "New";
            return View("SearchVehicles", searchType );
        }

        [HttpGet]
        public ActionResult Used()
        {
            SearchType searchType = new SearchType();
            searchType.SearchCategory = "Used";
            return View("SearchVehicles", searchType);
        }

        public ActionResult Vehicles()
        {
            SearchType searchType = new SearchType();
            searchType.SearchCategory = "Both";
            return View("SearchVehicles", searchType);
        }


        [HttpGet]
        public ActionResult SearchAll()
        {
            SearchType searchType = new SearchType();
            searchType.SearchCategory = "Both";
            return View("SearchVehicles", searchType);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            DetailsVM model = new DetailsVM();
            var thisVehicle = _repo.GetVehicleById(id);
            model.VehicleDetails = thisVehicle;
            model.VehicleMake = _repo.GetMakeByModel(thisVehicle.VehicleModelId);
            //var currPrice = _repo.GetCurrentPrice(id).VehiclePrice;
            //if (currPrice != 0)
            //    model.VehiclePrice = currPrice;
            return View(model);
        }

        [HttpPost]
        public ActionResult Details(DetailsVM details)
        {
            return View("ContactUs", "Home", new { details.VehicleDetails.VIN });
        }


    }
}