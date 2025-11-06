using LeetCodeSolutions.Problems.Interfaces;

namespace LeetCodeSolutions.Problems;

/// <summary>
/// Problem 3: Longest Substring Without Repeating Characters.
/// https://leetcode.com/problems/longest-substring-without-repeating-characters/
/// Approach:
/// - Iterates through each character as a potential starting point (i).
/// - For each start index, expands a substring using a HashSet char
///   to ensure all characters are unique.
/// - Stops expanding when a duplicate character is found.
/// - Tracks and updates the maximum substring length found so far.
/// Complexity:
/// - Time Complexity: O(n²) — each pair of characters is compared at most once.
/// - Space Complexity: O(k) — where k is the number of unique characters in the current substring.
/// </summary>
public class Problem003_LengthOfLongestSubstring : ILeetCodeProblem
{
    public void SolveProblem()
    {
        var s = "c";
        var result = LengthOfLongestSubstring(s);

        Console.WriteLine($"Input: {s}");
        Console.WriteLine($"Output: {result}");
    }

    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        int maxLength = 0;
        var possibleSubstring = new HashSet<char>();

        for (int i = 0; i < s.Length; i++)
        {
            possibleSubstring.Clear();
            possibleSubstring.Add(s[i]);

            for (int j = i + 1; j < s.Length; j++)
            {
                if (possibleSubstring.Contains(s[j]))
                    break;

                possibleSubstring.Add(s[j]);
            }

            maxLength = Math.Max(maxLength, possibleSubstring.Count);
        }

        return maxLength;
    }
}