    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSim_Console
{
    internal class Player : Creature, IAction, IBonusAction
    {
        private char _type;

        public Player() { }

        public Player(string name, int profMod, int maxHP, int str, int dex, int con, int intl, int wis, int cha, int AC, char type)
            : base(name, profMod, maxHP, str, dex, con, intl, wis, cha, AC)
        {
            this._type = type;
        }
        

    }
}
