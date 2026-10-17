public class ElectroScooter(
    string name, InventoryNumber number, NoviceScore score, 
    DamageLevel damage, EnergyConsumption energy
) : Vehicle(name, number, score, damage), IEnergyConsumer
{
    public EnergyConsumption Energy { get; } = energy;
}