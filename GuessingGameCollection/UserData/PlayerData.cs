namespace GuessingGameCollection.UserData;

public class PlayerData
{
    public string Name { get; private set; }
    public int NumberOfGames { get; private set; }
    int totalGuess;


    public PlayerData(string name, int guesses)
    {
        Name = name;
        NumberOfGames = 1;
        totalGuess = guesses;
    }


    //Does more than one thing
    public void Update(int guesses)
    {
        totalGuess += guesses;
        NumberOfGames++;
    }

    //Returns a more specific average than the method name indicates
    public double GetAverageScore()
    {
        return (double)totalGuess / NumberOfGames;
    }


    public override bool Equals(Object p)
    {
        return Name.Equals(((PlayerData)p).Name);
    }

    public override string ToString()
    {
        return string.Format("{0,-9}{1,5:D}{2,9:F2}", Name, NumberOfGames, GetAverageScore());
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}