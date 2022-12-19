using GuessingGameCollection.Games;
using GuessingGameCollection.Games.Components;

namespace GuessingGameCollection.Controllers;
public class GameManager : IGamesManager
{
    private readonly List<IGame> _games;

    public GameManager(List<IGame> games)
    {
        _games = games;
    }

    public List<string> GetAvailableGames()
    {
        List<string> games = new();
        int index = 0;

        foreach (var game in _games)
        {
            games.Add(index + ". " + game.GetName());
            index++;
        }

        return games;
    }

    public IGame GetGame(int index)
    {
        return _games[index];
    }

    public bool IsValidIndex(int index)
    {
        return (index >= 0 && index < _games.Count()) ? true : false;
    }
}