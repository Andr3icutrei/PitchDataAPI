using PitchData.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Repositories.Interfaces
{
    public interface ICoachRepository : IBaseRepository<Coach>
    {
        Task<IEnumerable<Coach>> GetCoachesAsync();
        Task<Coach?> GetCoachesAsync(int id);
    }
}
