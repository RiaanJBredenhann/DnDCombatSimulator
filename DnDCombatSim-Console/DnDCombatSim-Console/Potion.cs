using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSim_Console
{
    internal class Potion : Item
    {
        private int _healingAmount;

        public Potion() { }

        public Potion(string name, int id) : base(name, id)
        {
            
        }
    }
}
