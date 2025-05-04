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
    public class InternationalTrophiesRepository : BaseRepository<InternationalTrophy>, IInternationalTrophyRepository
    {
        public InternationalTrophiesRepository(PitchDataDatabaseContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<InternationalTrophy>> GetAllInternationalTrophysWithNationalTeamAsync()
        {
            return await GetRecords().
                Include(intTrophy => intTrophy.WinnerTeam).
                ToListAsync();
        }

        public async Task<InternationalTrophy?> GetAllInternationalTrophysWithNationalTeamAsync(int id)
        {
            return await GetRecords().
                Include(intTrophy => intTrophy.WinnerTeam).
                FirstOrDefaultAsync(intTrophy => intTrophy.Id == id);
        }
    }
}
