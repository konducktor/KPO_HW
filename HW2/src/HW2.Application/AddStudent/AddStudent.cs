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

    public void Execute(string name, string surname)
    {
        Student student = _studentFactory.Create(name, surname);
        
        _studentRepository.Save(student);
    }
}