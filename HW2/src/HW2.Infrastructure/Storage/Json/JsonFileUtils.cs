using System.Text.Json;

namespace HW2.Infrastructure;

internal static class JsonFileUtils
{
    private static readonly JsonSerializerOptions SerializerOptions = new() { WriteIndented = true };

    public static T? Read<T>(string filePath) where T : class
    {
        if (!File.Exists(filePath))
            return null;

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }

    public static void Write<T>(T instance, string filePath)
    {
        string directoryPath = Path.GetDirectoryName(Path.GetFullPath(filePath))!;
        Directory.CreateDirectory(directoryPath);

        string json = JsonSerializer.Serialize(instance, SerializerOptions);
        File.WriteAllText(filePath, json);
    }
}
