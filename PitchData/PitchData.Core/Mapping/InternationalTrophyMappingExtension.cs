using PitchData.Core.Dtos.Requests;
using PitchData.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PitchData.Database.Enums;

namespace PitchData.Core.Mapping
{
    public static class InternationalTrophyMappingExtension
    {
        public static InternationalTrophy ToEntity(this AddInternationalTrophyRequest payload)
        {
            InternationalTrophy internationalTrophy = new InternationalTrophy();

            if (Enum.TryParse<InternationalCompetitions>(payload.Competition, true, out var competition))
            {
                internationalTrophy.Competition = competition;
            }
            else
            {
                throw new ArgumentException($"Invalid competition: {payload.Competition}");

            }

            internationalTrophy.WinDate = payload.WinDate;
            internationalTrophy.NationalTeamId = payload.NationalTeamId;

            return internationalTrophy;
        }
    }
}
