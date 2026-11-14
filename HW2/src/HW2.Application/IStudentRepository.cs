using HW2.Domain;

namespace HW2.Application;

public interface IStudentRepository
{
    public AcademicRecord GetAcademicRecord();
    public Student GetStudentBy(StudentId id);
    public void Save(Student student);
}