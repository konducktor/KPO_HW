public class ServiceCenter : IInspectionService
{
    private readonly int _maxAllowedDamage;

    public ServiceCenter(int maxAllowedDamage = 6)
    {
        _maxAllowedDamage = maxAllowedDamage;
    }

    public InspectionResult Inspect(Vehicle vehicle)
    {
        if (vehicle.DamageLevel.Value > _maxAllowedDamage)
            return InspectionResult.FailedDamage;
        
        return InspectionResult.Passed;
    }
}