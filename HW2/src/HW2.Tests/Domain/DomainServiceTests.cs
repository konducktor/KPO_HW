using HW2.Domain;

namespace HW2.Tests;

public class DomainServiceTests
{
    private readonly DomainService _service = new();

    [Fact]
    public void CalculateFinalScore_SingleCriterion_ScoreRatioTimesWeight()
    {
        Criterion criterion = TestData.Criterion(maxScore: 10, weight: 0.5m);
        Rubricator rubricator = TestData.Rubricator(criterion);
        var review = new StudentReview();
        TestData.Grade(review, rubricator, criterion, 5);

        Assert.Equal(0.25m, _service.CalculateFinalScore(review, rubricator));
    }

    [Fact]
    public void CalculateFinalScore_SeveralCriteria_SumsWeightedRatios()
    {
        Criterion first = TestData.Criterion(maxScore: 10, weight: 0.6m);
        Criterion second = TestData.Criterion(maxScore: 20, weight: 0.4m);
        Rubricator rubricator = TestData.Rubricator(first, second);
        var review = new StudentReview();
        TestData.Grade(review, rubricator, first, 5);
        TestData.Grade(review, rubricator, second, 20);

        // 5/10*0.6 + 20/20*0.4 = 0.3 + 0.4
        Assert.Equal(0.7m, _service.CalculateFinalScore(review, rubricator));
    }

    [Fact]
    public void CalculateFinalScore_AllZeroPoints_ReturnsZero()
    {
        Criterion criterion = TestData.Criterion();
        Rubricator rubricator = TestData.Rubricator(criterion);
        var review = new StudentReview();
        TestData.Grade(review, rubricator, criterion, 0);

        Assert.Equal(0m, _service.CalculateFinalScore(review, rubricator));
    }

    [Fact]
    public void CalculateFinalScore_MaxPoints_ReturnsSumOfWeights()
    {
        Criterion first = TestData.Criterion(maxScore: 10, weight: 2);
        Criterion second = TestData.Criterion(maxScore: 5, weight: 3);
        Rubricator rubricator = TestData.Rubricator(first, second);
        var review = new StudentReview();
        TestData.Grade(review, rubricator, first, 10);
        TestData.Grade(review, rubricator, second, 5);

        Assert.Equal(5m, _service.CalculateFinalScore(review, rubricator));
    }

    [Fact]
    public void CalculateFinalScore_NotAllCriteriaGraded_Throws()
    {
        Criterion first = TestData.Criterion();
        Criterion second = TestData.Criterion();
        Rubricator rubricator = TestData.Rubricator(first, second);
        var review = new StudentReview();
        TestData.Grade(review, rubricator, first, 5);

        Assert.Throws<InvalidOperationException>(() => _service.CalculateFinalScore(review, rubricator));
    }

    [Fact]
    public void CalculateFinalScore_ScoreCancelled_Throws()
    {
        Criterion criterion = TestData.Criterion();
        Rubricator rubricator = TestData.Rubricator(criterion);
        var review = new StudentReview();
        TestData.Grade(review, rubricator, criterion, 5);
        review.RemoveScore(criterion.Id);

        Assert.Throws<InvalidOperationException>(() => _service.CalculateFinalScore(review, rubricator));
    }

    [Fact]
    public void CalculateFinalScore_ScoreFixed_UsesLatestPoints()
    {
        Criterion criterion = TestData.Criterion(maxScore: 10, weight: 1);
        Rubricator rubricator = TestData.Rubricator(criterion);
        var review = new StudentReview();
        TestData.Grade(review, rubricator, criterion, 2);
        TestData.Grade(review, rubricator, criterion, 8);

        Assert.Equal(0.8m, _service.CalculateFinalScore(review, rubricator));
    }

    [Fact]
    public void CalculateFinalScore_EmptyRubricatorAndReview_ReturnsZero()
    {
        Assert.Equal(0m, _service.CalculateFinalScore(new StudentReview(), new Rubricator()));
    }
}
