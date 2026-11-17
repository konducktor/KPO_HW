public class InventoryTests
{
    [Fact]
    public void Add_DuplicateNumber_Throws()
    {
        var inventory = new Inventory();
        var item = new Helmet("Шлем", new InventoryNumber(1));
        inventory.Add(item);

        Assert.Throws<InvalidOperationException>(() => inventory.Add(new Helmet("Другой", new InventoryNumber(1))));
    }

    [Fact]
    public void Items_CannotBeModifiedFromOutside()
        => Assert.False(new Inventory().Items is List<IInventoryItem>);
}