using CarDealershipMastery.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipMastery.UI.Models
{
    public class NewModelVM
    {
        public VModel NewModel { get; set; }
        public List<VModel> AllModels { get; set; }
        public List<SelectListItem> AllMakes { get; set; }

        public NewModelVM()
        {
            NewModel = new VModel();
            AllModels = new List<VModel>();
            AllMakes = new List<SelectListItem>();
        }

        public void SetAllMakes(IEnumerable<Make> setList)
        {
            foreach (var item in setList)
            {
                AllMakes.Add(new SelectListItem()
                {
                    Value = item.MakeId.ToString(),
                    Text = item.MakeType
                });
            }
        }

    }
}