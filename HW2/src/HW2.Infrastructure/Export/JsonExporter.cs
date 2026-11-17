using HW2.Application;
using System.Text.Json;

namespace HW2.Infrastructure;

public class JsonExporter : FileWriteExporter
{
    public JsonExporter(string filePath) : base(filePath) {}

    protected override string Convert(ExportData data)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(data, options);

        return json;
    }
}