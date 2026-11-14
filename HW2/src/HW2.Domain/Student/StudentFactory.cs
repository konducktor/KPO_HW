namespace HW2.Domain;

public class StudentFactory
{
    private readonly IStudentIdGenerator _idGenerator;

    public StudentFactory(IStudentIdGenerator idGenerator)
    {
        _idGenerator = idGenerator;
    }

    public Student Create(string name, string surname)
    {
        return new(_idGenerator.Next(), name, surname);
    }
}