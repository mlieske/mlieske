using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipMastery.UI.Models
{
    public class InventoryReportVM
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Count { get; set; }
        public decimal StockValue { get; set; }
        public bool New { get; set; }
    }
}