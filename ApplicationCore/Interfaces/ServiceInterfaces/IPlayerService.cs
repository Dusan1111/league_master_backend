using Domain.Core.Responses;
using Domain.DTOs;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface IPlayerService
    {
        Task<ResponseBase> AddNewPlayer(PlayerCreateDTO playerDTO);
        Task<ResponseBase> UpdatePlayer(int playerId, PlayerCreateDTO playerToUpdate);
        Task<ResponseBase> GetPlayerDetails(int playerId);
        Task<ResponseBase> DeletePlayer(int playerId);
    }
}
