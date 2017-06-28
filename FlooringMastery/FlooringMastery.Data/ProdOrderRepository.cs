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
    public class ProdOrderRepository : IOrderRepository
    {
        public string path { get; set; }

        private void SetPath(string orderDate)
        {
            path = @"C:\sgbitbucket\michele-lieske-individual-work\flooringmastery\Orders\Orders_" + orderDate + ".txt";
        }

        public LoadOrdersResponse LoadAllOrders(string orderDate)
        {
            List<Order> orders = new List<Order>();
            LoadOrdersResponse response = new LoadOrdersResponse();
            SetPath(orderDate);
            if (!File.Exists(path))
            {
                response.Success = false;
                response.Message = "There are no orders for that date.";
            }
            else
            {
                string[] rows = File.ReadAllLines(path);

                for (int i = 1; i < rows.Length; i++) //skips header row
                {
                    Order o = new Order();
                    string[] columns = rows[i].Split(',');

                    o.OrderNumber = int.Parse(columns[0]);
                    o.CustomerName = columns[1];
                    o.State = columns[2];
                    o.TaxRate = decimal.Parse(columns[3]);
                    o.ProductType = columns[4];
                    o.Area = decimal.Parse(columns[5]);
                    o.CostPerSquareFoot = decimal.Parse(columns[6]);
                    o.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                    o.MaterialCost = decimal.Parse(columns[8]);
                    o.LaborCost = decimal.Parse(columns[9]);
                    o.Tax = decimal.Parse(columns[10]);
                    o.Total = decimal.Parse(columns[11]);

                    orders.Add(o);
                }
                if (orders.Count() != 0)
                {
                    response.Success = true;
                    response.Orders = orders;
                    //response.Date = orderDate;
                }
                else
                {
                    response.Success = false;
                    response.Message = "There are no orders for that date.";
                }
            }
            return response;
        }

        public LoadOrdersResponse LoadOrder(string orderDate, string orderNumber)
        {
            LoadOrdersResponse response = new LoadOrdersResponse();
            LoadOrdersResponse orderList = new LoadOrdersResponse();

            orderList = LoadAllOrders(orderDate);
            
            if (orderList.Success != false && orderList.Orders.Count() > 0)
            {
                var result = orderList.Orders.Where(a => a.OrderNumber.ToString() == orderNumber);
                if (result.Count() > 0 )
                {
                    response.Success = true;
                    response.SingleOrder = result.Single();
                }
            }
            else
            {
                response.Success = false;
                response.Message = $"Order number {orderNumber} was not found.";
            }
            return response;
        }

        public Response SaveOrder(Order order, string date)
        {
            Response response = new Response();
            try
            {
                SetPath(date);
                if (!File.Exists(path))
                {
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot," +
                            "LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                    }
                }
                
                using (StreamWriter writer = File.AppendText(path))
                    {
                        writer.WriteLine($"{order.OrderNumber},{order.CustomerName},{order.State},{order.TaxRate},{order.ProductType}," +
                            $"{order.Area},{order.CostPerSquareFoot},{order.LaborCostPerSquareFoot},{order.MaterialCost}," +
                            $"{order.LaborCost},{order.Tax},{order.Total}");
                    }
                response.Success = true;
            }
            catch
            {
                response.Success = false;
                response.Message = "Order could not be saved.";
            }

            return response;
        }

        public Response RemoveOrder(Order newOrder, string date)
        {
            LoadOrdersResponse response = new LoadOrdersResponse();

            try
            {
                SetPath(date);
                response = LoadAllOrders(date);
                var result = response.Orders.Where(a => a.OrderNumber != newOrder.OrderNumber);
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot," +
                        "LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                }
                using (StreamWriter writer = File.AppendText(path))
                {
                    foreach (var order in result)
                    {
                        writer.WriteLine($"{order.OrderNumber},{order.CustomerName},{order.State},{order.TaxRate},{order.ProductType}," +
                            $"{order.Area},{order.CostPerSquareFoot},{order.LaborCostPerSquareFoot},{order.MaterialCost}," +
                            $"{order.LaborCost},{order.Tax},{order.Total}");
                    }
                }
                response.Success = true;
            }
            catch
            {
                response.Success = false;
                response.Message = "Was not able to remove the order";
            }

            return response;
        }


    }



}

