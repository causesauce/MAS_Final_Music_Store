using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        Order CreateOrder(Order order);
        Order UpdateOrder(int id, Order order);
        bool RemoveOrder(int id);
    }
}
