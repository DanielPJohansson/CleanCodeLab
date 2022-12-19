
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

IGamesManager menu = new GameManager(availableGames);
IScoreDAO scoreDAO = new ScoreDAO("result.txt");

GameController gameController = new GameController(ui, menu, scoreDAO);

if (args.Length > 0)
{
    if (args[0] == "practice")
    {
        gameController.IsPractice = true;
    }
    else
    {
        Console.WriteLine($"Invalid argument: {args[0]}");
    }
}
else
{
    gameController.Run();
}



