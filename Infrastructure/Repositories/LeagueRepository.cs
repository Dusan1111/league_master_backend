using ApplicationCore.Interfaces.RepositoryInterfaces;
using Domain.Entites;
using League_Master.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly LeagueMasterDbContext _dbContext;

        public LeagueRepository(LeagueMasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<League> AddNewLeague(League leagueToAdd, int numberOfRounds)
        {
            var addedLeague = await _dbContext.Leagues.AddAsync(leagueToAdd);

            for(int i = 1; i <= numberOfRounds; i++)
            {
                var addedRound = new Round()
                {
                    LeagueId = addedLeague.Entity.Id,
                    Name = "Kolo " + i
                };
                await _dbContext.Rounds.AddAsync(addedRound);
            }
            try
            {
                var result = _dbContext.SaveChangesAsync();

                return leagueToAdd;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<League> DeleteLeague(int leagueId)
        {
            throw new NotImplementedException();
        }

        public Task<League> GetLeagueDetails(int leagueId)
        {
            throw new NotImplementedException();
        }

        public Task<League> UpdateLeague(int leagueId, League leagueToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
