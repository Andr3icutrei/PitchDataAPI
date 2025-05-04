using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PitchData.Database.Context;
using PitchData.Database.Entities;
using PitchData.Database.Repositories.Interfaces;

namespace PitchData.Database.Repositories
{
    public class ClubTrophiesRepository : BaseRepository<ClubTrophy>, IClubTrophyRepository
    {
        public ClubTrophiesRepository(PitchDataDatabaseContext dbContext) : base(dbContext) 
        {
            
        }
        public async Task<IEnumerable<ClubTrophy>> GetClubTrophiesWithClubTeamAsync()
        {
            return await GetRecords().Include(ct => ct.WinnerTeam).ToListAsync();
        }

        public async Task<ClubTrophy?> GetClubTrophiesWithClubTeamAsync(int id)
        {
            return await GetRecords().Include(ct => ct.WinnerTeam).FirstOrDefaultAsync(ct => ct.Id == id);
        }
    }
}
