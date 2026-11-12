namespace HW2.Domain;

public readonly record struct CriterionId
{
    public int Id { get; }

    public CriterionId(int id)
    {
        Id = id;
    }
}