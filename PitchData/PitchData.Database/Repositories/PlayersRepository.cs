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
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(PitchDataDatabaseContext dbContext) : base(dbContext) 
        {
            
        }
        public async Task<IEnumerable<Player>> GetPlayersWithTeamsAsync()
        {
            return await GetRecords().
                Include(p => p.NationalTeam).
                Include(p => p.ClubTeam).ToListAsync();
        }

        public async Task<Player?> GetPlayersWithTeamsAsync(int id)
        {
            return await GetRecords().
                Include(p => p.NationalTeam).
                Include(p => p.ClubTeam).
                FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
