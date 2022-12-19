using GuessingGameCollection.Games;

namespace GuessingGameCollection.Tests.MockClasses;

public class MockGame : IGame
{

    public List<string> Results { get; set; } = new();
    public List<string> Guesses { get; set; } = new();

    public string? CurrentGoal { get; set; }

    public string EvaluateGuess(string guess)
    {
        Guesses.Add(guess);
        string result = Results.First();
        Results.Remove(result);
        return result;
    }

    public void GenerateNewGameGoal()
    {
        CurrentGoal = "1234";
    }

    public string GetName()
    {
        throw new NotImplementedException();
    }

    public bool IsWinCondition(string result)
    {
        throw new NotImplementedException();
    }

}