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

            List<Weapon> weapons = new List<Weapon>
            {
                Greataxe,
                Dagger,
                HandCrossbow
            };

            List<Spell> spells = new List<Spell>
            {
                Fireball,
                AcidSplash,
                FireBolt
            };

            /*List<Slot> spellSlots = new List<Slot>
            {
                new Slot(0, 0),
                new Slot(1, 1),
                new Slot(2, 1),
                new Slot(3, 1),
                new Slot(4, 1)
            };*/
/*
            List<Consumable> consumables = new List<Consumable>
            {
                new Consumable("Potion of Healing", new Dice(1,4), 2),
                new Consumable("Dynamite", new Dice(3, 6), 2)
            };*/

            

            List<Player> players = new List<Player>();
            List<Monster> monsters = new List<Monster>();
            //List<Creature> tempCreatures = new List<Creature>();
            List<Creature> initiativeOrder = new List<Creature>();
            



            int rounds;
            int wins = 0;

            //Random r = new Random();

            for (int i = 1; i <= 100; i++)
            {
                players.Clear();
                monsters.Clear();
                initiativeOrder.Clear();

                Player player1 = new Player('P', "Bjorn", 11, 14, 2, 8, 16, 12, 14, 10, 10, spells, new List<Slot>
                {
                    new Slot(0, 0),
                    new Slot(1, 1),
                    new Slot(2, 1),
                    new Slot(3, 1),
                    new Slot(4, 1)
                }, "Charisma", weapons, new List<Consumable>
                {
                    new Consumable("Potion of Healing", new Dice(1,4), 2),
                    new Consumable("Dynamite", new Dice(3, 6), 2)
                });

                Player player2 = new Player('P', "Yonaka", 12, 14, 2, 8, 16, 12, 14, 10, 10, spells, new List<Slot>
                {
                    new Slot(0, 0),
                    new Slot(1, 1),
                    new Slot(2, 1),
                    new Slot(3, 1),
                    new Slot(4, 1)
                }, "Charisma", weapons, new List<Consumable>
                {
                    new Consumable("Potion of Healing", new Dice(1,4), 2),
                    new Consumable("Dynamite", new Dice(3, 6), 2)
                });

                Player player3 = new Player('P', "Paul", 12, 14, 2, 8, 16, 12, 14, 10, 10, spells, new List<Slot>
                {
                    new Slot(0, 0),
                    new Slot(1, 1),
                    new Slot(2, 1),
                    new Slot(3, 1),
                    new Slot(4, 1)
                }, "Charisma", weapons, new List<Consumable>
                {
                    new Consumable("Potion of Healing", new Dice(1,4), 2),
                    new Consumable("Dynamite", new Dice(3, 6), 2)
                });

                Monster monster1 = new Monster('M', "Goblin 1", 1, 30, 14, 2, 12, 14, 10, 8, 6, 7, spells, new List<Slot>
                {
                    new Slot(0, 0),
                    new Slot(1, 1),
                    new Slot(2, 1),
                    new Slot(3, 1),
                    new Slot(4, 1)
                }, "Wisdom", weapons);

                Monster monster2 = new Monster('M', "Goblin 2", 1, 30, 14, 2, 12, 14, 10, 8, 6, 7, spells, new List<Slot>
                {
                    new Slot(0, 0),
                    new Slot(1, 1),
                    new Slot(2, 1),
                    new Slot(3, 1),
                    new Slot(4, 1)
                }, "Wisdom", weapons);

                Monster monster3 = new Monster('M', "Goblin 3", 1, 30, 14, 2, 12, 14, 10, 8, 6, 7, spells, new List<Slot>
                {
                    new Slot(0, 0),
                    new Slot(1, 1),
                    new Slot(2, 1),
                    new Slot(3, 1),
                    new Slot(4, 1)
                }, "Wisdom", weapons);

                initiativeOrder.Add(player1);
                initiativeOrder.Add(player2);
                initiativeOrder.Add(player3);
                initiativeOrder.Add(monster1);
                initiativeOrder.Add(monster2);
                initiativeOrder.Add(monster3);

                foreach (Creature c in initiativeOrder)
                {
                    if (c.CreatureType == 'P')
                    {
                        Player p = (Player)c;
                        //initiativeOrder.Add(p);
                        players.Add(p);
                    }
                    else
                    {
                        Monster m = (Monster)c;
                        //initiativeOrder.Add(m);
                        monsters.Add(m);
                    }
                }

                initiativeOrder = RollInitiative(initiativeOrder);

                Console.WriteLine( "\n==================================================");
                Console.WriteLine(  $"                 Simulation {i}");
                Console.WriteLine(   "==================================================");

                rounds = 0;
                while (players.Count > 0 && monsters.Count > 0)
                {
                    rounds++;
                    Console.WriteLine( "\n     ========================================");
                    Console.WriteLine(  $"                     Round {rounds}");
                    Console.WriteLine(   "     ========================================\n");
                    foreach (Creature c in initiativeOrder)
                    {
                        if (c.CurrentHP > 0)
                        {
                            if (Creature.RollD20() <= 10)
                                c.AttackWithWeapon(c.ChooseTarget(players, monsters), players, monsters);
                            else
                                c.CastASpell(c.ChooseTarget(players, monsters), players, monsters);

                            if (players.Count == 0 || monsters.Count == 0)
                                break;

                            if (c.CreatureType == 'P')
                            {
                                Player p = (Player)c;
                                if (p.CurrentHP <= p.MaxHP / 2)
                                    p.UseConsumable();
                                else
                                    p.UseConsumable(p.ChooseTarget(players, monsters), monsters);
                            }

                            if (players.Count == 0 || monsters.Count == 0)
                                break;
                        }
                        else Console.WriteLine($"{c.Name} is dead");
                    }
                }

                if (monsters.Count == 0)
                    wins++;
            }

            Console.WriteLine( "\n==================================================");
            Console.WriteLine(  $"     Players won {wins} out of 100 encounters");

            switch (wins)
            {
                case int i when i >= 0 && i < 20:
                    Console.WriteLine("             Deadly Encounter");
                    break;
                case int i when i >= 20 && i < 40:
                    Console.WriteLine("           Very Hard Encounter");
                    break;
                case int i when i >= 40 && i < 60:
                    Console.WriteLine("              Hard Encounter");
                    break;
                case int i when i >= 60 && i < 80:
                    Console.WriteLine("             Medium Encounter");
                    break;
                case int i when i >= 80 && i <= 100:
                    Console.WriteLine("              Easy Encounter");
                    break;
            }

            Console.WriteLine("==================================================");


        }

        public static List<Creature> RollInitiative(List<Creature> creatures)
        {
            foreach (Creature c in creatures)
                c.Initiative = Creature.RollD20() + c.DexterityMod;

            creatures.Sort((c1, c2) => c2.Initiative.CompareTo(c1.Initiative));
            return creatures;

        }

    }
}
