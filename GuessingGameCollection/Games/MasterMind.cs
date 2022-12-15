using System.Text;

namespace GuessingGameCollection.Games;

public class MasterMind : IGame
{
    private string goal;

    public string EvaluateGuess(string guess)
    {
        string lengthAdjustedGuess = EnsureGuessLengthMatchesGoalLength(guess);
        bool[] digitIsMatched = new bool[lengthAdjustedGuess.Length];

        int numberOfExactMatches = GetExactMatches(lengthAdjustedGuess, digitIsMatched);
        int numberOfMatchesInWrongPosition = GetMatchesInWrongPosition(lengthAdjustedGuess, digitIsMatched);

        return UpdateCurrentResult(numberOfExactMatches, numberOfMatchesInWrongPosition);
    }

    private string EnsureGuessLengthMatchesGoalLength(string guess)
    {
        if (guess.Length > goal.Length)
        {
            return guess.Substring(0, goal.Length);
        }

        while (guess.Length < goal.Length)
        {
            guess += " ";
        }

        return guess;
    }

    private int GetExactMatches(string guess, bool[] digitIsMatched)
    {
        int matches = 0;
        for (int i = 0; i < goal.Length; i++)
        {
            if (goal[i] == guess[i])
            {
                matches++;
                digitIsMatched[i] = true;
            }
        }

        return matches;
    }

    private int GetMatchesInWrongPosition(string guess, bool[] digitIsMatched)
    {
        int wrongPositionMatches = 0;

        for (int i = 0; i < goal.Length; i++)
        {
            for (int j = 0; j < goal.Length; j++)
            {
                bool equalAndNotMatched = goal[i] == guess[j] && digitIsMatched[j] == false;

                if (equalAndNotMatched)
                {
                    digitIsMatched[j] = true;
                    wrongPositionMatches++;
                    break;
                }
            }
        }

        return wrongPositionMatches;
    }


    private string UpdateCurrentResult(int numberOfExactMatches, int numberOfMatchesInWrongPosition)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append('B', numberOfExactMatches);
        stringBuilder.Append(',');
        stringBuilder.Append('C', numberOfMatchesInWrongPosition);
        return stringBuilder.ToString();
    }

    public string GenerateGameGoal()
    {
        int maxValue = 5;
        int[] digits = GenerateFourRandomDigits(maxValue);
        return BuildStringFromDigits(digits);
    }

    private static int[] GenerateFourRandomDigits(int maxValue)
    {
        int numberOfDigits = 4;

        int[] digits = new int[numberOfDigits];
        Random random = new();

        for (int i = 0; i < numberOfDigits; i++)
        {
            digits[i] = random.Next(maxValue + 1);
        }

        return digits;
    }

    private static string BuildStringFromDigits(int[] digits)
    {
        StringBuilder stringBuilder = new();
        foreach (var digit in digits)
        {
            stringBuilder.Append(digit);
        }

        return stringBuilder.ToString();
    }
}