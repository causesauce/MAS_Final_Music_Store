using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public interface IOrderInstrumentRepository
    {
        List<OrderInstrument> GetAllOrderInstruments();
        OrderInstrument GetOrderInstrumentByIds(int orderId, int instrumentId);
        OrderInstrument CreateOrderInstrument(OrderInstrument oi);
        OrderInstrument UpdateOrderInstrument(int orderId, int instrumentId, OrderInstrument oi);
        bool RemoveOrderInstrument(int orderId, int instrumentId);
    }
}
