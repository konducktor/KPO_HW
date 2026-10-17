public class PrintInventory(
    IConsoleIO console, ItemFormatter formatter, Inventory inventory
): IMenuCommand
{
    public string Title { get; } = "Вывести все предметы в банке";

    public void Run()
    {
        console.Print("Предметы в банке:");
        foreach (IInventoryItem item in inventory.Items)
            console.Print(formatter.Format(item));
        console.Print("");
    }
}