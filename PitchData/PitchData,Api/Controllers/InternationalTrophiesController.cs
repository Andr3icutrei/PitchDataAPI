using Microsoft.AspNetCore.Mvc;
using PitchData.Core.Dtos;
using PitchData.Core.Dtos.Requests;
using PitchData.Core.Services.Interfaces;
using PitchData.Database.Repositories.Interfaces;

namespace PitchData_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternationalTrophiesController : ControllerBase
    {
        private readonly IInternationalTrophyService _internationalTrophyService;
        private readonly ILogger<InternationalTrophiesController> _logger;

        public InternationalTrophiesController(IInternationalTrophyService internationalTrophyService, ILogger<InternationalTrophiesController> logger)
        {
            _internationalTrophyService = internationalTrophyService ?? throw new ArgumentNullException(nameof(internationalTrophyService));
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
        public async Task<ActionResult<IEnumerable<InternationalTrophyDto>>> GetAllInternationalTrophysWithNationalTeam()
        {
            try
            {
                _logger.LogInformation("Getting international trophies with national teams: ");
                var result = await _internationalTrophyService.GetAllInternationalTrophysWithNationalTeamAsync();
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
        public async Task<ActionResult<InternationalTrophyDto>> GetAllInternationalTrophysWithNationalTeamAsync(int id)
        {
            try
            {
                _logger.LogInformation("Getting internationa trophy: ", id);

                var trophy = await _internationalTrophyService.GetAllInternationalTrophysWithNationalTeamAsync(id);

                if (trophy == null)
                {
                    return NotFound($"Trophy ID {id} not found");
                }

                return Ok(trophy);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting trophy: ", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpPost("add-internationalTrophy")]
        public async Task<IActionResult> AddInternationalTrophy([FromBody] AddInternationalTrophyRequest request)
        {
            var result = await _internationalTrophyService.AddInternationalTrophyAsync(request);

            if(!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("International trophy added successfully");
        }
    }
}
