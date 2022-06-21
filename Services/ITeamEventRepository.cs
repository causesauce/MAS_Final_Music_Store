using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public interface ITeamEventRepository
    {
        List<TeamEvent> GetAllTeamEvents();
        TeamEvent GetTeamEventById(int id);
        TeamEvent CreateTeamEvent(TeamEvent teamEvent);
        TeamEvent UpdateTeamEvent(int id, TeamEvent teamEvent);
        bool RemoveTeamEvent(int id);
    }
}
