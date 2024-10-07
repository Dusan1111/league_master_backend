using Domain.Core.Responses;
using Domain.DTOs;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface ILeagueService
    {
        Task<ResponseBase> AddNewLeague(LeagueCreateDTO leagueCreateDTO);
        Task<ResponseBase> UpdateLeague(int leagueId, LeagueCreateDTO leagueToUpdate);
        Task<ResponseBase> GetLeagues();
        Task<ResponseBase> GetLeagueDetails(int leagueId);
        Task<ResponseBase> DeleteLeague(int leagueId);
    }
}
