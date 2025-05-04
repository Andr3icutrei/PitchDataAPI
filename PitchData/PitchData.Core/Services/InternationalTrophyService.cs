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
    public class InternationalTrophyService : IInternationalTrophyService
    {
        private readonly IInternationalTrophyRepository _repository;

        public InternationalTrophyService(IInternationalTrophyRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InternationalTrophyDto>> GetAllInternationalTrophysWithNationalTeamAsync()
        {
            var coaches = await _repository.GetAllInternationalTrophysWithNationalTeamAsync();

            return MapInternationalTrophyToDto(coaches);
        }

        public async Task<InternationalTrophyDto?> GetAllInternationalTrophysWithNationalTeamAsync(int id)
        {
            var coaches = await _repository.GetAllInternationalTrophysWithNationalTeamAsync(id);

            if (coaches == null)
                return null;

            return MapInternationalTrophyToDto(coaches);
        }

        private IEnumerable<InternationalTrophyDto> MapInternationalTrophyToDto(IEnumerable<InternationalTrophy> trophies)
        {
            return trophies.Select(trophy => MapInternationalTrophyToDto(trophy)).ToList();
        }

        private InternationalTrophyDto MapInternationalTrophyToDto(InternationalTrophy trophy)
        {
            return new InternationalTrophyDto
            {
                Id = trophy.Id,
                CreatedAt = trophy.CreatedAt,
                ModifiedAt = trophy.ModifiedAt,

                Competition = trophy.Competition.ToString(),
                WinDate = trophy.WinDate,
                NationalTeamId = trophy.NationalTeamId,
            };
        }
        public async Task<(bool Success, string ErrorMessage)> AddInternationalTrophyAsync(AddInternationalTrophyRequest request)
        {
            InternationalTrophy trophy;
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
