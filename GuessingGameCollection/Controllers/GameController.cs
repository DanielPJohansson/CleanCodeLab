using GuessingGameCollection.Data;
using GuessingGameCollection.Games;
using GuessingGameCollection.UI;
using GuessingGameCollection.UserData;

namespace GuessingGameCollection.Controllers;
public class GameController
{
    public bool IsPractice { get; set; } = false;
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
        GetNameFromUser();
        bool continuePlaying;

        do
        {
            RunNewGame();
            SaveScore();
            DisplayHighScores();
            DisplayScoreForCurrentGame();
            continuePlaying = QueryContinuePlaying();
        }
        while (continuePlaying);
    }

    private void GetNameFromUser()
    {
        _ui.OutputString("Enter your user name:\n");
        currentPlayer = _ui.GetStringInput();
    }

    private void RunNewGame()
    {
        ResetGame();
        _game.GenerateGameGoal();

        DisplayStartMessage();

        string guess = _ui.GetStringInput();
        HandleGuess(guess);

        while (_game.GuessIsWrong)
        {
            guess = _ui.GetStringInput();
            _ui.OutputString(guess + "\n");

            HandleGuess(guess);
        }
    }

    private void ResetGame()
    {
        numberOfGuessesInCurrentGame = 0;
        _game.Reset();
    }

    private void DisplayStartMessage()
    {
        _ui.OutputString("New game:\n");
        if (IsPractice) _ui.OutputString("For practice, number is: " + _game.Goal + "\n");
    }

    private void HandleGuess(string guess)
    {
        _game.EvaluateGuess(guess);
        _ui.OutputString(_game.CurrentResult + "\n");
        numberOfGuessesInCurrentGame++;
    }

    private void SaveScore()
    {
        _scoreDAO.PostScore(currentPlayer, numberOfGuessesInCurrentGame);
    }

    private void DisplayHighScores()
    {
        List<Player> highScores = _scoreDAO.GetHighScores();
        _ui.OutputString("Player   games average");

        foreach (Player player in highScores)
        {
            _ui.OutputString(player.ToString());
        }
    }

    private void DisplayScoreForCurrentGame()
    {
        _ui.OutputString("Correct, it took " + numberOfGuessesInCurrentGame + " guesses");
    }

    private bool QueryContinuePlaying()
    {
        _ui.OutputString("Continue?");
        string answer = _ui.GetStringInput();

        if (answer.StartsWith('n'))
        {
            return false;
        }

        return true;
    }
}