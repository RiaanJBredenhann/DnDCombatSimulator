namespace DnDCombatSim_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            List<Monster> monsters = new List<Monster>();
            List<Weapon> weapons = new List<Weapon>();

            Player Bjorn = new Player("Bjorn", 2, 8, 10, 16, 12, 10, 13, 10, 14, 'M');
            weapons.Add(new Weapon("Longbow", "1d10"));
            weapons.Add(new Weapon("Dagger", "1d4"));
            Bjorn.SetWeapons(weapons);
            weapons.Clear();
            players.Add(Bjorn);

            Player Peul = new Player("Peul", 2, 10, 16, 10, 12, 8, 10, 12, 17, 'M');
            weapons.Add(new Weapon("Longsword", "1d10"));
            weapons.Add(new Weapon("Dagger", "1d4"));
            Peul.SetWeapons(weapons);
            weapons.Clear();
            players.Add(Peul);

            Player Yonaka = new Player("Yonaka", 2, 12, 17, 12, 14, 8, 10, 12, 15, 'M');
            weapons.Add(new Weapon("Katana", "1d18"));
            weapons.Add(new Weapon("Dagger", "1d4"));
            Yonaka.SetWeapons(weapons);
            weapons.Clear();
            players.Add(Yonaka);

            for (int i = 1; i <= 3; i++ )
            {
                Monster Monster = new Monster("Goblin", 2, 6, 12, 10, 8, 6, 7, 9, 12, i);
                monsters.Add(Monster);
            }

            foreach (Player player in players)
            {
                Console.WriteLine($"{player.GetName()} has the following weapons:");
                player.GetWeapons();
                Console.WriteLine();
            }

             
        }
    }
}
