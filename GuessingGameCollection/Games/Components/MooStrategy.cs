namespace GuessingGameCollection.Games.Components;

public class MooStrategy : IGameStrategy
{
    public string Name { get; } = "Moo";

    public string GenerateRandomGoal()
    {
        int[] digits = GetFourUniqueAndRandomDigits();

        return string.Join("", digits);
    }

    private static int[] GetFourUniqueAndRandomDigits()
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
}