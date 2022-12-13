namespace GuessingGameCollection.UserData;

public class PlayerResult
{
    public string Name { get; set; }
    public int NumberOfGames { get; set; }
    public int NumberOfGuesses { get; set; }


    public PlayerResult()
    {

    }

    public PlayerResult(string name, int guesses)
    {
        Name = name;
        NumberOfGames = 1;
        NumberOfGuesses = guesses;
    }

    //Does more than one thing
    public void Update(int guesses)
    {
        NumberOfGuesses += guesses;
        NumberOfGames++;
    }

    public double GetAverageScore()
    {
        return (double)NumberOfGuesses / NumberOfGames;
    }

    public override string ToString()
    {
        return string.Format("{0,-9}{1,5:D}{2,9:F2}", Name, NumberOfGames, GetAverageScore());
    }
}