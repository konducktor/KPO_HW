public class Inventory
{
    private readonly List<IInventoryItem> items = new();
    
    public IReadOnlyList<IInventoryItem> Items { get; }

    public Inventory()
    {
        Items = items.AsReadOnly();
    }

    public void Add(IInventoryItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        if (items.Any(i => i.Number == item.Number))
            throw new InvalidOperationException($"Номер {item.Number} уже на балансе");
        
        items.Add(item);
    }
}