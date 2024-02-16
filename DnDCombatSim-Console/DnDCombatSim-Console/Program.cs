namespace DnDCombatSim_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //-- Creating Lists for the players and monsters
            //-- Player and Monster are subclasses of Creature and are seperated into different Lists
            //   since Players can only attack Monsters and vice versa
            List<Player> players = new List<Player>();
            List<Monster> monsters = new List<Monster>();
            List<Creature> initiativeOrder = new List<Creature>();

            Player Bjorn = new Player("Bjorn", 2, 8, 'P', 10, 16, 12, 10, 13, 10, 14, 'M');
            Bjorn.SetWeapons();
            players.Add(Bjorn);
            initiativeOrder.Add(Bjorn);

            Player Peul = new Player("Peul", 2, 10, 'P', 16, 10, 12, 8, 10, 12, 17, 'M');
            Peul.SetWeapons();
            players.Add(Peul);
            initiativeOrder.Add(Peul);

            Player Yonaka = new Player("Yonaka", 2, 12, 'P', 17, 12, 14, 8, 10, 12, 15, 'M');
            Yonaka.SetWeapons();
            players.Add(Yonaka);
            initiativeOrder.Add(Yonaka);

            for (int i = 1; i <= 3; i++ )
            {
                Monster Monster = new Monster("Goblin", 2, 6, 'M', 12, 10, 8, 6, 7, 9, 12, i);
                Monster.SetWeapons();
                monsters.Add(Monster);
                initiativeOrder.Add(Monster);
            }

            foreach (Creature c in initiativeOrder)
            {
                c.RollInitiative();
            }

            initiativeOrder = SortInitiative(initiativeOrder);

            foreach (Creature c in initiativeOrder)
            {
                Console.WriteLine($"{c.GetName()}    {c.GetInitiative()}");
            }
            Console.WriteLine();

            int playerWins = 0;
            int monsterWins = 0;
            int roundCounter = 0;
            int deadPlayers = 0;
            int deadMonsters = 0;

            for (int i = 1; i <= 10; i++)
            {
                roundCounter = 0;
                ResetIsDead(initiativeOrder);

                while (players.Count >= deadPlayers && monsters.Count >= deadMonsters)
                {
                    roundCounter++;
                    deadPlayers = 0;
                    deadMonsters = 0;

                    Console.WriteLine($"========== ROUND {roundCounter} ========== \n");

                    foreach (Creature c in initiativeOrder)
                    {
                        if (!c.GetIsDead())
                            c.AttackWithWeapon(players, monsters);
                        else
                            Console.WriteLine($"{c.GetName()} is dead \n");
                    }

                    deadPlayers = CheckDeadPlayers(players);
                    deadMonsters = CheckDeadMonsters(monsters);
                }

                Console.WriteLine();

                if (monsters.Count == 0)
                {
                    Console.WriteLine("Players Won! \n");
                    playerWins++;

                    Console.WriteLine("Survivors \n");
                    foreach (Player p in players)
                    {
                        Console.WriteLine(p.GetName());
                    }
                }
                else
                {
                    Console.WriteLine("Monsters Won! \n");
                    monsterWins++;

                    Console.WriteLine("Survivors \n");
                    foreach (Monster m in monsters)
                    {
                        Console.WriteLine(m.GetName());
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Players won {playerWins} out of 10 simulations");
            Console.WriteLine($"Monsters won {monsterWins} out of 10 simulations");




        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //
        //                                  CLASS METHODS
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //

        public static List<Creature> SortInitiative(List<Creature> creatures)
        {
            bool sorted = false;
            Creature temp;

            while (!sorted)
            {
                sorted = true;

                for (int i = 0; i < creatures.Count; i++)
                {
                    if (i < creatures.Count - 1)
                    {
                        if (creatures[i].GetInitiative() < creatures[i + 1].GetInitiative())
                        {
                            temp = creatures[i];
                            creatures[i] = creatures[i + 1];
                            creatures[i + 1] = temp;

                            sorted = false;
                        }
                    }
                }
            }
            return creatures;
        }

        public static void ResetIsDead(List<Creature> initiativeOrder)
        {
            foreach (Creature c in initiativeOrder)
            {
                c.SetIsDead(false);
            }
        }

        public static int CheckDeadPlayers(List<Player> players)
        {
            int deadCreatures = 0;

            foreach (Player p in players)
            {
                if (p.GetIsDead())
                    deadCreatures++;
            }
            return deadCreatures;
        }

        public static int CheckDeadMonsters(List<Monster> monsters)
        {
            int deadCreatures = 0;

            foreach (Monster m in monsters)
            {
                if (m.GetIsDead())
                    deadCreatures++;
            }
            return deadCreatures;
        }
    }
}
