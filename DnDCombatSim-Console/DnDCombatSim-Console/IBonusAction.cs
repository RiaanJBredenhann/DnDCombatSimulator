using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSim_Console
{
    internal interface IBonusAction
    {
        void HealSelf();
        void HealAlly(Creature c);
    }
}
