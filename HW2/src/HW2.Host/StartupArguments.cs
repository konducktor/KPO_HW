namespace HW2.Host;

public static class StartupArguments
{
    private const string StorageOptionName = "--storage";

    public static StorageKind ParseStorageKind(string[] arguments)
    {
        int optionIndex = Array.IndexOf(arguments, StorageOptionName);
        if (optionIndex == -1)
            return StorageKind.InMemory;

        int valueIndex = optionIndex + 1;
        if (valueIndex >= arguments.Length)
            throw new ArgumentException($"После {StorageOptionName} нужно указать хранилище: inmemory или json");

        return arguments[valueIndex].ToLowerInvariant() switch
        {
            "inmemory" => StorageKind.InMemory,
            "json" => StorageKind.Json,
            _ => throw new ArgumentException(
                $"Неизвестное хранилище '{arguments[valueIndex]}'; допустимо: inmemory, json"
            )
        };
    }
}
