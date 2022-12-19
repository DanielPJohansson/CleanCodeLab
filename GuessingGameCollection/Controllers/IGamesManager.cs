using GuessingGameCollection.Games;

namespace GuessingGameCollection.Controllers;
public interface IGamesManager
{
    public List<string> GetAvailableGames();

    public IGame GetGame(int index);

    public bool IsValidIndex(int index);
}