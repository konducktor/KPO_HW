namespace HW2.Domain;

public class DomainService
{
    private Rubricator _rubricator;

    public DomainService(Rubricator rubricator)
    {
        _rubricator = rubricator;
    }

    public decimal CalculateCumulativeScore(StudentReview studentReview)
    {
        if (studentReview.Scores.Count != _rubricator.Criteria.Count)
            throw new InvalidOperationException(
                $"Количество оценённых критериев не совпадает с рубрикатором"
            );

        decimal output = 0M;
        foreach (CriterionId criterionId in _rubricator.Criteria.Keys)
        {
            Score score = studentReview.Scores[criterionId];
            Criterion criterion = _rubricator.Criteria[criterionId];

            output += score.Points.Value / criterion.MaxScore * criterion.Weight;
        }

        return output;
    }
}