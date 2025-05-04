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
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _repository;

        public CoachService(ICoachRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CoachDto>> GetCoachesAsync()
        {
            var coaches = await _repository.GetCoachesAsync();

            return MapCoachToDto(coaches);
        }

        public async Task<CoachDto?> GetCoachesAsync(int id)
        {
            // We also need to add this method to the repository
            var coaches = await _repository.GetCoachesAsync(id);

            if (coaches == null)
                return null;

            return MapCoachToDto(coaches);
        }

        // Helper methods for mapping to avoid code duplication
        private IEnumerable<CoachDto> MapCoachToDto(IEnumerable<Coach> coaches)
        {
            return coaches.Select(coach => MapCoachToDto(coach)).ToList();
        }

        private CoachDto MapCoachToDto(Coach coach)
        {
            return new CoachDto
            {
                Id = coach.Id,
                CreatedAt = coach.CreatedAt,
                ModifiedAt = coach.ModifiedAt,

                FirstName = coach.FirstName,
                LastName = coach.LastName,
                CareerWins = coach.CareerWins,
                CareerDraws = coach.CareerDraws,
                CareerLosses = coach.CareerLosses,
                Nationality = coach.Nationality,
            };
        }
        public async Task<(bool Success, string ErrorMessage)> AddCoachAsync(AddCoachRequest request)
        {
            Coach coach;

            try
            {
                coach = request.ToEntity();
            }
            catch (ArgumentException ex)
            {
                return (false, ex.Message);
            }

            _repository.Insert(coach);
            await _repository.SaveChangesAsync();

            return (true, null);
        }
    }
}
