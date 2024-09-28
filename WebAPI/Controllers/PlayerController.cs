using Domain.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using ApplicationCore.Interfaces.ServiceInterfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(IPlayerService playerService, ILogger<PlayerController> logger)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
            _logger = logger;
        }

        [HttpPost("Add")]
        //   [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<ActionResult<ResponseBase>> AddAsync(PlayerCreateDTO playerCreateDTO)
        {
            try
            {
                var response = await _playerService.AddNewPlayer(playerCreateDTO);

                if (!response.Success)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{playerId}")]
        public async Task<ActionResult<ResponseBase>> GetPlayerDetailsAsync(int playerId)
        {
            try
            {
                var response = await _playerService.GetPlayerDetails(playerId);

                if (!response.Success)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{playerId}")]
        public async Task<ActionResult<ResponseBase>> UpdatePlayerAsync(int playerId, PlayerCreateDTO playerToUpdate)
        {
            try
            {
                var response = await _playerService.UpdatePlayer(playerId, playerToUpdate);

                if (!response.Success)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{playerId}")]
        public async Task<ActionResult<ResponseBase>> DeletePlayerAsync(int playerId)
        {
            try
            {
                var response = await _playerService.DeletePlayer(playerId);

                if (!response.Success)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
