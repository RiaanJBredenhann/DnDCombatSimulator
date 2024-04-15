using System.Runtime.CompilerServices;
using System.Linq;

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
            Consumable HealingPotion = new Consumable("Potion of Healing", new Dice(1,4), 2);
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
            spellSlots.Add(new Slot(0, 0));
            spellSlots.Add(new Slot(1, 1));
            spellSlots.Add(new Slot(2, 1));
            spellSlots.Add(new Slot(3, 1));
            spellSlots.Add(new Slot(4, 1));
            List<Consumable> consumables = new List<Consumable>();
            consumables.Add(HealingPotion);
            consumables.Add(Dynamite);



            Player player1 = new Player("Bjorn", 10, 14, 2, 8, 16, 12, 14, 10, 10, spells, spellSlots, "Charisma", weapons, consumables);
            Player player2 = new Player("Yonaka", 10, 14, 2, 8, 16, 12, 14, 10, 10, spells, spellSlots, "Charisma", weapons, consumables);
            Player player3 = new Player("Paul", 10, 14, 2, 8, 16, 12, 14, 10, 10, spells, spellSlots, "Charisma", weapons, consumables);
            Monster monster1 = new Monster("Goblin 1", 1, 5, 14, 2, 12, 14, 10, 8, 6, 7, spells, spellSlots, "Wisdom", weapons);
            Monster monster2 = new Monster("Goblin 2", 1, 5, 14, 2, 12, 14, 10, 8, 6, 7, spells, spellSlots, "Wisdom", weapons);
            Monster monster3 = new Monster("Goblin 3", 1, 5, 14, 2, 12, 14, 10, 8, 6, 7, spells, spellSlots, "Wisdom", weapons);

          /*  List<Player> players = new List<Player>();
            List<Monster> monsters = new List<Monster>();
            List<Creature> initiativeOrder = new List<Creature>();

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);

            initiativeOrder.Add(player1);
            initiativeOrder.Add(player2);
            initiativeOrder.Add(player3);

            monsters.Add(monster1);
            monsters.Add(monster2);
            monsters.Add(monster3);

            initiativeOrder.Add(monster1);
            initiativeOrder.Add(monster2);
            initiativeOrder.Add(monster3);

            initiativeOrder = RollInitiative(initiativeOrder);*/



            for (int i = 0; i < 10; i++)
            {
                player1.UseConsumable();
                Console.WriteLine();
            }


            for (int i = 0; i < 10; i++)
            {
                player1.UseConsumable(monster1);
                Console.WriteLine();
            }




        }

        public static List<Creature> RollInitiative(List<Creature> creatures)
        {
            foreach (Creature c in creatures)
                c.Initiative = Creature.RollD20() + c.DexterityMod;

            return creatures.OrderByDescending(c => c.Initiative).ToList();

        }

    }
}
