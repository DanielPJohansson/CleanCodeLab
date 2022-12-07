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
    private int numberOfGuessesInCurrentGame = 0;

    public GameController(IUI ui, IGame game, IScoreDAO scoreDAO)
    {
        _ui = ui;
        _game = game;
        _scoreDAO = scoreDAO;
    }

    public void Run()
    {
        bool continuePlaying = true;
        _ui.OutputString("Enter your user name:\n");
        currentPlayer = _ui.GetStringInput();

        while (continuePlaying)
        {
            ResetNumberOfGuesses();
            RunNewGame();
            PrintHighScores();
            PrintResultForCurrentGame();

            continuePlaying = QueryContinuePlaying();
        }
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

        string guess = string.Empty;
        guess = _ui.GetStringInput();
        _game.EvaluateGuess(guess);
        _ui.OutputString(_game.CurrentResult + "\n");
        numberOfGuessesInCurrentGame++;

        while (_game.GuessIsCorrect is false)
        {
            guess = _ui.GetStringInput();
            _ui.OutputString(guess + "\n");

            _game.EvaluateGuess(guess);
            _ui.OutputString(_game.CurrentResult + "\n");
            numberOfGuessesInCurrentGame++;
        }

        _scoreDAO.PostScore(currentPlayer, numberOfGuessesInCurrentGame);
    }

    private void PrintHighScores()
    {
        var highScores = _scoreDAO.GetHighScores();
        _ui.OutputString("Player   games average");

        foreach (PlayerData player in highScores)
        {
            _ui.OutputString(player.ToString());
        }
    }
    private void PrintResultForCurrentGame()
    {
        _ui.OutputString("Correct, it took " + numberOfGuessesInCurrentGame + " guesses");
    }

    private bool QueryContinuePlaying()
    {
        _ui.OutputString("Continue?");
        string answer = _ui.GetStringInput();

        if (!string.IsNullOrEmpty(answer) && answer.StartsWith('n'))
        {
            return false;
        }

        return true;
    }


}