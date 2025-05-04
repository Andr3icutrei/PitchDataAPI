using PitchData.Database.Entities;
using PitchData.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Dtos
{
    public class InternationalTrophyDto : BaseDto
    {
        public string Competition { get; set; }
        public DateTime WinDate { get; set; }
        public int NationalTeamId { get; set; }
        public string WinnerTeamName { get; set; }
    }
}
