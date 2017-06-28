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
    public class EditOrderWorkflow
    {
        
        public static void Execute()
        {
            string getDate;
            int orderNumber;
            IProductRepository productFile = ProductRepositoryFactory.Create();
            LoadProductsResponse loadedProducts = productFile.LoadProducts();

            Order updatedOrder = new Order();
            DataEntryValidation checkData = new DataEntryValidation();
            LoadOrdersResponse response = new LoadOrdersResponse();
            OrderManager orderManager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("*****************Edit An Order*******************");
            Console.WriteLine();

            Console.WriteLine("Enter the date the order was placed.");
            getDate = checkData.DateValidation();
            LoadOrdersResponse checkOrderDatesResponse = new LoadOrdersResponse();
            checkOrderDatesResponse = orderManager.DisplayOrders(getDate);
            if (!checkOrderDatesResponse.Success)
            {
                Console.Write("There are no orders on that date.  Press a key to go back to the menu...");
                Console.ReadKey();
                return;
            }
            //Console.WriteLine("converted date " + getDate);

            orderNumber = checkData.GetOrderNumber();
            response = orderManager.RetrieveOrder(getDate, orderNumber.ToString());
            if (!response.Success)
            {
                Console.Write("There are no orders with that order number.  Press a key to go back to the menu...");
                Console.ReadKey();
                return;
            }
            updatedOrder = response.SingleOrder;

            string getName, newName;
            Console.WriteLine($"Current Customer Name is: {response.SingleOrder.CustomerName}");
            Console.Write("Updated Customer Name (Press enter to leave as is): ");
            getName = Console.ReadLine();
            if(getName != "")
            {
                newName = checkData.NameValidation(getName);
                updatedOrder.CustomerName = newName;
            }

            string getState, newState;
            Console.WriteLine($"Current State is: {response.SingleOrder.State}");
            Console.Write("Updated State Name (Press enter to leave as is): ");
            getState = Console.ReadLine().ToUpper();
            if (getState != "")
            {
                newState = checkData.StateValidation(getState);
                updatedOrder.State = newState;
            }

            string getProduct, newProduct;
            Console.WriteLine("Full Products List:");
            ConsoleIO.DisplayProducts(loadedProducts.ProductList);
            Console.WriteLine($"Current Product Type is: {response.SingleOrder.ProductType}");
            Console.Write("Updated Product Type from list above (Press enter to leave as is): ");
            getProduct = Console.ReadLine();
            if (getProduct != "")
            {
                newProduct = checkData.ProdTypeValidation(getProduct);
                updatedOrder.ProductType = newProduct;
            }

            string getArea;
            decimal newArea;
            Console.WriteLine($"Current Area is: {response.SingleOrder.Area}");
            Console.Write("Updated Area (Press enter to leave as is): ");
            getArea = Console.ReadLine();
            if (getArea != "")
            {
                newArea = checkData.AreaValidation(getArea);
                updatedOrder.Area = newArea;
            }

            Order calculatedOrder = checkData.CalculateValues(updatedOrder);
            ConsoleIO.DisplayOrder(calculatedOrder,getDate);

            Console.Write("Would you like to save this new order (Y/N)? ");
            while (true)
            {
                string confirm = Console.ReadLine();
                if (confirm.ToUpper() != "Y" && confirm.ToUpper() != "N")
                {
                    Console.WriteLine("Please enter Y or N");
                }
                else if (confirm.ToUpper() == "N")
                {
                    return;
                }
                else
                {
                    break;
                }

            }


            Response removeResponse = new Response();
            removeResponse = orderManager.RemoveOrder(calculatedOrder, getDate);

            Response addResponse = new Response();
            addResponse = orderManager.AddOrder(calculatedOrder,getDate); 
            
            if(removeResponse.Success && addResponse.Success)
            {
                Console.WriteLine("Order updated successfully");
            }
            else if (!removeResponse.Success)
            {
                Console.WriteLine($"Order update failed: {removeResponse.Message}" );
            }
            else
            {
                Console.WriteLine($"Order update failed: {addResponse.Message}");
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            
        }
    }
}
