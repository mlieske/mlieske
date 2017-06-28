using FlooringMastery.Data;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public class TaxRepositoryFactory
    {
        public static ITaxRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new TestTaxRepository();
                case "Prod":
                    return new ProdTaxRepository();
                default:
                    throw new Exception("App.config file is not valid");

            }
        }
    }
}
