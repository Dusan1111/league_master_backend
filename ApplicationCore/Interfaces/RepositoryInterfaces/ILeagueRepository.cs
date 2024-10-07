using Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryInterfaces
{
    public interface ILeagueRepository
    {
        Task<League> AddNewLeague(League leagueToAdd);
        Task<League> UpdateLeague(int leagueId, League leagueToUpdate);
        Task<List<League>> GetAllLeagues();
        Task<League> GetLeagueDetails(int leagueId);
        Task<League> DeleteLeague(int leagueId);
    }
}
