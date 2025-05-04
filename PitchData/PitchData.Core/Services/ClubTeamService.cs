using PitchData.Core.Dtos;
using PitchData.Core.Services.Interfaces;
using PitchData.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PitchData.Database.Repositories.Interfaces;
using PitchData.Database.Entities;
using PitchData.Core.Dtos.Requests;
using PitchData.Core.Mapping;

namespace PitchData.Core.Services
{
    public class ClubTeamService : IClubTeamService
    {
        private readonly IClubTeamRepository _repository;

        public ClubTeamService(IClubTeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClubTeamDto>> GetClubTeamsWithPlayersAsync()
        {
            // Existing implementation
            var clubTeams = await _repository.GetClubTeamsWithPlayersAsync();

            // Map entities to DTOs
            return MapClubTeamsToDto(clubTeams);
        }

        public async Task<ClubTeamDto?> GetClubTeamWithPlayersAsync(int id)
        {
            // We also need to add this method to the repository
            var clubTeam = await _repository.GetClubTeamWithPlayersAsync(id);

            if (clubTeam == null)
                return null;

            // Use the same mapping logic
            return MapClubTeamToDto(clubTeam);
        }

        // Helper methods for mapping to avoid code duplication
        private IEnumerable<ClubTeamDto> MapClubTeamsToDto(IEnumerable<ClubTeam> clubTeams)
        {
            return clubTeams.Select(club => MapClubTeamToDto(club)).ToList();
        }

        private ClubTeamDto MapClubTeamToDto(ClubTeam club)
        {
            return new ClubTeamDto
            {
                Id = club.Id,
                CreatedAt = club.CreatedAt,
                ModifiedAt = club.ModifiedAt,

                Name = club.Name,
                FoundedYear = club.FoundedYear,
                Country = club.Country,
                CurrentFormation = club.CurrentFormation.ToString(),
                TacticalAttackingStyle = club.TacticalAttackingStyle.ToString(),
                TacticalDefensiveStyle = club.TacticalDefensiveStyle.ToString(),

                Players = club.Players?.Select(player => new PlayerDto
                {
                    Id = player.Id,
                    CreatedAt = player.CreatedAt,
                    ModifiedAt = player.ModifiedAt,

                    FullName = $"{player.FirstName} {player.LastName}",
                    DateOfBirth = player.DateOfBirth,
                    Nationality = player.Nationality,
                    Height = player.Height,
                    Goals = player.Goals,
                    Assists = player.Assists,
                    Position = player.Position.ToString(),
                    MarketValue = player.MarketValue
                }).ToList() ?? new List<PlayerDto>()
            };
        }
        public async Task<(bool Success, string ErrorMessage)> AddClubTeamAsync(AddClubTeamRequest request)
        {
            ClubTeam team;
            try
            {
                team = request.ToEntity();
            }
            catch (ArgumentException ex)
            {
                return (false,ex.Message);
            }

            _repository.Insert(team);

            await _repository.SaveChangesAsync();

            return (true, null);
        }
    }

}
