namespace GuessingGameCollection.Games.Components;

public interface IGameStrategy
{
    public string Name { get; }
    public string GenerateRandomGoal();

}