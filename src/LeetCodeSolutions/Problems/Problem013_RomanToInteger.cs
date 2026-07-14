using LeetCodeSolutions.Problems.Interfaces;

namespace LeetCodeSolutions.Problems;

/// <summary>
///     Problem: Roman to Integer
///     https://leetcode.com/problems/roman-to-integer/
///
///     Approach:
///     Use a dictionary to map Roman numeral characters
///     to their integer values.
///
///     Iterate through the string from left to right:
///     - If the current numeral is smaller than the next numeral,
///       subtract the current value from the next value
///       and skip the next character.
///     - Otherwise, add the current numeral value directly.
///
///     This handles special subtraction cases such as:
///     IV = 4, IX = 9, XL = 40, CM = 900.
///
///     Time Complexity: O(n)
///     Space Complexity: O(1)
///
///     Note:
///     The dictionary size is constant because Roman numerals
///     only contain seven fixed symbols.
/// </summary>
public class Problem013_RomanToInteger : ILeetCodeProblem
{
    public void SolveProblem()
    {
        var input = "MCMXCIV";
        var result = RomanToInt(input);

        Console.WriteLine($"Input: {input}");
        Console.WriteLine($"Output: : {result}");
    }

    public int RomanToInt(string romanNumber)
    {
        var romanDictionary = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        var result = 0;

        for (int i = 0; i < romanNumber.Length; i++)
        {
            if (i < romanNumber.Length - 1 && romanDictionary[romanNumber[i]] <
                romanDictionary[romanNumber[i + 1]])
            {
                result += romanDictionary[romanNumber[i + 1]] - romanDictionary[romanNumber[i]];
                i++;
            }
            else
            {
                result += romanDictionary[romanNumber[i]];
            }
        }

        return result;
    }
}