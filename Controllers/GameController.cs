using CleanCodeLab.Data;
using CleanCodeLab.Games;
using CleanCodeLab.UI;
using CleanCodeLab.UserData;

namespace CleanCodeLab.Controllers;
public class GameController
{
    private readonly IGame _game;
    private readonly IUI _ui;

    private ScoreDAO scoreDAO;

    public GameController(IUI ui, IGame game)
    {
        _ui = ui;
        _game = game;

        scoreDAO = new();
    }

    public void Run()
    {
        bool playOn = true;
        _ui.OutputString("Enter your user name:\n");
        string name = _ui.GetStringInput();

        while (playOn)
        {
            string goal = _game.MakeGoal();

            _ui.OutputString("New game:\n");
            //comment out or remove next line to play real games!
            _ui.OutputString("For practice, number is: " + goal + "\n");

            int numberOfGuesses = 0;
            string guess = string.Empty;
            string bbcc = string.Empty;

            while (bbcc != "BBBB,")
            {
                numberOfGuesses++;
                guess = _ui.GetStringInput();
                _ui.OutputString(guess + "\n");
                bbcc = _game.CheckBC(goal, guess);
                _ui.OutputString(bbcc + "\n");
            }

            scoreDAO.PostScore(name, numberOfGuesses);
            var highScores = scoreDAO.GetHighScores();
            _ui.OutputString("Player   games average");
            foreach (PlayerData player in highScores)
            {
                _ui.OutputString(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.Average()));
            }
            _ui.OutputString("Correct, it took " + numberOfGuesses + " guesses\nContinue?");

            string answer = _ui.GetStringInput();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                playOn = false;
            }
        }
    }
}