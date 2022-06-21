using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        [MinLength(1, ErrorMessage = "Brand Name cannot be less than 1")]
        public string Name { get; set; }
        public DateTime YearEstablished { get; set; }
        public byte[] Logo { get; set; }

        public HashSet<Contract> Contracts { get; set; } = new();
        public HashSet<Instrument> Instruments { get; set; } = new();
    }
}
