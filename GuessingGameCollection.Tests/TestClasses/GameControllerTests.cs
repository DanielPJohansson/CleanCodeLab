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
    List<string> inputs;
    List<string> results;
    List<string> expectedOutput;

    [TestMethod]
    public void GameControllerRun_GivesCorrectConsoleOutput()
    {
        CreateMockIO();

        IGame game = new GuessingGame(new MockGoalGenerator() { Goal = "1234" });

        IGamesManager mockMenu = new MockMenuOptions(game);
        IUI mockUi = new MockUi()
        {
            MockUserInput = inputs,
        };
        IScoreDAO mockScoreDAO = new MockScoreDAO();

        var controller = new GameController(mockUi, mockMenu, mockScoreDAO);

        controller.Run();

        List<string> output = (mockUi as MockUi)!.MockPrintToConsole;

        CollectionAssert.AreEqual(expectedOutput, output);
    }

    private void CreateMockIO()
    {
        inputs = new() { "Daniel", "1", "5678", "1256", "1243", "1234", "n" };
        expectedOutput = new() {
            "Enter your user name:\n",
            "Select game to play:\n",
            "0. Moo",
            "New game:\n",
            ",\n",
            "BB,\n",
            "BB,CC\n",
            "BBBB,\n",
            "Player   games average",
            "Daniel       1     4.00",
            "Correct, it took 4 guesses",
            "Continue?" };
    }
}