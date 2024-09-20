using Domain.Core.Responses;
using System.Threading.Tasks;

namespace Domain.Core.RepositoriesInterfaces.Authentification
{
    public interface IAuthenticationRepository
    {
        Task<LoginResponse> Login(string username, string password);
        Task<LoginResponse> BackofficeLogin(string username, string password);
        Task<LoginResponse> RefreshToken(string accessToken, string refreshToken);
    }
}
