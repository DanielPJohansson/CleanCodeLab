namespace GuessingGameCollection.Games;

public interface IGame
{
    public string Goal { get; }
    public string CurrentResult { get; }
    public bool GuessIsWrong { get; }

    public void GenerateGameGoal();

    public void EvaluateGuess(string guess);
}