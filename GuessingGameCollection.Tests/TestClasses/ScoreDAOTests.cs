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

        List<Player> expected = new List<Player>() {
            new Player("Erik", 6),
            new Player("Åsa", 8),
            new Player("Ali", 8),
            new Player("Daniel", 8)
        };
        expected[0].Update(7);
        expected[2].Update(9);
        expected[3].Update(10);
        expected[3].Update(12);
        expected[3].Update(12);


        List<Player> retrievedData = scoreDAO.GetHighScores();

        CollectionAssert.AreEqual(expected, retrievedData);

        for (int i = 0; i < retrievedData.Count; i++)
        {
            Assert.AreEqual(expected[i].NumberOfGames, retrievedData[i].NumberOfGames);
            Assert.AreEqual(expected[i].GetAverageScore(), retrievedData[i].GetAverageScore());
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