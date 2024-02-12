using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSim_Console
{
    internal class Item
    {
        private string _name;
        private int _id;

        public Item() { }
        public Item(string name, int id) 
        {
            this._name = name;
            this._id = id;
        }

    }
}
