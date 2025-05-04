using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Enums
{
    public enum TacticalAttackingStyles
    {
        InvalidTacticalAttackingStyles = 0,

        TikiTaka = 1,
        Counterattack = 2,
        Balanced = 4,
        ShortPassing = 8,
        DirectPassing = 16,
        Possession = 32,
        ForwardRuns = 64,

    }
}
