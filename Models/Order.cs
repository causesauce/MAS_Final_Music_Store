using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Description { get; set; }
        public string DeliveryAddress { get; set; }
        public bool OrderIsPaid { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public Person CustomerIdNavigation { get; set; }
        public HashSet<OrderInstrument> OrderInstruments { get; set; } = new();

        
    }
}
