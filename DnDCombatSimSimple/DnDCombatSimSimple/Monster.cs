using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSimSimple
{
    internal class Monster : Creature
    {
        public int ID {  get; set; }

        public Monster(string name, int id, int maxHP, int AC, int str, int dex, int con, int wis, int intl, int cha,
                     List<Spell> spells, List<Slot> slots, List<Weapon> weapons) :
           base(name, maxHP, AC, str, dex, con, wis, intl, cha, spells, slots, weapons)
        {
            this.ID = id;
        }
    }
}
