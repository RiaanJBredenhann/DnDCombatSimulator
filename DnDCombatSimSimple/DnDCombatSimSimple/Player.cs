using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSimSimple
{
    internal class Player : Creature
    {
        private List<Consumable> _consumables = new List<Consumable>();
        public List<Consumable> Consumables
        {
            get { return _consumables; }
            set { _consumables = value; }
        }


        public Player(string name, int maxHP, int currentHP, int AC, int str, int dex, int con, int wis, int intl, int cha,
                      List<Spell> spells, int[] slots, List<Weapon> weapons, List<Consumable> consumables) : 
            base(name, maxHP, currentHP, AC, str, dex, con, wis, intl, cha, spells, slots, weapons)
        {
            this.Consumables = consumables;
        }
    }
}
