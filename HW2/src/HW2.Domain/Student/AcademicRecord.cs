namespace HW2.Domain;

public class AcademicRecord
{
    private readonly List<Student> students = new();
    
    public IReadOnlyList<Student> Students { get; }

    public AcademicRecord()
    {
        Students = students.AsReadOnly();
    }

    public void AddStudent(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);
        
        if (students.Any(i => i.Id == student.Id))
            throw new InvalidOperationException($"Студент с айди {student.Id} уже в ведомости");

        students.Add(student);
    }

    public Student GetStudentBy(StudentId id)
    {
        Student? student = students.Find(i => i.Id == id);
        if (student == null)
            throw new KeyNotFoundException($"Студента с айди {id} нет в ведомости");
        
        return student;
    }
}