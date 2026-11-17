using HW2.Domain;

namespace HW2.Tests;

public class RubricatorTests
{
    [Fact]
    public void Add_DuplicateId_Throws()
    {
        var rubricator = new Rubricator();
        var id = new CriterionId(1);
        rubricator.Add(new Criterion(id, "Первый", 10, 1));

        Assert.Throws<InvalidOperationException>(
            () => rubricator.Add(new Criterion(id, "Второй", 5, 1))
        );
    }

    [Fact]
    public void Add_Null_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => new Rubricator().Add(null!));
    }

    [Fact]
    public void Add_NewCriterion_AvailableById()
    {
        Criterion criterion = TestData.Criterion();
        Rubricator rubricator = TestData.Rubricator(criterion);

        Assert.Same(criterion, rubricator.Criteria[criterion.Id]);
    }
}
