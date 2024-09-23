using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using Domain.Core.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private IAuthenticationRepository _authRepo;

        public AuthenticationService([NotNull] ILogger<AuthenticationService> logger, IAuthenticationRepository authRepo)
        {
            _logger = logger;
            _authRepo = authRepo;
        }

        public async Task<LoginResponse> Login(string inputUsername, string inputPassword)
        {
            var response = new LoginResponse();
            var loggedInClient = await _authRepo.Login(inputUsername, inputPassword);

            if (loggedInClient is null)
            {
                response.Message = "Email ili lozinka nisu ispravni";
                return response;
            }
            else if (!IsPasswordValid(loggedInClient.Password, inputPassword)) 
            {
                response.Message = "Email ili lozinka nisu ispravni";
                return response;
            }
            // else if()  proveriti ROLU
            response.Success = true;
            response.Message = string.Format("Korisnik '{0}' uspešno prijavljen!", inputUsername);
            response.Data = loggedInClient;

            return response;
        }

        public Task<LoginResponse> RefreshToken(string accessToken, string refreshToken)
        {
            throw new System.NotImplementedException();
        }

        #region Private Methods

        private bool IsPasswordValid(string dbClientPassword, string inputPassword)
        {
            return dbClientPassword is not null && dbClientPassword.ToLower().Equals(CreateMD5(inputPassword));
        }

        private string CreateMD5(string inputPassword)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(inputPassword);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes).ToLower();
            }
        }

        #endregion
    }
}
