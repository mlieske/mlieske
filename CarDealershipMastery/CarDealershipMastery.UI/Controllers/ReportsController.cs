using CarDealershipMastery.Data;
using CarDealershipMastery.Data.Interfaces;
using CarDealershipMastery.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipMastery.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReportsController : Controller
    {
        private IRepository _repo;

        public ReportsController()
        {
            _repo = RepositoryFactory.Create();
        }

        // GET: Reports
        public ActionResult Index()
        {
            return View(); //page with Inventory and sales reports links
        }

        public ActionResult Sales()
        {
            SalesReportWithUsersVM bigModel = new SalesReportWithUsersVM();
            decimal totalDollars = 0;
            int totalVehicles = 0;
            //List<SalesReportVM> model = new List<SalesReportVM>();
            var sales = _repo.GetPurchases().GroupBy(p => p.UserName);
            foreach(var user in sales)
            {
                SalesReportVM singleModel = new SalesReportVM();
                singleModel.Name = user.Key;
                foreach(var dollars in user)
                {
                    totalDollars += dollars.PurchPrice;
                }
                foreach(var vehicles in user)
                {
                    totalVehicles += 1;
                }
                singleModel.TotalSales = totalDollars;
                singleModel.TotalVehicles = totalVehicles;
                totalDollars = 0;
                totalVehicles = 0;
                bigModel.AllSalesReport.Add(singleModel);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();

            var users = userManager.Users.ToList();
            bigModel.AllUsers = users;

            //List<AppUser> userList = new List<AppUser>();
            //foreach (var user in users)
            //{
            //    userList.Add(user);
            //}

            //bigModel.SetAllUsers(userList);
            //bigModel.AllUsers = new SelectList(userList, "", "");

            return View(bigModel);  
        }

        public ActionResult Inventory()
        {
            decimal stockValue = 0;
            int count = 0;
            List<InventoryReportVM> model = new List<InventoryReportVM>();

            var notSold = _repo.GetAllVehicles().Where(v => v.Sold == false).ToList();

            var inv = notSold.GroupBy(v => new { v.New, v.VehicleModelId.ModelType, v.Year, v.VehicleModelId.ModelMake });
            foreach (var vehicle in inv)
            {
               
                InventoryReportVM singleModel = new InventoryReportVM();
                singleModel.New = vehicle.Key.New;
                singleModel.Model = vehicle.Key.ModelType;
                singleModel.Year = vehicle.Key.Year;
                singleModel.Make = vehicle.Key.ModelMake.MakeType;
               
                foreach (var s in vehicle)
                {
                    stockValue += s.MSRP;
                    count++;
                }
                singleModel.StockValue = stockValue;
                singleModel.Count = count;
                stockValue = 0;
                count = 0;
                model.Add(singleModel);
            }

            return View(model);

        }


    }
}