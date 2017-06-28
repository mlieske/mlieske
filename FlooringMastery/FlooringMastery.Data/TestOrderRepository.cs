using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.IO;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data
{
    public class TestOrderRepository : IOrderRepository
    {
        private static List<Order> _orders = new List<Order>();

        public TestOrderRepository()
        {
            if (!_orders.Any())
            {
                    _orders.AddRange(new List<Order>()
                {
                    new Order
                    {
                        OrderNumber = 1,
                        CustomerName = "My Test Order",
                        State = "MN",
                        TaxRate = 3.5M,
                        ProductType = "Wood",
                        Area = 100m,
                        CostPerSquareFoot = 4.50M,
                        LaborCostPerSquareFoot = 4M,
                        MaterialCost = 3M,
                        LaborCost = 5.35M,
                        Tax = 0M,
                        Total = 0M
                    },
                    new Order
                    {
                        OrderNumber = 2,
                        CustomerName = "My Test Order2",
                        State = "MN",
                        TaxRate = 3.5M,
                        ProductType = "Wood",
                        Area = 100m,
                        CostPerSquareFoot = 4.50M,
                        LaborCostPerSquareFoot = 4M,
                        MaterialCost = 3M,
                        LaborCost = 5.35M,
                        Tax = 0M,
                        Total = 0M
                    },
                    new Order
                    {
                        OrderNumber = 3,
                        CustomerName = "My Test Order3",
                        State = "MN",
                        TaxRate = 3.5M,
                        ProductType = "Wood",
                        Area = 100m,
                        CostPerSquareFoot = 4.50M,
                        LaborCostPerSquareFoot = 4M,
                        MaterialCost = 3M,
                        LaborCost = 5.35M,
                        Tax = 0M,
                        Total = 0M
                    },
                });
            }
        }
        


   

    public LoadOrdersResponse LoadAllOrders(string orderDate)
        {
            LoadOrdersResponse response = new LoadOrdersResponse();
            response.Orders = _orders;
            response.Success = true;
            //response.Date = orderDate;
            return response;
        }

        public LoadOrdersResponse LoadOrder(string orderDate,string orderNumber)
        {
            LoadOrdersResponse response = new LoadOrdersResponse();
            response.Success = true;
            var result = _orders.Where(a => a.OrderNumber.ToString() == orderNumber).Single();
            response.SingleOrder = result;
            //response.Date = orderDate;
            return response;
        }

        public Response SaveOrder(Order order,string orderDate)
        {

            Response response = new Response();
            _orders.Add(order);
            response.Success = true;
            return response;
        }

        public Response RemoveOrder(Order order, string date)
        {
            Response response = new Response();
            _orders.Remove(order);
            response.Success = true;
            return response;

        }
    }
}
