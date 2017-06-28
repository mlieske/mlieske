using FlooringMastery.Models.Interfaces;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;

namespace FlooringMastery.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create() {
            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new TestOrderRepository());
                case "Prod":
                    return new OrderManager(new ProdOrderRepository());
                default:
                    throw new Exception("App.config file is not valid");

            }

            
        }
    }
}
