using PitchData.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Repositories.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Task<IEnumerable<Player>> GetPlayersWithTeamsAsync();
        Task<Player?> GetPlayersWithTeamsAsync(int id);
    }
}
