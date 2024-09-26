using ApplicationCore.Interfaces.RepositoryInterfaces;
using Domain.Entites;
using Domain.Entities;
using League_Master.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly LeagueMasterDbContext _dbContext;

        public TeamRepository(LeagueMasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNewTeam(Team newTeam, List<Player> newPlayers)
        {
            var newStanding = new Standing();
            var result = 0;
            var activeSeason = newTeam.SeasonLeagues.LastOrDefault().Season;
            //var activeSeasonId = .Id;
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var newStandingResult = _dbContext.Standings.AddAsync(newStanding);
                    result = await _dbContext.SaveChangesAsync();

                    if (result > 0)
                    {
                        newTeam.StandingId = newStandingResult.Result.Entity.Id;
                        await _dbContext.Teams.AddAsync(newTeam);
                        result = await _dbContext.SaveChangesAsync();

                        if (result > 0)
                        {
                            foreach (var newPlayer in newPlayers)
                            {
                                var playerTeam = new PlayerTeam()
                                {
                                  //  SeasonId = activeSeason.Id,
                                    PlayerId = newPlayer.Id,
                                    TeamId = newTeam.Id
                                };
                                await _dbContext.PlayerTeams.AddAsync(playerTeam);
                            }
                            result = await _dbContext.SaveChangesAsync();
                        }
                    }
                    await dbContextTransaction.CommitAsync();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback(); //Required according to MSDN article 
                    throw; //Not in MSDN article, but recommended so the exception still bubbles up
                }
            }

            return result;
        }

        public Task<int> DeleteTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetTeamDetails(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateTeam(int teamId, Team teamToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
