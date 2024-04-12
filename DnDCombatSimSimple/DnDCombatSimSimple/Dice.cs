using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSimSimple
{
    internal class Dice
    {
        public int Amount { get; }
        public int Type { get; }


        public Dice(int amount, int type) 
        {
            this.Amount = amount;
            this.Type = type;
        }

        // returns the raw value of a specified dice roll
        public int CalculateDice()
        {
            Random r = new Random();
            int result = 0;

            for (int i = 1; i <= this.Amount; i++)
            {
                result += r.Next(1, this.Type + 1);
            }

            return result;
        }

        public int CalculateDice(Spell spell, Slot slot)
        {
            Random r = new Random();
            int result = 0;

            for (int i = 1; i <= this.Amount + (slot.Level - spell.Level); i++)
            {
                result += r.Next(1, this.Type + 1);
            }

            return result;
        }
    }
}
