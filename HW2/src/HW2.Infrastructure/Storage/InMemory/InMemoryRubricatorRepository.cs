using HW2.Domain;
using HW2.Application;

namespace HW2.Infrastructure;

public class InMemoryRubricatorRepository : IRubricatorRepository
{
    private Rubricator _rubricator;

    public InMemoryRubricatorRepository()
    {
        _rubricator = new();
    }

    public Rubricator Get()
    {
        return _rubricator;
    }

    public void Save(Rubricator rubricator)
    {
        // тут этот метод бесполезен, потому что изменение происходит по ссылке
        _rubricator = rubricator;
    }
}