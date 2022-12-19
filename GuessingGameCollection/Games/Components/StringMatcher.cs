using GuessingGameCollection.Helpers;

namespace GuessingGameCollection.Games.Components;

public class StringMatcher
{
    private readonly string _input;
    private readonly string _target;
    private bool[] isMatchedInInput;
    private bool[] isMatchedInTarget;
    private int length;

    public StringMatcher(string input, string target)
    {
        _target = target;
        _input = input.SetToLengthOf(this._target);
        length = this._input.Length;
        isMatchedInInput = new bool[length];
        isMatchedInTarget = new bool[length];
    }

    public int GetNumberOfExactMatches()
    {
        int exactMatches = 0;
        for (int i = 0; i < length; i++)
        {
            if (EqualAtSameIndex(i))
            {
                exactMatches++;
                isMatchedInInput[i] = true;
                isMatchedInTarget[i] = true;
            }
        }

        return exactMatches;
    }

    public int GetNumberOfMatchesInWrongPosition()
    {
        int wrongPositionMatches = 0;

        for (int indexInTarget = 0; indexInTarget < length; indexInTarget++)
        {
            for (int indexInInput = 0; indexInInput < length; indexInInput++)
            {
                if (EqualAtSameIndex(indexInInput))
                {
                    continue;
                }

                if (EqualAndNotMatched(indexInTarget, indexInInput))
                {
                    isMatchedInInput[indexInInput] = true;
                    isMatchedInTarget[indexInTarget] = true;
                    wrongPositionMatches++;
                    break;
                }
            }
        }

        return wrongPositionMatches;
    }

    private bool EqualAndNotMatched(int indexInTarget, int indexInInput)
    {
        return EqualAtIndices(indexInInput, indexInTarget)
        && isMatchedInInput[indexInInput] == false
        && isMatchedInTarget[indexInTarget] == false;
    }

    private bool EqualAtSameIndex(int index)
    {
        return _input[index] == _target[index];
    }

    private bool EqualAtIndices(int indexInInput, int indexInTarget)
    {
        return _input[indexInInput] == _target[indexInTarget];
    }
}