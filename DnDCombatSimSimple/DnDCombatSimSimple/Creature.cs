using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSimSimple
{
    internal class Creature
    {
        public char CreatureType { get; }
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


        public Creature(char creatureType, string name, int maxHP, int AC, int profMod, int str, int dex, int con, int wis, int intl, int cha, 
                        List<Spell> spells, List<Slot> slots, string spellcastingAbility, List<Weapon> weapons) 
        { 
            this.CreatureType = creatureType;
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
        }

        public Creature() { }

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //
        //                                             METHODS
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //

        /* Calculate and return the ability score modifier by taking the ability score as an argument */
        static int CalculateModifier(int abilityScore)
        {
            return (abilityScore - 10) / 2;
        }

        /* Return a random creature of the opposite type depending on the type of creature currently in turn order 
         * A player creature will choose a random monster creature and vice versa */
        public Creature ChooseTarget(List<Player> players, List<Monster> monsters)
        {
            Random r = new Random();

            if (this.CreatureType == 'P')
                return monsters[r.Next(0, monsters.Count)];
            else
                return players[r.Next(0, players.Count)];
        }

        /* The current creature in turn order will attack the target that was randomly selected with a random weapon in their inventory
         * First we choose a random weapon from the creature's inventory and calculate the attack and damage modifier
         *      Heavy weapons us strength and light weapons use dexterity
         * We then roll the attack and if it hits we roll for damage, other wise we communicate that the attack missed
         * Finally we check if the target was killed and if so we remove it from its respective list */
        public void AttackWithWeapon(Creature target, List<Player> players, List<Monster> monsters)
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

                Console.WriteLine($"{this.Name} rolled a {attackRoll} and hit {target.Name} dealing {damageRoll} point(s) of damage");

                if (target.CurrentHP <= 0)
                {
                    if (target.CreatureType == 'P')
                        players.Remove((Player)target);
                    else
                        monsters.Remove((Monster)target);
                    Console.Write($" killing {target.Name}");
                }
            }
            else Console.WriteLine($"{this.Name} rolled a {attackRoll} and missed {target.Name} dealing no damage");

        }

        /* The current creature in turn order will attack the target that was randomly selected with a random spell in their spell list
         * First we choose a random spell from the creature's spell list and calculate the attack modifier based on the creature's spellcasting ability
         * Next we identify what type of spell it is, saveing throw or armour class, and call the appropriate method
         *  */
        public void CastASpell(Creature target, List<Player> players, List<Monster> monsters)
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

                if (target.CurrentHP <= 0)
                {
                    if (target.CreatureType == 'P')
                        players.Remove((Player)target);
                    else
                        monsters.Remove((Monster)target);
                    Console.Write($" killing {target.Name}");
                }
            }
            else
            {
                Console.WriteLine($"{this.Name} does not have any spell slots left to cast {chosenSpell.Name} and will attack with their weapon");
                this.AttackWithWeapon(target, players, monsters);
            }

            //Console.WriteLine();

        }

        public Slot ChooseSpellSlot(Spell chosenSpell)
        {
            if (chosenSpell.Level == 0)
                return this.SpellSlots[0];
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

        /* Saving throw spells require the target to perfomr a saving throw to decide whether or not the spell affect them
         * On a save, the spell either does nothing or only deals half damage
         * On a fail, the spellafflicts the target with a cndition or does full damage */
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
                Console.WriteLine($"{target.Name} failed the save against {chosenSpell.Name} and took {damageRoll} point(s) of damage");
            else
            {
                damageRoll = Math.Ceiling(damageRoll/2);
                Console.WriteLine($"{target.Name} succedded on the save against {chosenSpell.Name} and took {damageRoll} point(s) of damage");
            }

            target.CurrentHP -= damageRoll;
        }

        /* Armour class spell target the target's armour directly, like a weapon attack
         * If the attack roll is equal to or higher than the target's armour class, the spell hits and deals damage, 
         * otherwise it misses and deals no damage */
        public void ArmourClassSpell(Creature target, Spell chosenSpell, Slot chosenSlot, int attackModifier)
        {
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
                Console.WriteLine($"{this.Name} rolled a {attackRoll} and hit {target.Name} dealing {damageRoll} point(s) of damage");
            }
            else
            {
                Console.WriteLine($"{this.Name} rolled a {attackRoll} and missed {target.Name} dealing no damage");
            }
        }

        /* Roll a 20 sided die
         * Returns a value from 1 to 20 */
        public static int RollD20()
        {
            Random r = new Random();
            return r.Next(1, 21);
        }

    }
}
