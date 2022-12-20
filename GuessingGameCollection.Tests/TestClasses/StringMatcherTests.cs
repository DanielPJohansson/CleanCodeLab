using GuessingGameCollection.Games.Components;

namespace GuessingGameCollection.Tests.TestClasses;
[TestClass]
public class StringMatcherTests
{
    [TestMethod]
    [DataRow(0, "boll", "1234")]
    [DataRow(1, "1", "1234")]
    [DataRow(0, "  1", "1234")]
    [DataRow(4, "1234", "1234")]
    [DataRow(4, "1234boll", "1234")]
    public void StringMatcher_GivesCorrectNumberOfExactMatches(int expected, string guess, string goal)
    {
        StringMatcher matcher = new StringMatcher(guess, goal);
        int exactMatches = matcher.GetNumberOfExactMatches();

        Assert.AreEqual(expected, exactMatches);
    }

    [TestMethod]
    [DataRow(0, "boll", "1234")]
    [DataRow(0, "1", "1234")]
    [DataRow(1, "  1", "1234")]
    [DataRow(0, "1234", "1234")]
    [DataRow(4, "4321", "1234")]
    public void StringMatcher_GivesCorrectNumberOfMatchesInWrongPosition(int expected, string guess, string goal)
    {
        StringMatcher matcher = new StringMatcher(guess, goal);
        int matchesInWrongPosition = matcher.GetNumberOfMatchesInWrongPosition();

        Assert.AreEqual(expected, matchesInWrongPosition);
    }
}