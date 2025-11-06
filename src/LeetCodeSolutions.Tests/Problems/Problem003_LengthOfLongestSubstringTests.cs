using LeetCodeSolutions.Problems;

namespace LeetCodeSolutions.Tests.Problems;

public class Problem003_LengthOfLongestSubstringTests
{
    private readonly Problem003_LengthOfLongestSubstring _solver = new();
    
    [Theory]
    [InlineData("abcabcbb", 3)]   // "abc"
    [InlineData("bbbbb", 1)]      // "b"
    [InlineData("pwwkew", 3)]     // "wke"
    [InlineData("", 0)]           // empty string
    [InlineData(" ", 1)]          // single whitespace
    [InlineData("au", 2)]         // "au"
    [InlineData("dvdf", 3)]       // "vdf"
    [InlineData("anviaj", 5)]     // "nviaj"
    [InlineData("tmmzuxt", 5)]    // "mzuxt"
    [InlineData("abcdef", 6)]     // all unique
    public void TestLengthOfLongestSubstring_ReturnsExpectedLength(string input, int expected)
    {
        // Act
        int result = _solver.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(expected, result);
    }
}