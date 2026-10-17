public class VehiclePark
{
    private readonly IInspectionService _inspection;
    private readonly List<Vehicle> vehicles = new();
    
    public IReadOnlyList<Vehicle> Vehicles { get; }

    public VehiclePark(IInspectionService inspection)
    {
        _inspection = inspection;
        Vehicles = vehicles.AsReadOnly();
    }

    public bool IsInPark(Vehicle vehicle)
    {
        return vehicles.Contains(vehicle);
    }

    public AdmissionResult TryAdmit(Vehicle vehicle)
    {
        if (IsInPark(vehicle))
            return new AdmissionResult(AdmissionStatus.AlreadyInPark);

        InspectionResult result = _inspection.Inspect(vehicle);
        if (result != InspectionResult.Passed)
            return new AdmissionResult(AdmissionStatus.InspectionFailed, result);

        vehicles.Add(vehicle);
        return new AdmissionResult(AdmissionStatus.Admitted);
    }

}