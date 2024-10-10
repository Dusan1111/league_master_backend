using Domain.Entites;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryInterfaces
{
    public interface ILeagueRepository
    {
        Task<League> AddNewLeague(League leagueToAdd);
        Task<League> UpdateLeague(int leagueId, League leagueToUpdate);
        Task<List<League>> GetAllLeagues();
        Task<League> GetLeagueDetails(int leagueId);
        Task<int> DeleteLeague(int leagueId);


        Task<SeasonLeague> AddNewCompetition(SeasonLeague competitionToAdd);
        Task<SeasonLeague> UpdateCompetition(int competitionId, SeasonLeague competitionToUpdate);
        Task<List<SeasonLeague>> GetAllCompetitions();
        Task<SeasonLeague> GetCompetitionDetails(int competitionId);
        Task<int> DeleteCompetition(int competitionId);

        Task<List<Season>> GetAllSeasons();
    }
}
