using ApplicationCore.Interfaces.RepositoryInterfaces;
using Domain.Core.Responses;
using League_Master.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Domain.Entites;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly LeagueMasterDbContext _context;
        private readonly MemoryCacheEntryOptions _cacheOptions;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;

        public AuthenticationRepository(LeagueMasterDbContext context, IConfiguration configuration, IMemoryCache memoryCache)
        {
             _context = context;
            _configuration = configuration;
            _memoryCache = memoryCache;

            _cacheOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(Convert.ToInt32(_configuration.GetSection("JWTSettings:RefreshTokenExpiryTimeInMinutes").Value))
            };
        }

        public async Task<User> Login(string username, string password)
        {
            string typedUsername = username.ToLower();

            var loggedInUser = await _context.Users
                .Where(user => user.Username.ToLower().Equals(typedUsername))
                .FirstOrDefaultAsync();

            return loggedInUser;
        }

        public Task<LoginResponse> RefreshToken(string accessToken, string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
