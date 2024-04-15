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
        public double CurrentHP { get; set; }
        public int ArmourClass { get; }
        public int Initiative { get; set; }

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

            if (chosenWeapon.Property == "Light")
                modifier = this.DexterityMod;
            else
                modifier = this.StrengthMod;

            Console.WriteLine($"{this.Name} is attacking {target.Name} with a {chosenWeapon.Name}");

            int d20Roll = RollD20();
            int attackRoll = d20Roll + this.ProficiencyMod + modifier;

            if (attackRoll >= target.ArmourClass)
            {
                double damageRoll = chosenWeapon.DamageDice.CalculateDice() + modifier;
                if (d20Roll == 20)
                {
                    damageRoll *= 2;
                    Console.WriteLine($"{this.Name} landed a critical hit dealing double damage!");
                }
                target.CurrentHP -= damageRoll;

                Console.Write($"{this.Name} rolled a {attackRoll} and hit {target.Name} dealing {damageRoll} point(s) of damage");

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
            Slot chosenSlot = ChooseSpellSlot(chosenSpell);

            if (chosenSlot != null)
            {
                int attackModifier;
                switch (this.SpellcastingAbility)
                {
                    case "Wisdom":
                        attackModifier = this.WisdomMod;
                        break;
                    case "Intelligence":
                        attackModifier = this.IntelligenceMod;
                        break;
                    case "Charisma":
                        attackModifier = this.CharismaMod;
                        break;
                    default:
                        attackModifier = 0;
                        break;
                }

                Console.WriteLine($"{this.Name} is casting {chosenSpell.Name} at level {chosenSlot.Level} on {target.Name}");

                if (chosenSpell.TargetType == "Save")
                    SavingThrowSpell(target, chosenSpell, chosenSlot, attackModifier);
                else
                    ArmourClassSpell(target, chosenSpell, chosenSlot, attackModifier);
            }
            else
            {
                Console.WriteLine($"{this.Name} does not have any spell slots left to cast {chosenSpell.Name} and will attack with their weapon");
                this.AttackWithWeapon(target);
            }

        }

        public Slot ChooseSpellSlot(Spell chosenSpell)
        {
            if (chosenSpell.Level == 0)
            {
                return this.SpellSlots[0];
            }
            else
            {
                for (int i = 1; i < this.SpellSlots.Count; i++)
                {
                    if (this.SpellSlots[i].Level >= chosenSpell.Level && this.SpellSlots[i].Amount > 0)
                    {
                        this.SpellSlots[i].Amount -= 1;
                        return this.SpellSlots[i];
                    }
                }
                return null;
            }
            
        }

        public void SavingThrowSpell(Creature target, Spell chosenSpell, Slot chosenSlot, int attackModifier)
        {
            //Random r = new Random();
            double damageRoll;
            int saveMod;

            switch (chosenSpell.Save)
            {
                case "Strength":
                    saveMod = target.StrengthMod;
                    break;
                case "Dexterity":
                    saveMod = target.DexterityMod;
                    break;
                case "Constitution":
                    saveMod = target.ConstitutionMod;
                    break;
                case "Intelligence":
                    saveMod = target.IntelligenceMod;
                    break;
                case "Wisdom":
                    saveMod = target.WisdomMod;
                    break;
                case "Charisma":
                    saveMod = target.CharismaMod;
                    break;
                default:
                    saveMod = 0;
                    break;
            }

            int d20Roll = RollD20();
            damageRoll = chosenSpell.DamageDice.CalculateDice(chosenSpell, chosenSlot);
            if (d20Roll == 20)
            {
                damageRoll *= 2;
                Console.WriteLine($"{this.Name} landed a critical hit dealing double damage!");
            }
                
            if (d20Roll + saveMod < 8 + this.ProficiencyMod + attackModifier)
            {
                Console.WriteLine($"{target.Name} failed the save against {chosenSpell.Name} and took {damageRoll} point(s) of damage");
            }
            else
            {
                damageRoll = Math.Ceiling(damageRoll/2);
                Console.WriteLine($"{target.Name} succedded on the save against {chosenSpell.Name} and took {damageRoll} point(s) of damage");
            }

            target.CurrentHP -= damageRoll;
        }

        public void ArmourClassSpell(Creature target, Spell chosenSpell, Slot chosenSlot, int attackModifier)
        {
            //Random r = new Random();
            int d20Roll = RollD20();
            int attackRoll = d20Roll + this.ProficiencyMod + attackModifier;
            if (attackRoll >= target.ArmourClass)
            {
                double damageRoll = chosenSpell.DamageDice.CalculateDice(chosenSpell, chosenSlot);
                if (d20Roll == 20)
                {
                    damageRoll *= 2;
                    Console.WriteLine($"{this.Name} landed a critical hit dealing double damage!");
                }
                target.CurrentHP -= damageRoll;

                Console.Write($"{this.Name} rolled a {attackRoll} and hit {target.Name} dealing {damageRoll} point(s) of damage");

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


        public static int RollD20()
        {
            Random r = new Random();
            return r.Next(1, 21);
        }

        

    }
}
