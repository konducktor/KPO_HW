using System.Runtime.InteropServices;

public class ItemFormatter
{
    public string Format(IInventoryItem item)
    {
        return $"{item.Number}: {item.Name}";
    }
}