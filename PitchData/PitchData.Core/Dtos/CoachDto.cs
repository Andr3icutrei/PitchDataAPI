using PitchData.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Dtos
{
    public class CoachDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CareerWins { get; set; }
        public int CareerDraws { get; set; }
        public int CareerLosses { get; set; }
        public String Nationality { get; set; }
        public string? ClubTeamName { get; set; }
        public string? NationalTeamName { get; set; }
    }
}
