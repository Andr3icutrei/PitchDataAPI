using PitchData.Core.Dtos;
using PitchData.Core.Dtos.Requests;
using PitchData.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core.Services.Interfaces
{
    public interface INationalTeamService
    {
        Task<IEnumerable<NationalTeamDto>> GetNationalTeamsWithPlayersAsync();
        Task<NationalTeamDto?> GetNationalTeamsWithPlayersAsync(int id);
        Task<(bool Success, string ErrorMessage)> AddNationalTeamAsync(AddNationalTeamRequest request);
    }
}
