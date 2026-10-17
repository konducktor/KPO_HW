public class VehiclesForNovices(
    IConsoleIO console, ItemFormatter formatter, VehiclePark park
) : IMenuCommand
{
    public string Title { get; } = "Вывести весь транспорт в парке, подходяший для новичков (для этого )";

    public void Run()
    {
        console.Print("Транспорт в парке, подходящий для новичков:");
        PrintVehiclesForNovicesFromPark();
    }

    void PrintVehiclesForNovicesFromPark()
    {
        foreach (Vehicle vehicle in park.Vehicles)
        {
            if (vehicle.NoviceScore.IsSuitableForNovice())
                console.Print(formatter.Format(vehicle));
        }
    }
}