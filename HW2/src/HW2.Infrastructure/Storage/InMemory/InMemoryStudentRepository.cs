using HW2.Domain;
using HW2.Application;

namespace HW2.Infrastructure;

public class InMemoryStudentRepository : IStudentRepository
{
    private AcademicRecord _academicRecord;

    public InMemoryStudentRepository()
    {
        _academicRecord = new();
    }

    public AcademicRecord Get()
    {
        return _academicRecord;
    }

    public void Save(AcademicRecord record)
    {
        // тут этот метод бесполезен, потому что изменение происходит по ссылке
        _academicRecord = record;
    }
}