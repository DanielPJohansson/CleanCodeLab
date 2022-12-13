using System.Text;

namespace GuessingGameCollection.Games;

public class Moo : IGame
{
    public string Goal { get; set; } = string.Empty;
    public string CurrentResult { get; private set; } = string.Empty;
    public bool GuessIsWrong { get; private set; } = true;

    public void GenerateGameGoal()
    {
        List<int> digits = GetUniqueRandomDigits(4, 9);
        Goal = BuildStringFromDigits(digits);
    }

    private List<int> GetUniqueRandomDigits(int numberOfDigits, int maxValue)
    {
        List<int> digits = new List<int>();

        Random randomGenerator = new Random();

        for (int i = 0; i < numberOfDigits; i++)
        {
            int randomDigit = randomGenerator.Next(maxValue + 1);

            while (digits.Contains(randomDigit))
            {
                randomDigit = randomGenerator.Next(maxValue + 1);
            }

            digits.Add(randomDigit);
        }

        return digits;
    }

    private string BuildStringFromDigits(List<int> digits)
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
}