using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using Domain.Core.Responses;
using Domain.DTOs;
using Domain.Entites;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepo;  

        public TeamService(ITeamRepository teamRepo)
        {
            _teamRepo = teamRepo;
        }

        public async Task<ResponseBase> AddNewTeam(TeamCreateDTO teamCreateDTO)
        {
            var response = new ResponseBase();
            Team newTeam = new Team()
            {
                Name = teamCreateDTO.Name,
                MinNumberOfPlayers = teamCreateDTO.MinNumberOfPlayers,
                MaxNumberOfPlayers = teamCreateDTO.MaxNumberOfPlayers,
                LogoImage = teamCreateDTO.LogoImage,
            };
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
            var teamDetails = await _teamRepo.GetTeamDetails(teamId);

            if (teamDetails is not null)
            {
                responseBase.Data = teamDetails;
                responseBase.Success = true;
            }
            return responseBase;
        }

        public async Task<ResponseBase> UpdateTeam(int teamId, TeamCreateDTO teamToUpdate)
        {
            var response = new ResponseBase();
            Team newPlayer = new Team()
            {
                Name = teamToUpdate.Name,
                MaxNumberOfPlayers = teamToUpdate.MaxNumberOfPlayers,
                MinNumberOfPlayers = teamToUpdate.MinNumberOfPlayers,
                LogoImage = teamToUpdate.LogoImage 
            };
            var result = await _teamRepo.UpdateTeam(teamId, newPlayer);

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
