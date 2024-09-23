using ApplicationCore.Interfaces.ServiceInterfaces;
using League_Master.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("league")]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService _leagueService;
        private readonly ILogger<AuthenticationController> _logger;

        public LeagueController(ILeagueService leagueService, ILogger<AuthenticationController> logger)
        {
            _leagueService = leagueService ?? throw new ArgumentNullException(nameof(leagueService));
            _logger = logger;
        }
    }
}
