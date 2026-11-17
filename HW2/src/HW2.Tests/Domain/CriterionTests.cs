using HW2.Domain;

namespace HW2.Tests;

public class CriterionTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Criterion_MaxScoreNotPositive_Throws(decimal maxScore)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new Criterion(new CriterionId(1), "Тест", maxScore, 1)
        );
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Criterion_WeightNotPositive_Throws(decimal weight)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new Criterion(new CriterionId(1), "Тест", 10, weight)
        );
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Criterion_BlankName_Throws(string name)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new Criterion(new CriterionId(1), name, 10, 1)
        );
    }

    [Fact]
    public void EnsureAccept_PointsAboveMax_Throws()
    {
        Criterion criterion = TestData.Criterion(maxScore: 10);

        Assert.Throws<ArgumentOutOfRangeException>(() => criterion.EnsureAccept(new Points(11)));
    }

    [Fact]
    public void EnsureAccept_PointsEqualToMax_Accepted()
    {
        Criterion criterion = TestData.Criterion(maxScore: 10);

        Assert.Equal(new Points(10), criterion.EnsureAccept(new Points(10)));
    }
}
