using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Responses;
using FlooringMastery.Models;
using System.IO;

namespace FlooringMastery.Data
{
    public class TestProductRepository : IProductRepository
    {
        Product testProduct = new Product
        {
            ProductType = "Wood",
            CostPerSquareFoot = 4.5M,
            LaborCostPerSquareFoot = 4M
        };

        List<Product> productList = new List<Product>();
        LoadProductsResponse response = new LoadProductsResponse();

        public LoadProductsResponse LoadProducts()
        {
            LoadProductsResponse response = new LoadProductsResponse();
            productList.Add(testProduct);
            response.Success = true;
            response.ProductList = productList;
            return response;
        }
    }
}
