namespace GuessingGameCollection.GameComponents;
public class MasterMind : IGameStrategy
{
    public string FormatResultForGameVariant(int numberOfExactMatches, int numberOfMatchesInWrongPosition)
    {
        throw new NotImplementedException();
    }

    public string GenerateRandomGoal()
    {
        int[] digits = GenerateFourRandomDigitsBetweenZeroAndFive();

        return string.Join("", digits);
    }

    private static int[] GenerateFourRandomDigitsBetweenZeroAndFive()
    {
        int numberOfDigits = 4;
        int maxValue = 6;

        int[] digits = new int[numberOfDigits];
        Random random = new();

        for (int i = 0; i < numberOfDigits; i++)
        {
            digits[i] = random.Next(maxValue);
        }

        return digits;
    }
}