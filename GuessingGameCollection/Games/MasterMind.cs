using System.Text;

namespace GuessingGameCollection.Games;

public class MasterMind : IGame
{
    public string Goal { get; set; } = string.Empty;
    public string CurrentResult { get; private set; } = string.Empty;
    public bool GuessIsWrong { get; private set; } = true;

    public void EvaluateGuess(string guess)
    {
        string lengthAdjustedGuess = EnsureGuessLengthMatchesGoalLength(guess);
        bool[] digitInGuessIsMatched = new bool[lengthAdjustedGuess.Length];

        int numberOfExactMatches = GetExactMatches(lengthAdjustedGuess, digitInGuessIsMatched);
        int numberOfMatchesInWrongPosition = GetWrongPositionMatches(lengthAdjustedGuess, digitInGuessIsMatched);

        if (numberOfExactMatches == Goal.Length)
        {
            GuessIsWrong = false;
        }

        UpdateCurrentResult(numberOfExactMatches, numberOfMatchesInWrongPosition);
    }

    private string EnsureGuessLengthMatchesGoalLength(string guess)
    {
        if (guess.Length > Goal.Length)
        {
            return guess.Substring(0, Goal.Length);
        }

        while (guess.Length < Goal.Length)
        {
            guess += " ";
        }

        return guess;
    }

    private int GetExactMatches(string guess, bool[] digitInGuessIsMatched)
    {
        int matches = 0;
        for (int i = 0; i < Goal.Length; i++)
        {
            if (Goal[i] == guess[i])
            {
                matches++;
                digitInGuessIsMatched[i] = true;
            }
        }

        return matches;
    }

    private int GetWrongPositionMatches(string guess, bool[] digitInGuessIsMatched)
    {
        int wrongPositionMatches = 0;

        for (int i = 0; i < Goal.Length; i++)
        {
            for (int j = 0; j < Goal.Length; j++)
            {
                bool equalAndNotMatched = Goal[i] == guess[j] && digitInGuessIsMatched[j] == false;

                if (equalAndNotMatched)
                {
                    digitInGuessIsMatched[j] = true;
                    wrongPositionMatches++;
                    break;
                }
            }
        }

        return wrongPositionMatches;
    }


    private void UpdateCurrentResult(int numberOfExactMatches, int numberOfMatchesInWrongPosition)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append('B', numberOfExactMatches);
        stringBuilder.Append(',');
        stringBuilder.Append('C', numberOfMatchesInWrongPosition);
        CurrentResult = stringBuilder.ToString();
    }

    public void GenerateGameGoal()
    {
        int maxValue = 5;
        int[] digits = GenerateFourRandomDigits(maxValue);
        Goal = BuildStringFromDigits(digits);
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

    public void Reset()
    {
        GuessIsWrong = true;
    }
}