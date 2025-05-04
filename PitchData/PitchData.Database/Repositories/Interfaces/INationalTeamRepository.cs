using PitchData.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Repositories.Interfaces
{
    public interface INationalTeamRepository : IBaseRepository<NationalTeam>
    {
        Task<IEnumerable<NationalTeam>> GetNationalTeamsWithPlayersAsync();
        Task<NationalTeam?> GetNationalTeamsWithPlayersAsync(int id);
    }
}
