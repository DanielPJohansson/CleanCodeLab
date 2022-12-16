namespace GuessingGameCollection.Games;

public interface IGame
{
    public string GenerateGameGoal();

    public string GetResultOfGuess(string guess, string goal);

    public string GetName();

}