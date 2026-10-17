public interface IConsoleIO
{
    public void Print(string text);
    public string ReadString(string prompt);
    public int ReadInt(string prompt, int min, int max);
    public double ReadDouble(string prompt, double min, double max);
}