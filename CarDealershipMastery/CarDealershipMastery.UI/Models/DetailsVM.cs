using CarDealershipMastery.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipMastery.UI.Models
{
    public class DetailsVM
    {
        public Vehicle VehicleDetails { get; set; }
        public Make VehicleMake { get; set; }
    }
}