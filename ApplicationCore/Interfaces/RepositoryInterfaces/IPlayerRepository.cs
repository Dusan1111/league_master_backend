using Domain.Entites;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryInterfaces
{
    public interface IPlayerRepository
    {
        Task<int> AddNewPlayer(Player newPlayer, int teamId, int leagueId);
        Task<int> UpdatePlayer(int playerId, Player playerToUpdate);
        Task<Player> GetPlayerDetails(int playerId);
        Task<int> DeletePlayer(int playerId);
    }
}
