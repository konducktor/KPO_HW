public abstract class Vehicle(
    string name, InventoryNumber number, NoviceScore score, DamageLevel damage
) : IInventoryItem
{
    public string Name { get; } = name;
    public InventoryNumber Number { get; } = number;
    public NoviceScore NoviceScore { get; } = score;
    public DamageLevel DamageLevel { get; } = damage;
}