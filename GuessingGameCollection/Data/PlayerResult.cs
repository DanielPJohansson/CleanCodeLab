namespace GuessingGameCollection.Data;

public class PlayerResult
{
    public string Name { get; private set; }
    public int NumberOfGames { get; private set; }
    public int TotalScore { get; private set; }
    public string Game { get; private set; }

    public PlayerResult(string name, int score, string game)
    {
        Name = name;
        NumberOfGames = 1;
        TotalScore = score;
        Game = game;
    }

    public void Update(int score)
    {
        TotalScore += score;
        NumberOfGames++;
    }

    public double GetAverageScore()
    {
        return (double)TotalScore / NumberOfGames;
    }

    public override bool Equals(Object? other)
    {
        if (other is PlayerResult)
        {
            return Name.Equals(((PlayerResult)other).Name);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}