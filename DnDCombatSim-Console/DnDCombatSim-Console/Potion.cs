using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSim_Console
{
    internal class Potion : Item
    {
        private string _damageDice;

        public Potion() { }

        public Potion(string name, int id, string damageDice) : base(name, id)
        {
            this._damageDice = damageDice;
        }

        public string GetDamageDice()
        {
            return this._damageDice;
        }
    }
}
