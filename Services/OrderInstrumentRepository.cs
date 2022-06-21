using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public class OrderInstrumentRepository : IOrderInstrumentRepository
    {

        private readonly Context _context;
        public OrderInstrumentRepository(Context context)
        {
            _context = context;
        }
        public OrderInstrument CreateOrderInstrument(OrderInstrument oi)
        {
            var newOrderInstrument = new OrderInstrument
            {
                OrderId = oi.OrderId,
                InstrumentId = oi.InstrumentId,
                Quantity = oi.Quantity
            };

            _context.OrderInstruments.Add(newOrderInstrument);
            _context.SaveChanges();
            return newOrderInstrument;
        }

        public OrderInstrument GetOrderInstrumentByIds(int orderId, int instrumentId)
        {
            return _context.OrderInstruments.Where(oi => oi.OrderId == orderId && oi.InstrumentId == instrumentId ).FirstOrDefault();
        }

        public List<OrderInstrument> GetAllOrderInstruments()
        {
            return _context.OrderInstruments.ToList();
        }

        public bool RemoveOrderInstrument(int orderId, int instrumentId)
        {
            var orderInstrument = GetOrderInstrumentByIds(orderId, instrumentId);
            if(orderInstrument is null)
            {
                return false;
            }

            _context.OrderInstruments.Remove(orderInstrument);
            _context.SaveChanges();
            return true;
        }

        public OrderInstrument UpdateOrderInstrument(int orderId, int instrumentId, OrderInstrument oi)
        {
            var updatedOrderInstrument = GetOrderInstrumentByIds(orderId, instrumentId);
            if (updatedOrderInstrument is null)
            {
                return null;
            }

            updatedOrderInstrument.Quantity = oi.Quantity;
            _context.SaveChanges();
            return updatedOrderInstrument;
        }
    }
}
