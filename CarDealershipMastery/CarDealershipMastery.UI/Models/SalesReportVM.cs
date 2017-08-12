using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipMastery.UI.Models
{
    public class SalesReportVM
    {
        public string Name { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalVehicles { get; set; }

    }
}