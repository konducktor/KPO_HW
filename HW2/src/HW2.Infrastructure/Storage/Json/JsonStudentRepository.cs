using HW2.Domain;
using HW2.Application;

namespace HW2.Infrastructure;

public class JsonStudentRepository : IStudentRepository
{
    private readonly string _filePath;
    private readonly IRubricatorRepository _rubricatorRepository;

    public JsonStudentRepository(string filePath, IRubricatorRepository rubricatorRepository)
    {
        _filePath = filePath;
        _rubricatorRepository = rubricatorRepository;
    }

    public AcademicRecord Get()
    {
        AcademicRecordDto? academicRecordDto = JsonFileUtils.Read<AcademicRecordDto>(_filePath);
        if (academicRecordDto is null)
            return new AcademicRecord();

        Rubricator rubricator = _rubricatorRepository.Get();
        return DtoToDomainMapper.MapAcademicRecord(academicRecordDto, rubricator);
    }

    public void Save(AcademicRecord record)
    {
        JsonFileUtils.Write(DomainToDtoMapper.MapAcademicRecord(record), _filePath);
    }
}
