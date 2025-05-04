using Microsoft.EntityFrameworkCore;
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
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlayerDto>> GetPlayersWithTeamsAsync()
        {
            var players = await _repository.GetPlayersWithTeamsAsync();

            return MapNationalTeamToDto(players);
        }

        public async Task<PlayerDto?> GetPlayersWithTeamsAsync(int id)
        {
            var players = await _repository.GetPlayersWithTeamsAsync(id);

            if (players == null)
                return null;

            return MapNationalTeamToDto(players);
        }

        private IEnumerable<PlayerDto> MapNationalTeamToDto(IEnumerable<Player> players)
        {
            return players.Select(player => MapNationalTeamToDto(player)).ToList();
        }

        private PlayerDto MapNationalTeamToDto(Player player)
        {
            return new PlayerDto
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
                MarketValue = player.MarketValue,
                ClubTeamId = player.ClubTeamId,
                NationalTeamId = player.NationalTeamId,
            };
        }
        public async Task<(bool Success, string ErrorMessage)> AddPlayerAsync(AddPlayerRequest request)
        {
            Player player;
            try
            {
                player = request.ToEntity();
            }
            catch (ArgumentException ex)
            {
                 return (false,ex.Message);
            }
            
            _repository.Insert(player);
            await _repository.SaveChangesAsync();

            return (true, null);
        }
    }
}
