using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipMastery.Models.TableModels
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VIN { get; set; }
        public int Year { get; set; }
        public bool New { get; set; }
        public decimal Mileage { get; set; }
        public decimal MSRP { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; }
        public bool Sold { get; set; }
        public string ImageName { get; set; }
        public int IntColorId { get; set; }
        public int ExtColorId { get; set; }
        public int VModelId { get; set; }
        public int BodyStyleId { get; set; }
        public int TransTypeId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual ExtColor VehicleExtColor { get; set; }
        public virtual BodyStyle VehicleBodyStyle { get; set; }
        public virtual VModel VehicleModelId { get; set; }
        public virtual TransType VehicleTrans { get; set; }
        public virtual IntColor VehicleIntColor { get; set; }

        public Vehicle()
        {
            DateAdded = DateTime.Now;
        }
    }
}
