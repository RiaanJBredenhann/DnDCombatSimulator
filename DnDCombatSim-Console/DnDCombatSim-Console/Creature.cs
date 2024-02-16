﻿using System;
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
        private int _currentHitPoints;
        private int _maxHitPoints;
        private char _creatureType;
        private bool _isDead;

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

        public Creature(string name, int profMod, int maxHP, char creatureType, int str, int dex, int con, int intl, int wis, int cha, int AC)
        {
            this._name = name;
            this._proficiencyModifier = profMod;
            this._maxHitPoints = maxHP;
            this._currentHitPoints = maxHP;
            this._creatureType = creatureType;
            this._isDead = false;
            this._strength = str;
            this._strengthModifier = CalculateModifier(str);
            this._dexterity = dex;
            this._dexterityModifier = CalculateModifier(dex);
            this._constitution = con;
            this._constitutionModifier = CalculateModifier(con);
            this._intelligence = intl;
            this._intelligenceModifier = CalculateModifier(intl);
            this._wisdom = wis;
            this._wisdomModifier = CalculateModifier(wis);
            this._charisma = cha;
            this._charismaModifier = CalculateModifier(cha);
            this._armourClass = AC;

            _items = new List<Item>();
            _weapons = new List<Weapon>();
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //
        //                                  CLASS METHODS
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //

        private int CalculateModifier(int abilityScore)
        {
            return (abilityScore - 10) / 2;
        }

        public void RollInitiative()
        {
            Random random = new Random();

            this._initiative = random.Next(1, 21) + this._dexterityModifier; 
        }

        public Creature ChooseTarget(Creature target, List<Player> players, List<Monster> monsters)
        {
            Random r = new Random();
            bool dead = true;

            if (this._creatureType == 'P')
            {
                while (dead)
                {
                    target = monsters[r.Next(0, monsters.Count)];
                    dead = target.GetIsDead();
                }
            }
            else
            {
                while (dead)
                {
                    target = players[r.Next(0, players.Count)];
                    dead = target.GetIsDead();
                }
            }
            return target;
        }

        private int TakeDamage(Weapon chosenWeapon)
        {
            Random r = new Random();

            string damageDice = chosenWeapon.GetDamageDice();
            int indexOfD = damageDice.IndexOf('d');
            int numberOfDice = int.Parse(damageDice.Substring(0, indexOfD));
            int typeOfDice = int.Parse(damageDice.Substring(indexOfD+1));
            int totalDamage = 0;

            for (int i = numberOfDice; i <= numberOfDice; i++)
            {
                totalDamage += r.Next(1, typeOfDice + 1);
            }

            this._currentHitPoints -= totalDamage;
            return totalDamage;
        }

        public void Kill(List<Creature> initiativeOrder, List<Player> players, List<Monster> monsters)
        {

        }

        public string GetName()
        {
            return this._name;
        }

        protected virtual int GetID()
        {
            return 0;
        }

        public int GetCurrentHitPoints()
        {
            return this._currentHitPoints;
        }

        public int GetMaxHitPoints()
        {
            return this._maxHitPoints;
        }

        public char GetCreatureType()
        {
            return this._creatureType;
        }

        public bool GetIsDead()
        {
            return this._isDead;
        }

        public void SetIsDead(bool isDead)
        {
            this._isDead = isDead;
        }

        public int GetInitiative()
        {
            return this._initiative;
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

        public void AttackWithWeapon(List<Player> players, List<Monster> monsters)
        {
            //throw new NotImplementedException();
            Random r = new Random();
            Creature target = new Creature();
            bool hit;
            int totalDamage;

            target = this.ChooseTarget(target, players, monsters);

            Weapon chosenWeapon = this._weapons[r.Next(0, this._weapons.Count)];

            Console.WriteLine($"{this.GetName()} {this.GetID()} is attacking {target.GetName()} {target.GetID()} with a {chosenWeapon.GetName()}");
            hit = this.RollAttack(target);

            if (hit)
            {
                totalDamage = target.TakeDamage(chosenWeapon);
                Console.Write($" for {totalDamage} damage \n");

                if (target._currentHitPoints <= 0)
                {
                    Console.WriteLine($"{this.GetName()} {this.GetID()} killed {target.GetName()} {target.GetID()} \n");
                    target._isDead = true;
                }
            }
        }

        public bool RollAttack(Creature target)
        {
            Random r = new Random();
            int attackRoll = r.Next(1, 21) + this._proficiencyModifier;

            if (attackRoll >= target._armourClass)
            {
                Console.WriteLine($"{this.GetName()} {this.GetID()} rolled {attackRoll} and hit {target.GetName()} {target.GetID()}");
                return true;
            }
            Console.WriteLine($"{this.GetName()} rolled {attackRoll} and missed {target.GetName()} \n");
            return false;
        }

        public void CastASpell(List<Player> players, List<Monster> monsters)
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
