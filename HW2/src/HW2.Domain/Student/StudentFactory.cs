namespace HW2.Domain;

public class StudentFactory
{
    private int _lastUniqueId;

    public StudentFactory()
    {
        _lastUniqueId = 0;
    }

    public Student create(string name, string surname)
    {
        return new(new StudentId(_lastUniqueId++), name, surname);
    }
}