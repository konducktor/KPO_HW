using HW2.Domain;
using HW2.Application;

namespace HW2.Infrastructure;

public class JsonRubricatorRepository : IRubricatorRepository
{
    private readonly string _filePath;

    public JsonRubricatorRepository(string filePath)
    {
        _filePath = filePath;
    }

    public Rubricator Get()
    {
        RubricatorDto? rubricatorDto = JsonFileUtils.Read<RubricatorDto>(_filePath);
        if (rubricatorDto is null)
            return new Rubricator();

        return DtoToDomainMapper.MapRubricator(rubricatorDto);
    }

    public void Save(Rubricator rubricator)
    {
        JsonFileUtils.Write(DomainToDtoMapper.MapRubricator(rubricator), _filePath);
    }
}
