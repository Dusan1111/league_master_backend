using Domain.Entites;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface ILeagueService
    {
        Task<League> AddNewLeague(string leagueName, int numberOfRounds);
        Task<League> UpdateLeague(int leagueId, League leagueToUpdate);
        Task<League> GetLeagueDetails(int leagueId);
        Task<League> DelegeLeague(int leagueId);
    }
}
