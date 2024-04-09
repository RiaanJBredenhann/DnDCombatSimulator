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

        public int ProficiencyMod { get; }
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

        public string SpellcastingAbility { get; }


        private List<Weapon> _weapons = new List<Weapon>();
        public List<Weapon> Weapons 
        {  
            get { return _weapons; } 
            set {  _weapons = value; }
        }


        public bool IsDead { get; set; }


        public Creature(string name, int maxHP, int AC, int profMod, int str, int dex, int con, int wis, int intl, int cha, 
                        List<Spell> spells, List<Slot> slots, string spellcastingAbility, List<Weapon> weapons) 
        { 
            this.Name = name;
            this.MaxHP = maxHP;
            this.CurrentHP = maxHP;
            this.ArmourClass = AC;
            this.ProficiencyMod = profMod;
            this.StrengthMod = CalculateModifier(str);
            this.DexterityMod = CalculateModifier(dex);
            this.ConstitutionMod = CalculateModifier(con);
            this.WisdomMod = CalculateModifier(wis);
            this.IntelligenceMod = CalculateModifier(intl);
            this.CharismaMod = CalculateModifier(cha);
            this.Spells = spells;
            this.SpellSlots = slots;
            this.SpellcastingAbility = spellcastingAbility;
            this.Weapons = weapons;
            this.IsDead = false;
        }

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //
        //                                             METHODS
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //

        static int CalculateModifier(int abilityScore)
        {
            return (abilityScore - 10) / 2;
        }

        public void AttackWithWeapon(Creature target)
        {
            Random r = new Random();
            Weapon chosenWeapon = this.Weapons[r.Next(0, this.Weapons.Count)];
            int modifier;
            int attackRoll;
            int damageRoll;

            if (chosenWeapon.Property == "Light")
                modifier = this.DexterityMod;
            else
                modifier = this.StrengthMod;

            Console.WriteLine($"{this.Name} is attacking {target.Name} with a {chosenWeapon.Name}");

            attackRoll = r.Next(1, 21) + this.ProficiencyMod + modifier;
            if (attackRoll >= target.ArmourClass)
            {
                damageRoll = chosenWeapon.DamageDice.CalculateDice() + modifier;
                target.CurrentHP -= damageRoll;

                Console.Write($"{this.Name} rolled a {attackRoll} and hit {target.Name} dealing {damageRoll} damage");

                if (target.CurrentHP <= 0)
                {
                    target.IsDead = true;
                    Console.WriteLine($" killing {target.Name}");
                }
            }
            else
            {
                Console.WriteLine($"{this.Name} rolled a {attackRoll} and missed {target.Name} dealing no damage");
            }

        }

        public void CastASpell(Creature target)
        {
            Random r = new Random();
            Spell chosenSpell = this.Spells[r.Next(0, this.Spells.Count)];
            int modifier = 0;
            int attackRoll;
            int damageRoll;

            switch (this.SpellcastingAbility)
            {
                case "Wisdom": 
                    modifier = this.WisdomMod;
                    break;
                case "Intelligence": 
                    modifier = this.IntelligenceMod;
                    break;
                case "Charisma": 
                    modifier = this.CharismaMod;
                    break;
            }

            Console.WriteLine($"{this.Name} is casting {chosenSpell.Name} on {target.Name}");

            attackRoll = r.Next(1, 21) + this.ProficiencyMod + modifier;
            if (attackRoll >= target.ArmourClass)
            {
                damageRoll = chosenSpell.DamageDice.CalculateDice() + modifier;
                target.CurrentHP -= damageRoll;

                Console.Write($"{this.Name} rolled a {attackRoll} and hit {target.Name} dealing {damageRoll} damage");

                if (target.CurrentHP <= 0)
                {
                    target.IsDead = true;
                    Console.WriteLine($" killing {target.Name}");
                }
            }
            else
            {
                Console.WriteLine($"{this.Name} rolled a {attackRoll} and missed {target.Name} dealing no damage");
            }

        }

        public void DrinkPotion()
        {

        }
        public void ThrowGrenade()
        {

        }

    }
}
