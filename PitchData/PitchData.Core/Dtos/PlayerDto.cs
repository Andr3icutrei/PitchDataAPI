using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Dtos
{
    public class PlayerDto : BaseDto
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public int Height { get; set; }
        public int? Goals { get; set; }
        public int? Assists { get; set; }
        public string Position { get; set; }
        public decimal? MarketValue { get; set; }
        public int? NationalTeamId { get; set; }   
        public int? ClubTeamId { get; set; }
    }
}
