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
        private int _dexterity;
        private int _constitution;
        private int _intelligence;
        private int _wisdom;
        private int _charisma;

        // Combat Stats
        private int _armourClass;
        private int initiative;

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
            this._dexterity = dex;
            this._constitution = con;
            this._intelligence = intl;
            this._wisdom = wis;
            this._charisma = cha;
            this._armourClass = AC;

            _items = new List<Item>();
            _weapons = new List<Weapon>();
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //
        //                                  CLASS METHODS
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //

        protected virtual int GetID()
        {
            return 0;
        }

        public List<Item> GetItems()
        {
            return this._items;
        }

        public void SetItems(Item item)
        {
            _items.Add(item);
        }

        public string GetName()
        {
            return this._name;
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
