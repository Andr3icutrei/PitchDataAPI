using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Enums
{
    public enum PlayerPositions
    {
        InvalidPosition = 0,

        GK = 1,
        LB = 2,
        CB = 4,
        RB = 8,
        CDM = 16,
        CM = 32,
        CAM = 64,
        RW = 128,
        ST = 256,
        LW = 512,
    }
}
