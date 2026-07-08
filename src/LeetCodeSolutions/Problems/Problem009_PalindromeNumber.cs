using System.Text;
using LeetCodeSolutions.Problems.Interfaces;

namespace LeetCodeSolutions.Problems;

/// <summary>
///     Problem: Palindrome Number
///     https://leetcode.com/problems/palindrome-number/
///
///     Approach:
///     Convert the integer to a string,
///     reverse it manually using StringBuilder,
///     and compare the reversed value with the original.
///
///     Time Complexity: O(logX)
///     Space Complexity: O(logX)
///
///     Note:
///     An optimized solution can avoid string allocation
///     by reversing half of the number mathematically.
/// </summary>
public class Problem009_PalindromeNumber : ILeetCodeProblem
{
    public void SolveProblem()
    {
        var input = 121;
        var result = IsPalindrome(input);

        Console.WriteLine($"Input: {input}");
        Console.WriteLine($"Output: : {result}");
    }

    public bool IsPalindrome(int x)
    {
        var stringInput = x.ToString();
        var reverseInput = new StringBuilder();
        var result = false;

        for (int i = 1; i <= stringInput.Length; i++)
        {
            reverseInput.Append(stringInput[stringInput.Length - i]);
        }

        if (stringInput == reverseInput.ToString())
            result = true;

        return result;
    }
}