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
    public class NationalTeamService : INationalTeamService
    {
        private readonly INationalTeamRepository _repository;

        public NationalTeamService(INationalTeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NationalTeamDto>> GetNationalTeamsWithPlayersAsync()
        {
            var teams = await _repository.GetNationalTeamsWithPlayersAsync();

            return MapNationalTeamToDto(teams);
        }

        public async Task<NationalTeamDto?> GetNationalTeamsWithPlayersAsync(int id)
        {
            var teams = await _repository.GetNationalTeamsWithPlayersAsync(id);

            if (teams == null)
                return null;

            return MapNationalTeamToDto(teams);
        }

        private IEnumerable<NationalTeamDto> MapNationalTeamToDto(IEnumerable<NationalTeam> teams)
        {
            return teams.Select(team => MapNationalTeamToDto(team)).ToList();
        }

        private NationalTeamDto MapNationalTeamToDto(NationalTeam team)
        {
            return new NationalTeamDto
            {
                Id = team.Id,
                CreatedAt = team.CreatedAt,
                ModifiedAt = team.ModifiedAt,

                FoundedYear = team.FoundedYear,
                Country = team.Country,
                CurrentFormation = team.CurrentFormation.ToString(),
                TacticalAttackingStyle = team.TacticalAttackingStyle.ToString(),
                TacticalDefensiveStyle = team.TacticalDefensiveStyle.ToString(),
                CoachId = team.CoachId,

                Players = team.Players?.Select(player => new PlayerDto
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
                }).ToList() ?? new List<PlayerDto>(),

                TrophiesWon = team.TrophiesWon?.Select(trophy => new InternationalTrophyDto
                {
                    Id = trophy.Id,
                    CreatedAt = trophy.CreatedAt,
                    ModifiedAt = trophy.ModifiedAt,

                    Competition = trophy.Competition.ToString(),
                    WinDate = trophy.WinDate,
                    NationalTeamId = trophy.NationalTeamId,
                }).ToList() ?? new List<InternationalTrophyDto>()
            };
        }
        public async Task<(bool Success, string ErrorMessage)> AddNationalTeamAsync(AddNationalTeamRequest request)
        {
            NationalTeam team;

            try
            {
                team = request.ToEntity();
            }
            catch (ArgumentException ex)
            {
                return (false, ex.Message);
            }

            _repository.Insert(team);
            await _repository.SaveChangesAsync();

            return (true, null);
        }
    }
}
