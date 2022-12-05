using GuessingGameCollection.Games;

namespace GuessingGameCollection.Tests;

[TestClass]
public class MooGameLogicTest
{
    private readonly Moo _game;


    public MooGameLogicTest()
    {
        _game = new Moo();
    }


    [TestMethod]
    public void TestMethod1()
    {
        var result = _game.GenerateGameGoal();

        Assert.IsNotNull(result);
    }

    [TestMethod]
    [DataRow()]
    public void TestMethod2()
    {
        // var result = _game.GetResultOfGuess();

        // Assert.IsNotNull(result);
    }
}