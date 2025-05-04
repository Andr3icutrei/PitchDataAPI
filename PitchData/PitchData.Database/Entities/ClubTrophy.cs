using PitchData.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Entities
{
    public class ClubTrophy : BaseEntity
    {
        public string Competition { get; set; }
        public DateTime WinDate { get; set; }
        //foreign
        public int ClubTeamId { get; set; }
        public ClubTeam WinnerTeam { get; set; }
    }
}
