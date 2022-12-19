namespace GuessingGameCollection.Games;

public interface IGame
{
    public string CurrentGoal { get; }
    public void GenerateNewGameGoal();

    public string EvaluateGuess(string guess);
    public bool IsWinCondition(string result);

    public string GetName();

}