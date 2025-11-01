using LeetCodeSolutions.Problems.Interfaces;

namespace LeetCodeSolutions.Problems;

/// <summary>
///     Problem 1: Two Sum
///     https://leetcode.com/problems/two-sum/
///     Approach:
///     Use a dictionary to track complements while iterating.
///     Time Complexity: O(n)
///     Space Complexity: O(n)
/// </summary>
public class Problem001_TwoSum : ILeetCodeProblem
{
    public void SolveProblem()
    {
        int[] nums = { 3, 2, 4 };
        var target = 6;
        var result = TwoSum(nums, target);

        Console.WriteLine($"Input: [{string.Join(", ", nums)}]");
        Console.WriteLine($"Target: {target}");
        Console.WriteLine($"Output: [{string.Join(", ", result)}]");
    }

    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];

            if (dict.ContainsKey(complement))
                return new[] { dict[complement], i };

            dict[nums[i]] = i;
        }

        return Array.Empty<int>();
    }
}