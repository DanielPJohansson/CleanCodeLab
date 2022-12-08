namespace GuessingGameCollection.UI;

public class ConsoleIO : IUI
{
    public string GetStringInput()
    {
        return Console.ReadLine()!;
    }

    public void OutputString(string s)
    {
        Console.WriteLine(s);
    }
}