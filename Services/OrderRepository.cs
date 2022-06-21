using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public Order CreateOrder(Order order)
        {
            var newOrder = new Order
            {
                Description = order.Description,
                DeliveryAddress = order.DeliveryAddress,
                OrderIsPaid = order.OrderIsPaid,
                CustomerId = order.CustomerId
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return newOrder;
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Where(o => o.OrderId == id).FirstOrDefault();
        }

        public bool RemoveOrder(int id)
        {
            var order = GetOrderById(id);
            if (order is null)
            {
                return false;
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();
            return true;
        }

        public Order UpdateOrder(int id, Order order)
        {
            var updatedOrder = GetOrderById(id);
            if (updatedOrder is null)
            {
                return null;
            }

            updatedOrder.Description = order.Description;
            updatedOrder.DeliveryAddress = order.DeliveryAddress;
            updatedOrder.OrderIsPaid = order.OrderIsPaid;

            _context.SaveChanges();
            return updatedOrder;
        }
    }
}
