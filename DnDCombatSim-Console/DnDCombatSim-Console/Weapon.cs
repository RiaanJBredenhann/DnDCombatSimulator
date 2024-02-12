using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSim_Console
{
    internal class Weapon
    {
        private string _name;
        private string[] _proporties;
        private string _damageDice;

        public Weapon() { }

        public Weapon(string name, string damageDice) 
        {
            this._name = name;
            this._damageDice = damageDice;
        }

        public string GetName()
        {
            return this._name;
        }

        public void SetProporties()
        {

        }
    }
}
