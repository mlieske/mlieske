using CarDealershipMastery.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipMastery.UI.Models
{
    public class NewMakeVM
    {
        public Make NewMake { get; set; }
        public List<Make> AllMakes { get; set; }

        public NewMakeVM()
        {
            NewMake = new Make();
            AllMakes = new List<Make>();
        }
    }


}