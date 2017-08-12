using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipMastery.Models.TableModels
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMessage { get; set; }
        public int? VehicleId { get; set; }

        public virtual Vehicle ContactUsVehicle { get; set; }
    }
}
