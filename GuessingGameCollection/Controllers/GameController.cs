using GuessingGameCollection.Data;
using GuessingGameCollection.Games;
using GuessingGameCollection.UI;

namespace GuessingGameCollection.Controllers;
public class GameController
{
    public bool IsPractice { get; set; } = false;
    private IGame? _game;
    private readonly IUI _ui;
    private readonly IScoreDAO _scoreDAO;
    private readonly IGamesManager _gamesManager;

    public GameController(IUI ui, IGamesManager gamesManager, IScoreDAO scoreDAO)
    {
        _gamesManager = gamesManager;
        _ui = ui;
        _scoreDAO = scoreDAO;
    }

    public void Run()
    {
        string playerName = GetPlayerName();
        IGame selectedGame = OpenGameSelectMenu();

        do
        {
            int score = PlayNewGame(selectedGame);
            SaveScore(playerName, score);
            DisplayHighScores();
            DisplayScoreForCurrentGame(score);
        }
        while (QueryContinuePlaying());
    }

    private string GetPlayerName()
    {
        _ui.OutputString("Enter your user name:\n");
        return _ui.GetStringInput();
    }

    private IGame OpenGameSelectMenu()
    {
        _ui.OutputString("Select game to play:\n");
        ListAvailableGames();
        return SelectGame();
    }

    private void ListAvailableGames()
    {
        List<string> games = _gamesManager.GetAvailableGames();
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
            choice = (int)char.GetNumericValue(input[0]);

        } while (_gamesManager.IsValidIndex(choice) is false);

        return _gamesManager.GetGame(choice);
    }

    private int PlayNewGame(IGame selectedGame)
    {
        _game = selectedGame;
        string goal = _game.GenerateGameGoal();

        DisplayStartMessage();
        DisplayGoalIfPractice(goal);

        int numberOfGuesses = 0;

        string guess = _ui.GetStringInput();
        HandleGuess(guess, goal);
        numberOfGuesses++;

        while (guess != goal)
        {
            guess = _ui.GetStringInput();
            _ui.OutputString(guess + "\n");

            HandleGuess(guess, goal);
            numberOfGuesses++;
        }

        return numberOfGuesses;
    }

    private void DisplayStartMessage()
    {
        _ui.OutputString("New game:\n");
    }

    private void DisplayGoalIfPractice(string goal)
    {
        if (IsPractice)
        {
            _ui.OutputString("For practice, number is: " + goal + "\n");
        }
    }

    private void HandleGuess(string guess, string goal)
    {
        string result = _game.GetResultOfGuess(guess, goal);
        _ui.OutputString(result + "\n");
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

    private void DisplayScoreForCurrentGame(int score)
    {
        _ui.OutputString("Correct, it took " + score + " guesses");
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