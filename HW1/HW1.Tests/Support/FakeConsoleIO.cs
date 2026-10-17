using System.Globalization;

public class FakeConsoleIO : IConsoleIO
{
    private readonly Queue<string> _inputs;

    public List<string> Output { get; } = new();

    public FakeConsoleIO(params string[] inputs)
    {
        _inputs = new Queue<string>(inputs);
    }

    public void Print(string text) => Output.Add(text);

    public string ReadString(string prompt)
    {
        Print(prompt);

        if (_inputs.Count == 0)
            throw new InvalidOperationException($"FakeConsoleIO: ответы закончились, а команда спросила: \"{prompt}\"");

        return _inputs.Dequeue();
    }

    public int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            string text = ReadString(prompt);

            if (!int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
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
        while (true)
        {
            string text = ReadString(prompt);

            if (!double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
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
