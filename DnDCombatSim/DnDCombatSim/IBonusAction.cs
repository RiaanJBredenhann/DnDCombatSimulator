using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSim
{
    internal interface IBonusAction
    {
        void HealSelf();
        void HealAlly();
    }
}
