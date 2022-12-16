namespace GuessingGameCollection.Helpers;

public static class StringExtensions
{
    public static string SetToLengthOf(this string input, string target)
    {
        if (input.Length > target.Length)
        {
            return input.Substring(0, target.Length);
        }

        while (input.Length < target.Length)
        {
            input += " ";
        }

        return input;
    }
}