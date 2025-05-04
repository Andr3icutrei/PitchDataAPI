using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Dtos.Requests
{
    public class AddNationalTeamRequest
    {
        public DateTime FoundedYear { get; set; }
        public string Country { get; set; }
        public string CurrentFormation { get; set; }
        public string TacticalAttackingStyle { get; set; }
        public string TacticalDefensiveStyle { get; set; }
        //foreign
        public int CoachId { get; set; }
    }
}
