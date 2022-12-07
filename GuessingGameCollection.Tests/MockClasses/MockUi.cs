using GuessingGameCollection.UI;

namespace GuessingGameCollection.Tests.MockClasses;

public class MockUi : IUI
{
    int userInputIndex = 0;
    public List<string> MockUserInput { get; set; } = new();
    public List<string> MockPrintToConsole { get; set; } = new();

    public string GetStringInput()
    {
        var stringToReturn = MockUserInput[userInputIndex];
        userInputIndex++;
        return stringToReturn;
    }

    public void OutputString(string s)
    {
        MockPrintToConsole.Add(s);
    }
}