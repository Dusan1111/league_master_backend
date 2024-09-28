using ApplicationCore.Interfaces.ServiceInterfaces;
using Domain.Core.Responses;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace WebAPI.Controllers
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
                return BadRequest(ex.Message);
            }
        }
    }
}
