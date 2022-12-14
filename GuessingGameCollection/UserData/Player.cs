namespace GuessingGameCollection.UserData;

public class Player
{
    public string Name { get; set; }
    public int NumberOfGames { get; set; }
    public int TotalScore { get; set; }

    public Player(string name, int score)
    {
        Name = name;
        NumberOfGames = 1;
        TotalScore = score;
    }

    //Does more than one thing
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
        if (other is Player)
        {
            return Name.Equals(((Player)other).Name);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override string ToString()
    {
        return string.Format("{0,-9}{1,5:D}{2,9:F2}", Name, NumberOfGames, GetAverageScore());
    }
}