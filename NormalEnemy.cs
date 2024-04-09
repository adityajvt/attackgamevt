public class Enemy : IEnemy
{
    public int HealthEnemy { get; set; }

    public Enemy()
    {
        HealthEnemy = 50;
    }

    public bool IsDefeated
    {
        get { return HealthEnemy <= 0; }
    }

    public void Attack(Player player)
    {
        Random random = new Random();
        int damage = random.Next(1, 11);

        player.Health -= damage;
        Console.WriteLine($"Enemy hit you for {damage} damage!");
        Console.WriteLine($"Your health is now {player.Health}");

        if (player.Health <= 0)
        {
            Console.WriteLine("Game over! You have been defeated by the enemy.");
            Environment.Exit(0);
        }
        /*
                else if (player.Health > 0 && HealthEnemy <= 0)
                {
                    Console.WriteLine("Congratulations! You have defeated the enemy.");

                    Game.currentLevel++;
                    // Game.enemies.Clear();
                }
        */
    }

    public void PerformRandomAction(Player player)
    {
        Random random = new Random();
        int action = random.Next(0, 2);

        if (action == 0)
        {
            Attack(player);
        }
        else
        {
            Defend(player);
        }
    }

    public void Defend(Player player)
    {
        Random random = new Random();
        int damageReduction = random.Next(1, 6);

        int damage = random.Next(1, 11);
        int actualDamage = Math.Max(0, damage - damageReduction);

        player.Health -= actualDamage;
        Console.WriteLine($"Enemy defends. Your health is now {player.Health}");

        if (player.Health <= 0)
        {
            Console.WriteLine("Game over! You have been defeated by the enemy.");
            Environment.Exit(0);
        }
        /*
                else if (player.Health > 0 && HealthEnemy <= 0)
                {
                    Console.WriteLine("Congratulations! You have defeated the enemy.");
                    Game.currentLevel++;
                    // Game.enemies.Clear();
                }
        */
    }
}