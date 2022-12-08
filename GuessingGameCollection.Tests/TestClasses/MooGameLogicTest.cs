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
    public void GenerateGameGoal_ReturnsOnlyDigits()
    {
        _game.GenerateGameGoal();
        string result = _game.Goal;

        foreach (var character in result)
        {
            Assert.IsTrue(char.IsDigit(character));
        }
    }

    [TestMethod()]
    public void GenerateGameGoal_ReturnsStringOfLengthFour()
    {
        _game.GenerateGameGoal();
        string result = _game.Goal;

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
    [DataRow("1234", "987512", ",")]
    public void GetResultOfGuess_ReturnsCorrectResult(string goal, string guessInput, string expected)
    {
        _game.Goal = goal;

        _game.EvaluateGuess(guessInput);

        string result = _game.CurrentResult;

        Assert.AreEqual(expected, result);
    }
}