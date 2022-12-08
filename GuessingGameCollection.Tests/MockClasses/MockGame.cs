using GuessingGameCollection.Games;

namespace GuessingGameCollection.Tests.MockClasses;

public class MockGame : IGame
{
    public string Goal { get; set; } = string.Empty;

    public string CurrentResult
    {
        get
        {
            string result = Results.First();
            Results.Remove(result);
            return result;
        }
    }
    public List<string> Results { get; set; } = new();
    public List<string> Guesses { get; set; } = new();

    public bool GuessIsWrong { get; set; } = true;

    public void EvaluateGuess(string guess)
    {
        Guesses.Add(guess);
        if (guess == Goal)
        {
            GuessIsWrong = false;
        }
    }

    public void GenerateGameGoal()
    {
        Goal = "1234";
    }
}