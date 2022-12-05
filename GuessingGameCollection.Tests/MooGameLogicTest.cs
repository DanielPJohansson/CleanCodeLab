using GuessingGameCollection.Games;

namespace GuessingGameCollection.Tests;

[TestClass()]
public class MooGameLogicTest
{
    private readonly Moo _game;


    public MooGameLogicTest()
    {
        _game = new Moo();
    }

    [TestMethod()]
    public void GenerateGameGoal_ReturnsNumberBetween0And9999()
    {
        var result = _game.GenerateGameGoal();

        int parsedResult;

        Assert.IsTrue(Int32.TryParse(result, out parsedResult) && parsedResult >= 0 && parsedResult <= 9999);
    }

    [TestMethod()]
    public void GenerateGameGoal_ReturnsStringOfLength4()
    {
        var result = _game.GenerateGameGoal();

        Assert.AreEqual(result.Length, 4);
    }

    [TestMethod()]
    [DataRow("1234", "1243", "BB,CC")]
    [DataRow("1234", "7896", ",")]
    [DataRow("1234", "jhg", ",")]
    [DataRow("1234", "4321", ",CCCC")]
    [DataRow("1234", "1234", "BBBB,")]
    [DataRow("1234", "", ",")]
    [DataRow("1234", "987556", ",")]
    public void GetResultOfGuess_ReturnsCorrectResult(string goalInput, string guessInput, string expected)
    {
        var result = _game.GetResultOfGuess(goalInput, guessInput);

        Assert.AreEqual(expected, result);
    }
}