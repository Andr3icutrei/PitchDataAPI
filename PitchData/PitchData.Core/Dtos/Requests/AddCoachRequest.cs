using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Dtos.Requests
{
    public class AddCoachRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CareerWins { get; set; }
        public int CareerDraws { get; set; }
        public int CareerLosses { get; set; }
        public string Nationality { get; set; }
    }
}
