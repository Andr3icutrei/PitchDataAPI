using PitchData.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Repositories.Interfaces
{
    public interface IClubTeamRepository : IBaseRepository<ClubTeam>
    {
        Task<IEnumerable<ClubTeam>> GetClubTeamsWithPlayersAsync();
        Task<ClubTeam?> GetClubTeamWithPlayersAsync(int id);
    }
}
