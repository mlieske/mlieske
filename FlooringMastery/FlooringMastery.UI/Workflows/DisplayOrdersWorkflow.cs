using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class DisplayOrdersWorkflow
    {
        //testorderrepository
        //displayallorders(DateTime)
        public static void Execute()
        {
            DataEntryValidation checkData = new DataEntryValidation();
            // need to call factory and assign an ordermanager
            OrderManager orderManager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("******************Display Orders*************************");
            string date = checkData.DateValidation();

            LoadOrdersResponse response = new LoadOrdersResponse();
            response = orderManager.DisplayOrders(date);

            if (response.Orders != null)
            {
                ConsoleIO.DisplayAllOrders(response.Orders, date);
            }
            else
            {
                Console.WriteLine("There are no orders to display for that date");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }

        }

    }
}
