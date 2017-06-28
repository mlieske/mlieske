using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class ProdProductRepository : IProductRepository
    {
        List<Product> productList = new List<Product>();
        LoadProductsResponse response = new LoadProductsResponse();
        string path = @"C:\sgbitbucket\michele-lieske-individual-work\flooringmastery\products.txt";

        public LoadProductsResponse LoadProducts()
        {
            string[] rows = File.ReadAllLines(path);
            for (int i = 1; i < rows.Length; i++) //skips header row
            {
                Product p = new Product();
                string[] columns = rows[i].Split(',');

                p.ProductType = columns[0];
                p.CostPerSquareFoot = decimal.Parse(columns[1]);
                p.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                productList.Add(p);
            }
            if (productList.Count() != 0)
            {
                response.Success = true;
                response.ProductList = productList;
            }
            else
            {
                response.Success = false;
                response.Message = "Products list did not load";
            }

            return response;

        }
    }
}
