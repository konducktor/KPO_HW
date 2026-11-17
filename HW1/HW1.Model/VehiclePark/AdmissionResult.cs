public enum AdmissionStatus
{
    Admitted,
    AlreadyInPark,
    InspectionFailed
}

public readonly record struct AdmissionResult(AdmissionStatus Status, InspectionResult? Inspection = null);