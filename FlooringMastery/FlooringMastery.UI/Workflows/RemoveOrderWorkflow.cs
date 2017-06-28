using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public static void Execute()
        {
            string orderDate;
            int orderNumber;
            Order orderToRemove = new Order();
            LoadOrdersResponse response = new LoadOrdersResponse();

            DataEntryValidation checkData = new DataEntryValidation();
            OrderManager orderManager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("******************Remove Order*******************");
            Console.WriteLine("Please enter the order date of the order you would like to remove.");
            orderDate = checkData.DateValidation();
            LoadOrdersResponse checkOrderDatesResponse = new LoadOrdersResponse();
            checkOrderDatesResponse = orderManager.DisplayOrders(orderDate);
            if (!checkOrderDatesResponse.Success)
            {
                Console.Write("There are no orders on that date.  Press a key to go back to the menu...");
                Console.ReadKey();
                return;
            }


            orderNumber = checkData.GetOrderNumber();
            response = orderManager.RetrieveOrder(orderDate, orderNumber.ToString());
            orderToRemove = response.SingleOrder;

            if (!response.Success)
            {
                Console.WriteLine("There are no orders with that number");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            ConsoleIO.DisplayOrder(orderToRemove, orderDate);


            Console.Write("Would you like to remove this order (Y/N)? ");
            while (true)
            {
                string confirm = Console.ReadLine();
                if (confirm.ToUpper() != "Y" && confirm.ToUpper() != "N")
                {
                    Console.WriteLine("Please enter Y or N");
                }
                else if (confirm.ToUpper() == "Y")
                {
                    Response removeResponse = new Response();
                    removeResponse = orderManager.RemoveOrder(response.SingleOrder, orderDate);
                    if (removeResponse.Success)
                    {
                        Console.WriteLine("Order successfully removed");
                    }
                    else
                    {
                        Console.WriteLine(removeResponse.Message);
                    }

                    Console.Write("Press any key to continue....");
                    Console.ReadKey();
                    break;
                }
            }


            
        }


    }
}
