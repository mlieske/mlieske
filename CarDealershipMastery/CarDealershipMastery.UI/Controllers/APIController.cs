using CarDealershipMastery.Data;
using CarDealershipMastery.Data.Interfaces;
using CarDealershipMastery.Models.TableModels;
using CarDealershipMastery.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealershipMastery.UI.Controllers
{
    [RoutePrefix("API")]

    public class APIController : ApiController
    {
        private IRepository _repo;

        public APIController()
        {
            _repo = RepositoryFactory.Create();
        }


        [Route("vehicles/{searchType}/{searchString}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetVehicles(string searchType, string searchString, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            var found = _repo.GetNewBySearch(searchType, searchString, minPrice, maxPrice, minYear, maxYear);

            if (found == null)
                throw new NotImplementedException();
            //return NotFound();
            else return Ok(found);
        }

        [Route("salesreport/{userName}/{startDate}/{endDate}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetUserReport(string userName, DateTime startDate, DateTime endDate)
        {

            decimal totalDollars = 0;
            int totalVehicles = 0;
            List<Purchase> sales = new List<Purchase>();
            sales = _repo.GetPurchases();
            if(userName != null)
            {
                sales = sales.Where(s => s.UserName == userName).ToList();
            }
            if (startDate != null)
            {
                sales = sales.Where(s => s.PurchaseDate >= startDate).ToList();
            }
            if (startDate != null)
            {
                sales = sales.Where(s => s.PurchaseDate <= endDate).ToList();
            }
            var groupedSales = sales.GroupBy(s => s.UserName);

            List<SalesReportVM> allSales = new List<SalesReportVM>();
            //var sales = _repo.GetPurchases().GroupBy(p => p.UserName);
            foreach (var user in groupedSales)
            {
                SalesReportVM singleModel = new SalesReportVM();
                singleModel.Name = user.Key;
                foreach (var dollars in user)
                {
                    totalDollars += dollars.PurchPrice;
                }
                foreach (var vehicles in user)
                {
                    totalVehicles += 1;
                }
                singleModel.TotalSales = totalDollars;
                singleModel.TotalVehicles = totalVehicles;
                totalDollars = 0;
                totalVehicles = 0;
                allSales.Add(singleModel);
            }

            return Ok(allSales);
        }



        [Route("getmodels/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModels(int id)
        {
            var found = _repo.GetModelsByMake(id);
    //        return Json(new[] {
    //            found
    //    new { value = '1', text = 'text 1' },
    //    new { value = '2', text = 'text 2' },
    //    new { value = '3', text = 'text 3' }
    //});
            return Ok(found);
        }

    }
}