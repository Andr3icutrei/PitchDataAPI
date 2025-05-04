using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PitchData.Core.Dtos;
using PitchData.Core.Dtos.Requests;
using PitchData.Core.Mapping;
using PitchData.Core.Services.Interfaces;
using PitchData.Database.Entities;

namespace PitchData_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {

        private readonly IPlayerService _playerService;
        private readonly ILogger<PlayersController> _logger;

        public PlayersController(IPlayerService playerService, ILogger<PlayersController> logger)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
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
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayers()
        {
            try
            {
                _logger.LogInformation("Getting all players with teams");
                var result = await _playerService.GetPlayersWithTeamsAsync();
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
        public async Task<ActionResult<PlayerDto>> GetPlayers(int id)
        {
            try
            {
                _logger.LogInformation("Getting player: ", id);

                var nationalTeam = await _playerService.GetPlayersWithTeamsAsync(id);

                if (nationalTeam == null)
                {
                    return NotFound($"Player ID {id} not found");
                }

                return Ok(nationalTeam);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving player : ", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost("add-player")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddCoach([FromBody] AddPlayerRequest request)
        {
            var result = await _playerService.AddPlayerAsync(request);

            if(!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Player added successfully");
        }
    }
}
