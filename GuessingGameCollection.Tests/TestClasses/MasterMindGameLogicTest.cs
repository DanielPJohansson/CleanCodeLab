using GuessingGameCollection.Games;

namespace GuessingGameCollection.Tests.TestClasses;

[TestClass]
public class MasterMindGameLogicTest
{
    private readonly MasterMind _masterMind;
    public MasterMindGameLogicTest()
    {
        _masterMind = new MasterMind();
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

        _masterMind.Goal = goal;

        _masterMind.EvaluateGuess(guessInput);

        string result = _masterMind.CurrentResult;

        Assert.AreEqual(expected, result);
    }

}