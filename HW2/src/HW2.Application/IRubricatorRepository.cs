using HW2.Domain;

namespace HW2.Application;

public interface IRubricatorRepository
{
    public Rubricator Get();
    public void Save(Rubricator rubricator);
}