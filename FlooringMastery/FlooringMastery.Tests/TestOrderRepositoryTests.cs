using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class TestOrderRepositoryTests
    {
        [Test]
        public void TestOrderRepositoryLoadAll()
        {
            OrderManager repo = OrderManagerFactory.Create();
            LoadOrdersResponse response = new LoadOrdersResponse();
            response = repo.DisplayOrders("06122017");

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(3, response.Orders.Count());
        }


        [TestCase("06122017", 1, "1", true)]
        public void TestOrderManagerFactoryLoadOneWithMatch(string date, int orderNumInt, string orderNumber, bool result)
        {
            OrderManager repository = OrderManagerFactory.Create();
            LoadOrdersResponse response = new LoadOrdersResponse();
            response = repository.RetrieveOrder(date, orderNumber);

            Assert.AreEqual(result, response.Success);
            Assert.AreEqual(orderNumInt, response.SingleOrder.OrderNumber);
        }

        [Test]
        public void TestAddOrderToRepository()
        {
            OrderManager orderManager = OrderManagerFactory.Create();
            Response response = new Response();
            Order order = new Order
            {
                OrderNumber = 4,
                CustomerName = "My Test Order4",
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
            };
            response = orderManager.AddOrder(order, "06102017");
            Assert.AreEqual(true, response.Success);
        }
    }
}
