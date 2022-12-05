using GuessingGameCollection.Data;
using GuessingGameCollection.Games;
using GuessingGameCollection.UI;
using GuessingGameCollection.UserData;

namespace GuessingGameCollection.Controllers;
public class GameController
{
    private readonly IGame _game;
    private readonly IUI _ui;
    private readonly IScoreDAO _scoreDAO;
    private string currentPlayer = string.Empty;
    private int numberOfGuessesInCurrentGame;

    public GameController(IUI ui, IGame game, IScoreDAO scoreDAO)
    {
        _ui = ui;
        _game = game;
        _scoreDAO = scoreDAO;
    }

    public void Run()
    {
        bool playOn = true;
        _ui.OutputString("Enter your user name:\n");
        currentPlayer = _ui.GetStringInput();

        while (playOn)
        {
            ResetNumberOfGuesses();
            RunNewGame();
            PrintHighScores();
            PrintResultForCurrentGame();

            playOn = NewMethod(playOn);
        }
    }

    private bool NewMethod(bool playOn)
    {
        _ui.OutputString("Continue?");
        string answer = _ui.GetStringInput();
        if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
        {
            playOn = false;
        }

        return playOn;
    }

    private void PrintResultForCurrentGame()
    {
        _ui.OutputString("Correct, it took " + numberOfGuessesInCurrentGame + " guesses");
    }

    private void ResetNumberOfGuesses()
    {
        numberOfGuessesInCurrentGame = 0;
    }

    private void RunNewGame()
    {
        _game.GenerateGameGoal();

        _ui.OutputString("New game:\n");
        //comment out or remove next line to play real games!
        _ui.OutputString("For practice, number is: " + _game.Goal + "\n");

        int numberOfGuesses = 0;
        string guess = string.Empty;

        while (_game.GuessIsCorrect is false)
        {
            numberOfGuessesInCurrentGame++;
            guess = _ui.GetStringInput();
            _ui.OutputString(guess + "\n");
            _game.EvaluateGuess(guess);
            _ui.OutputString(_game.CurrentResult + "\n");
        }

        _scoreDAO.PostScore(currentPlayer, numberOfGuesses);
    }

    private void PrintHighScores()
    {
        var highScores = _scoreDAO.GetHighScores();
        _ui.OutputString("Player   games average");

        foreach (PlayerData player in highScores)
        {
            _ui.OutputString(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.GetAverageScore()));
        }
    }
}