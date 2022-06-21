using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.DTOs
{
    public class WorkerDto : PersonDto
    {
        public double Salary { get; set; }
        public WorkerType WorkerType { get; set; }
        public int? MemberTeamId { get; set; }
        public int? ManagerTeamId { get; set; }

    }
}
