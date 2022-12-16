using System.Text;
using GuessingGameCollection.Games.Components;

namespace GuessingGameCollection.Games;
public class GuessingGame : IGame
{
    private IGameStrategy _gameStrategy;

    public GuessingGame(IGameStrategy gameStrategy)
    {
        _gameStrategy = gameStrategy;
    }

    public void SetStrategy(IGameStrategy gameStrategy)
    {
        _gameStrategy = gameStrategy;
    }

    public string GenerateGameGoal()
    {
        return _gameStrategy.GenerateRandomGoal();
    }

    public string GetResultOfGuess(string guess, string goal)
    {
        Matcher matcher = new Matcher(guess, goal);

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

    public string GetName()
    {
        return _gameStrategy.Name;
    }
}