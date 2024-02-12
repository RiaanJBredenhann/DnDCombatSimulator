using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSim
{
    internal class Monster : Creature, IAction, IBonusAction
    {
        private int _id;

        public Monster() { }

        public Monster(string name, int profMod, int currHP, int maxHP, int str, int dex, int con, int intl, int wis, int cha, int AC, int id)
            : base(name, profMod, currHP, maxHP, str, dex, con, intl, wis, cha, AC)
        {
            this._id = id;
        }
    }
}
