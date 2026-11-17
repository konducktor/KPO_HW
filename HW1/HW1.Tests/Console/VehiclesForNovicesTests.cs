public class VehiclesForNovicesTests
{
    private static VehiclesForNovices CreateCommand(TestApp app) => new(app.IO, app.Formatter, app.Park);

    [Fact]
    public void Run_ListsOnlyVehiclesWithScoreSixAndAbove()
    {
        var app = new TestApp();
        var five = app.AddAndAdmit(app.Vehicles.CreateElectroScooter("Скутер-5", 5, 0, 100.0));
        var six = app.AddAndAdmit(app.Vehicles.CreateElectroScooter("Скутер-6", 6, 0, 100.0));
        var ten = app.AddAndAdmit(app.Vehicles.CreateElectroBicycle("Эвелик-10", 10, 0, 50.0));

        CreateCommand(app).Run();

        Assert.DoesNotContain(app.Formatter.Format(five), app.IO.Output);
        Assert.Contains(app.Formatter.Format(six), app.IO.Output);
        Assert.Contains(app.Formatter.Format(ten), app.IO.Output);
    }

    [Fact]
    public void Run_BicycleWithoutEnergy_IsStillListed()
    {
        var app = new TestApp();
        var bicycle = app.AddAndAdmit(app.Vehicles.CreateBicycle("Вело-9", 9, 0));

        CreateCommand(app).Run();

        Assert.Contains(app.Formatter.Format(bicycle), app.IO.Output);
    }

    [Fact]
    public void Run_VehicleNotInPark_IsNotListed()
    {
        var app = new TestApp();
        var onlyInInventory = app.AddToInventory(app.Vehicles.CreateBicycle("Вело-на-балансе", 9, 0));

        CreateCommand(app).Run();

        Assert.DoesNotContain(app.Formatter.Format(onlyInInventory), app.IO.Output);
    }

    [Fact]
    public void Run_RejectedByInspection_IsNotListedEvenIfEasy()
    {
        var app = new TestApp();
        app.Inspection.Result = InspectionResult.FailedDamage;
        var rejected = app.AddAndAdmit(app.Vehicles.CreateBicycle("Вело-сломан", 10, 9));

        CreateCommand(app).Run();

        Assert.DoesNotContain(app.Formatter.Format(rejected), app.IO.Output);
    }

    [Fact]
    public void Run_NoSuitableVehicles_PrintsOnlyHeader()
    {
        var app = new TestApp();
        app.AddAndAdmit(app.Vehicles.CreateBicycle("Вело-3", 3, 0));

        CreateCommand(app).Run();

        Assert.Single(app.IO.Output);
    }
}
