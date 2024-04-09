using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSimSimple
{
    internal class Creature
    {
        public string Name { get; }

        public int MaxHP { get; }
        public int CurrentHP { get; set; }
        public int ArmourClass { get; }

        public int Strength { get; }
        public int StrengthMod { get; }
        public int Dexterity { get; }
        public int DexterityMod { get; }
        public int Constitution { get; }
        public int ConstitutionMod { get; }
        public int Intelligence { get; }
        public int IntelligenceMod { get; }
        public int Wisdom { get; }
        public int WisdomMod { get; }
        public int Charisma { get; }
        public int CharismaMod { get; }


        private List<Spell> _spells = new List<Spell>();
        public List<Spell> Spells 
        { 
            get { return _spells; } 
            set { _spells = value; }
        }

        private List<Slot> _spellSlots = new List<Slot>();
        public List<Slot> SpellSlots
        {
            get { return _spellSlots; }
            set { _spellSlots = value; }
        }

        private List<Weapon> _weapons = new List<Weapon>();
        public List<Weapon> Weapons 
        {  
            get { return _weapons; } 
            set {  _weapons = value; }
        }


        public Creature(string name, int maxHP, int AC, int str, int dex, int con, int wis, int intl, int cha, 
                        List<Spell> spells, List<Slot> slots, List<Weapon> weapons) 
        { 
            this.Name = name;
            this.MaxHP = maxHP;
            this.CurrentHP = maxHP;
            this.ArmourClass = AC;
            this.StrengthMod = CalculateModifier(str);
            this.DexterityMod = CalculateModifier(dex);
            this.ConstitutionMod = CalculateModifier(con);
            this.WisdomMod = CalculateModifier(wis);
            this.IntelligenceMod = CalculateModifier(intl);
            this.CharismaMod = CalculateModifier(cha);
            this.Spells = spells;
            this.SpellSlots = slots;
            this.Weapons = weapons;
        }

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //
        //                                             METHODS
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //

        static int CalculateModifier(int abilityScore)
        {
            return (abilityScore - 10) / 2;
        }

    }
}
