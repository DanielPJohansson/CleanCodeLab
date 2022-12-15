using GuessingGameCollection.GameComponents;

namespace GuessingGameCollection.Tests.MockClasses;

public class MockGoalGenerator : IGameStrategy
{
    public string Goal { get; set; }

    public string FormatResultForGameVariant(int numberOfExactMatches, int numberOfMatchesInWrongPosition)
    {
        throw new NotImplementedException();
    }

    public string GenerateRandomGoal()
    {
        return Goal;
    }
}