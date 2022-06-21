using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.DTOs
{
    public class CustomerDto : PersonDto
    {
        [Range(0, double.MaxValue)]
        public double Balance { get; set; }

        [Range(0, double.MaxValue)]
        public double BonusPoints { get; set; }
    }
}
