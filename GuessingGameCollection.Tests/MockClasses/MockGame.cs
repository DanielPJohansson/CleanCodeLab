using GuessingGameCollection.Games;

namespace GuessingGameCollection.Tests.MockClasses;

public class MockGame : IGame
{
    public string Goal { get; set; }

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

    public bool GuessIsCorrect { get; set; }

    public void EvaluateGuess(string guess)
    {
        Guesses.Add(guess);
        if (guess == Goal)
        {
            GuessIsCorrect = true;
        }
    }

    public void GenerateGameGoal()
    {
        Goal = "1234";
    }
}