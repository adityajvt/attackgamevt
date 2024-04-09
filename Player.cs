public class Player
{

    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int MeeleDamage { get; set; }
    public int RangedDamage { get; set; }
    public int Defence { get; set; }

    public List<string> SpecialAbilities { get; set; } = new List<string>();
    public static List<string> Inventory { get; set; } = new List<string>();


    public Player()
    {

        MaxHealth = 100;
        Health = MaxHealth;
        MeeleDamage = 10;
        RangedDamage = 5;
        Defence = 5;

        SpecialAbilities = new List<string>();
        Inventory = new List<string>();
    }

    public void IncreaseStats(int level)
    {
        // MaxHealth += 20;
        // Health = MaxHealth;
        MeeleDamage += 5;
        Defence += 3;

        if (level == 1)
        {
            Inventory.Add("No Items Collected!");
        }

        if (level == 2)
        {
            SpecialAbilities.Add("Critical hits");
            Inventory.Add("Map");
        }

        if (level == 3)
        {
            SpecialAbilities.Add("Blocker");
            Inventory.Add("Sword");
        }

        if (level == 4)
        {
            SpecialAbilities.Add("Life Steal");
            Inventory.Add("Shield");
        }

        if (level == 5)
        {
            SpecialAbilities.Add("Ranged Attack");
            Inventory.Add("Armor");
        }
        if (level == 6)
        {
            Inventory.Add("Bow");
        }
    }

    public void Attack(IEnemy enemy)
    {
        Random random = new Random();

        int damage = MeeleDamage + random.Next(1, 11);
        enemy.HealthEnemy -= damage;

        Console.WriteLine($"You hit the enemy for {damage} damage!");
        Console.WriteLine($"Your health is now {Health}");
    }

    public void Heal()
    {
        int healAmount = 20;

        Health = Math.Min(Health + healAmount, MaxHealth);
        Console.WriteLine($"You healed for {healAmount} health!");
    }

    public static string[] itemsList = { "No Items", "Map", "Sword", "Sheild", "Armour", "Bow" };
}