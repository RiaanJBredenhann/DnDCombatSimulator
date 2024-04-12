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
        public int Level { get; }
        public Dice DamageDice { get; }
        public string TargetType { get; }
        public string Save { get; }


        public Spell(string name, int level, Dice dice, string targetType, string save)
        {
            this.Name = name;
            this.Level = level;
            this.DamageDice = dice;
            this.TargetType = targetType;
            this.Save = save;
        }
    }
}
