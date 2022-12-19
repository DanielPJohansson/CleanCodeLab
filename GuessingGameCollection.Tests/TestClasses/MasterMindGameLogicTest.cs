using GuessingGameCollection.Games;
using GuessingGameCollection.Games.Components;
using GuessingGameCollection.Tests.MockClasses;

namespace GuessingGameCollection.Tests.TestClasses;

[TestClass]
public class MasterMindGameLogicTest
{
    private readonly GuessingGame _game;
    public MasterMindGameLogicTest()
    {
        IGameStrategy mastermind = new MasterMindStrategy();
        _game = new GuessingGame(mastermind);
    }

    [TestMethod]
    [DataRow("1154", "11", "BB,")]
    [DataRow("1154", "01231154", "B,")]
    [DataRow("1154", "0123", "B,")]
    [DataRow("1154", "0513", ",CC")]
    [DataRow("1154", "0051", "B,C")]
    [DataRow("1154", "5411", ",CCCC")]
    [DataRow("1154", "1154", "BBBB,")]
    [DataRow("1154", "", ",")]
    [DataRow("1154", "abcd", ",")]
    public void GetResultOfGuess_ReturnsCorrectResult(string goal, string guessInput, string expected)
    {
        MockGoalGenerator strategy = new MockGoalGenerator() { Goal = goal };

        _game.SetStrategy(strategy);
        _game.GenerateNewGameGoal();

        string result = _game.EvaluateGuess(guessInput);

        Assert.AreEqual(expected, result);
    }

}