namespace GuessingGameCollection.Games;

public interface IGame
{
    public string GenerateGameGoal();

    public string GetResultOfGuess(string goal, string guess);
}