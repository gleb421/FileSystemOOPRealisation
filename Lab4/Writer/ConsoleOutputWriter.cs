namespace Itmo.ObjectOrientedProgramming.Lab4.Writer;

public class ConsoleOutputWriter : IOutputWriter
{
    public void Write(string message)
    {
        Console.Write(message); // Пишет сообщение без переноса строки
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}