namespace GuessingGameCollection.Games;

public interface IGame
{
    public string GetGameGoal();

    public string GetResultOfGuess(string guess);

}