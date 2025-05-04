using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Enums
{
    public enum Formations
    {
        InvalidFormation = 0,

        _4_3_3 = 1,
        _4_4_2 = 2,
        _4_2_4 = 4,
        _3_5_2 = 8,
        _3_4_3 = 16,
        _4_2_3_1 = 32,
        _5_3_2 = 64,
        _4_5_1 = 128,
        _4_3_2_1 = 256,
        _4_4_1_1 = 512
    }
}
