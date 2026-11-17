public class ItemFactory(IInventoryNumberGenerator numbers)
{
    public ChargingStation CreateChargingStation(string name)
    {
        return new(name, numbers.getUnique());
    }

    public DockStation CreateDockStation(string name)
    {
        return new(name, numbers.getUnique());
    }

    public Helmet CreateHelmet(string name)
    {
        return new(name, numbers.getUnique());
    }
}