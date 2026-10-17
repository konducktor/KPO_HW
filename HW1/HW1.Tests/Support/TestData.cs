public static class TestData
{
    private static int _n;

    public static ElectroScooter ElectroScooter(int novice = 8, int damage = 0, double energy = 0.3)
    {
        return new(
            "ElectroScooter", new InventoryNumber(++_n), new NoviceScore(novice), 
            new DamageLevel(damage), new EnergyConsumption(energy)
        );
    }

    public static Bicycle Bicycle(int novice = 8, int damage = 0)
    {
        return new(
            "Bicycle", new InventoryNumber(++_n), 
            new NoviceScore(novice), new DamageLevel(damage)
        );
    }

    public static ElectroBicycle ElectroBicycle(int novice = 8, int damage = 0, double energy = 0.3)
    {
        return new(
            "ElectroBicycle", new InventoryNumber(++_n), new NoviceScore(novice), 
            new DamageLevel(damage), new EnergyConsumption(energy)
        );
    }
}