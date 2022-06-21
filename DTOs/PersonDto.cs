using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.DTOs
{
    public class PersonDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public HashSet<PersonType> PersonTypes { get; set; }

        public bool ChangePersonalData { get; set; }
    }
}
