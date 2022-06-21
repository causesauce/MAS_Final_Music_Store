using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [MinLength(2, ErrorMessage = "Team Name cannot be less than 2")]
        public string Name { get; set; }
        [Range(0, 20)]
        public int MembersNum { get { return Members.Count; } }
        public HashSet<Person> Members { get; set; } = new();
        public HashSet<Person> Managers { get; set; } = new();
        public HashSet<TeamEvent> TeamEvents { get; set; } = new();

    }
}
