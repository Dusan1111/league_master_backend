using Domain.Core.RepositoriesInterfaces.Authentification;
using Domain.Core.Responses;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace League_Master.WebAPI.Controllers
{
    [ApiController]
    [Route("authorization")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authRepo;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthenticationRepository authRepo, ILogger<AuthenticationController> logger)
        {
            _authRepo = authRepo ?? throw new ArgumentNullException(nameof(authRepo));
            _logger = logger;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Login(UserLoginDTO request)
        {
            try
            {
                _logger.Log(LogLevel.Trace, $"[AuthentificationController] Login attempt for user: {request.UserName}.");
                var response = await _authRepo.Login(request.UserName, request.Password);
                if (!response.Success)
                {
                    _logger.Log(LogLevel.Warning, $"[AuthentificationController] Failed login attempt for user: {request.UserName}. Reason: {response.Message}");
                    return BadRequest(response);
                }

                _logger.Log(LogLevel.Information, $"[AuthentificationController] Successful login for user: {request.UserName}.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ResponseBase
                {
                    Success = false,
                    Message = "Došlo je do tehničke greške."
                };

                _logger.Log(LogLevel.Error, $"[AuthentificationController] Exception during login for user: {request.UserName}. Error: {ex.Message}. StackTrace: {ex.StackTrace}");

                return BadRequest(errorResponse);
            }
        }

        [HttpPost]
        [Route("Refresh")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Refresh(TokenDTO tokenDTO)
        {
            try
            {
                _logger.Log(LogLevel.Trace, $"[AuthentificationController] Token refresh attempt.");

                if (tokenDTO is null)
                {
                    _logger.Log(LogLevel.Trace, $"[AuthentificationController] Token refresh failed. Reason: Token is null.");
                    return BadRequest("Invalid client request");
                }

                string accessToken = tokenDTO.AccessToken;
                string refreshToken = tokenDTO.RefreshToken;

                var response = await _authRepo.RefreshToken(accessToken, refreshToken);

                if (!response.Success)
                {
                    _logger.Log(LogLevel.Trace, $"[AuthentificationController] Token refresh failed. Reason: {response.Message}");
                    return Unauthorized(response);
                }

                _logger.Log(LogLevel.Trace, $"[AuthentificationController] Token refresh successful.");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"[AuthentificationController] Exception during token refresh. Error: {ex.Message}. StackTrace: {ex.StackTrace}");

                return BadRequest(ex.Message);
            }
        }
    }
}
