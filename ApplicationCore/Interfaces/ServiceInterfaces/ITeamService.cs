using Domain.Core.Responses;
using Domain.DTOs;
using Domain.Entites;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface ITeamService
    {
        Task<ResponseBase> AddNewTeam(TeamCreateDTO teamCreateDTO);
        Task<ResponseBase> UpdateTeam(int teamId, Team teamToUpdate);
        Task<ResponseBase> GetTeamDetails(int teamId);
        Task<ResponseBase> DeleteTeam(int teamId);
    }
}
