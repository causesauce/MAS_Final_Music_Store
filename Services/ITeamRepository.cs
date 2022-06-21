using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public interface ITeamRepository
    {
        List<Team> GetAllTeams();
        Team GetTeamById(int id);
        Team UpdateTeam(int id, Team team);
        Team CreateTeam(Team team);
        bool RemoveTeam(int id);

    }
}
