using GuessingGameCollection.Data;
using GuessingGameCollection.Games;
using GuessingGameCollection.UI;

namespace GuessingGameCollection.Controllers;
public class GameController
{
    public bool IsPractice { get; set; } = false;
    private readonly IGame _game;
    private readonly IUI _ui;
    private readonly IScoreDAO _scoreDAO;


    public GameController(IUI ui, IGame game, IScoreDAO scoreDAO)
    {
        _ui = ui;
        _game = game;
        _scoreDAO = scoreDAO;
    }

    public void Run()
    {
        string playerName = GetPlayerName();
        SelectGame();

        do
        {
            int score = PlayNewGame();
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
    private void SelectGame()
    {
        throw new NotImplementedException();
    }

    private int PlayNewGame()
    {
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

    private void DisplayGoalIfPractice(string answer)
    {
        if (IsPractice)
        {
            _ui.OutputString("For practice, number is: " + answer + "\n");
        }
    }

    private void HandleGuess(string guess, string answer)
    {
        string result = _game.GetResultOfGuess(guess, answer);
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