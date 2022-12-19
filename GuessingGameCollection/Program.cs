
using GuessingGameCollection.Controllers;
using GuessingGameCollection.Data;
using GuessingGameCollection.Games;
using GuessingGameCollection.Games.Components;
using GuessingGameCollection.UI;

IUI ui = new ConsoleIO();
List<IGame> availableGames = new List<IGame>()
{
    new GuessingGame(new MasterMindStrategy()),
    new GuessingGame(new MooStrategy())
};

IGamesManager gamesManager = new GameManager(availableGames);
IScoreDAO scoreDAO = new ScoreDAO("result.txt");

GameController gameController = new GameController(ui, gamesManager, scoreDAO);

if (args.Length > 0)
{
    if (args[0] == "practice")
    {
        gameController.IsPractice = true;
    }
    else
    {
        Console.WriteLine($"Unknown argument: {args[0]}. Running as default.");
    }
}

gameController.Run();



