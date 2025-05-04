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

    public class ClubTeamRepository : BaseRepository<ClubTeam>, IClubTeamRepository
    {
        public ClubTeamRepository(PitchDataDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public async Task<IEnumerable<ClubTeam>> GetClubTeamsWithPlayersAsync()
        {
            return await GetRecords()
                .Include(c => c.Players)
                .ToListAsync();
        }

        public async Task<ClubTeam?> GetClubTeamWithPlayersAsync(int id)
        {
            return await GetRecords()
                .Include(c => c.Players)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
