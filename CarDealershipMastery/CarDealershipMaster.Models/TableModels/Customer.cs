using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipMastery.Models.TableModels
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustLastName { get; set; }
        public string CustFirstName { get; set; }
        public string CustEmail { get; set; }
        public string CustPhone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
