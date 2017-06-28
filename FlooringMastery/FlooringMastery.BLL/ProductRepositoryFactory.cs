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
    public class ProductRepositoryFactory
    {
        public static IProductRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new TestProductRepository();
                case "Prod":
                    return new ProdProductRepository();
                default:
                    throw new Exception("App.config file is not valid");

            }
        }
    }
}
