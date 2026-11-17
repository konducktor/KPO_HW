using HW2.Domain;

namespace HW2.Application;

public class CreateNewCriterion
{
    private readonly IRubricatorRepository _rubricatorRepository;
    private readonly CriterionFactory _criterionFactory;

    public CreateNewCriterion(IRubricatorRepository rubricatorRepository,
                              CriterionFactory criterionFactory)
    {
        _rubricatorRepository = rubricatorRepository;
        _criterionFactory = criterionFactory;
    }

    public CriterionId Execute(string name, decimal maxScore, decimal weight)
    {
        Rubricator rubricator = _rubricatorRepository.Get();
        Criterion criterion = _criterionFactory.Create(name, maxScore, weight);

        rubricator.Add(criterion);
        _rubricatorRepository.Save(rubricator);

        return criterion.Id;
    }
}
