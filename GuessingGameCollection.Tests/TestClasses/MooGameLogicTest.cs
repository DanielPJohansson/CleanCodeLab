using GuessingGameCollection.Games.Components;
using GuessingGameCollection.Games;
using GuessingGameCollection.Tests.MockClasses;

namespace GuessingGameCollection.Tests;

[TestClass()]
public class MooGameLogicTest
{
    private readonly GuessingGame _game;


    public MooGameLogicTest()
    {

        _game = new GuessingGame(new MooStrategy());
    }

    [TestMethod()]
    public void GenerateGameGoal_ReturnsOnlyDigits()
    {
        _game.GenerateNewGameGoal();

        string goal = _game.CurrentGoal;

        foreach (var character in goal)
        {
            Assert.IsTrue(char.IsDigit(character));
        }
    }

    [TestMethod()]
    public void GenerateGameGoal_ReturnsStringOfLengthFour()
    {
        _game.GenerateNewGameGoal();

        string goal = _game.CurrentGoal;

        Assert.AreEqual(goal.Length, 4);
    }

    [TestMethod()]
    [DataRow("1234", "1243", "BB,CC")]
    [DataRow("1234", "1155", "B,")]
    [DataRow("1234", "5511", ",C")]
    [DataRow("1234", "7896", ",")]
    [DataRow("1234", "4321", ",CCCC")]
    [DataRow("1234", "1234", "BBBB,")]
    [DataRow("1234", "", ",")]
    [DataRow("1234", "987512", ",")]
    [DataRow("1234", "jhg", ",")]
    public void GetResultOfGuess_ReturnsCorrectResult(string goal, string guessInput, string expected)
    {
        MockGoalGenerator strategy = new MockGoalGenerator() { Goal = goal };

        _game.SetStrategy(strategy);
        _game.GenerateNewGameGoal();

        string result = _game.EvaluateGuess(guessInput);


        Assert.AreEqual(expected, result);
    }
}