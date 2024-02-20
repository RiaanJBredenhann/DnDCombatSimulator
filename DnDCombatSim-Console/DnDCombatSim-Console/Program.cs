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
            List<Creature> deadCreatures = new List<Creature>();
            List<Creature> initiativeOrder = new List<Creature>();

            Player Bjorn = new Player("Bjorn", 2, 8, 'P', 10, 16, 12, 10, 13, 10, 14, 'M');
            players.Add(Bjorn);

            Player Peul = new Player("Peul", 2, 10, 'P', 16, 10, 12, 8, 10, 12, 17, 'M');
            players.Add(Peul);

            Player Yonaka = new Player("Yonaka", 2, 12, 'P', 17, 12, 14, 8, 10, 12, 15, 'M');
            players.Add(Yonaka);

            foreach (Player p in players)
            {
                p.SetWeapons();
                p.SetItems();
                initiativeOrder.Add(p);
            }

            for (int i = 1; i <= 3; i++ )
            {
                Monster Monster = new Monster("Goblin", 2, 6, 'M', 12, 10, 8, 6, 7, 9, 12, i);
                Monster.SetWeapons();
                monsters.Add(Monster);
                initiativeOrder.Add(Monster);
            }

            // Here we set the initiativescore of every Creature in the simulation         
            foreach (Creature c in initiativeOrder)
            {
                c.RollInitiative();
            }

            // And here we order the Creatures by their initiative score
            // Creatures take their turns in order of their initiative score
            initiativeOrder = SortInitiative(initiativeOrder);

            // Here we display all the Creatures in the simulation and their initiative score
            foreach (Creature c in initiativeOrder)
            {
                Console.WriteLine($"{c.GetName()}    {c.GetInitiative()}");
            }
            Console.WriteLine();

            int playerWins = 0;
            int roundCounter;

            // Here is the simulation loop
            // The simulation runs 100 times, where every loop contains another loop for a single fight, where every creature
            // performs and Action and a Bonus Action
            //    We randomly decide whether the active Creature takes an Action or a Bonus Action as well as which Action or Bonus Action
            // After the active Creature took its turn we check to see if either side of the fight is completely dead
            //    If so, we break out of the fight loop and check the winner of the fight
            // Once we incremented the corrosponding counter for either Player wins or Monster wins, we continue the simulation

            // Smulation Loop
            // Runs 100 times
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine( "\n========================================");
                Console.WriteLine($"            SIMULATION {i}");
                Console.WriteLine( "========================================");

                roundCounter = 0;
                ResetCreatures(players, monsters, deadCreatures);
                ResetIsDead(initiativeOrder);

                // Combat Loop
                // Runs a variable amount of times, until one side of the fight is wiped out
                while (players.Count > 0 && monsters.Count > 0)
                {
                    roundCounter++;

                    Console.WriteLine($"\n     ========== ROUND {roundCounter} ==========");

                    foreach (Creature c in initiativeOrder)
                    {
                        if (!c.GetIsDead())
                        {
                            c.AttackWithWeapon(players, monsters, deadCreatures);
                            if (c.GetCurrentHitPoints() <= c.GetMaxHitPoints())
                                c.HealSelf();

                            if (players.Count == 0 || monsters.Count == 0)
                                break;
                        }   
                        else
                            Console.WriteLine($"\n{c.GetName()} is dead and can't attack");
                    }
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

                    Console.WriteLine("Survivors \n");
                    foreach (Monster m in monsters)
                    {
                        Console.WriteLine(m.GetName());
                    }
                }
            }

            Console.WriteLine("\n   ==============================\n");
            Console.WriteLine($"Players won {playerWins} out of 100 simulations");
            Console.WriteLine($"Monsters won {100 - playerWins} out of 100 simulations");

            DetermineDifficulty(playerWins);
            Console.WriteLine("\n   ==============================\n");

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

        public static void ResetCreatures(List<Player> players, List<Monster> monsters, List<Creature> deadCreatures)
        {
            foreach (Creature c in deadCreatures)
            {
                if (c.GetCreatureType() == 'P')
                    players.Add((Player)c);
                else 
                    monsters.Add((Monster)c);
            }
            deadCreatures.Clear();
        }

        public static void DetermineDifficulty(int playerWins)
        {
            Console.Write("\nCombat Difficulty: ");
            switch (playerWins)
            {
                case int i when i >= 0 && i < 20:
                    Console.Write("Deadly");
                    break;
                case int i when i >= 20 && i < 40:
                    Console.Write("Very Hard");
                    break;
                case int i when i >= 40 && i < 60:
                    Console.Write("Hard");
                    break;
                case int i when i >= 60 && i < 80:
                    Console.Write("Medium");
                    break;
                case int i when i >= 80 && i <= 100:
                    Console.Write("Easy");
                    break;
            }
            Console.WriteLine();   
        }
    }
}
