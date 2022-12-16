namespace GuessingGameCollection.Games.Components;
public class MasterMindStrategy : IGameStrategy
{
    public string Name { get; } = "MasterMind";

    public string GenerateRandomGoal()
    {
        int[] digits = GenerateFourRandomDigitsBetweenZeroAndFive();

        return string.Join("", digits);
    }

    private static int[] GenerateFourRandomDigitsBetweenZeroAndFive()
    {
        int numberOfDigits = 8;
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