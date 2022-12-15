using System.Text;

namespace GuessingGameCollection.Games;

public class Moo : IGame
{
    public string Goal { get; set; } = string.Empty;
    public string CurrentResult { get; private set; } = string.Empty;
    public bool GuessIsWrong { get; private set; } = true;

    public void GenerateGameGoal()
    {
        int[] digits = GetFourUniqueRandomDigits();
        Goal = BuildStringFromDigits(digits);
    }

    private int[] GetFourUniqueRandomDigits()
    {
        int numberOfDigits = 4;
        int maxValue = 10;

        int[] digits = new int[numberOfDigits];

        Random randomGenerator = new Random();

        for (int i = 0; i < numberOfDigits; i++)
        {
            int randomDigit = randomGenerator.Next(maxValue);

            while (digits.Contains(randomDigit))
            {
                randomDigit = randomGenerator.Next(maxValue);
            }

            digits[i] = randomDigit;
        }

        return digits;
    }

    private string BuildStringFromDigits(int[] digits)
    {
        StringBuilder stringBuilder = new();
        foreach (var digit in digits)
        {
            stringBuilder.Append(digit);
        }

        return stringBuilder.ToString();
    }

    public void EvaluateGuess(string guess)
    {
        int numberOfCorrectDigitWrongPosition = 0;
        int numberOfCorrectDigitAndPosition = 0;

        for (int i = 0; i < Goal.Length; i++)
        {
            for (int j = 0; j < Goal.Length && j < guess.Length; j++)
            {
                if (Goal[i] == guess[j])
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

        if (numberOfCorrectDigitAndPosition == Goal.Length)
        {
            GuessIsWrong = false;
        }

        UpdateCurrentResult(numberOfCorrectDigitWrongPosition, numberOfCorrectDigitAndPosition);
    }

    private void UpdateCurrentResult(int numberOfCorrectDigitWrongPosition, int numberOfCorrectDigitAndPosition)
    {
        CurrentResult = "BBBB".Substring(0, numberOfCorrectDigitAndPosition) + "," + "CCCC".Substring(0, numberOfCorrectDigitWrongPosition);
    }

    public void Reset()
    {
        GuessIsWrong = true;
    }
}