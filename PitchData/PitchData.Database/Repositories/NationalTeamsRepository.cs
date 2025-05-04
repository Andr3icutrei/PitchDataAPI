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
    public class NationalTeamsRepository : BaseRepository<NationalTeam>, INationalTeamRepository
    {
        public NationalTeamsRepository(PitchDataDatabaseContext dbContext) : base(dbContext)
        {

        }
        public async Task<NationalTeam?> GetNationalTeamsWithPlayersAsync(int id)
        {
            return await GetRecords().
                Include(nt => nt.Coach).
                Include(nt => nt.Players).
                Include(nt => nt.TrophiesWon).FirstOrDefaultAsync(nt => nt.Id == id);
        }

        public async Task<IEnumerable<NationalTeam>> GetNationalTeamsWithPlayersAsync()
        {
            return await GetRecords().
                Include(nt => nt.Coach).
                Include(nt => nt.Players).
                Include(nt => nt.TrophiesWon).
                ToListAsync();
        }
    }
}
