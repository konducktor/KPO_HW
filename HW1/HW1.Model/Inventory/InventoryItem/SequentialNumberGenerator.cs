public class SequentialNumberGenerator : IInventoryNumberGenerator
{
    private int _lastFreeNumber = 0;

    public InventoryNumber getUnique()
    {
        InventoryNumber uniqueNumber = new InventoryNumber(_lastFreeNumber);
        _lastFreeNumber++;

        return uniqueNumber;
    }
}