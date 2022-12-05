
using CleanCodeLab.Controllers;
using CleanCodeLab.Games;
using CleanCodeLab.UI;

IUI ui = new ConsoleIO();
IGame game = new Moo();
GameController controller = new GameController(ui, game);
controller.Run();


