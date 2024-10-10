using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using AutoMapper;
using Domain.Core.Responses;
using Domain.DTOs;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _leagueRepo;
        private readonly IMapper _mapper;
        public LeagueService(ILeagueRepository leagueRepo, IMapper mapper)
        {
            _leagueRepo = leagueRepo;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResponseBase> AddNewLeague(LeagueCreateDTO leagueCreateDTO)
        {
            var response = new ResponseBase();
            League newLeague = new League()
            {
                Name = leagueCreateDTO.Name,
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

        public Task<int> DeleteLeague(int leagueId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseBase> GetCompetitions()
        {
            var responseBase = new ResponseBase();
            var competitions = await _leagueRepo.GetAllCompetitions();
            var competitionDtoList =  _mapper.Map<List<CompetitionRecordDTO>>(competitions);

            if (competitions is not null)
            {
                responseBase.Data = competitionDtoList;
                responseBase.Success = true;
            }
            return responseBase;
        }

        public Task<ResponseBase> GetLeagueDetails(int leagueId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseBase> GetLeagues()
        {
            var responseBase = new ResponseBase();
            var leagues = await _leagueRepo.GetAllLeagues();
            var leagueDtoList = _mapper.Map<List<LeagueRecordDTO>>(leagues);

            if (leagues is not null)
            {
                responseBase.Data = leagueDtoList;
                responseBase.Success = true;
            }
            return responseBase;
        }

        public async Task<ResponseBase> GetSeasons()
        {
            var responseBase = new ResponseBase();
            var seasons = await _leagueRepo.GetAllSeasons();
            var seasonDtoList = _mapper.Map<List<SeasonRecordDTO>>(seasons);

            if (seasonDtoList is not null)
            {
                responseBase.Data = seasonDtoList;
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
