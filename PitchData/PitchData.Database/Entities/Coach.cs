using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Entities
{
    public class Coach : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public int CareerWins { get; set; }
        public int CareerDraws { get; set; }    
        public int CareerLosses { get; set; }
        [MaxLength(50)]
        public string Nationality { get; set; }

        public ClubTeam? ClubTeam { get; set; }
        public NationalTeam? NationalTeam { get; set; }
    }
}
