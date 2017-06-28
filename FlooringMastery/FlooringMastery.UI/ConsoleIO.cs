using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrder(Order order, string date)
        {
            string formattedDate = date.Substring(0, 2) + "/" + date.Substring(2, 2) + "/" + date.Substring(4, 4);
            Console.WriteLine("**************************************************");
            Console.WriteLine();
            Console.WriteLine($"{order.OrderNumber} | {formattedDate}");
            Console.WriteLine(order.CustomerName);
            Console.WriteLine(order.State);
            Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"Materials: {order.MaterialCost:c}");
            Console.WriteLine($"Labor: {order.LaborCost:c}");
            Console.WriteLine($"Tax: {order.Tax:c}");
            Console.WriteLine($"Total: {order.Total:c}");
            Console.WriteLine();
            Console.WriteLine("**************************************************");
        }

        public static void DisplayAllOrders(List<Order> orders, string date)
        {
            Console.Clear();
            foreach(var order in orders)
            {
                DisplayOrder(order, date);
            }
            Console.Write("Press any key to continue....");
            Console.ReadKey();
        }

        public static void DisplayProducts(List<Product> products)
        {
            foreach(var product in products)
            {
                Console.WriteLine($"Product Name: {product.ProductType,-10} Price: {product.CostPerSquareFoot:c}");
            }
        }
    }
}
