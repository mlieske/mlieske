using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipMastery.Models.TableModels
{
    public class VModel
    {
        public int VModelId { get; set; }
        public string ModelType { get; set; }
        public int MakeId { get; set; }

        public virtual Make ModelMake { get; set; }
    }
}
