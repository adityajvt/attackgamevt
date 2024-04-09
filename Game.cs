public class Game()
{
    public static int currentLevel = 1;
    public static List<IEnemy> enemies = new List<IEnemy>();

    public static List<string> awards = new List<string>(Player.Inventory);
    public void StartGame()
    {
        Console.WriteLine("Welcome to the game!");
        Player player = new Player();


        int choice = 0;

        while (currentLevel <= 6)
        {
            Console.WriteLine($"Current Level: {currentLevel}");
            Console.WriteLine($"You have collected {Player.itemsList[currentLevel - 1]} at this Level.");

            if (currentLevel < 6)
            {
                int numberOfEnemies = currentLevel;

                for (int i = 0; i < numberOfEnemies; i++)
                {
                    /*
                    if (currentLevel == 1)
                    {
                        enemies.Add(new Enemy());
                    }
                    else
                    {
                        for (int j = 0; j < currentLevel; j++)
                        {
                            enemies.Add(new Enemy());
                        }
                    }
                    */
                    enemies.Add(new Enemy());
                }

                player.IncreaseStats(currentLevel);

                Console.Clear();
                Console.WriteLine("Choose your action:");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Heal");
                Console.WriteLine("3. Quit");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    foreach (var enemy in enemies)
                    {
                        player.Attack(enemy);
                        enemy.PerformRandomAction(player);
                    }
                    if (enemies.All(e => e.IsDefeated))
                    {
                        currentLevel++;
                        enemies.Clear();
                    }
                    enemies.Clear();
                }
                else if (choice == 2)
                {
                    player.Heal();
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            else if(currentLevel == 6)
            {
                MurlocsBoss boss = new MurlocsBoss();
                boss.Attack(player);
                player.IncreaseStats(currentLevel);

                Console.WriteLine("Choose your action:");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Heal");
                Console.WriteLine("3. Quit");

                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    player.Attack(boss);
                    boss.Attack(player);
                    if (boss.IsDefeated)
                    {
                        currentLevel++;
                    }
                }
                else if (choice == 2)
                {
                    player.Heal();
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }
}
