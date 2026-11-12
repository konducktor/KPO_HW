namespace HW2.Domain;

public readonly record struct StudentId
{
    public int Id { get; }

    public StudentId(int id)
    {
        Id = id;
    }
}