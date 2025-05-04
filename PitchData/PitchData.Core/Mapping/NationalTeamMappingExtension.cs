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
    public static class NationalTeamMappingExtension
    {
        public static NationalTeam ToEntity(this AddNationalTeamRequest payload)
        {
            NationalTeam team = new NationalTeam();

            if (Enum.TryParse<Formations>(payload.CurrentFormation, ignoreCase: true, out Formations formation))
            {
                team.CurrentFormation = formation;
            }
            else
            {
                throw new ArgumentException($"Invalid formation: {payload.CurrentFormation}");
            }

            if (Enum.TryParse<TacticalAttackingStyles>(payload.TacticalAttackingStyle, ignoreCase: true, out TacticalAttackingStyles att))
            {
                team.TacticalAttackingStyle = att;
            }
            else
            {
                throw new ArgumentException($"Invalid attacking style: {payload.TacticalAttackingStyle}");
            }


            if (Enum.TryParse<TacticalDefensiveStyles>(payload.TacticalDefensiveStyle, ignoreCase: true, out TacticalDefensiveStyles def))
            {
                team.TacticalDefensiveStyle = def;
            }
            else
            {
                throw new ArgumentException($"Invalid deffensive style: {payload.TacticalDefensiveStyle}");
            }

            team.CoachId = payload.CoachId;
            team.FoundedYear = payload.FoundedYear;
            team.Country = payload.Country;

            return team;
        }
    }
}
