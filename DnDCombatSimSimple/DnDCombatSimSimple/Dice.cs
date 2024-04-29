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

        /* This is an overloaded method used to calculate the dice roll of any object with a DamageDice property
         * This method returns the raw value of a specified dice roll for weapon attacks */
        public double CalculateDice()
        {
            Random r = new Random();
            double result = 0;

            for (int i = 1; i <= this.Amount; i++) 
                result += r.Next(1, this.Type + 1);

            return result;
        }

        /* This method returns the raw value of the specified dice roll for spell attacks
         * Spells can be upcast using spell slots of higher levels and in turn will deal more damage
         * So we identify the spell slot used for the spell and adapt the damage the spell deals accordingly */
        public double CalculateDice(Spell spell, Slot slot)
        {
            Random r = new Random();
            double result = 0;

            for (int i = 1; i <= this.Amount + (slot.Level - spell.Level); i++) 
                result += r.Next(1, this.Type + 1);

            return result;
        }
    }
}
