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
        public int Amount { get; set; }


        public Consumable(string name, Dice dice, int amount)
        {
            this.Name = name;
            this.DamageDice = dice;
            this.Amount = amount;
        }

    }
}
