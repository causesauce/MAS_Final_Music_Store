using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [MinLength(10, ErrorMessage = "Contract Content cannot be less than 10 characters")]
        public string Content { get; set; }

        public int _brandId { get; set; }
        public int BrandId { 
            get { return _brandId; }
            set 
            { 
                if(_brandId != 0)
                {
                    throw new ArgumentException("Changing of brand's id violates Composition association");
                }
                _brandId = value;
            }
        }
        private Brand _brandIdNavigation;
        public Brand BrandIdNavigation 
        {
            get { return _brandIdNavigation; }
            set 
            {
                if (_brandIdNavigation is not null) 
                    throw new ArgumentException("Changing of brand reference violates Composition association");

                _brandIdNavigation = value;
            }
        }
    }
}
