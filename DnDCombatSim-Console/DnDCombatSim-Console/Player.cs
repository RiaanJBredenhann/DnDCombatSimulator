    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSim_Console
{
    internal class Player : Creature, IAction, IBonusAction
    {
        private char _classType;

        public Player() { }

        public Player(string name, int id, int profMod, int maxHP, char creatureType, int str, int dex, int con, int intl, int wis, int cha, int AC, char classType)
            : base(name, id, profMod, maxHP, creatureType, str, dex, con, intl, wis, cha, AC)
        {
            this._classType = classType;
        }
        

    }
}
