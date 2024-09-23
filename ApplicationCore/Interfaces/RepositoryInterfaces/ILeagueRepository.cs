using Domain.Entites;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryInterfaces
{
    public interface ILeagueRepository
    {
        Task<League> AddNewLeague(League leagueToAdd, int numberOfRounds);
        Task<League> UpdateLeague(int leagueId, League leagueToUpdate);
        Task<League> GetLeagueDetails(int leagueId);
        Task<League> DeleteLeague(int leagueId);
    }
}
