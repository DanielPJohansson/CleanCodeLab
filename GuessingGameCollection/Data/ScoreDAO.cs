using GuessingGameCollection.UserData;

namespace GuessingGameCollection.Data;
public class ScoreDAO : IScoreDAO
{
    private readonly string _fileName;

    public ScoreDAO(string fileName)
    {
        _fileName = fileName;
    }

    public void PostScore(string name, int numberOfGuesses, string gameName)
    {
        using StreamWriter streamWriter = new StreamWriter(_fileName, append: true);
        streamWriter.WriteLine(name + "#&#" + numberOfGuesses + "#&#" + gameName);
        streamWriter.Close();
    }

    public List<Player> GetHighScores(string game)
    {
        List<Player> results = ReadPlayerResultsFromFile(game);
        OrderResultsByScoreAscending(results);

        return results;
    }

    private List<Player> ReadPlayerResultsFromFile(string game)
    {
        List<Player> results = new List<Player>();

        using StreamReader streamReader = new StreamReader(_fileName);

        string? line;
        while ((line = streamReader.ReadLine()) != null)
        {
            Player player = ConvertToPlayer(line);
            if (player.Game == game)
            {
                AddOrUpdatePlayer(results, player);
            }
        }

        streamReader.Close();
        return results;
    }

    private static Player ConvertToPlayer(string line)
    {
        string[] nameScoreAndGame = line.Split("#&#");
        string name = nameScoreAndGame[0];
        int score = Convert.ToInt32(nameScoreAndGame[1]);
        string game = nameScoreAndGame[2];

        return new Player(name, score, game);
    }

    private static void AddOrUpdatePlayer(List<Player> results, Player player)
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

    private static bool PlayerNotInResultList(int index)
    {
        return index < 0;
    }

    private static void OrderResultsByScoreAscending(List<Player> results)
    {
        results.Sort((p1, p2) => p1.GetAverageScore().CompareTo(p2.GetAverageScore()));
    }
}