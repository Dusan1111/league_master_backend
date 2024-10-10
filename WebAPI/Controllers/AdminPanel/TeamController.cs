using ApplicationCore.Interfaces.ServiceInterfaces;
using Domain.Core.Responses;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace WebAPI.Controllers.AdminPanel
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly ILogger<PlayerController> _logger;

        public TeamController(ITeamService teamService, ILogger<PlayerController> logger)
        {
            _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
            _logger = logger;
        }

        [HttpPost("Add")]
        //   [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<ActionResult<ResponseBase>> AddAsync(TeamCreateDTO teamCreateDTO)
        {
            try
            {
                var response = await _teamService.AddNewTeam(teamCreateDTO);

                if (!response.Success)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Došlo je do greške prilikom čuvanja tima!");
            }
        }

        [HttpGet]
        public async Task<ActionResult<ResponseBase>> GetAllTeamsAsync()
        {
            try
            {
                var response = await _teamService.GetAllTeams();

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

        [HttpGet("Get Details{teamId}")]
        public async Task<ActionResult<ResponseBase>> GetTeamDetailsAsync(int teamId)
        {
            try
            {
                var response = await _teamService.GetTeamDetails(teamId);

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


        [HttpPut("Update{teamId}")]
        public async Task<ActionResult<ResponseBase>> UpdateTeamAsync(int teamId, TeamCreateDTO teamToUpdate)
        {
            try
            {
                var response = await _teamService.UpdateTeam(teamId, teamToUpdate);

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
