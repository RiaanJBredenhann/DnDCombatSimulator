using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSim_Console
{
    internal class Creature : IAction, IBonusAction
    {
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //
        //                                     MEMBERS
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //

        // Details
        private string _name;
        private int _proficiencyModifier;
        private int _currentHealthPoints;
        private int _maxHealthPoints;

        // Ability Stats
        private int _strength;
        private int _strengthModifier;
        private int _dexterity;
        private int _dexterityModifier;
        private int _constitution;
        private int _constitutionModifier;
        private int _intelligence;
        private int _intelligenceModifier;
        private int _wisdom;
        private int _wisdomModifier;
        private int _charisma;
        private int _charismaModifier;

        // Combat Stats
        private int _armourClass;
        private int _initiative;

        // Weapons
        protected List<Weapon> _weapons;

        // Spells
        private int[] _spellSlots;
        private Spell[] _spells;

        // Items
        private List<Item> _items;

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //
        //                                   CONSTRUCTORS
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //

        public Creature() { }

        public Creature(string name, int profMod, int maxHP, int str, int dex, int con, int intl, int wis, int cha, int AC)
        {
            this._name = name;
            this._proficiencyModifier = profMod;
            this._maxHealthPoints = maxHP;
            this._currentHealthPoints = maxHP;
            this._strength = str;
            this._strengthModifier = (str - 10) / 2;
            this._dexterity = dex;
            this._dexterityModifier = (dex - 10) / 2;
            this._constitution = con;
            this._constitutionModifier = (con - 10) / 2;
            this._intelligence = intl;
            this._intelligenceModifier = (intl - 10) / 2;
            this._wisdom = wis;
            this._wisdomModifier = (wis - 10) / 2;
            this._charisma = cha;
            this._charismaModifier = (cha - 10) / 2;
            this._armourClass = AC;

            _items = new List<Item>();
            _weapons = new List<Weapon>();
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //
        //                                  CLASS METHODS
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //

        public void RollInitiative()
        {
            Random random = new Random();

            this._initiative = random.Next(1, 21) + this._dexterityModifier; 
        }

        protected virtual int GetID()
        {
            return 0;
        }

        public string GetName()
        {
            return this._name;
        }

        public int GetInitiative()
        {
            return this._initiative;
        }

        public void GetWeapons()
        {
            foreach (Weapon weapon in this._weapons)
            {
                Console.WriteLine(weapon.GetName());
            }
        }

        public void SetWeapons()
        {
            this._weapons.Add(new Weapon("Dagger", "1d4"));
            this._weapons.Add(new Weapon("Longbow", "1d10"));
            this._weapons.Add(new Weapon("Longsword", "1d10"));
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //
        //                                 INTERFACE METHODS
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //

        public void AttackWithWeapon(Creature c)
        {
            //throw new NotImplementedException();

            Console.WriteLine($"{this._name} attacked {c._name} {c.GetID()}");
        }

        public void CastASpell(Creature c)
        {
            throw new NotImplementedException();
        }

        public void HealAlly(Creature c)
        {
            throw new NotImplementedException();
        }

        public void HealSelf()
        {
            throw new NotImplementedException();
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //
    }
}
