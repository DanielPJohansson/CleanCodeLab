namespace GuessingGameCollection.Data;
public interface IScoreDAO
{
    public void PostScore(PlayerResult playerResult);
    public List<PlayerResult> GetHighScores(string game);
}