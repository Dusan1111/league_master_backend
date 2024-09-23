using Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryInterfaces
{
    public interface ITeamRepository
    {
        Task<int> AddNewTeam(Team newTeam, List<Player> newPlayers);
        Task<int> UpdateTeam(int teamId, Team teamToUpdate);
        Task<Team> GetTeamDetails(int teamId);
        Task<int> DeleteTeam(int teamId);
    }
}
