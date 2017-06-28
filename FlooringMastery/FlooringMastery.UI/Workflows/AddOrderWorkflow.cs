using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public static void Execute()
        {
            OrderManager orderManager = OrderManagerFactory.Create();
            IProductRepository productFile = ProductRepositoryFactory.Create();
            LoadProductsResponse loadedProducts = productFile.LoadProducts();

            DataEntryValidation checkData = new DataEntryValidation();
            Response response = new Response();
            Order holdOrder = new Order();
            string name, state, productType, area, date;
            decimal convertedArea;

            Console.Clear();
            Console.WriteLine("*********************Add Order********************");

            date = checkData.FutureDateValidation();

            Console.Write("Please enter the customer name (numbers, letters, periods, commas): ");
            name = Console.ReadLine();
            holdOrder.CustomerName = checkData.NameValidation(name);
            
            Console.Write("Please enter the two-letter state code: ");
            state = Console.ReadLine().ToUpper();
            holdOrder.State = checkData.StateValidation(state);

            Console.WriteLine();
            ConsoleIO.DisplayProducts(loadedProducts.ProductList);
            Console.Write("Please enter the product name from the list above: ");
            productType = Console.ReadLine();
            holdOrder.ProductType = checkData.ProdTypeValidation(productType);

            Console.Write("Please enter the area in square feet (must be at least 100 sq ft.): ");
            area = Console.ReadLine();
            convertedArea = checkData.AreaValidation(area);
            holdOrder.Area = convertedArea;

            LoadOrdersResponse checkResponse = orderManager.DisplayOrders(date);
            if (checkResponse.Success == true)
            {
                holdOrder.OrderNumber = checkResponse.Orders.Max(a => a.OrderNumber) + 1;
            }
            else
            {
                holdOrder.OrderNumber = 1;
            }

            Order calculatedOrder = checkData.CalculateValues(holdOrder);

            ConsoleIO.DisplayOrder(calculatedOrder, date);

            Console.Write("Would you like to save this new order (Y/N)? ");
            while (true)
            {
                string confirm = Console.ReadLine();
                if (confirm.ToUpper() != "Y" && confirm.ToUpper() !="N")
                {
                    Console.WriteLine("Please enter Y or N");
                }
                else if(confirm.ToUpper() == "N")
                {
                    return;
                }
                else
                {
                    break;
                }
            }

            response.Success = true;

            response = orderManager.AddOrder(calculatedOrder, date); 

            if (response.Success)
            {
                Console.WriteLine("Order successfully saved.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.ReadKey();
            }
        }
    }
}
