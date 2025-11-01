using LeetCodeSolutions.Problems;
namespace LeetCodeSolutions.Tests.Problems;

public class Problem001_TwoSumTests
{
    [Fact]
    public void TestTwoSum_BasicCase()
    {
        var solver = new Problem001_TwoSum();
        int[] result = solver.TwoSum(new[] {2, 7, 11, 15}, 9);
        Assert.Equal(new[] {0, 1}, result);
    }
}