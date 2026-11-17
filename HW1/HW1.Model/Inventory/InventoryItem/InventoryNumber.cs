public readonly record struct InventoryNumber
{
    public readonly int Value;

    public InventoryNumber(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return $"№{Value}";
    }
}