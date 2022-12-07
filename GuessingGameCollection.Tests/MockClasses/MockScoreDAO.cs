using GuessingGameCollection.Data;
using GuessingGameCollection.UserData;

namespace GuessingGameCollection.Tests.MockClasses;

public class MockScoreDAO : IScoreDAO
{
    public string PostedScore { get; set; }
    public PlayerData PostedPlayerData { get; set; }

    public List<PlayerData> GetHighScores()
    {
        List<PlayerData> players = new();
        players.Add(PostedPlayerData);

        return players;
    }

    public void PostScore(string name, int numberOfGuesses)
    {
        PostedPlayerData = new PlayerData(name, numberOfGuesses);
    }
}