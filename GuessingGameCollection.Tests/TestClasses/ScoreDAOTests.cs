using GuessingGameCollection.Data;
using GuessingGameCollection.UserData;

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

        scoreDAO.PostScore("Daniel", 8);
        scoreDAO.PostScore("Åsa", 8);
        scoreDAO.PostScore("Daniel", 10);
        scoreDAO.PostScore("Erik", 6);
        scoreDAO.PostScore("Erik", 7);
        scoreDAO.PostScore("Daniel", 12);
        scoreDAO.PostScore("Ali", 8);
        scoreDAO.PostScore("Ali", 9);
        scoreDAO.PostScore("Daniel", 12);

        List<PlayerResult> expected = new List<PlayerResult>() {
            new PlayerResult("Erik", 6),
            new PlayerResult("Åsa", 8),
            new PlayerResult("Ali", 8),
            new PlayerResult("Daniel", 8)
        };
        expected[0].Update(7);
        expected[2].Update(9);
        expected[3].Update(10);
        expected[3].Update(12);
        expected[3].Update(12);


        List<PlayerResult> retrievedData = scoreDAO.GetHighScores();

        for (int i = 0; i < retrievedData.Count; i++)
        {
            Assert.AreEqual(expected[i].ToString(), retrievedData[i].ToString());
        }
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