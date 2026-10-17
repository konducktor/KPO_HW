public class AddDemonstrative(
    IConsoleIO console, VehicleFactory vehicles, ItemFactory items, 
    Inventory inventory, VehiclePark park
) : IMenuCommand
{
    public string Title { get; } = "Добавить демонстративные предметы в банк и парк";

    public void Run()
    {
        inventory.Add(vehicles.CreateElectroScooter("Самокат для самых маленьких", 8, 2, 150.0));
        inventory.Add(items.CreateHelmet("Шлем"));
        inventory.Add(vehicles.CreateBicycle("Велик из 90-х", 5, 6));
        inventory.Add(vehicles.CreateElectroBicycle("Спортивный велик 6700", 1, 9, 500.0));
        inventory.Add(items.CreateDockStation("Док-станция"));
        inventory.Add(items.CreateChargingStation("Зарядная станция"));
        inventory.Add(vehicles.CreateElectroScooter("Новейший самокат", 6, 1, 200.0));

        park.TryAdmit((Vehicle) inventory.Items[0]);
        park.TryAdmit((Vehicle) inventory.Items[2]);
        park.TryAdmit((Vehicle) inventory.Items[3]);

        console.Print("В банк и парк добавлены предметы для демонстрации!");
    }
}