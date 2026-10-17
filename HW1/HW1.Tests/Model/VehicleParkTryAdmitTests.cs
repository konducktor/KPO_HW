public class VehicleParkTryAdmitTests
{
    [Fact]
    public void InspectionFailed_VehicleNotAdded()
    {
        var inspection = new FakeInspectionService(InspectionResult.FailedDamage);
        var park = new VehiclePark(inspection);

        var result = park.TryAdmit(TestData.ElectroScooter());

        Assert.Equal(AdmissionStatus.InspectionFailed, result.Status);
        Assert.Equal(InspectionResult.FailedDamage, result.Inspection);
        Assert.Empty(park.Vehicles);
    }

    [Fact]
    public void InspectionPassed_VehicleAdded()
    {
        var park = new VehiclePark(new FakeInspectionService(InspectionResult.Passed));
        var scooter = TestData.ElectroScooter();

        var result = park.TryAdmit(scooter);

        Assert.Equal(AdmissionStatus.Admitted, result.Status);
        Assert.Contains(scooter, park.Vehicles);
    }

    [Fact]
    public void AlreadyInPark_ReturnsAlreadyInParkSkipsInspection()
    {
        var inspection = new FakeInspectionService(InspectionResult.Passed);
        var park = new VehiclePark(inspection);
        var scooter = TestData.ElectroScooter();
        park.TryAdmit(scooter);

        var result = park.TryAdmit(scooter);

        Assert.Equal(AdmissionStatus.AlreadyInPark, result.Status);
        Assert.Equal(1, inspection.Calls); // чтобы второй раз осмотр не вызывался
        Assert.Single(park.Vehicles);
    }
}