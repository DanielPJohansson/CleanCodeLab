using GuessingGameCollection.UserData;

namespace GuessingGameCollection.Data;
public interface IScoreDAO
{
    public void PostScore(string name, int numberOfGuesses);
    public List<PlayerResult> GetHighScores();
}