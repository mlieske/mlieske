using CarDealershipMastery.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipMastery.UI.Models
{
    public class ManageSpecialsVM
    {
        public Special VMSpecial { get; set; }
        public List<Special> VMAllSpecials { get; set; }

        public ManageSpecialsVM()
        {
            VMSpecial = new Special();
            VMAllSpecials = new List<Special>();
        }
    }

}