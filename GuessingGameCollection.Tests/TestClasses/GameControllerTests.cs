using GuessingGameCollection.Controllers;
using GuessingGameCollection.Data;
using GuessingGameCollection.Games;
using GuessingGameCollection.Tests.MockClasses;
using GuessingGameCollection.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessingGameCollection.Tests;

[TestClass]
public class GameControllerTests
{

    [TestMethod]
    public void GameControllerRun_GivesCorrectConsoleOutput()
    {
        List<string> inputs = new() { "Daniel", "5678", "1256", "1243", "1234", "n" };
        List<string> results = new() { ",", "BB,", "BB,CC", "BBBB," };
        List<string> expectedOutput = new() {
            "Enter your user name:\n",
            "New game:\n",
            ",\n",
            "1256\n",
            "BB,\n",
            "1243\n",
            "BB,CC\n",
            "1234\n",
            "BBBB,\n",
            "Player   games average",
            "Daniel       1     4.00",
            "Correct, it took 4 guesses",
            "Continue?" };

        IGame mockGame = new MockGame()
        {
            Results = results
        };
        IUI mockUi = new MockUi()
        {
            MockUserInput = inputs,
        };
        IScoreDAO mockScoreDAO = new MockScoreDAO();

        var controller = new GameController(mockUi, mockGame, mockScoreDAO);

        controller.Run();

        List<string> output = (mockUi as MockUi)!.MockPrintToConsole;

        CollectionAssert.AreEqual(expectedOutput, output);
    }

}