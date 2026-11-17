public class FakeInspectionService(InspectionResult result = InspectionResult.Passed) : IInspectionService
{
    public InspectionResult Result { get; set; } = result;

    public int Calls { get; private set; }

    public InspectionResult Inspect(Vehicle vehicle)
    {
        Calls++;
        return Result;
    }
}