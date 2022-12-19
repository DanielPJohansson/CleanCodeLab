using GuessingGameCollection.Data;
using GuessingGameCollection.Games;
using GuessingGameCollection.UI;

namespace GuessingGameCollection.Controllers;
public class GameController
{
    public bool IsPractice { get; set; } = false;
    private readonly IUI _ui;
    private readonly IScoreDAO _scoreDAO;
    private readonly IGamesManager _gameManager;
    private IGame _game;

    public GameController(IUI ui, IGamesManager gamesManager, IScoreDAO scoreDAO)
    {
        _gameManager = gamesManager;
        _game = gamesManager.GetGame(0);
        _ui = ui;
        _scoreDAO = scoreDAO;
    }

    public void Run()
    {
        string playerName = GetPlayerName();

        do
        {
            _game = SelectGameFromAvailable();
            int score = PlayNewGame();
            SaveScore(playerName, score);
            DisplayHighScores();
            DisplayScoreForCurrentGameRound(score);
        }
        while (ContinuePlaying());

        _ui.Exit();
    }

    private string GetPlayerName()
    {
        _ui.OutputString("Enter your user name:\n");
        return _ui.GetStringInput();
    }

    private IGame SelectGameFromAvailable()
    {
        _ui.OutputString("Select game to play:\n");
        ListAvailableGames();
        return SelectGame();
    }

    private void ListAvailableGames()
    {
        List<string> games = _gameManager.GetAvailableGames();
        foreach (var game in games)
        {
            _ui.OutputString(game);
        }
    }

    private IGame SelectGame()
    {
        int choice;
        do
        {
            string input = _ui.GetStringInput().Trim();
            choice = (int)char.GetNumericValue(input.First());

        } while (_gameManager.GameExists(choice) is false);

        return _gameManager.GetGame(choice);
    }

    private int PlayNewGame()
    {
        _game.GenerateNewGameGoal();

        DisplayStartMessage();
        DisplayIfPractice();

        int numberOfGuesses = 0;
        string result;

        do
        {
            result = HandleGuess();
            numberOfGuesses++;
        }
        while (_game.IsWinCondition(result) != true);

        return numberOfGuesses;
    }

    private string HandleGuess()
    {
        string guess = _ui.GetStringInput();
        string result = _game.EvaluateGuess(guess);
        _ui.OutputString(result + "\n");
        return result;
    }

    private void DisplayStartMessage()
    {
        _ui.OutputString("New game:\n");
    }

    private void DisplayIfPractice()
    {
        if (IsPractice)
        {
            _ui.OutputString("For practice, number is: " + _game.CurrentGoal + "\n");
        }
    }

    private void SaveScore(string playerName, int score)
    {
        PlayerResult result = new PlayerResult(playerName, score, _game.GetName());
        _scoreDAO.PostScore(result);
    }

    private void DisplayHighScores()
    {
        List<PlayerResult> highScores = _scoreDAO.GetHighScores(_game.GetName());
        _ui.OutputString("Player   games average");

        foreach (PlayerResult player in highScores)
        {
            _ui.OutputString(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.GetAverageScore()));
        }
    }

    private void DisplayScoreForCurrentGameRound(int score)
    {
        _ui.OutputString("Correct, it took " + score + " guesses");
    }

    private bool ContinuePlaying()
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