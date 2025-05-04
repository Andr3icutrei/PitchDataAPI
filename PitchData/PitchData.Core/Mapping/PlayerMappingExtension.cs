using PitchData.Core.Dtos.Requests;
using PitchData.Database.Entities;
using PitchData.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Mapping
{
    public static class PlayerMappingExtension
    {
        public static Player ToEntity(this AddPlayerRequest payload)
        {
            Player player = new Player();

            if (Enum.TryParse<PlayerPositions>(payload.Position, true, out PlayerPositions pos))
            {
                player.Position = pos;
            }
            else
            {
                throw new ArgumentException($"Invalid position :{pos}");
            }

            player.FirstName = payload.FirstName;
            player.LastName = payload.LastName;
            player.DateOfBirth = payload.DateOfBirth;
            player.Nationality = payload.Nationality;
            player.Height = payload.Height;
            player.Goals = payload.Goals;
            player.Assists = payload.Assists;
            player.IsActive = payload.IsActive;
            player.MarketValue = payload.MarketValue;
            player.ClubTeamId = payload.ClubTeamId ;
            player.NationalTeamId = payload.NationalTeamId;

            return player;
        }
    }
}
