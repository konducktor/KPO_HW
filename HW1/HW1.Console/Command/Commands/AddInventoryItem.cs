public class AddInventoryItem(
    IConsoleIO console, ItemFormatter formatter, 
    VehicleFactory vehicles, ItemFactory items, Inventory inventory
) : IMenuCommand
{
    public string Title { get; } = "Добавить предмет в банк";

    public void Run()
    {
        string name = console.ReadString("Введите название предмета");

        PrintAddInventoryItem();
        IInventoryItem newItem;
        switch (console.ReadString(""))
        {
            case "1":
                newItem = vehicles.CreateElectroScooter(name, ReadNoviceScore(), ReadDamageLevel(), ReadEnergyConsumption());
                break;
            case "2":
                newItem = vehicles.CreateBicycle(name, ReadNoviceScore(), ReadDamageLevel());
                break;
            case "3":
                newItem = vehicles.CreateElectroBicycle(name, ReadNoviceScore(), ReadDamageLevel(), ReadEnergyConsumption());
                break;
            case "4":
                newItem = items.CreateChargingStation(name);
                break;
            case "5":
                newItem = items.CreateDockStation(name);
                break;
            case "6":
                newItem = items.CreateHelmet(name);
                break;
            default:
                console.Print("Неизвестный тип предмета");
                return;
        }

        inventory.Add(newItem);

        console.Print("Предмет был добавлен:");
        console.Print(formatter.Format(newItem));
        console.Print("");
    }

    void PrintAddInventoryItem()
    {
        console.Print("Выберите тип предмета:");
        console.Print("1 - Электросамокат");
        console.Print("2 - Велосипед");
        console.Print("3 - Электровелосипед");
        console.Print("4 - Зарядная станция");
        console.Print("5 - Док-станция");
        console.Print("6 - Шлем");
    }

    int ReadNoviceScore()
    {
        return console.ReadInt("Насколько подходит для новичков (1-10)? Будет добавлен в транспорт для новичков, если значение больше 6", 1, 10);
    }

    int ReadDamageLevel()
    {
        return console.ReadInt("Какое количество повреждений (0-10)? Могут возникнуть трудности с техосмотром, если значение не больше 6", 0, 10);
    }

    double ReadEnergyConsumption()
    {
        return console.ReadDouble("Какое ежедневное потребление энергии (кВт/ч)", 0.0, 10000.0);
    }
}