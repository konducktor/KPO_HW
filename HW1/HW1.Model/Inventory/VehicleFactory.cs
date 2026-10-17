public class VehicleFactory(IInventoryNumberGenerator numbers)
{
    public Bicycle CreateBicycle(string name, int noviceScore, int damage)
    {
        return new(name, numbers.getUnique(), new NoviceScore(noviceScore), new DamageLevel(damage));
    }

    public ElectroBicycle CreateElectroBicycle(string name, int noviceScore, int damage, double energy)
    {
        return new(name, numbers.getUnique(), new NoviceScore(noviceScore), new DamageLevel(damage), new EnergyConsumption(energy));
    }

    public ElectroScooter CreateElectroScooter(string name, int noviceScore, int damage, double energy)
    {
        return new(name, numbers.getUnique(), new NoviceScore(noviceScore), new DamageLevel(damage), new EnergyConsumption(energy));
    }
}