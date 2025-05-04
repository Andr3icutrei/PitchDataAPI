using Microsoft.Extensions.Logging;
using PitchData.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PitchData.Core.Dtos.Requests;
using PitchData.Database.Enums;

namespace PitchData.Core.Mapping
{
    public static class ClubTeamMappingExtension
    {
        public static ClubTeam ToEntity(this AddClubTeamRequest payload)
        {
            ClubTeam clubTeamEntity = new ClubTeam();

            if (Enum.TryParse<Formations>(payload.CurrentFormation, ignoreCase: true, out Formations formation))
            {
                clubTeamEntity.CurrentFormation = formation;
            }
            else
            {
                throw new ArgumentException($"Invalid formation: {payload.CurrentFormation}");
            }

            if (Enum.TryParse<TacticalAttackingStyles>(payload.TacticalAttackingStyle, ignoreCase: true, out TacticalAttackingStyles att))
            {
                clubTeamEntity.TacticalAttackingStyle = att;
            }
            else
            {
                throw new ArgumentException($"Invalid attacking style: {payload.TacticalAttackingStyle}");
            }


            if (Enum.TryParse<TacticalDefensiveStyles>(payload.TacticalDefensiveStyle, ignoreCase: true, out TacticalDefensiveStyles def))
            {
                clubTeamEntity.TacticalDefensiveStyle = def;
            }
            else
            {
                throw new ArgumentException($"Invalid deffensive style: {payload.TacticalDefensiveStyle}");
            }

            clubTeamEntity.Name = payload.Name;
            clubTeamEntity.FoundedYear = payload.FoundedYear;
            clubTeamEntity.Country = payload.Country;
            clubTeamEntity.CoachId = payload.CoachId;

            return clubTeamEntity;
        }
    }
}
