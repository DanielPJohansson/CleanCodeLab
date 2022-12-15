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

    public string GenerateGameGoal()
    {
        goal = _gameStrategy.GenerateRandomGoal();
        return goal;
    }

    public string EvaluateGuess(string guess)
    {
        int numberOfCorrectDigitWrongPosition = 0;
        int numberOfCorrectDigitAndPosition = 0;

        for (int i = 0; i < goal.Length; i++)
        {
            for (int j = 0; j < goal.Length && j < guess.Length; j++)
            {
                if (goal[i] == guess[j])
                {
                    if (i == j)
                    {
                        numberOfCorrectDigitAndPosition++;
                    }
                    else
                    {
                        numberOfCorrectDigitWrongPosition++;
                    }
                }
            }
        }

        return _gameStrategy.FormatResultForGameVariant(numberOfCorrectDigitWrongPosition, numberOfCorrectDigitAndPosition);
    }
}