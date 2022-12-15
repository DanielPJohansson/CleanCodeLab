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

        scoreDAO.PostScore("Daniel", 8, "Moo");
        scoreDAO.PostScore("Åsa", 8, "Moo");
        scoreDAO.PostScore("Daniel", 10, "Moo");
        scoreDAO.PostScore("Erik", 6, "Moo");
        scoreDAO.PostScore("Erik", 7, "Moo");
        scoreDAO.PostScore("Daniel", 12, "Moo");
        scoreDAO.PostScore("Ali", 8, "Moo");
        scoreDAO.PostScore("Ali", 9, "Moo");
        scoreDAO.PostScore("Daniel", 12, "Moo");

        List<Player> expected = new List<Player>() {
            new Player("Erik", 6, "Moo"),
            new Player("Åsa", 8, "Moo"),
            new Player("Ali", 8, "Moo"),
            new Player("Daniel", 8, "Moo")
        };
        expected[0].Update(7);
        expected[2].Update(9);
        expected[3].Update(10);
        expected[3].Update(12);
        expected[3].Update(12);


        List<Player> retrievedData = scoreDAO.GetHighScores("Moo");

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