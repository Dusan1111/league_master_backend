using Domain.Core.Responses;
using Domain.Entites;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryInterfaces
{
    public interface IAuthenticationRepository
    {
        Task<User> Login(string username, string password);
    }
}
