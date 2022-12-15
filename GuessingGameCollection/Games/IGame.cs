namespace GuessingGameCollection.Games;

public interface IGame
{
    public string GenerateGameGoal();

    public string EvaluateGuess(string guess);

}