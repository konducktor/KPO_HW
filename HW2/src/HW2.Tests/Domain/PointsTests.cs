using HW2.Domain;

namespace HW2.Tests;

public class PointsTests
{
    [Fact]
    public void Points_Negative_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Points(-0.01m));
    }

    [Fact]
    public void Points_Zero_IsAllowed()
    {
        Assert.Equal(0m, new Points(0).Value);
    }

    [Fact]
    public void Points_ResultOfOperationBelowZero_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Points(1) * -1m);
    }
}
