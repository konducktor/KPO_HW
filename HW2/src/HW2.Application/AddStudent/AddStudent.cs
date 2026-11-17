using HW2.Domain;

namespace HW2.Application;

public class AddStudent
{
    private readonly IStudentRepository _studentRepository;
    private readonly StudentFactory _studentFactory;

    public AddStudent(IStudentRepository studentRepository, StudentFactory studentFactory)
    {
        _studentRepository = studentRepository;
        _studentFactory = studentFactory;
    }

    public StudentId Execute(string name, string surname)
    {
        AcademicRecord record = _studentRepository.Get();
        Student student = _studentFactory.Create(name, surname);

        record.AddStudent(student);
        _studentRepository.Save(record);

        return student.Id;
    }
}
