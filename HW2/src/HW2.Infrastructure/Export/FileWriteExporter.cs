using HW2.Application;

namespace HW2.Infrastructure;

public abstract class FileWriteExporter: IFinalScoreExporter
{
    private readonly string _filePath;

    public FileWriteExporter(string filePath)
    {
        _filePath = filePath;
    }

    public void Export(ExportData data)
    {
        string content = Convert(data);
        WriteToFile(content, _filePath);
    }

    protected abstract string Convert(ExportData data);
    protected virtual void WriteToFile(string content, string filePath)
    {
        File.WriteAllText(filePath, content);
    }
}