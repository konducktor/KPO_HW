public class QuantityEnergyReportTests
{
    private static QuantityEnergyReport CreateCommand(TestApp app)
    {
        return new(app.IO, app.Park);
    }

    [Fact]
    public void Run_EmptyPark_ReportsZeroUnitsAndZeroEnergy()
    {
        var app = new TestApp();

        CreateCommand(app).Run();

        Assert.Contains(app.IO.Output, line => line.Contains("в парке: 0"));
        Assert.Contains(app.IO.Output, line => line.Contains("энергии: 0"));
    }

    [Fact]
    public void Run_SumsEnergy_AndBicycleCountsAsUnitButNotAsEnergy()
    {
        var app = new TestApp();
        app.AddAndAdmit(app.Vehicles.CreateElectroScooter("Самокат", 8, 0, 100.0));
        app.AddAndAdmit(app.Vehicles.CreateElectroBicycle("Эвелик", 7, 0, 50.0));
        app.AddAndAdmit(app.Vehicles.CreateBicycle("Велик", 9, 0));

        CreateCommand(app).Run();

        Assert.Contains(app.IO.Output, line => line.Contains("в парке: 3"));
        Assert.Contains(app.IO.Output, line => line.Contains("энергии: 150"));
    }

    [Fact]
    public void Run_CountsOnlyActiveParkNotWholeInventory()
    {
        var app = new TestApp();
        app.AddToInventory(app.Vehicles.CreateElectroScooter("Только на балансе", 8, 0, 100.0));
        app.AddAndAdmit(app.Vehicles.CreateElectroBicycle("В парке", 7, 0, 50.0));

        CreateCommand(app).Run();

        Assert.Contains(app.IO.Output, line => line.Contains("в парке: 1"));
        Assert.Contains(app.IO.Output, line => line.Contains("энергии: 50"));
    }

    [Fact]
    public void Run_RejectedVehicle_IsNotCounted()
    {
        var app = new TestApp();
        app.Inspection.Result = InspectionResult.FailedDamage;
        app.AddAndAdmit(app.Vehicles.CreateElectroScooter("Сломанный", 8, 9, 100.0));

        CreateCommand(app).Run();

        Assert.Contains(app.IO.Output, line => line.Contains("в парке: 0"));
        Assert.Contains(app.IO.Output, line => line.Contains("энергии: 0"));
    }

    [Fact]
    public void Run_PrintsReportHeader()
    {
        var app = new TestApp();

        CreateCommand(app).Run();

        Assert.Contains(app.IO.Output, line => line.Contains("Отчёт по парку"));
    }
}
