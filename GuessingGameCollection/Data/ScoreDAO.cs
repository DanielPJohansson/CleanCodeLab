using GuessingGameCollection.UserData;

namespace GuessingGameCollection.Data;
public class ScoreDAO : IScoreDAO
{
    private readonly string _fileName;

    public ScoreDAO(string fileName)
    {
        _fileName = fileName;
    }

    public void PostScore(string name, int numberOfGuesses)
    {
        StreamWriter output = new StreamWriter(_fileName, append: true);
        output.WriteLine(name + "#&#" + numberOfGuesses);
        output.Close();
    }

    public List<Player> GetHighScores()
    {
        List<Player> results = ReadFromFile();

        results.Sort((p1, p2) => p1.GetAverageScore().CompareTo(p2.GetAverageScore()));

        return results;
    }

    private List<Player> ReadFromFile()
    {
        StreamReader input = new StreamReader(_fileName);
        List<Player> results = new List<Player>();

        string? line;
        while ((line = input.ReadLine()) != null)
        {
            string[] nameAndScore = line.Split("#&#");
            string name = nameAndScore[0];
            int score = Convert.ToInt32(nameAndScore[1]);

            UpdateResults(results, name, score);
        }

        input.Close();
        return results;
    }

    private static void UpdateResults(List<Player> results, string name, int score)
    {
        Player? player = results.SingleOrDefault(player => player.Name == name);

        if (player is null)
        {
            results.Add(new Player(name, score));
        }
        else
        {
            player.Update(score);
        }
    }
}