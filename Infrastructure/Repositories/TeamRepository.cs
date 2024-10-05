using ApplicationCore.Interfaces.RepositoryInterfaces;
using Domain.Entites;
using Domain.Entities;
using League_Master.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<int> AddNewTeam(Team newTeam, int leagueId)
        {
            var newStanding = new Standing();
            var newTeamLeague = new TeamLeague();
            var result = 0;

            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var addNewTeamResult = await _dbContext.Teams.AddAsync(newTeam);
                    result = await _dbContext.SaveChangesAsync();
   
                    if (result > 0)
                    {                              
                        var addedTeamId = addNewTeamResult.Entity.Id;
                        newStanding.TeamId = addedTeamId;
                        await _dbContext.Standings.AddAsync(newStanding);

                        newTeamLeague.TeamId = addedTeamId;
                        newTeamLeague.LeagueId = leagueId;

                        var addTeamToLeagueResult = await _dbContext.TeamLeagues.AddAsync(newTeamLeague);
                        
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

        public async Task<List<Team>> GetAllTeams()
        {
            return await _dbContext.Teams.ToListAsync();
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
