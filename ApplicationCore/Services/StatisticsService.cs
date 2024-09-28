using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using Domain.Core.Responses;
using Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _statisticsRepo;
        public StatisticsService(IStatisticsRepository statisticsRepo)
        {
            _statisticsRepo = statisticsRepo;
        }

        public async Task<ResponseBase> GetLeagueStandings(int leagueId, int seasonId)
        {
            var response = new ResponseBase();
            var leagueStatisticsForSeason = await _statisticsRepo.GetLeagueStandings(leagueId, seasonId);

            List<LeagueStandingRecordDTO> leagueStandingRecordDTOs = new List<LeagueStandingRecordDTO>();
            int leaguePosition = 1;

            foreach (var leagueStats in leagueStatisticsForSeason)
            {
                var leagueStandingRecordDTO = new LeagueStandingRecordDTO()
                {
                    TeamId = leagueStats.TeamId,
                    TeamName = leagueStats.Team.Name,
                    LeaguePosition = leaguePosition,
                    ScoredGoals = leagueStats.ScoredGoals,
                    ReceivedGoals = leagueStats.ReceivedGoals,
                    GoalsDifference = leagueStats.GoalsDifference,
                    NumberOfGamesPlayed = leagueStats.NumberOfGamesPlayed,
                    NumberOfWins = leagueStats.NumberOfWins,
                    NumberOfLosses = leagueStats.NumberOfLosses,
                    NumberOfDraws = leagueStats.NumberOfDraws,
                    TotalPoints = leagueStats.TotalPoints
                };
                leagueStandingRecordDTOs.Add(leagueStandingRecordDTO);
                leaguePosition ++;
            }
            if (leagueStatisticsForSeason is null)
            {
                response.Message = $"Statistike za ligu sa ID-em: '{leagueId}' ne postoji!";
            }
            else
            {
                response.Message = $"Statistike za ligu sa ID-em: '{leagueId}' je pronađena!";
                response.Data = leagueStandingRecordDTOs;
            }
            return response;
        }
    }
}
