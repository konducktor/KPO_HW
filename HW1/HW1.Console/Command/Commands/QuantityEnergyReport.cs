public class QuantityEnergyReport(IConsoleIO console, VehiclePark park) : IMenuCommand
{
    public string Title { get; } = "Составление отчёта по числу единиц и суммарной энергии парка";

    public void Run()
    {
        EnergyConsumption energy = calcCumulativeParkEnergy();

        console.Print("Отчёт по парку:");
        console.Print($"\tЧисло единиц транспорта в парке: {park.Vehicles.Count}");
        console.Print($"\tСуммарный дневной расход энергии: {energy.DailyConsumption}");
    }

    EnergyConsumption calcCumulativeParkEnergy()
    {
        EnergyConsumption cumulativeEnergy = EnergyConsumption.Zero;

        foreach (Vehicle vehicle in park.Vehicles)
        {
            if (vehicle is IEnergyConsumer)
            {
                IEnergyConsumer energyConsumer = (IEnergyConsumer) vehicle;
                cumulativeEnergy = cumulativeEnergy + energyConsumer.Energy;
            }
        }

        return cumulativeEnergy;
    }
}