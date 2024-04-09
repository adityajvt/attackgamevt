public class MurlocsBoss : IEnemy
{
    public int HealthEnemy { get; set; }
    public List<string> SpecialAbilities { get; set; }

    public MurlocsBoss()
    {
        HealthEnemy = 150;
        SpecialAbilities = new List<string> { "Ground Slash", "Speed Dash", "Health Regeneration" };
    }

    public bool IsDefeated
    {
        get { return HealthEnemy <= 0; }
    }

    public void Attack(Player player)
    {
        Random random = new Random();
        int damage = random.Next(10, 21);
        player.Health -= damage;
        Console.WriteLine($"Boss enemy attacked the player for {damage} damage. Player health: {player.Health}");

        if (player.Health <= 0)
        {
            Console.WriteLine("Game over! You have been defeated by the enemy.");
            Environment.Exit(0);
        }

        else if (player.Health > 0 && HealthEnemy <= 0)
        {
            Console.WriteLine("Congratulations! You have defeated the enemy.");

            Game.currentLevel++;
            Game.enemies.Clear();
        }

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
        Console.WriteLine($"Enemy defends and takes reduced damage of {actualDamage}. Your health is now {player.Health}");

        if (player.Health <= 0)
        {
            Console.WriteLine("Game over! You have been defeated by the enemy.");
            Environment.Exit(0);
        }

        else if (player.Health > 0 && HealthEnemy <= 0)
        {
            Console.WriteLine("Congratulations! You have defeated the enemy.");
            Game.currentLevel++;
            Game.enemies.Clear();
        }
    }

    public void UseSpecialAbility(Player player)
    {
        Random random = new Random();
        int abilityIndex = random.Next(0, SpecialAbilities.Count);

        switch (SpecialAbilities[abilityIndex])
        {
            case "Ground Slash":
                int slashDamage = 30;
                player.Health -= slashDamage;
                Console.WriteLine($"Boss enemy used Ground Slash for {slashDamage} damage. Player health: {player.Health}");
                break;
            case "Speed Dash":
                int dashDamage = 20;
                player.Health -= dashDamage;
                Console.WriteLine($"Boss enemy used Speed Dash for {dashDamage} damage. Player health: {player.Health}");
                break;
            case "Health Regeneration":
                int regenAmount = 10;
                HealthEnemy += regenAmount;
                Console.WriteLine($"Boss enemy regenerated {regenAmount} health. Boss health: {HealthEnemy}");
                break;
            default:
                Console.WriteLine("Boss enemy did a regular attack.");
                Attack(player);
                break;
        }

        if (player.Health <= 0)
        {
            Console.WriteLine("Game over! You have been defeated by the boss enemy.");
            return;
        }
    }
}