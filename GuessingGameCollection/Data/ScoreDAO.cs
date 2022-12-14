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
        using StreamWriter streamWriter = new StreamWriter(_fileName, append: true);
        streamWriter.WriteLine(name + "#&#" + numberOfGuesses);
        streamWriter.Close();
    }

    public List<Player> GetHighScores()
    {
        List<Player> results = ReadPlayerResultsFromFile();
        OrderResultsByScoreAscending(results);

        return results;
    }

    private List<Player> ReadPlayerResultsFromFile()
    {
        List<Player> results = new List<Player>();

        using StreamReader streamReader = new StreamReader(_fileName);

        string? line;
        while ((line = streamReader.ReadLine()) != null)
        {
            Player player = ConvertToPlayer(line);
            AddOrUpdatePlayer(results, player);
        }

        streamReader.Close();
        return results;
    }
    private Player ConvertToPlayer(string line)
    {
        string[] nameAndScore = line.Split("#&#");
        string name = nameAndScore[0];
        int score = Convert.ToInt32(nameAndScore[1]);

        return new Player(name, score);
    }

    private void AddOrUpdatePlayer(List<Player> results, Player player)
    {
        int index = results.IndexOf(player);

        if (PlayerNotInResultList(index))
        {
            results.Add(player);
        }
        else
        {
            results[index].Update(player.TotalScore);
        }
    }

    private bool PlayerNotInResultList(int index)
    {
        return index < 0;
    }

    private void OrderResultsByScoreAscending(List<Player> results)
    {
        results.Sort((p1, p2) => p1.GetAverageScore().CompareTo(p2.GetAverageScore()));
    }
}