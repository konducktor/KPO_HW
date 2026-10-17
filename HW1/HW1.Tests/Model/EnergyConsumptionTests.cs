public class EnergyConsumptionTests
{
    [Fact]
    public void EnergyConsumption_Negative_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new EnergyConsumption(-0.1));
    }

    [Fact]
    public void EnergyConsumption_Plus_Adds()
    {
        Assert.Equal(0.8, (new EnergyConsumption(0.3) + new EnergyConsumption(0.5)).DailyConsumption, precision: 6);
    }
}