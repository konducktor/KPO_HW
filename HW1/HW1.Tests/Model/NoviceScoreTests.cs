public class NoviceScoreTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(11)]
    [InlineData(-1)]
    public void NoviceScore_OutOfRange_Throws(int v)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new NoviceScore(v));   
    }

    [Theory]
    [InlineData(5, false)]
    [InlineData(6, true)]
    public void NoviceScore_Threshold(int v, bool expected)
    {
        Assert.Equal(expected, new NoviceScore(v).IsSuitableForNovice());
    }
}