using GuessingGameCollection.Controllers;
using GuessingGameCollection.Games;

namespace GuessingGameCollection.Tests.MockClasses;
public class MockMenuOptions : IGamesManager
{
    private readonly IGame _game;

    public MockMenuOptions(IGame game)
    {
        _game = game;
    }

    public List<string> GetAvailableGames()
    {
        return new List<string>() { "0. Moo" };
    }

    public IGame GetGame(int index)
    {
        return _game;
    }

    public bool GameExists(int index)
    {
        return true;
    }
}