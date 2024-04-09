public interface IEnemy
{
    int HealthEnemy { get; set; }
    bool IsDefeated { get; }
    void Attack(Player player);
    void PerformRandomAction(Player player);
    void Defend(Player player);
}