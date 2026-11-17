public class TestApp
{
    public FakeConsoleIO IO { get; }
    public FakeInspectionService Inspection { get; } = new();
    public Inventory Inventory { get; } = new();
    public VehiclePark Park { get; }
    public VehicleFactory Vehicles { get; }
    public ItemFactory Items { get; }
    public ItemFormatter Formatter { get; } = new();

    public TestApp(params string[] inputs)
    {
        IO = new FakeConsoleIO(inputs);
        Park = new VehiclePark(Inspection);

        var numbers = new SequentialNumberGenerator();
        Vehicles = new VehicleFactory(numbers);
        Items = new ItemFactory(numbers);
    }

    public T AddToInventory<T>(T item) where T : IInventoryItem
    {
        Inventory.Add(item);
        return item;
    }

    public T AddAndAdmit<T>(T vehicle) where T : Vehicle
    {
        Inventory.Add(vehicle);
        Park.TryAdmit(vehicle);
        return vehicle;
    }
}
