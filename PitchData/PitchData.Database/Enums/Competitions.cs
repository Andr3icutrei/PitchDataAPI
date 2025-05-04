using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Enums
{
    public enum ClubCompetitions
    {
        InvalidCompetition = 0,

        ChampionsLeague = 1,
        EuropaLeague = 2,
        ConferenceLeague = 4,
        LeagueTitle = 8,
        LeagueCup = 16,
        UEFASuperCup = 32
    }
    public enum InternationalCompetitions
    {
        InvalidCompetition = 0,

        WorldCup = 1,
        Euro = 2, 
        CopaAmerica = 4
    }
}
