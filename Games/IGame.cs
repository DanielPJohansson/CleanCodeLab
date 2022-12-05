namespace CleanCodeLab.Games;

public interface IGame
{
    public string MakeGoal();

    public string CheckBC(string goal, string guess);
}