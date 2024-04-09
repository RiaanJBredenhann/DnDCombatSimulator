namespace DnDCombatSimSimple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weapon Greataxe = new Weapon("Greataxe", new Dice(2,6), "Heavy");
            Spell Fireball = new Spell("Fireball", new Dice(3, 6));
            Consumable HealingPotion = new Consumable("Healing Potion", new Dice(1,4));

            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(Greataxe);
            List<Spell> spells = new List<Spell>();
            spells.Add(Fireball);
            List<Slot> spellSlots = new List<Slot>();
            spellSlots.Add(new Slot(1, 4));
            spellSlots.Add(new Slot(2, 3));
            spellSlots.Add(new Slot(3, 2));
            spellSlots.Add(new Slot(4, 1));
            List<Consumable> consumables = new List<Consumable>();
            consumables.Add(HealingPotion);


            Player player = new Player("Bjorn", 10, 14, 9, 16, 12, 14, 10, 10, spells, spellSlots, weapons, consumables);

            Console.WriteLine("Name: " + player.Name);
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
            Console.WriteLine("Consumables: " + player.Consumables[0].Name);

            List<Player> players = new List<Player>();
            List<Monster> monsters = new List<Monster>();
            List<Creature> initiativeOrder = new List<Creature>();





        }
    }
}
