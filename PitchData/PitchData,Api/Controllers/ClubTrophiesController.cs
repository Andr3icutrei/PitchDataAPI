using Microsoft.AspNetCore.Mvc;
using PitchData.Core.Dtos;
using PitchData.Core.Dtos.Requests;
using PitchData.Core.Services.Interfaces;
using PitchData.Database.Repositories.Interfaces;

namespace PitchData_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubTrophiesController : ControllerBase
    {
        private readonly IClubTrophyService _clubTrophyService;
        private readonly ILogger<ClubTrophiesController> _logger;

        public ClubTrophiesController(IClubTrophyService clubTrophyService, ILogger<ClubTrophiesController> logger)
        {
            _clubTrophyService = clubTrophyService ?? throw new ArgumentNullException(nameof(clubTrophyService));
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
        public async Task<ActionResult<IEnumerable<ClubTrophyDto>>> GetClubTrophies()
        {
            try
            {
                _logger.LogInformation("Getting club trophies: ");
                var result = await _clubTrophyService.GetClubTrophiesWithClubTeamAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting trophies");
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
        public async Task<ActionResult<ClubTrophyDto>> GetClubTrophies(int id)
        {
            try
            {
                _logger.LogInformation("Getting national team: ", id);

                var clubtrophy = await _clubTrophyService.GetClubTrophiesWithClubTeamAsync(id);

                if (clubtrophy == null)
                {
                    return NotFound($"National team ID {id} not found");
                }

                return Ok(clubtrophy);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving team : ", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpPost("add-clubTrophy")]
        public async Task<IActionResult> AddCoach([FromBody] AddClubTrophyRequest request)
        {
            var result = await _clubTrophyService.AddClubTrophyAsync(request);

            if (!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Trophy added successfully");
        }
    }
}
