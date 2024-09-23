using Domain.Core.Responses;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> Login(string username, string password);
        Task<LoginResponse> RefreshToken(string accessToken, string refreshToken);
    }
}
