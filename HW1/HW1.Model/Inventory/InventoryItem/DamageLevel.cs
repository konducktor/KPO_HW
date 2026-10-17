public readonly record struct DamageLevel
{
    public const int MIN = 0;
    public const int MAX = 10;

    public int Value { get; }

    public DamageLevel(int value)
    {
        if (value < MIN || value > MAX)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value, $"Оценка должна быть от {MIN} до {MAX}");
        }

        Value = value;
    }
}