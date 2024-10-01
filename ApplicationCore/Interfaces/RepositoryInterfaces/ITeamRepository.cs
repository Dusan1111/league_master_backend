using Domain.Entites;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryInterfaces
{
    public interface ITeamRepository
    {
        Task<int> AddNewTeam(Team newTeam, int leagueId);
        Task<int> UpdateTeam(int teamId, Team teamToUpdate);
        Task<Team> GetTeamDetails(int teamId);
        Task<int> DeleteTeam(int teamId);
    }
}
