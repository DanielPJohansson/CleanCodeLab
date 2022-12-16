using System.Text;
using GuessingGameCollection.GameComponents;

namespace GuessingGameCollection.Games;

public class Moo : IGame
{
    private string goal;
    private IGameStrategy _gameStrategy;

    public Moo(IGameStrategy gameStrategy)
    {
        _gameStrategy = gameStrategy;
    }

    public void SetGoalGenerator(IGameStrategy gameStrategy)
    {
        _gameStrategy = gameStrategy;
    }

    public string GetGameGoal()
    {
        goal = _gameStrategy.GenerateRandomGoal();
        return goal;
    }

    public string GetResultOfGuess(string guess)
    {
        int numberOfMatchesInWrongPosition = 0;
        int numberOfExactMatches = 0;

        for (int i = 0; i < goal.Length; i++)
        {
            for (int j = 0; j < goal.Length && j < guess.Length; j++)
            {
                if (goal[i] == guess[j])
                {
                    if (i == j)
                    {
                        numberOfExactMatches++;
                    }
                    else
                    {
                        numberOfMatchesInWrongPosition++;
                    }
                }
            }
        }

        return FormatResultForGameVariant(numberOfExactMatches, numberOfMatchesInWrongPosition);
    }

    public string FormatResultForGameVariant(int numberOfExactMatches, int numberOfMatchesInWrongPosition)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append('B', numberOfExactMatches);
        stringBuilder.Append(',');
        stringBuilder.Append('C', numberOfMatchesInWrongPosition);
        return stringBuilder.ToString();
    }
}