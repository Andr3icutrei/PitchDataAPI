using PitchData.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Entities
{
    public class NationalTeam : BaseEntity
    {
        public DateTime FoundedYear { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        public Formations CurrentFormation { get; set; }
        public TacticalAttackingStyles TacticalAttackingStyle { get; set; }
        public TacticalDefensiveStyles TacticalDefensiveStyle { get; set; }
        public int CoachId {  get; set; }
        public Coach Coach { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<InternationalTrophy> TrophiesWon { get; set; }
    }
}
