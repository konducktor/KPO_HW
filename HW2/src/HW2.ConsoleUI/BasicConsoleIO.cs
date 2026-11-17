using System.Globalization;
using System.Numerics;

namespace HW2.ConsoleUI;

public class BasicConsoleIO : IConsoleIO
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }

    public string ReadString(string prompt)
    {
        Print(prompt);

        return Console.ReadLine() ?? throw new EndOfStreamException("Ввод закончился");
    }

    public int ReadInt(string prompt, int min, int max)
    {
        return ReadNumber(prompt, min, max);
    }

    public decimal ReadDecimal(string prompt, decimal min, decimal max)
    {
        return ReadNumber(prompt, min, max);
    }

    private T ReadNumber<T>(string prompt, T min, T max) where T : INumber<T>
    {
        while (true)
        {
            string text = ReadString(prompt);

            if (!T.TryParse(text, CultureInfo.CurrentCulture, out T value))
            {
                Print("На вход требуется число (дробные через запятую)");
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
