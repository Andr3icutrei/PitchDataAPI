using Microsoft.EntityFrameworkCore;
using PitchData.Database.Context;
using PitchData.Database.Entities;
using PitchData.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Repositories
{
    public class CoachesRepository : BaseRepository<Coach>, ICoachRepository
    {
        public CoachesRepository(PitchDataDatabaseContext dbContext) : base(dbContext) 
        {

        }
        public async Task<IEnumerable<Coach>> GetCoachesAsync()
        {
            return await GetRecords().Include(c => c.ClubTeam).Include(c => c.NationalTeam).ToListAsync();
        }

        public async Task<Coach?> GetCoachesAsync(int id)
        {
            return await GetRecords().
                Include(c => c.ClubTeam).
                Include(c => c.NationalTeam).
                FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
