
using GuessingGameCollection.Controllers;
using GuessingGameCollection.Data;
using GuessingGameCollection.Games;
using GuessingGameCollection.Games.Components;
using GuessingGameCollection.UI;

IUI ui = new ConsoleIO();
IGameStrategy gameStrategy = new MasterMindStrategy();
IGame game = new GuessingGame(gameStrategy);
IScoreDAO scoreDAO = new ScoreDAO("result.txt");

GameController gameController = new GameController(ui, game, scoreDAO);

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

gameController.Run();


