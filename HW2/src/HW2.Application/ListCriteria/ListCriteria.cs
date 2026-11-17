namespace HW2.Application;

public class ListCriteria
{
    private readonly IRubricatorRepository _rubricatorRepository;

    public ListCriteria(IRubricatorRepository rubricatorRepository)
    {
        _rubricatorRepository = rubricatorRepository;
    }

    public IReadOnlyList<CriterionData> Execute()
    {
        return _rubricatorRepository.Get().Criteria.Values
            .Select(criterion => new CriterionData(
                criterion.Id.Id, criterion.Name, criterion.MaxScore, criterion.Weight
            ))
            .ToList();
    }
}
