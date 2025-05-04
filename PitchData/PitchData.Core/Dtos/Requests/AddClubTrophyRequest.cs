using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Dtos.Requests
{
    public class AddClubTrophyRequest
    {
        public string Competition { get; set; }
        public DateTime WinDate { get; set; }
        //foreign
        public int ClubTeamId { get; set; }
    }
}
