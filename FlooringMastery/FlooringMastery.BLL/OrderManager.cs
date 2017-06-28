using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderManager { get; set; }

        public OrderManager(IOrderRepository repository)
        {
            _orderManager = repository;
        }

        public LoadOrdersResponse RetrieveOrder(string date, string orderNumber)
        {
            LoadOrdersResponse response = new LoadOrdersResponse();
            response = _orderManager.LoadOrder(date, orderNumber);
            return response;
        }

        public LoadOrdersResponse DisplayOrders(string date)
        {
            LoadOrdersResponse response = new LoadOrdersResponse();
            response = _orderManager.LoadAllOrders(date);
            return response;
        }

        public Response AddOrder(Order order, string date)
        {
            Response response = new Response();
            response = _orderManager.SaveOrder(order, date);
            return response;
        }

        public Response RemoveOrder(Order orderToRemove, string date)
        {
            Response response = new Response();
            response = _orderManager.RemoveOrder(orderToRemove, date);
            return response;
        }
    }
}
