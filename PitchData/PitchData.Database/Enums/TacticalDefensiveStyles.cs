using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Database.Enums
{
    public enum TacticalDefensiveStyles
    {
        InvalidTacticalDefensiveStyles = 0,

        PressureOnHeavyTouch = 1,
        PressAfterPossesionLoss = 2,
        Balanced = 4,
        DropBack = 8,
        ConstantPressure = 16
    }
}
