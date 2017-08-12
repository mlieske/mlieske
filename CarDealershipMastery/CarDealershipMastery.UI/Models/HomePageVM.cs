using CarDealershipMastery.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipMastery.UI.Models
{
    public class HomePageVM
    {
        public List<Vehicle> FeaturedVehicles { get; set; }
        public List<Special> AllSpecials { get; set; }

        public HomePageVM()
        {
            FeaturedVehicles = new List<Vehicle>();
            AllSpecials = new List<Special>();
        }
    }

}