namespace HW2.Domain;

public class Student
{
    public StudentId Id { get; }
    public string Name { get; }
    public string Surname { get; }
    public StudentReview Review { get; }

    public Student(StudentId id, string name, string surname)
    {
        Id = id;
        Review = new();

        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidDataException(
                $"Имя студента не должно быть пустым"
            );
        Name = name;

        if (string.IsNullOrWhiteSpace(surname))
            throw new InvalidDataException(
                $"Фамилия не должна быть пустой"
            );
        Surname = surname;
    }
}
