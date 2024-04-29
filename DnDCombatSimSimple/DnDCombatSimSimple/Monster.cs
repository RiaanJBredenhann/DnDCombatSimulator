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

        public Monster(char creatureType, string name, int id, int maxHP, int AC, int profMod, int str, int dex, int con, int wis, int intl, int cha,
                     List<Spell> spells, List<Slot> slots, string spellcastingAbility, List<Weapon> weapons) :
           base(creatureType, name, maxHP, AC, profMod, str, dex, con, wis, intl, cha, spells, slots, spellcastingAbility, weapons)
        {
            this.ID = id;
        }

        public Monster() { }
    }
}
