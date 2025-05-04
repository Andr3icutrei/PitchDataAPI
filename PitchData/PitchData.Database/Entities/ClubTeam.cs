using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PitchData.Database.Enums;

namespace PitchData.Database.Entities
{
    public class ClubTeam : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime FoundedYear { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        public Formations CurrentFormation { get; set; }
        public TacticalAttackingStyles TacticalAttackingStyle { get; set; }
        public TacticalDefensiveStyles TacticalDefensiveStyle { get; set; }
        //foreign 
        public int CoachId { get; set; }
        public Coach Coach { get; set; }

        public ICollection<Player> Players { get; set; }
        public ICollection<ClubTrophy> TrophiesWon { get; set; }
    }
}
