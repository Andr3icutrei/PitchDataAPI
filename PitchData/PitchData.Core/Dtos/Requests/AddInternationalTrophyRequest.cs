using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Dtos.Requests
{
    public class AddInternationalTrophyRequest
    {
        public string Competition { get; set; }
        public DateTime WinDate { get; set; }
        // foreign
        public int NationalTeamId { get; set; }
    }
}
