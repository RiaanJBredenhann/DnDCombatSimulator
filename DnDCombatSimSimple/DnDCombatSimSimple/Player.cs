using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

        public Player(string name, int maxHP, int AC, int profMod,  int str, int dex, int con, int wis, int intl, int cha,
                      List<Spell> spells, List<Slot> slots, string spellcastingAbility, List<Weapon> weapons, List<Consumable> consumables) : 
            base(name, maxHP, AC, profMod, str, dex, con, wis, intl, cha, spells, slots, spellcastingAbility, weapons)
        {
            this.Consumables = consumables;
            //this.IsDead = false;
        }

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //
        //                                             METHODS
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //

        public void UseConsumable(Creature target)
        {
            //Random r = new Random();

            for (int i = 0; i < this.Consumables.Count; i++)
            {
                if (this.Consumables[i].Name == "Dynamite")
                {
                    this.Consumables[i].Amount -= 1;

                    if (RollD20() + target.DexterityMod >= 12)
                        target.CurrentHP -= this.Consumables[i].DamageDice.CalculateDice() / 2;
                    else
                        target.CurrentHP -= this.Consumables[i].DamageDice.CalculateDice();
                    break;
                }
            }
        }

        public void UseConsumable()
        {
            for (int i = 0; i < this.Consumables.Count; i++)
            {
                if (this.Consumables[i].Name == "Healing Potion")
                {
                    this.Consumables[i].Amount -= 1;
                    this.CurrentHP += this.Consumables[i].DamageDice.CalculateDice();
                    break;
                }
            }

        }

    }
}
