using Domain.Core.Responses;
using Domain.DTOs;
using Domain.Entites;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface ILeagueService
    {
        Task<ResponseBase> AddNewLeague(string leagueName, int numberOfRounds);
        Task<ResponseBase> UpdateLeague(int leagueId, LeagueCreateDTO leagueToUpdate);
        Task<ResponseBase> GetLeagues();
        Task<ResponseBase> GetLeagueDetails(int leagueId);
        Task<ResponseBase> DeleteLeague(int leagueId);
    }
}
