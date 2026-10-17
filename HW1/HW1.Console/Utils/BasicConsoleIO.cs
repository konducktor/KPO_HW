public class BasicConsoleIO : IConsoleIO
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
    
    public string ReadString(string prompt)
    {
        Print(prompt);

        string? tmp;
        do tmp = Console.ReadLine(); while (tmp == null);
        return tmp;
    }

    public int ReadInt(string prompt, int min, int max)
    {
        int value;
        while (true)
        {
            string stringValue = ReadString(prompt);

            if (!int.TryParse(stringValue, out value))
            {
                Print("На вход требуется число");
                continue;
            }

            if (value < min || value > max)
            {
                Print($"Требуется число от {min} до {max}");
                continue;
            }

            return value;
        }
    }

    public double ReadDouble(string prompt, double min, double max)
    {
        double value;
        while (true)
        {
            string stringValue = ReadString(prompt);

            if (!double.TryParse(stringValue, out value))
            {
                Print("На вход требуется число");
                continue;
            }

            if (value < min || value > max)
            {
                Print($"Требуется число от {min} до {max}");
                continue;
            }

            return value;
        }
    }
}