using GuessingGameCollection.UserData;

namespace GuessingGameCollection.Data;
public interface IScoreDAO
{
    public void PostScore(string name, int numberOfGuesses, string game);
    public List<Player> GetHighScores(string game);
}