using PitchData.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Dtos.Requests
{
    public class AddClubTeamRequest
    {
        public string Name { get; set; }
        public DateTime FoundedYear { get; set; }
        public string Country { get; set; }
        public string CurrentFormation { get; set; }
        public string TacticalAttackingStyle { get; set; }
        public string TacticalDefensiveStyle { get; set; }
        public int CoachId { get; set; }
    }
}
