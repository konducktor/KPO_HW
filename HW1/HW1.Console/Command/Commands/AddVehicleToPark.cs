public class AddVehicleToPark(
    IConsoleIO console, Inventory inventory, VehiclePark park
) : IMenuCommand
{
    public string Title { get; } = "Пройти техосмотр и добавить транспорт в парк";

    public void Run()
    {
        if (!inventory.Items.OfType<Vehicle>().Any())
        {
            console.Print("На балансе нет транспорта");
            return;
        }

        int number;
        Vehicle vehicle;
        while (true)
        {
            number = console.ReadInt("Введите инвентарный номер транспорта", 0, inventory.Items.Count - 1);

            if (inventory.Items[number] is Vehicle found)
            {
                vehicle = found;
                break;
            }

            console.Print("Предмет под этим номером не является транспортом");
        }

        AdmissionResult result = park.TryAdmit(vehicle);
        switch (result.Status)
        {
            case AdmissionStatus.AlreadyInPark:
                console.Print("Этот транспорт уже есть в парке");
                break;
            case AdmissionStatus.InspectionFailed:
                if (result.Inspection is { } reason)
                    PrintInspectionResult(reason);
                break;
            case AdmissionStatus.Admitted:
                console.Print($"Транспорт под номером {number} успешно добавлен в парк!");
                break;
        }
    }

    void PrintInspectionResult(InspectionResult result)
    {
        switch (result)
        {
            case InspectionResult.Failed:
                console.Print("Транспорт не прошёл проверку сервисного центра");
                break;
            case InspectionResult.FailedDamage:
                console.Print("Транспорт не прошёл проверку сервисного центра: слишком сильно повреждён");
                break;
        }
    }
}
