using System.Text;

namespace GuessingGameCollection.Games;

/// <summary>
/// Description of game rules
/// </summary>
public class Moo : IGame
{
    public string Goal { get; set; } = string.Empty;
    public string CurrentResult { get; set; } = string.Empty;
    public bool GuessIsCorrect { get; set; } = false;

    public void GenerateGameGoal()
    {
        List<int> digits = GetUniqueRandomDigits(4, 9);
        Goal = BuildStringFromDigits(digits);
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
            GuessIsCorrect = true;
        }

        UpdateCurrentResult(numberOfCorrectDigitWrongPosition, numberOfCorrectDigitAndPosition);
    }

    private void UpdateCurrentResult(int numberOfCorrectDigitWrongPosition, int numberOfCorrectDigitAndPosition)
    {
        CurrentResult = "BBBB".Substring(0, numberOfCorrectDigitAndPosition) + "," + "CCCC".Substring(0, numberOfCorrectDigitWrongPosition);
    }
}