namespace GuessingGameCollection.Data;
public class ScoreDAO : IScoreDAO
{
    private readonly string _fileName;

    public ScoreDAO(string fileName)
    {
        _fileName = fileName;
    }

    public void PostScore(PlayerResult playerResult)
    {
        using StreamWriter streamWriter = new StreamWriter(_fileName, append: true);
        streamWriter.WriteLine(playerResult.Name + "#&#" + playerResult.TotalScore + "#&#" + playerResult.Game);
        streamWriter.Close();
    }

    public List<PlayerResult> GetHighScores(string game)
    {
        List<PlayerResult> results = ReadPlayerResultsForGameFromFile(game);
        OrderResultsByScoreAscending(results);

        return results;
    }

    private List<PlayerResult> ReadPlayerResultsForGameFromFile(string game)
    {
        List<PlayerResult> results = new List<PlayerResult>();

        using StreamReader streamReader = new StreamReader(_fileName);

        string? line;
        while ((line = streamReader.ReadLine()) != null)
        {
            PlayerResult playerResult = ConvertToPlayerResult(line);
            if (playerResult.Game == game)
            {
                AddOrUpdatePlayer(results, playerResult);
            }
        }

        streamReader.Close();
        return results;
    }

    private static PlayerResult ConvertToPlayerResult(string line)
    {
        string[] nameScoreAndGame = line.Split("#&#");
        string name = nameScoreAndGame[0];
        int score = Convert.ToInt32(nameScoreAndGame[1]);
        string game = nameScoreAndGame[2];

        return new PlayerResult(name, score, game);
    }

    private static void AddOrUpdatePlayer(List<PlayerResult> results, PlayerResult playerResult)
    {
        int index = results.IndexOf(playerResult);

        if (PlayerNotInResultList(index))
        {
            results.Add(playerResult);
        }
        else
        {
            results[index].Update(playerResult.TotalScore);
        }
    }

    private static bool PlayerNotInResultList(int index)
    {
        return index < 0;
    }

    private static void OrderResultsByScoreAscending(List<PlayerResult> results)
    {
        results.Sort((p1, p2) => p1.GetAverageScore().CompareTo(p2.GetAverageScore()));
    }
}