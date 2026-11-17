public class ServiceCenterTests
{
    [Theory]
    [InlineData(0, InspectionResult.Passed)]
    [InlineData(6, InspectionResult.Passed)]
    [InlineData(7, InspectionResult.FailedDamage)]
    [InlineData(10, InspectionResult.FailedDamage)]
    public void Inspect_UsesDamageThreshold(int damage, InspectionResult expected)
    {
        var center = new ServiceCenter(maxAllowedDamage: 6);

        Assert.Equal(expected, center.Inspect(TestData.ElectroScooter(damage: damage)));
    }
}