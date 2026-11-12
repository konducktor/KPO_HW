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
        decimal output = 0M;
        foreach (CriterionId criterionId in _rubricator.Criteria.Keys)
        {
            if (!studentReview.Scores.ContainsKey(criterionId))
                throw new InvalidOperationException(
                    $"Не хватает оценки по критерию: {_rubricator.Criteria[criterionId].Name}"
                );
            
            Score score = studentReview.Scores[criterionId];
            Criterion criterion = _rubricator.Criteria[criterionId];

            output += score.Points.Value / criterion.MaxScore * criterion.Weight;
        }

        return output;
    }
}