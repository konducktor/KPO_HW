namespace HW2.ConsoleUI;

public interface IConsoleIO
{
    public void Print(string text);
    public string ReadString(string prompt);
    public int ReadInt(string prompt, int min, int max);
    public decimal ReadDecimal(string prompt, decimal min, decimal max);
}
