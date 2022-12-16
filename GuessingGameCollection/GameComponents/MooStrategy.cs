using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameCollection.GameComponents
{
    public class MooStrategy : IGameStrategy
    {
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
}