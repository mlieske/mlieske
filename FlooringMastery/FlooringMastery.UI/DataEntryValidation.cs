using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public class DataEntryValidation
    {
        public LoadTaxFileResponse LoadedTaxes { get;}
        public LoadProductsResponse LoadedProducts { get;}
        ITaxRepository taxFile = TaxRepositoryFactory.Create();
        IProductRepository productFile = ProductRepositoryFactory.Create();

        public DataEntryValidation()
        {
            LoadedTaxes = taxFile.LoadTaxes();
            LoadedProducts = productFile.LoadProducts();
        }

        public string FutureDateValidation()
        {
            string date;
            DateTime convertedDate;
            string dateForFile;
            while (true)
            {
                Console.Write("Please enter the date in this format mm/dd/yyyy:  ");
                date = Console.ReadLine();
                
                if (DateTime.TryParse(date, out convertedDate))
                {
                    if (convertedDate < DateTime.Now.Date)
                    {
                        Console.WriteLine("Date must be today or later");
                    }
                    else
                    {
                        string[] dateParts = convertedDate.ToString().Split('/',' ');
                        dateForFile = dateParts[0].PadLeft(2,'0') + dateParts[1].PadLeft(2,'0') + dateParts[2];
                        return dateForFile;
                    }
                }
                else
                {
                    Console.WriteLine("Please make sure you are entering in mm/dd/yyyy format");
                }
            }
        }

        public string DateValidation()
        {
            string date;
            DateTime convertedDate;
            string dateForFile;
            while (true)
            {
                Console.Write("Please enter the date in this format mm/dd/yyyy:  ");
                date = Console.ReadLine();

                if (DateTime.TryParse(date, out convertedDate))
                {
                        string[] dateParts = convertedDate.ToString().Split('/', ' ');
                        dateForFile = dateParts[0].PadLeft(2, '0') + dateParts[1].PadLeft(2, '0') + dateParts[2];
                        return dateForFile;
                }
                else
                {
                    Console.WriteLine("Please make sure you are entering in mm/dd/yyyy format");
                }
            }
        }

        public string NameValidation(string nameToReturn)
        {
            while (true)
            { 
                if (nameToReturn.All(c => Char.IsLetterOrDigit(c) || c == '.' || c == ' '))
                {
                    if (nameToReturn != "")
                    {
                        return nameToReturn;
                    }
                    else
                    {
                        Console.WriteLine("You must enter a company name.");
                        Console.Write("Please enter the customer name (numbers, letters, periods): ");
                        nameToReturn = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Name can only include numbers, letters,and periods");
                    Console.Write("Please enter the customer name (numbers, letters, periods): ");
                    nameToReturn = Console.ReadLine();
                }
            }
        }

        public string StateValidation(string state)
        {
            while (true)
            {
                if (state.Length != 2 || !state.All(c => Char.IsLetter(c)))
                {
                    Console.WriteLine("Please be sure to enter the state in a two-letter format.");
                    Console.Write("Please enter the two-letter state code: ");
                    state = Console.ReadLine().ToUpper();
                }
                else
                {
                    var result = LoadedTaxes.TaxList.Any(a => a.StateAbbreviation == state);
                    if (!result)
                    {
                        Console.WriteLine($"I'm sorry, we are not authorized to sell in {state}.");
                        Console.Write("Please enter the two-letter state code: ");
                        state = Console.ReadLine().ToUpper();
                    }
                    else
                    {
                        return state;
                    }
                }
            }
        }

        public string ProdTypeValidation(string productType)
        {
            while (true)
            {
                if (!LoadedProducts.ProductList.Any(a => a.ProductType.ToUpper() == productType.ToUpper()))
                {
                    Console.Write("Please enter the product name from the list above: ");
                    productType = Console.ReadLine();
                }
                else
                {
                    productType = productType.Substring(0, 1).ToUpper() + productType.Substring(1).ToLower();
                    return productType;
                }
            }
        }

        public decimal AreaValidation(string area)
        {
            while (true)
            {
                if (decimal.TryParse(area, out decimal convertedArea))
                {
                    if (convertedArea >= 100)
                    {
                        return convertedArea;
                    }
                    else
                    {
                        Console.WriteLine("Area must be at least 100");
                        Console.Write("Please enter the area in square feet (must be at least 100 sq ft.): ");
                        area = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Please enter the area as just a number");
                    Console.Write("Please enter the area in square feet (must be at least 100 sq ft.): ");
                    area = Console.ReadLine();
                }
            }
        }

        public int GetOrderNumber()
        {
            while (true)
            {
                int orderNumber;
                Console.Write("Please enter the order number: ");
                string getOrder = Console.ReadLine();
                if (int.TryParse(getOrder, out orderNumber))
                {
                    return orderNumber;
                }
                else
                {
                    Console.WriteLine("Please enter a number for the order number");
                }
            }
        }

        public Order CalculateValues(Order order)
        {
            var taxRate = LoadedTaxes.TaxList.Where(a => a.StateAbbreviation == order.State)
                .Select(b => b.TaxRate).Single();
            order.TaxRate = taxRate;

            var cost = LoadedProducts.ProductList.Where(a => a.ProductType.ToUpper() == order.ProductType.ToUpper())
                .Select(b => b.CostPerSquareFoot).Single();
            order.CostPerSquareFoot = cost;

            var labor = LoadedProducts.ProductList.Where(a => a.ProductType.ToUpper() == order.ProductType.ToUpper())
                .Select(b => b.LaborCostPerSquareFoot).Single();
            order.LaborCostPerSquareFoot = labor;

            order.MaterialCost = Math.Round(order.Area * order.CostPerSquareFoot,2);
            order.LaborCost = Math.Round(order.Area * order.LaborCostPerSquareFoot,2);
            order.Tax = Math.Round(((order.MaterialCost + order.LaborCost) * (order.TaxRate / 100)),2);
            order.Total = Math.Round(order.MaterialCost + order.LaborCost + order.Tax,2);

            return order;
        }
    }
}
