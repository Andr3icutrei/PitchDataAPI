using Microsoft.AspNetCore.Mvc;
using PitchData.Core.Dtos;
using PitchData.Core.Dtos.Requests;
using PitchData.Core.Services;
using PitchData.Core.Services.Interfaces;

namespace PitchData_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
        private readonly ICoachService _coachesService;
        private readonly ILogger<CoachesController> _logger;

        public CoachesController(ICoachService coachesService, ILogger<CoachesController> logger)
        {
            _coachesService = coachesService ?? throw new ArgumentNullException(nameof(coachesService));
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
        public async Task<ActionResult<IEnumerable<CoachDto>>> GetCoaches()
        {
            try
            {
                _logger.LogInformation("Getting all club teams with their players");
                var result = await _coachesService.GetCoachesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting coaches");
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
        public async Task<ActionResult<CoachDto>> GetCoaches(int id)
        {
            try
            {
                _logger.LogInformation("Getting coach: ", id);

                var coach = await _coachesService.GetCoachesAsync(id);

                if (coach == null)
                {
                    return NotFound($"Coaches ID {id} not found");
                }

                return Ok(coach);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while coach: ", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost("add-coach")]
        public async Task<IActionResult> AddCoach([FromBody] AddCoachRequest request)
        {
            var result = await _coachesService.AddCoachAsync(request);

            if (!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Event added successfully");
        }
    }
}
