using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public abstract class Instrument : IInstrument
    {
        public int InstrumentId { get; set; }
        [MinLength(5, ErrorMessage = "Instrument Name cannot be less than 5")]
        public string Name { get; set; }
        [Range(0.01, double.MaxValue)]

        public double Price { get; set; }
        [MinLength(5, ErrorMessage = "Instrument Description cannot be less than 5")]

        public string Description { get; set; }
        public byte[] Photo { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public HashSet<OrderInstrument> OrderInstruments { get; set; } = new();
        public HashSet<EventInstrument> EventInstruments { get; set; } = new();

        public HashSet<Review> Reviews { get; set; } = new();

        public int BrandId { get; set; }
        public Brand BrandIdNavigation { get; set; }


        public virtual void CopyData(IInstrument instrument)
        {
            var instrumentCasted = (Instrument)instrument;
            Name = instrumentCasted.Name;
            Price = instrumentCasted.Price;
            Description = instrumentCasted.Description;
            Photo = instrumentCasted.Photo;
            Quantity = instrumentCasted.Quantity;
            BrandId = instrumentCasted.BrandId;
        }

        
    }
}
