using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public class TeamEvent
    {
        public int TeamEventId { get; set; }
        [MinLength(2, ErrorMessage = "TeamEvent DutiesDesc cannot be less than 2")]
        public string DutiesDesc { get; set; }
        public int TeamId { get; set; }
        public Team TeamIdNavigation { get; set; }
        public int EventId { get; set; }
        public Event EventIdNavigation { get; set; }
    }
}
