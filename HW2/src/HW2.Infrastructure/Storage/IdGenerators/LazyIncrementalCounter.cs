namespace HW2.Infrastructure;

internal class LazyIncrementalCounter
{
    private readonly Func<int> _findMaxExistingValue;
    private int? _lastIssuedValue;

    public LazyIncrementalCounter(Func<int> findMaxExistingValue)
    {
        _findMaxExistingValue = findMaxExistingValue;
    }

    public int Next()
    {
        _lastIssuedValue ??= _findMaxExistingValue();
        _lastIssuedValue += 1;

        return _lastIssuedValue.Value;
    }
}
