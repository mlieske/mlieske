using FlooringMastery.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*********************************");
                Console.WriteLine("Flooring Program");
                Console.WriteLine();
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("5. Quit");
                Console.WriteLine();
                Console.WriteLine("*********************************");
                Console.WriteLine();
                Console.Write("Enter your choice: ");

                string menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        DisplayOrdersWorkflow.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow.Execute();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Please select one of the menu items. Press a key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
