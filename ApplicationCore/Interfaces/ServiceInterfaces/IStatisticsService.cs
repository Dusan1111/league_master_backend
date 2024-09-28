
using Domain.Core.Responses;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface IStatisticsService
    {
        Task<ResponseBase> GetLeagueStandings(int leagueId, int seasonId);
    }
}
