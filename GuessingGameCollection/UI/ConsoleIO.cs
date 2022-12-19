namespace GuessingGameCollection.UI;

public class ConsoleIO : IUI
{
    public void Exit()
    {
        System.Environment.Exit(0);
    }

    public string GetStringInput()
    {
        return Console.ReadLine()!;
    }

    public void OutputString(string output)
    {
        Console.WriteLine(output);
    }
}