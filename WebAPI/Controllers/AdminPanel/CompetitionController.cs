using ApplicationCore.Interfaces.ServiceInterfaces;
using Domain.Core.Responses;
using Domain.DTOs;
using League_Master.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers.AdminPanel
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitionController : ControllerBase
    {
        private readonly ILeagueService _leagueService;
        private readonly ILogger<AuthenticationController> _logger;

        public CompetitionController(ILeagueService leagueService, ILogger<AuthenticationController> logger)
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
                var response = await _leagueService.AddNewLeague(leagueCreateDTO);

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

        [HttpGet("Get Leagues")]
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

        [HttpGet("Get Competitions")]
        public async Task<ActionResult<ResponseBase>> GetCompetitionsAsync()
        {
            try
            {
                var response = await _leagueService.GetCompetitions();

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

        [HttpGet("Get Seasons")]
        public async Task<ActionResult<ResponseBase>> GetSeasonsAsync()
        {
            try
            {
                var response = await _leagueService.GetSeasons();

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
        public async Task<ActionResult<ResponseBase>> GetPlayerLeagueAsync(int leagueId)
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
        public async Task<ActionResult<ResponseBase>> UpdateLeagueAsync(int leagueId, LeagueCreateDTO leagueToUpdate)
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
        public async Task<ActionResult<ResponseBase>> DeleteLeagueAsync(int leagueId)
        {
            try
            {
                var response = await _leagueService.DeleteLeague(leagueId);

                if (response == 0)
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
