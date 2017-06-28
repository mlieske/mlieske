using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Responses
{
    public class LoadTaxFileResponse : Response
    {
        public List<TaxesByState> TaxList { get; set; }
    }
}
