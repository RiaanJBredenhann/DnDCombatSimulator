using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSimSimple
{
    internal class Spell
    {
        public string Name { get; }
        public Dice DamageDice { get; }
        public string TargetType { get; }
        public string Save { get; }


        public Spell(string name, Dice dice)
        {
            this.Name = name;
            this.DamageDice = dice;
        }
    }
}
