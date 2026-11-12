namespace HW2.Domain;

public readonly record struct Points : IComparable<Points>
{
    public static Points Zero => new(0);

    public decimal Value { get; }

    public Points(decimal value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(
                nameof(value), value, $"Оценка должна быть не меньше 0"
            );
        
        Value = value;
    }

    public static Points operator +(Points a, Points b) => new(a.Value + b.Value);

    public static Points operator *(Points p, decimal factor) => new(p.Value * factor);
    public static Points operator *(decimal factor, Points p) => p * factor;

    public static decimal operator /(Points a, Points b) => a.Value / b.Value;

    public static bool operator <(Points a, Points b) => a.Value < b.Value;
    public static bool operator >(Points a, Points b) => a.Value > b.Value;
    public static bool operator <=(Points a, Points b) => a.Value <= b.Value;
    public static bool operator >=(Points a, Points b) => a.Value >= b.Value;

    public int CompareTo(Points other) => Value.CompareTo(other.Value);
}