namespace HW2.Domain;

public class Criterion
{
    public CriterionId Id { get; }
    public string Name { get; } = "";
    public decimal MaxScore { get; }
    public decimal Weight { get; }

    public Criterion(CriterionId id, string name, decimal maxScore, decimal weight)
    {
        Id = id;
        Name = name;

        if (maxScore <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxScore), maxScore,
                $"Максимальная оценка {Name} должна быть больше 0"
            );
        MaxScore = maxScore;

        if (weight <= 0)
            throw new ArgumentOutOfRangeException(nameof(weight), weight,
                $"Вес оценки {Name} должен быть быть больше 0"
            );
        Weight = weight;
    }

    public Points EnsureAccept(Points points)
    {
        if (points.Value > MaxScore)
            throw new ArgumentOutOfRangeException(
                nameof(points), points,
                $"Оценка критерия '{Name}' должна быть не больше {MaxScore}"
            );

        return points;
        
    }
}