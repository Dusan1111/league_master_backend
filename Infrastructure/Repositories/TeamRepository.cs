using ApplicationCore.Interfaces.RepositoryInterfaces;
using Domain.Entites;
using League_Master.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly LeagueMasterDbContext _dbContext;

        public TeamRepository(LeagueMasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNewTeam(Team newTeam)
        {
            var newStanding = new Standing();
            var result = 0;
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                   var addNewTeamResult = await _dbContext.Teams.AddAsync(newTeam);
                    result = await _dbContext.SaveChangesAsync();
   
                    if (result > 0)
                    {
                        newStanding.TeamId = addNewTeamResult.Entity.Id;
                        var newStandingResult = _dbContext.Standings.AddAsync(newStanding);
                        result = await _dbContext.SaveChangesAsync();

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
