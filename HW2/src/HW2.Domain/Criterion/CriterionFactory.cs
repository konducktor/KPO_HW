namespace HW2.Domain;

public class CriterionFactory
{
    private readonly ICriterionIdGenerator _idGenerator;

    public CriterionFactory(ICriterionIdGenerator idGenerator)
    {
        _idGenerator = idGenerator;
    }

    public Criterion Create(string name, decimal maxScore, decimal weight)
    {
        return new(_idGenerator.Next(), name, maxScore, weight);
    }
}