using PitchData.Database.Entities;
using PitchData.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Dtos
{
    public class NationalTeamDto : BaseDto
    {
        public DateTime FoundedYear { get; set; }
        public string Country { get; set; }
        public string CurrentFormation { get; set; }
        public string TacticalAttackingStyle { get; set; }
        public string TacticalDefensiveStyle { get; set; }
        public int CoachId { get; set; }
        public string CoachName { get; set; }
        public ICollection<PlayerDto> Players { get; set; }
        public ICollection<InternationalTrophyDto> TrophiesWon { get; set; }
    }
}
