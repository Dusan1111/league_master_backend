using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using Domain.Core.Responses;
using Domain.DTOs;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _leagueRepo;

        public LeagueService(ILeagueRepository leagueRepo)
        {
            _leagueRepo = leagueRepo;
        }

        public async Task<ResponseBase> AddNewLeague(LeagueCreateDTO leagueCreateDTO)
        {
            var response = new ResponseBase();
            League newLeague = new League()
            {
                Name = leagueCreateDTO.Name,
                NumberOfRounds = leagueCreateDTO.NumberOfRounds
            };
            var result = await _leagueRepo.AddNewLeague(newLeague);

            if (result is null)
            {
                response.Message = "Došlo je do greške prilikom dodavanja lige!";
            }
            else 
            {
                response.Success = true;
                response.Message = "Liga je uspešno dodata!";
                response.Data = result;
            }
            return response;
        }

        public Task<ResponseBase> DeleteLeague(int leagueId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseBase> GetLeagueDetails(int leagueId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseBase> GetLeagues()
        {
            var responseBase = new ResponseBase();
            var leagues = await _leagueRepo.GetAllLeagues();

            if(leagues is not null)
            {
                responseBase.Data = leagues;
                responseBase.Success = true;
            }
            return responseBase;
        }

        public Task<ResponseBase> UpdateLeague(int leagueId, LeagueCreateDTO leagueToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
