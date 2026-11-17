public class DamageLevelTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(11)]
    public void DamageLevel_OutOfRange_Throws(int v)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new DamageLevel(v));
    }
}