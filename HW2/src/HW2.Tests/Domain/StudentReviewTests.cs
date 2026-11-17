using HW2.Domain;

namespace HW2.Tests;

public class StudentReviewTests
{
    [Fact]
    public void AddScore_CriterionNotInRubricator_Throws()
    {
        Rubricator rubricator = TestData.Rubricator(TestData.Criterion());
        Criterion foreignCriterion = TestData.Criterion();
        var review = new StudentReview();

        Assert.Throws<InvalidOperationException>(
            () => review.AddScore(rubricator, foreignCriterion.Id, new Points(1), DateTime.Now)
        );
    }

    [Fact]
    public void AddScore_PointsAboveMaxScore_Throws()
    {
        Criterion criterion = TestData.Criterion(maxScore: 10);
        Rubricator rubricator = TestData.Rubricator(criterion);
        var review = new StudentReview();

        Assert.Throws<ArgumentOutOfRangeException>(
            () => review.AddScore(rubricator, criterion.Id, new Points(10.01m), DateTime.Now)
        );
        Assert.Empty(review.Scores);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(10)]
    public void AddScore_PointsWithinRange_Saved(decimal points)
    {
        Criterion criterion = TestData.Criterion(maxScore: 10);
        Rubricator rubricator = TestData.Rubricator(criterion);
        var review = new StudentReview();

        review.AddScore(rubricator, criterion.Id, new Points(points), DateTime.Now);

        Assert.Equal(points, review.Scores[criterion.Id].Points.Value);
    }

    [Fact]
    public void AddScore_SameCriterionTwice_ReplacesScore()
    {
        Criterion criterion = TestData.Criterion();
        Rubricator rubricator = TestData.Rubricator(criterion);
        var review = new StudentReview();

        TestData.Grade(review, rubricator, criterion, 3);
        TestData.Grade(review, rubricator, criterion, 7);

        Assert.Single(review.Scores);
        Assert.Equal(7m, review.Scores[criterion.Id].Points.Value);
    }

    [Fact]
    public void AddScore_InvalidFix_KeepsPreviousScore()
    {
        Criterion criterion = TestData.Criterion(maxScore: 10);
        Rubricator rubricator = TestData.Rubricator(criterion);
        var review = new StudentReview();
        TestData.Grade(review, rubricator, criterion, 5);

        Assert.Throws<ArgumentOutOfRangeException>(
            () => review.AddScore(rubricator, criterion.Id, new Points(11), DateTime.Now)
        );

        Assert.Equal(5m, review.Scores[criterion.Id].Points.Value);
    }

    [Fact]
    public void AddScore_KeepsDateAndComment()
    {
        Criterion criterion = TestData.Criterion();
        Rubricator rubricator = TestData.Rubricator(criterion);
        var review = new StudentReview();
        var date = new DateTime(2026, 3, 4, 12, 0, 0);

        review.AddScore(rubricator, criterion.Id, new Points(1), date, "молодец");

        Assert.Equal(date, review.Scores[criterion.Id].Date);
        Assert.Equal("молодец", review.Scores[criterion.Id].Comment);
    }

    [Fact]
    public void RemoveScore_ExistingScore_RemovesAndReturnsTrue()
    {
        Criterion criterion = TestData.Criterion();
        Rubricator rubricator = TestData.Rubricator(criterion);
        var review = new StudentReview();
        TestData.Grade(review, rubricator, criterion, 5);

        Assert.True(review.RemoveScore(criterion.Id));
        Assert.Empty(review.Scores);
    }

    [Fact]
    public void RemoveScore_MissingScore_ReturnsFalse()
    {
        Assert.False(new StudentReview().RemoveScore(new CriterionId(999)));
    }

    [Fact]
    public void Scores_CannotBeModifiedFromOutside()
    {
        var scores = (IDictionary<CriterionId, Score>)new StudentReview().Scores;

        Assert.True(scores.IsReadOnly);
    }
}
