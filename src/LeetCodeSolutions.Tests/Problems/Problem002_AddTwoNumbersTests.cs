using LeetCodeSolutions.Helpers;
using LeetCodeSolutions.Problems;

namespace LeetCodeSolutions.Tests.Problems;

public class Problem002_AddTwoNumbersTests
{
    private readonly Problem002_AddTwoNumbers _solver = new();

    [Fact]
    public void TestAddTwoNumbers_BasicCase_ReturnsExpectedResult()
    {
        // Arrange
        var l1 = LinkedListHelper.FromArray(new[] { 2, 4, 3 });
        var l2 = LinkedListHelper.FromArray(new[] { 5, 6, 4 });

        // Act
        var result = _solver.AddTwoNumbers(l1, l2);
        var resultArray = LinkedListHelper.ToArray(result);

        // Assert
        Assert.Equal(new[] { 7, 0, 8 }, resultArray);
    }

    [Fact]
    public void TestAddTwoNumbers_WithCarryOver_ReturnsExpectedResult()
    {
        // Arrange: 9 -> 9 -> 9 + 1 = 1000 → [0, 0, 0, 1]
        var l1 = LinkedListHelper.FromArray(new[] { 9, 9, 9 });
        var l2 = LinkedListHelper.FromArray(new[] { 1 });

        // Act
        var result = _solver.AddTwoNumbers(l1, l2);
        var resultArray = LinkedListHelper.ToArray(result);

        // Assert
        Assert.Equal(new[] { 0, 0, 0, 1 }, resultArray);
    }
    
    [Fact]
    public void TestAddTwoNumbers_DifferentLengths_ReturnsExpectedResult()
    {
        // Arrange: 2 -> 4 -> 9 + 5 -> 6 -> 4 -> 9 = [7, 0, 4, 0, 1]
        var l1 = LinkedListHelper.FromArray(new[] { 2, 4, 9 });
        var l2 = LinkedListHelper.FromArray(new[] { 5, 6, 4, 9 });

        // Act
        var result = _solver.AddTwoNumbers(l1, l2);
        var resultArray = LinkedListHelper.ToArray(result);

        // Assert
        Assert.Equal(new[] { 7, 0, 4, 0, 1 }, resultArray);
    }

    [Fact]
    public void TestAddTwoNumbers_EmptyLists_ReturnsZero()
    {
        // Arrange
        var l1 = LinkedListHelper.FromArray(new[] { 0 });
        var l2 = LinkedListHelper.FromArray(new[] { 0 });

        // Act
        var result = _solver.AddTwoNumbers(l1, l2);
        var resultArray = LinkedListHelper.ToArray(result);

        // Assert
        Assert.Equal(new[] { 0 }, resultArray);
    }

    [Fact]
    public void TestAddTwoNumbers_WithSingleDigitCarry_ReturnsExpectedResult()
    {
        // Arrange: 5 + 5 = 10 → [0, 1]
        var l1 = LinkedListHelper.FromArray(new[] { 5 });
        var l2 = LinkedListHelper.FromArray(new[] { 5 });

        // Act
        var result = _solver.AddTwoNumbers(l1, l2);
        var resultArray = LinkedListHelper.ToArray(result);

        // Assert
        Assert.Equal(new[] { 0, 1 }, resultArray);
    }
}