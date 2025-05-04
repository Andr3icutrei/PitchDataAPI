using PitchData.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Entities
{
    public class InternationalTrophy : BaseEntity
    {
        public InternationalCompetitions Competition { get; set; }
        public DateTime WinDate { get; set; }
        public int NationalTeamId { get; set; } 
        public NationalTeam WinnerTeam { get; set; }  
    }
}
