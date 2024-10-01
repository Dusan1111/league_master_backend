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
            var result = await _teamRepo.AddNewTeam(newTeam, teamCreateDTO.LeagueId);

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

        public Task<ResponseBase> GetTeamDetails(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseBase> UpdateTeam(int teamId, Team teamToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
