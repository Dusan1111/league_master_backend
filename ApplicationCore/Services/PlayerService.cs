using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using Domain.Core.Responses;
using Domain.DTOs;
using Domain.Entites;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepo;
        public PlayerService(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public async Task<ResponseBase> AddNewPlayer(PlayerCreateDTO playerCreateDTO)
        {
            var response = new ResponseBase();
            Player newPlayer = new Player()
            {
                Name = playerCreateDTO.Name,
                Lastname = playerCreateDTO.Lastname,
            };
            var result = await _playerRepo.AddNewPlayer(newPlayer, playerCreateDTO.TeamId, playerCreateDTO.LeagueId);

            if (result == -1)
            {
                response.Message = $"Igrač:'{ playerCreateDTO.Name } { playerCreateDTO.Name }' je registrovan za neki drugi tim u datoj ligi!";
            }
            else if (result == -2)
            {
                response.Message = $"Liga sa ID-em: '{ playerCreateDTO.LeagueId } 'ne postoji!";
            }
            else if (result == -3)
            {
                response.Message = $"Tim sa ID-em: '{ playerCreateDTO.TeamId }' ne postoji!";
            }
            else if (result == 1)
            {
                response.Success = true;
                response.Message = "Igrač je uspešno dodat!";
                response.Data = newPlayer;
            }
            return response;
        }

        public async Task<ResponseBase> DeletePlayer(int playerId)
        {
            var response = new ResponseBase();
            var result = await _playerRepo.DeletePlayer(playerId);

            if (result == 0)
            {
                response.Message = $"Igrač sa ID-em: '{playerId}' ne postoji!";
            }
            else
            {
                response.Message = $"Igrač sa ID-em: '{playerId}' je obrisan!";
                response.Data = playerId;
            }
            return response;
        }

        public async Task<ResponseBase> GetPlayerDetails(int playerId)
        {
            var response = new ResponseBase();
            var playerDetails = await _playerRepo.GetPlayerDetails(playerId);
            
            if(playerDetails is null)
            {
                response.Message = $"Igrač sa ID-em: '{ playerId }' ne postoji!";
            }
            else
            {
                response.Message = $"Igrač sa ID-em: '{ playerId }' je pronađen!";
                response.Data = playerDetails;
            }
            return response;
        }

        public async Task<ResponseBase> UpdatePlayer(int playerId, PlayerCreateDTO playerToUpdate)
        {
            var response = new ResponseBase();
            Player newPlayer = new Player()
            {
                Name = playerToUpdate.Name,
                Lastname = playerToUpdate.Lastname,
            };
            var result = await _playerRepo.UpdatePlayer(playerId, newPlayer);

            if (result == -1)
            {
                response.Message = $"Igrač sa ID-em: '{ playerId }' ne postoji!";
            }
            else
            {
                response.Success = true;
                response.Message = $"Igrač sa ID-em: '{ playerId }' uspešno ažurirana!";
                response.Data = playerToUpdate;
            }

            return response;
        }
    }
}
