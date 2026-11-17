public class VehicleFactoryTests
{
    [Fact]
    public void Create_TwoVehicles_GetDifferentInventoryNumbers()
    {
        var app = new TestApp();

        var first = app.Vehicles.CreateBicycle("A", 5, 0);
        var second = app.Vehicles.CreateBicycle("B", 5, 0);

        Assert.NotEqual(first.Number, second.Number);
    }

    [Fact]
    public void CreateElectroVehicles_AreEnergyConsumers()
    {
        var app = new TestApp();

        var scooter = app.Vehicles.CreateElectroScooter("S", 8, 0, 100.0);
        var ebike = app.Vehicles.CreateElectroBicycle("E", 8, 0, 50.0);

        Assert.Equal(100.0, Assert.IsAssignableFrom<IEnergyConsumer>(scooter).Energy.DailyConsumption);
        Assert.Equal(50.0, Assert.IsAssignableFrom<IEnergyConsumer>(ebike).Energy.DailyConsumption);
    }

    [Fact]
    public void CreateBicycle_IsNotEnergyConsumer()
    {
        var app = new TestApp();

        var bicycle = app.Vehicles.CreateBicycle("B", 8, 0);

        Assert.False(bicycle is IEnergyConsumer);
    }

    [Fact]
    public void Create_KeepsGivenName()
    {
        var app = new TestApp();

        var bicycle = app.Vehicles.CreateBicycle("Городской", 8, 0);

        Assert.Equal("Городской", bicycle.Name);
    }
}
