using ApplicationCore.Interfaces.RepositoryInterfaces;
using Domain.Entites;
using League_Master.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly LeagueMasterDbContext _dbContext;

        public StatisticsRepository(LeagueMasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Standing>> GetLeagueStandings(int leagueId, int seasonId)
        {
            var teamsInLeagueIds =  await _dbContext.SeasonLeagues
                .Where(sl => sl.LeagueId == leagueId && sl.SeasonId == seasonId)
                .Select(x => x.TeamId)
                .ToListAsync();

            return await _dbContext.Standings
                 .Where(standing => teamsInLeagueIds.Contains(standing.Id))
                 .Include(standing => standing.Team)
                 .OrderByDescending(x => x.TotalPoints)
                 .ToListAsync();
        }
    }
}
