using PitchData.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Repositories.Interfaces
{
    public interface IClubTrophyRepository : IBaseRepository<ClubTrophy>
    {
        Task<IEnumerable<ClubTrophy>> GetClubTrophiesWithClubTeamAsync();
        Task<ClubTrophy?> GetClubTrophiesWithClubTeamAsync(int id);
    }
}
