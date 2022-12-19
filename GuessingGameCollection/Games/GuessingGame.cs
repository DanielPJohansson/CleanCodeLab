using System.Text;
using GuessingGameCollection.Games.Components;

namespace GuessingGameCollection.Games;
public class GuessingGame : IGame
{
    public string CurrentGoal { get; private set; } = string.Empty;
    private IGameStrategy _gameStrategy;

    public GuessingGame(IGameStrategy gameStrategy)
    {
        _gameStrategy = gameStrategy;
        GenerateNewGameGoal();
    }

    public void SetStrategy(IGameStrategy gameStrategy)
    {
        _gameStrategy = gameStrategy;
    }

    public void GenerateNewGameGoal()
    {
        CurrentGoal = _gameStrategy.GenerateRandomGoal();
    }

    public string EvaluateGuess(string guess)
    {
        StringMatcher matcher = new StringMatcher(guess, CurrentGoal);

        int numberOfExactMatches = matcher.GetNumberOfExactMatches();
        int numberOfMatchesInWrongPosition = matcher.GetNumberOfMatchesInWrongPosition();

        return FormatResult(numberOfExactMatches, numberOfMatchesInWrongPosition);
    }

    private string FormatResult(int numberOfExactMatches, int numberOfMatchesInWrongPosition)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append('B', numberOfExactMatches);
        stringBuilder.Append(',');
        stringBuilder.Append('C', numberOfMatchesInWrongPosition);
        return stringBuilder.ToString();
    }

    public bool IsWinCondition(string result)
    {
        string winResult = FormatResult(CurrentGoal.Length, 0);
        return result == winResult;
    }

    public string GetName()
    {
        return _gameStrategy.Name;
    }
}