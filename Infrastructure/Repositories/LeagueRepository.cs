using ApplicationCore.Interfaces.RepositoryInterfaces;
using Domain.Core.Enums;
using Domain.Entites;
using Domain.Entities;
using League_Master.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<League> AddNewLeague(League leagueToAdd)
        {
            await _dbContext.Leagues.AddAsync(leagueToAdd);

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

        public Task<int> DeleteLeague(int leagueId)
        {
            throw new NotImplementedException();
        }

        public Task<League> GetLeagueDetails(int leagueId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<League>> GetAllLeagues()
        {
            return await _dbContext.Leagues
            .Include(l => l.SeasonLeagues).ThenInclude(sl => sl.Season).ToListAsync();
        }

        public Task<League> UpdateLeague(int leagueId, League leagueToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<SeasonLeague> AddNewCompetition(SeasonLeague competitionToAdd)
        {
            await _dbContext.SesasonLeagues.AddAsync(competitionToAdd);

            try
            {
                var result = _dbContext.SaveChangesAsync();
                return competitionToAdd;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SeasonLeague> UpdateCompetition(int competitionId, SeasonLeague competitionToUpdate)
        {
            var updatedCompetition = await _dbContext.SesasonLeagues
                .FirstOrDefaultAsync(competition => competition.Id == competitionId);

            if (updatedCompetition is not null)
            {
                updatedCompetition.SeasonId = competitionToUpdate.SeasonId;
                updatedCompetition.LeagueId = competitionToUpdate.LeagueId;
                updatedCompetition.NumberOfRounds = competitionToUpdate.NumberOfRounds;
                updatedCompetition.NumberOfPlayOffRounds = competitionToUpdate.NumberOfPlayOffRounds;

                await _dbContext.SaveChangesAsync();
            }
            return updatedCompetition;
        }


        public async Task<List<SeasonLeague>> GetAllCompetitions()
        {
            return await _dbContext.SesasonLeagues
                  .Include(competition => competition.League)
                  .Include(competition => competition.Season)
                  .ToListAsync();
        }

        public async Task<SeasonLeague> GetCompetitionDetails(int competitionId)
        {
            return await _dbContext.SesasonLeagues
                   .Where(competition => competition.Id == competitionId)
                       //.Include(competition => competition.League)
                       //.Include(competition => competition.Season)
                       .FirstOrDefaultAsync();
        }

        public async Task<int> DeleteCompetition(int competitionId)
        {
            var competition = await _dbContext.SesasonLeagues.FindAsync(competitionId);

            if (competition is not null && competition.Status == CompetitionStatusEnum.Kreirana)
            {
                _dbContext.SesasonLeagues.Remove(competition);

                return await _dbContext.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<List<Season>> GetAllSeasons()
        {
            return await _dbContext.Seasons.ToListAsync();
        }
    }
}
