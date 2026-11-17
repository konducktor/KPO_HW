using HW2.Domain;

namespace HW2.Application;

public interface IStudentRepository
{
    public AcademicRecord Get();
    public void Save(AcademicRecord record);
}