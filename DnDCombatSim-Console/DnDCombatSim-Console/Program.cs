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

            foreach (Creature c in initiativeOrder)
            {
                c.AttackWithWeapon(players, monsters);
            }
             
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




    }
}
