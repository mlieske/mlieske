using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipMastery.Models.TableModels
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int? VehicleId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchPrice { get; set; }
        public int CustomerId { get; set; }
        public int PaymentTypeId { get; set; }
        public string UserName { get; set; }

        public virtual Customer PurchCustomer { get; set; }
        public virtual PaymentType PurchPaymentType { get; set; }
        public virtual Vehicle PurchVehicle { get; set; }

        public Purchase()
        {
            //PurchaseDate = DateTime.Now;
        }
    }

}
