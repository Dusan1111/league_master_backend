using ApplicationCore.Interfaces.ServiceInterfaces;
using Domain.Core.Responses;
using Domain.DTOs;
using League_Master.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService _leagueService;
        private readonly ILogger<AuthenticationController> _logger;

        public LeagueController(ILeagueService leagueService, ILogger<AuthenticationController> logger)
        {
            _leagueService = leagueService ?? throw new ArgumentNullException(nameof(leagueService));
            _logger = logger;
        }

        [HttpPost("Add")]
        //   [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<ActionResult<ResponseBase>> AddAsync(LeagueCreateDTO leagueCreateDTO)
        {
            try
            {
                var response = await _leagueService.AddNewLeague(leagueCreateDTO.LeagueName, leagueCreateDTO.NumberOfRounds);

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

        [HttpGet]
        public async Task<ActionResult<ResponseBase>> GetLeaguesAsync()
        {
            try
            {
                var response = await _leagueService.GetLeagues();

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

        [HttpGet("{leagueId}")]
        public async Task<ActionResult<ResponseBase>> GetPlayerDetailsAsync(int leagueId)
        {
            try
            {
                var response = await _leagueService.GetLeagueDetails(leagueId);

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

        [HttpPut("{leagueId}")]
        public async Task<ActionResult<ResponseBase>> UpdatePlayerAsync(int leagueId, LeagueCreateDTO leagueToUpdate)
        {
            try
            {
                var response = await _leagueService.UpdateLeague(leagueId, leagueToUpdate);

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


        [HttpDelete("{leagueId}")]
        public async Task<ActionResult<ResponseBase>> DeletePlayerAsync(int leagueId)
        {
            try
            {
                var response = await _leagueService.DeleteLeague(leagueId);

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
