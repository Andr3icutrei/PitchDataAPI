using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PitchData.Core.Dtos.Requests;
using PitchData.Database.Entities;
using PitchData.Database.Enums;

namespace PitchData.Core.Mapping
{
    public static class ClubTrophyMappingExtension
    {
        public static ClubTrophy ToEntity(this AddClubTrophyRequest payload)
        {
            ClubTrophy clubTrophy = new ClubTrophy();

            if(Enum.TryParse<ClubCompetitions>(payload.Competition,ignoreCase: true,out ClubCompetitions comp))
            {
                clubTrophy.Competition = payload.Competition;
            }
            else
            {
                throw new ArgumentException($"Invalid competition: {payload.Competition}");
            }

            clubTrophy.WinDate = payload.WinDate;
            clubTrophy.ClubTeamId = payload.ClubTeamId;

            return clubTrophy;
        }
    }
}
