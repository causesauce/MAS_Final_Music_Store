using MAS_Final_Music_Store.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    class TeamRepository : ITeamRepository
    {
        private readonly Context _context;

        public TeamRepository(Context context)
        {
            _context = context;
        }

        public Team CreateTeam(Team team)
        {
            var newTeam = new Team
            {
                Name = team.Name
            };

            _context.Teams.Add(newTeam);
            _context.SaveChanges();
            return newTeam;
        }

        public List<Team> GetAllTeams()
        {
            return _context.Teams.Include(t => t.Members).ToList();
        }

        public Team GetTeamById(int id)
        {
            return _context.Teams.Where(t => t.TeamId == id).Include(t => t.Members).FirstOrDefault();
        }

        public bool RemoveTeam(int id)
        {
            var team = GetTeamById(id);
            if(team is null)
            {
                return false;
            }

            _context.Teams.Remove(team);
            _context.SaveChanges();
            return true;
        }

        public Team UpdateTeam(int id, Team team)
        {
            var editedTeam = GetTeamById(id);
            if (editedTeam is null)
            {
                return null;
            }

            editedTeam.Name = team.Name;
            _context.SaveChanges();
            return editedTeam;
        }
    }
}
