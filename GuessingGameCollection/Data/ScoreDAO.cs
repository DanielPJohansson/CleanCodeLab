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

    public List<PlayerResult> GetHighScores()
    {
        List<PlayerResult> results = ReadResultsFromFile();
        OrderResults(results);

        return results;
    }

    private void OrderResults(List<PlayerResult> results)
    {
        results.Sort((p1, p2) => p1.GetAverageScore().CompareTo(p2.GetAverageScore()));
    }

    private List<PlayerResult> ReadResultsFromFile()
    {
        List<PlayerResult> results = new List<PlayerResult>();

        using StreamReader streamReader = new StreamReader(_fileName);

        string? line;
        while ((line = streamReader.ReadLine()) != null)
        {
            PlayerResult result = ConvertToPlayerResult(line);

            AddOrUpdateResults(results, result);
        }

        streamReader.Close();
        return results;
    }

    private static PlayerResult ConvertToPlayerResult(string? line)
    {
        string[] nameAndScore = line.Split("#&#");
        string name = nameAndScore[0];
        int score = Convert.ToInt32(nameAndScore[1]);
        return new PlayerResult(name, score);
    }

    private void AddOrUpdateResults(List<PlayerResult> results, PlayerResult result)
    {
        PlayerResult? player = results.SingleOrDefault(player => player.Name == result.Name);

        if (player is null)
        {
            results.Add(result);
        }
        else
        {
            player.Update(result.NumberOfGuesses);
        }
    }
}