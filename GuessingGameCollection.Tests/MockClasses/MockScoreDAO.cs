using GuessingGameCollection.Data;

namespace GuessingGameCollection.Tests.MockClasses;

public class MockScoreDAO : IScoreDAO
{
    public string? PostedScore { get; set; }
    public PlayerResult? PostedPlayerData { get; set; }

    public List<PlayerResult> GetHighScores(string game)
    {
        List<PlayerResult> players = new();
        players.Add(PostedPlayerData);

        return players;
    }

    public void PostScore(PlayerResult playerResult)
    {
        PostedPlayerData = playerResult;
    }
}