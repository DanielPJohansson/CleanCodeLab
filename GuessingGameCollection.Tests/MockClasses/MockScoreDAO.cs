using GuessingGameCollection.Data;
using GuessingGameCollection.UserData;

namespace GuessingGameCollection.Tests.MockClasses;

public class MockScoreDAO : IScoreDAO
{
    public string? PostedScore { get; set; }
    public PlayerResult? PostedPlayerData { get; set; }

    public List<PlayerResult> GetHighScores()
    {
        List<PlayerResult> players = new();
        players.Add(PostedPlayerData);

        return players;
    }

    public void PostScore(string name, int numberOfGuesses)
    {
        PostedPlayerData = new PlayerResult(name, numberOfGuesses);
    }
}