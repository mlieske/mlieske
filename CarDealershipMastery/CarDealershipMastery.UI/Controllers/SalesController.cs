using CarDealershipMastery.Data;
using CarDealershipMastery.Data.Interfaces;
using CarDealershipMastery.Models.TableModels;
using CarDealershipMastery.UI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipMastery.UI.Controllers
{
    [Authorize(Roles = "sales")]
    public class SalesController : Controller
    {
        private IRepository _repo;

        public SalesController()
        {
            _repo = RepositoryFactory.Create();
        }

        // GET: Sales
        public ActionResult Index() //search
        {
            return View();
        }

        public ActionResult Purchase(int id)
        {
            PurchaseVM model = new PurchaseVM();
            Vehicle vehicle = _repo.GetVehicleById(id);
            model.PurchaseVMVehicle = vehicle;
            model.VehicleMake = _repo.GetMakeByModel(vehicle.VehicleModelId);
            model.SetAllStates();
            model.SetPaymentTypes(_repo.GetAllPaymentTypes());
            Customer customer = new Customer();
            Purchase purchase = new Purchase();


            model.PurchaseVMCustomer = customer;
            model.PurchaseVMPurchase = purchase;

            return View(model);

        }

        [HttpPost]
        public ActionResult Purchase(PurchaseVM model)
        {
            //set sold flag to true
            //assign vehicle id to purchase
            //assign customerID to purchase
            //assign username
            var newCustId = _repo.AddCustomer(model.PurchaseVMCustomer);
            model.PurchaseVMPurchase.CustomerId = newCustId;
            model.PurchaseVMPurchase.VehicleId = model.PurchaseVMVehicle.VehicleId;
            model.PurchaseVMPurchase.PurchaseDate = DateTime.Now;
            model.PurchaseVMPurchase.UserName = User.Identity.GetUserName();

            _repo.AddPurchase(model.PurchaseVMPurchase);

            Vehicle vehicle = _repo.GetVehicleById(model.PurchaseVMVehicle.VehicleId);
            vehicle.Sold = true;
            _repo.EditVehicle(vehicle);

            return RedirectToAction("Index","Home");

        }

    }
}