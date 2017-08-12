using CarDealershipMastery.Data.Interfaces;
using CarDealershipMastery.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipMastery.Data
{
    public class RepositoryFactory
    {
        public static IRepository Create()
        {
            var repo = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (repo)
            {
                case "QA":
                    return new MockRepository();
                case "Prod":
                    return new EFRepository();
                default:
                    throw new NotImplementedException();
            }

        }
    }
}
