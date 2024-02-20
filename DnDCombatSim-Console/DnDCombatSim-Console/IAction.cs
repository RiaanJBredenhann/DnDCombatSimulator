using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSim_Console
{
    internal interface IAction
    {
        void AttackWithWeapon(List<Player> players, List<Monster> monsters, List<Creature> deadCreatures);
        void CastASpell(List<Player> players, List<Monster> monsters);
    }
}
