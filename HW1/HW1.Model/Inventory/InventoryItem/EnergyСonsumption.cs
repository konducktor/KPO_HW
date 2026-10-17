public readonly record struct EnergyConsumption
{
    public static readonly EnergyConsumption Zero = new(0.0);
    public double DailyConsumption { get; }

    public EnergyConsumption(double consumption)
    {
        if (consumption < 0.0)
            throw new ArgumentOutOfRangeException(
                nameof(consumption), consumption, $"Оценка должна быть больше 0.0");

        DailyConsumption = consumption;
    }

    public static EnergyConsumption operator+(EnergyConsumption a, EnergyConsumption b)
    {
        return new(a.DailyConsumption + b.DailyConsumption);   
    }
}