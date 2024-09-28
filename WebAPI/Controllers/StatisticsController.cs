using Domain.Core.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using ApplicationCore.Interfaces.ServiceInterfaces;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {

        private readonly IStatisticsService _statisticsService;
        private readonly ILogger<StatisticsController> _logger;

        public StatisticsController(IStatisticsService teamService, ILogger<StatisticsController> logger)
        {
            _statisticsService = teamService ?? throw new ArgumentNullException(nameof(teamService));
            _logger = logger;
        }

        [HttpGet("{leagueId}")]
        public async Task<ActionResult<ResponseBase>> GetStatisticsForSeasonAsync(int leagueId)
        {
            try
            {
                var response = await _statisticsService.GetLeagueStandings(leagueId, 2);

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
