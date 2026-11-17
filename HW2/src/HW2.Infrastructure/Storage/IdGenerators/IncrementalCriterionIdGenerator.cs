using HW2.Application;
using HW2.Domain;

namespace HW2.Infrastructure;

public class IncrementalCriterionIdGenerator : ICriterionIdGenerator
{
    private readonly LazyIncrementalCounter _counter;

    public IncrementalCriterionIdGenerator(IRubricatorRepository rubricatorRepository)
    {
        _counter = new LazyIncrementalCounter(() => FindMaxCriterionId(rubricatorRepository));
    }

    public CriterionId Next()
    {
        return new CriterionId(_counter.Next());
    }

    private static int FindMaxCriterionId(IRubricatorRepository rubricatorRepository)
    {
        return rubricatorRepository.Get().Criteria.Keys
            .Select(criterionId => criterionId.Id)
            .DefaultIfEmpty(0)
            .Max();
    }
}
