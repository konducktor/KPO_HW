public class Helmet(string name, InventoryNumber number) : IInventoryItem
{
    public string Name { get; } = name;
    public InventoryNumber Number { get; } = number;
}