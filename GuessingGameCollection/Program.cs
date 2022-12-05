
using GuessingGameCollection.Controllers;
using GuessingGameCollection.Data;
using GuessingGameCollection.Games;
using GuessingGameCollection.UI;

IUI ui = new ConsoleIO();
IGame game = new Moo();
IScoreDAO scoreDAO = new ScoreDAO();

GameController controller = new GameController(ui, game, scoreDAO);
controller.Run();


