using HW2.Domain;

namespace HW2.Tests;

public static class TestData
{
    private static int _lastId;

    public static Criterion Criterion(decimal maxScore = 10, decimal weight = 1, string name = "Критерий")
    {
        return new(new CriterionId(++_lastId), name, maxScore, weight);
    }

    public static Student Student(int id = 1, string name = "Иван", string surname = "Иванов")
    {
        return new(new StudentId(id), name, surname);
    }

    public static Rubricator Rubricator(params Criterion[] criteria)
    {
        var rubricator = new Rubricator();
        foreach (Criterion criterion in criteria)
            rubricator.Add(criterion);

        return rubricator;
    }

    public static void Grade(StudentReview review, Rubricator rubricator, Criterion criterion, decimal points)
    {
        review.AddScore(rubricator, criterion.Id, new Points(points), new DateTime(2026, 1, 1));
    }
}
