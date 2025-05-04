using Microsoft.AspNetCore.Mvc;
using PitchData.Core.Dtos;
using PitchData.Core.Dtos.Requests;
using PitchData.Core.Services;
using PitchData.Core.Services.Interfaces;

namespace PitchData_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalTeamsController : ControllerBase
    {
        private readonly INationalTeamService _nationalTeamService;
        private readonly ILogger<NationalTeamsController> _logger;

        public NationalTeamsController(INationalTeamService nationalTeamService, ILogger<NationalTeamsController> logger)
        {
            _nationalTeamService = nationalTeamService ?? throw new ArgumentNullException(nameof(nationalTeamService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets all club teams with their players
        /// </summary>
        /// <returns>A list of club teams including their players</returns>
        /// <response code="200">Returns the club teams list</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<NationalTeamDto>>> GetNationalTeams()
        {
            try
            {
                _logger.LogInformation("Getting all national teams with their players");
                var result = await _nationalTeamService.GetNationalTeamsWithPlayersAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting teams");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Gets a specific club team with its players by id
        /// </summary>
        /// <param name="id">The ID of the club team</param>
        /// <returns>The club team with its players</returns>
        /// <response code="200">Returns the club team</response>
        /// <response code="404">If the club team was not found</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NationalTeamDto>> GetNationalTeams(int id)
        {
            try
            {
                _logger.LogInformation("Getting national team: ", id);

                var nationalTeam = await _nationalTeamService.GetNationalTeamsWithPlayersAsync(id);

                if (nationalTeam == null)
                {
                    return NotFound($"National team ID {id} not found");
                }

                return Ok(nationalTeam);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving team : ", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpPost("add-nationalTeam")]
        public async Task<IActionResult> AddNationalTeam([FromBody] AddNationalTeamRequest request)
        {
            var result = await _nationalTeamService.AddNationalTeamAsync(request);

            if(!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("National team added successfully");
        }
    }
}
