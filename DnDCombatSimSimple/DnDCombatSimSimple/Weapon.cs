using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSimSimple
{
    internal class Weapon
    {
        public string Name { get; }
        public Dice DamageDice { get; }
        public string Property { get; }

        public Weapon(string name, Dice dice, string property)
        {
            this.Name = name;
            this.DamageDice = dice;
            this.Property = property;
        }

    }
}
