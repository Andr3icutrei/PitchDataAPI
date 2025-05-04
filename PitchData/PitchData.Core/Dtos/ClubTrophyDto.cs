using PitchData.Database.Entities;
using PitchData.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Dtos
{
    public class ClubTrophyDto : BaseDto
    {
        public string Competition { get; set; }
        public DateTime WinDate { get; set; }
        //foreign
        public int ClubTeamId { get; set; }
        public string WinnerTeamName { get; set; }
    }
}
