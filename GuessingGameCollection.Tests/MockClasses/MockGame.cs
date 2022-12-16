using GuessingGameCollection.Games;

namespace GuessingGameCollection.Tests.MockClasses;

public class MockGame : IGame
{
    public string Goal { get; set; } = string.Empty;

    public List<string> Results { get; set; } = new();
    public List<string> Guesses { get; set; } = new();

    public bool GuessIsWrong { get; set; } = true;

    public string GetResultOfGuess(string guess)
    {
        Guesses.Add(guess);
        string result = Results.First();
        Results.Remove(result);
        return result;
    }

    public string GetGameGoal()
    {
        return "1234";
    }


}