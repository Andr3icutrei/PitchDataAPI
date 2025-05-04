using PitchData.Core.Dtos;
using PitchData.Core.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Services.Interfaces
{
    public interface IClubTeamService
    {
        Task<IEnumerable<ClubTeamDto>> GetClubTeamsWithPlayersAsync();
        Task<ClubTeamDto?> GetClubTeamWithPlayersAsync(int id);
        Task<(bool Success, string ErrorMessage)> AddClubTeamAsync(AddClubTeamRequest request);
    }
}
