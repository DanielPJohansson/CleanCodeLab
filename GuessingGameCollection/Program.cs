
using GuessingGameCollection.Controllers;
using GuessingGameCollection.Data;
using GuessingGameCollection.Games;
using GuessingGameCollection.UI;

IUI ui = new ConsoleIO();
// IGame game = new Moo();
IGame game = new MasterMind();
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


