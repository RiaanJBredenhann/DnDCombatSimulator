using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSimSimple
{
    internal class Slot
    {
        public int Level { get; }
        public int Amount { get; set; }

        public Slot(int level, int amount)
        {
            this.Level = level;
            this.Amount = amount;
        }
    }
}
