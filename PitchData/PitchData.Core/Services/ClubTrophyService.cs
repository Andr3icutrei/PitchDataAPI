using PitchData.Core.Dtos;
using PitchData.Core.Dtos.Requests;
using PitchData.Core.Mapping;
using PitchData.Core.Services.Interfaces;
using PitchData.Database.Entities;
using PitchData.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Services
{
    public class ClubTrophyService : IClubTrophyService
    {
        private readonly IClubTrophyRepository _repository;

        public ClubTrophyService(IClubTrophyRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClubTrophyDto>> GetClubTrophiesWithClubTeamAsync()
        {
            var clubTrohpies = await _repository.GetClubTrophiesWithClubTeamAsync();

            return MapClubTrophyToDto(clubTrohpies);
        }

        public async Task<ClubTrophyDto?> GetClubTrophiesWithClubTeamAsync(int id)
        {
            // We also need to add this method to the repository
            var clubTrohpies = await _repository.GetClubTrophiesWithClubTeamAsync(id);

            if (clubTrohpies == null)
                return null;

            return MapClubTrophyToDto(clubTrohpies);
        }

        // Helper methods for mapping to avoid code duplication
        private IEnumerable<ClubTrophyDto> MapClubTrophyToDto(IEnumerable<ClubTrophy> clubTrohpies)
        {
            return clubTrohpies.Select(trophy => MapClubTrophyToDto(trophy)).ToList();
        }

        private ClubTrophyDto MapClubTrophyToDto(ClubTrophy trophy)
        {
            var club = trophy.WinnerTeam;

            return new ClubTrophyDto
            {
                Id = trophy.Id,
                CreatedAt = trophy.CreatedAt,
                ModifiedAt = trophy.ModifiedAt,

                Competition = trophy.Competition,
                WinDate = trophy.WinDate,
                ClubTeamId = trophy.ClubTeamId,

            };
        }
        public async Task<(bool Success, string ErrorMessage)> AddClubTrophyAsync(AddClubTrophyRequest request)
        {
            ClubTrophy trophy;

            try
            {
                trophy = request.ToEntity();
            }
            catch (ArgumentException ex)
            {
                return (false, ex.Message);
            }

            _repository.Insert(trophy);
            await _repository.SaveChangesAsync();

            return (true, null);
        }
    }
}
