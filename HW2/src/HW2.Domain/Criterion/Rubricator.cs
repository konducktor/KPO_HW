using System.Collections.ObjectModel;

namespace HW2.Domain;

public class Rubricator
{
    private readonly Dictionary<CriterionId, Criterion> _criteria;

    public ReadOnlyDictionary<CriterionId, Criterion> Criteria { get; }

    public Rubricator()
    {
        _criteria = new();
        Criteria = _criteria.AsReadOnly();
    }

    public void Add(Criterion criterion)
    {
        ArgumentNullException.ThrowIfNull(criterion);
        
        if (_criteria.ContainsKey(criterion.Id))
            throw new InvalidOperationException($"Критерий с айди {criterion.Id} уже в рубрикаторе");
        
        _criteria.Add(criterion.Id, criterion);
    }
}