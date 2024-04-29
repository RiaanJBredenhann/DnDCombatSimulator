using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatSimSimple
{
    internal class Player : Creature
    {
        private List<Consumable> _consumables = new List<Consumable>();
        public List<Consumable> Consumables
        {
            get { return _consumables; }
            set { _consumables = value; }
        }

        public Player(char creatureType, string name, int maxHP, int AC, int profMod, int str, int dex, int con, int wis, int intl, int cha,
                      List<Spell> spells, List<Slot> slots, string spellcastingAbility, List<Weapon> weapons, List<Consumable> consumables) :
            base(creatureType, name, maxHP, AC, profMod, str, dex, con, wis, intl, cha, spells, slots, spellcastingAbility, weapons)
        {
            this.Consumables = consumables;
        }

        public Player() { }

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //
        //                                             METHODS
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //

        /* A Player is able to use consumables in their inventory, if they have any
         * This is an overloaded method that affects the type of consumable used based on the presence of an argument
         * This method takes two arguments and is used for throwing a stick of dynamite to deal damage to a target
         * If the target succeeds on the saving throw, the target only receives half damage, otherwise it receives full damage */
        public void UseConsumable(Creature target, List<Monster> monsters)
        {
            for (int i = 0; i < this.Consumables.Count; i++)
            {
                if (this.Consumables[i].Name == "Dynamite")
                {
                    if (this.Consumables[i].Amount > 0)
                    {
                        Console.WriteLine($"{this.Name} is throwing a stick of dynamite at {target.Name}");
                        this.Consumables[i].Amount -= 1;

                        int d20Roll = RollD20();
                        double damageRoll = this.Consumables[i].DamageDice.CalculateDice();

                        if (d20Roll + target.DexterityMod >= 12)
                        {
                            damageRoll = Math.Ceiling(damageRoll / 2);
                            Console.WriteLine($"{target.Name} succeeded on the save against the dynamite and took {damageRoll} point(s) of damage");
                        }
                        else Console.WriteLine($"{target.Name} failed the save against the dynamite and took {damageRoll} point(s) of damage");

                        target.CurrentHP -= damageRoll;

                        if (target.CurrentHP <= 0)
                            monsters.Remove((Monster)target);

                        break;
                    } else Console.WriteLine($"{this.Name} has no more sticks of dynamite.");
                }
            }
        }

        /* This method takes zero arguments and is used for drinking a healing potion
         * The Player can use of of their heling potions in their inventory and heal for a rolled amount of hit points, 
         * not exceeding their max HP */
        public void UseConsumable()
        {
            for (int i = 0; i < this.Consumables.Count; i++)
            {
                if (this.Consumables[i].Name == "Potion of Healing")
                {
                    if (this.Consumables[i].Amount > 0)
                    {
                        this.Consumables[i].Amount -= 1;
                        double healingAmount = this.Consumables[i].DamageDice.CalculateDice();

                        Console.WriteLine($"{this.Name} is drinking a {this.Consumables[i].Name} and healed for {healingAmount} hit point(s)");
                        
                        this.CurrentHP += healingAmount;
                        if (this.CurrentHP > this.MaxHP) this.CurrentHP = this.MaxHP;

                        break;
                    } else Console.WriteLine($"{this.Name} has no more healing potions.");
                } 
            }
        }

    }
}
