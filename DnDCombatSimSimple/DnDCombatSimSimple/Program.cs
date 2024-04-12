using System.Runtime.CompilerServices;

namespace DnDCombatSimSimple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weapon Greataxe = new Weapon("Greataxe", new Dice(2,6), "Heavy");
            Weapon Dagger = new Weapon("Dagger", new Dice(1, 4), "Light");
            Weapon HandCrossbow = new  Weapon("Hand Crossbow", new Dice(1, 6), "Light");
            Spell Fireball = new Spell("Fireball", 3, new Dice(3, 6), "Save", "Dexterity");
            Spell AcidSplash = new Spell("Acid Splash", 0, new Dice(1,6), "Save", "Dexterity");
            Spell FireBolt = new Spell("Fire Bolt", 0, new Dice(1, 6), "Armour Class", "None");
            Consumable HealingPotion = new Consumable("Healing Potion", new Dice(1,4), 2);
            Consumable Dynamite = new Consumable("Dynamite", new Dice(3, 6), 2);

            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(Greataxe);
            weapons.Add(Dagger);
            weapons.Add(HandCrossbow);
            List<Spell> spells = new List<Spell>();
            spells.Add(Fireball);
            spells.Add(AcidSplash);
            spells.Add(FireBolt);
            List<Slot> spellSlots = new List<Slot>();
            spellSlots.Add(new Slot(1, 1));
            spellSlots.Add(new Slot(2, 1));
            spellSlots.Add(new Slot(3, 1));
            spellSlots.Add(new Slot(4, 1));
            List<Consumable> consumables = new List<Consumable>();
            consumables.Add(HealingPotion);
            consumables.Add(Dynamite);

            Player player = new Player("Bjorn", 10, 14, 2, 8, 16, 12, 14, 10, 10, spells, spellSlots, "Charisma", weapons, consumables);
            Monster monster = new Monster("Goblin", 1, 5, 14, 2, 12, 14, 10, 8, 6, 7, spells, spellSlots, "Wisdom", weapons);

            /*Console.WriteLine("Name: " + player.Name);
            Console.WriteLine("Max HP: " + player.MaxHP);
            Console.WriteLine("Current HP: " + player.CurrentHP);
            Console.WriteLine("Armour CLass: " + player.ArmourClass);
            Console.WriteLine("Strength Mod: " + player.StrengthMod);
            Console.WriteLine("Dexterity Mod: " + player.DexterityMod);
            Console.WriteLine("Constitution Mod: " + player.ConstitutionMod);
            Console.WriteLine("Wisdom Mod: " + player.WisdomMod);
            Console.WriteLine("Intelligence Mod: " + player.IntelligenceMod);
            Console.WriteLine("Charisma Mod: " + player.CharismaMod);
            Console.WriteLine("Spells: " + player.Spells[0].Name);
            Console.WriteLine("Spell Slots: " + player.SpellSlots[0].Level);
            Console.WriteLine("Weapons: " + player.Weapons[0].Name);
            Console.WriteLine("Consumables: " + player.Consumables[0].Name);*/

            /*Console.WriteLine(player.Weapons[0].DamageDice.CalculateDice());
            Console.WriteLine(player.Weapons[0].DamageDice.CalculateDice());*/

            /*Console.WriteLine(player.Weapons.Count);*/

            /*for (int i = 0; i < 5; i++)
            player.AttackWithWeapon(monster);

            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            player.CastASpell(monster);*/

            for (int i = 0; i <= 10; i++ )
            {
                player.CastASpell(monster);
            }









            List<Player> players = new List<Player>();
            List<Monster> monsters = new List<Monster>();
            List<Creature> initiativeOrder = new List<Creature>();





        }

    }
}
