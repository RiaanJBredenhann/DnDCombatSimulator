using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSim
{
    internal class Creature : IAction, IBonusAction
    {
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

        // Weapons
        private Weapon[] _weapons;

        // Spells
        private int[] _spellSlots;
        private Spell[] _spells;

        // Inventory
        private Item[] _items;

        public Creature() { }

        public Creature(string name, int profMod, int currHP, int maxHP, int str, int dex, int con, int intl, int wis, int cha, int AC)
        {
            this._name = name;
            this._proficiencyModifier = profMod;
            this._currentHealthPoints = currHP;
            this._maxHealthPoints = maxHP;
            this._strength = str;
            this._dexterity = dex;
            this._constitution = con;
            this._intelligence = intl;
            this._wisdom = wis;
            this._charisma = cha;
            this._armourClass = AC;
        }

        public void AttackWithWeapon()
        {
            throw new NotImplementedException();
        }

        public void CastASpell()
        {
            throw new NotImplementedException();
        }

        public void HealAlly()
        {
            throw new NotImplementedException();
        }

        public void HealSelf()
        {
            throw new NotImplementedException();
        }
    }
}
