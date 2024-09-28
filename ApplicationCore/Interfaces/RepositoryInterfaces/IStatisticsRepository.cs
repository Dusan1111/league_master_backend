using Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryInterfaces
{
    public interface IStatisticsRepository
    {
        Task<List<Standing>> GetLeagueStandings(int leagueId, int seasonId);
    }
}
