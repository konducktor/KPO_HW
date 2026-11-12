namespace HW2.Domain;

public class Rubricator
{
    public Dictionary<CriterionId, Criterion> Criteria { get; }

    public Rubricator()
    {
        Criteria = new();
    }

    public void Add(Criterion criterion)
    {
        ArgumentNullException.ThrowIfNull(criterion);
        
        if (Criteria.ContainsKey(criterion.Id))
            throw new InvalidOperationException($"Критерий с айди {criterion.Id} уже в рубрикаторе");
        
        Criteria.Add(criterion.Id, criterion);
    }

    public bool IsValid(CriterionId id)
    {
        return Criteria.ContainsKey(id);
    }
}