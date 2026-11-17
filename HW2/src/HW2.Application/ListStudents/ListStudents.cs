namespace HW2.Application;

public class ListStudents
{
    private readonly IStudentRepository _studentRepository;

    public ListStudents(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public IReadOnlyList<StudentData> Execute()
    {
        return _studentRepository.Get().Students
            .Select(student => new StudentData(student.Id.Id, student.Name, student.Surname))
            .ToList();
    }
}
