using GuessingGameCollection.Data;

namespace GuessingGameCollection.Tests;

[TestClass]
public class ScoreDAOTests
{
    private string path = string.Empty;

    [TestInitialize]
    public void Initialize()
    {
        path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "test.txt");
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }


    [TestMethod]
    public void PostScore()
    {
        ScoreDAO scoreDAO = new ScoreDAO(path);

        scoreDAO.PostScore(new PlayerResult("Daniel", 8, "Moo"));
        scoreDAO.PostScore(new PlayerResult("Åsa", 8, "Moo"));
        scoreDAO.PostScore(new PlayerResult("Daniel", 10, "Moo"));
        scoreDAO.PostScore(new PlayerResult("Erik", 6, "Moo"));
        scoreDAO.PostScore(new PlayerResult("Erik", 7, "Moo"));
        scoreDAO.PostScore(new PlayerResult("Daniel", 12, "Moo"));
        scoreDAO.PostScore(new PlayerResult("Daniel", 8, "MasterMind"));
        scoreDAO.PostScore(new PlayerResult("Daniel", 7, "MasterMind"));
        scoreDAO.PostScore(new PlayerResult("Ali", 8, "Moo"));
        scoreDAO.PostScore(new PlayerResult("Ali", 9, "Moo"));
        scoreDAO.PostScore(new PlayerResult("Ali", 7, "MasterMind"));
        scoreDAO.PostScore(new PlayerResult("Ali", 5, "MasterMind"));
        scoreDAO.PostScore(new PlayerResult("Daniel", 12, "Moo"));

        List<string> expected = new List<string>() {
            string.Format("{0,-9}{1,5:D}{2,9:F2}", "Erik", 2, 6.50),
            string.Format("{0,-9}{1,5:D}{2,9:F2}", "Åsa", 1, 8.00),
            string.Format("{0,-9}{1,5:D}{2,9:F2}", "Ali", 2, 8.50),
            string.Format("{0,-9}{1,5:D}{2,9:F2}", "Daniel", 4, 10.50)
        };

        List<PlayerResult> retrievedData = scoreDAO.GetHighScores("Moo");

        List<string> actual = new();

        foreach (var player in retrievedData)
        {
            actual.Add(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.GetAverageScore()));
        }

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestCleanup]
    public void TestCleanup()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}