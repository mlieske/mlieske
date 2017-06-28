using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IOrderRepository
    {
        LoadOrdersResponse LoadOrder(string orderdate, string orderNumber);
        LoadOrdersResponse LoadAllOrders(string orderdate);
        Response SaveOrder(Order order, string date);
        Response RemoveOrder(Order order, string date);
    }
}
