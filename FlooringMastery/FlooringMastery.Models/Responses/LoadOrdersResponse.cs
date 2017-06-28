using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Responses
{
    public class LoadOrdersResponse : Response
    {
        public List<Order> Orders { get; set; }
        public Order SingleOrder { get; set; }
    }
}
