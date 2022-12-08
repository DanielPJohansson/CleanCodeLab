using GuessingGameCollection.Data;
using GuessingGameCollection.UserData;

namespace GuessingGameCollection.Tests.MockClasses;

public class MockScoreDAO : IScoreDAO
{
    public string? PostedScore { get; set; }
    public Player? PostedPlayerData { get; set; }

    public List<Player> GetHighScores()
    {
        List<Player> players = new();
        players.Add(PostedPlayerData);

        return players;
    }

    public void PostScore(string name, int numberOfGuesses)
    {
        PostedPlayerData = new Player(name, numberOfGuesses);
    }
}