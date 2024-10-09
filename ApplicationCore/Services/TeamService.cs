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
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepo;
        private readonly ILeagueRepository _leagueRepo;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository teamRepo, ILeagueRepository leagueRepo, IMapper mapper)
        {
            _teamRepo = teamRepo;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _leagueRepo = leagueRepo;
        }

        public async Task<ResponseBase> AddNewTeam(TeamCreateDTO teamCreateDTO)
        {
            var response = new ResponseBase();
            var newTeam = _mapper.Map<Team>(teamCreateDTO);

            var result = await _teamRepo.AddNewTeam(newTeam, teamCreateDTO.SeasonLeagueId);

            if(result == 0)
            {
                response.Message = "Došlo je do greške prilikom dodavanja tima!";
            }
            else if (result == 1)
            {
                response.Success = true;
                response.Message = "Tim je uspešno dodat!";
                response.Data = newTeam;
            }
            return response;
        }

        public Task<ResponseBase> DeleteTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseBase> GetAllTeams()
        {
            var responseBase = new ResponseBase();
            var teams = await _teamRepo.GetAllTeams();

            if (teams is not null)
            {
                responseBase.Data = teams;
                responseBase.Success = true;
            }
            return responseBase;
        }

        public async Task<ResponseBase> GetTeamDetails(int teamId)
        {
            var responseBase = new ResponseBase();

            var teamEntityDetails = await _teamRepo.GetTeamDetails(teamId);
            
            var teamDtoDetails = _mapper.Map<TeamDetailsDTO>(teamEntityDetails);
            teamDtoDetails.Leagues = new List<LeagueDetailsDTO>();

            var leagues =  await _leagueRepo.GetAllLeagues();

            foreach(var league in leagues)
            {
                foreach (var seasonLeague in league.SeasonLeagues)
                {
                    var leagueDto = new LeagueDetailsDTO()
                    {
                        Id = league.Id,
                        Name = league.Name + ", " + seasonLeague.Season.Name
                    };
                   teamDtoDetails.Leagues.Add(leagueDto);
                }
            }

            if (teamDtoDetails is not null)
            {
                responseBase.Data = teamDtoDetails;
                responseBase.Success = true;
            }
            return responseBase;
        }

        public async Task<ResponseBase> UpdateTeam(int teamId, TeamCreateDTO teamToUpdate)
        {
            var response = new ResponseBase();
            var updatedTeam = _mapper.Map<Team>(teamToUpdate);

            var result = await _teamRepo.UpdateTeam(teamId, updatedTeam);

            if (result == -1)
            {
                response.Message = $"Tim sa ID-em: '{teamId}' ne postoji!";
            }
            else
            {
                response.Success = true;
                response.Message = $"Tim sa ID-em: '{teamId}' uspešno ažurirana!";
                response.Data = teamToUpdate;
            }
            return response;
        }
    }
}
