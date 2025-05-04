using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PitchData.Database.Enums;

namespace PitchData.Database.Entities
{
    public class Player : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(50)]
        public string Nationality { get; set; }
        public int Height { get; set; }
        public int? Goals { get; set; }
        public int? Assists { get; set; }
        public PlayerPositions Position { get; set; }
        public bool IsActive { get; set; }
        [Precision(18, 2)]
        public decimal? MarketValue { get; set; }

        //foreign 
        public int? NationalTeamId { get;set; }
        public NationalTeam? NationalTeam { get; set; }
        public int? ClubTeamId { get; set; }
        public ClubTeam? ClubTeam { get; set; }
    }
}
