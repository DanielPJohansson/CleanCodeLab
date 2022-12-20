using GuessingGameCollection.Games.Components;

namespace GuessingGameCollection.Tests.MockClasses;

public class MockGoalGenerator : IGameStrategy
{
    public string Goal { get; set; }

    public string Name { get; set; }


    public string GenerateRandomGoal()
    {
        return Goal;
    }
}