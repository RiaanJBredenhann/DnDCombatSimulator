using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSim_Console
{
    internal interface IAction
    {
        void AttackWithWeapon(Creature c);
        void CastASpell(Creature c);
    }
}
