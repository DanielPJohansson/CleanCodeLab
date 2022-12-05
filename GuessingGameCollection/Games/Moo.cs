using System.Text;

namespace GuessingGameCollection.Games;

/// <summary>
/// Description of game rules
/// </summary>
public class Moo : IGame
{
    public string GenerateGameGoal()
    {
        Random randomGenerator = new Random();
        // StringBuilder stringBuilder = new();
        string goal = string.Empty;

        for (int i = 0; i < 4; i++)
        {
            int random = randomGenerator.Next(10);
            string randomDigit = "" + random;

            while (goal.Contains(randomDigit))
            {
                random = randomGenerator.Next(10);
                randomDigit = "" + random;
            }

            goal = goal + randomDigit;
        }

        return goal;
    }

    public string GetResultOfGuess(string goal, string guess)
    {
        int numberOfCorrectDigitWrongPosition = 0, numberOfCorrectDigitAndPosition = 0;

        guess += "    ";     // if player entered less than 4 chars
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (goal[i] == guess[j])
                {
                    if (i == j)
                    {
                        numberOfCorrectDigitAndPosition++;
                    }
                    else
                    {
                        numberOfCorrectDigitWrongPosition++;
                    }
                }
            }
        }
        return "BBBB".Substring(0, numberOfCorrectDigitAndPosition) + "," + "CCCC".Substring(0, numberOfCorrectDigitWrongPosition);
    }
}