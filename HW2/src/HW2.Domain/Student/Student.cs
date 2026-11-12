using System.Diagnostics.Contracts;

namespace HW2.Domain;

public class Student
{
    public StudentId Id;
    public string Name { get; }
    public string Surname { get; }
    public StudentReview StudentReview { get; }

    public Student(StudentId id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
        StudentReview = new();
    }
}
