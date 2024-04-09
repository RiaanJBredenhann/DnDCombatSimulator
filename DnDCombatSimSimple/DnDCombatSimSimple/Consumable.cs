using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSimSimple
{
    internal class Consumable
    {
        public string Name { get; }
        public Dice DamageDice { get; }


        public Consumable(string name, Dice dice)
        {
            this.Name = name;
            this.DamageDice = dice;
        }

    }
}
