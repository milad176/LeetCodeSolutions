using LeetCodeSolutions.Helpers;
using LeetCodeSolutions.Problems.Interfaces;

namespace LeetCodeSolutions.Problems;

/// <summary>
/// Problem 2: Add Two Numbers
/// https://leetcode.com/problems/add-two-numbers/
/// Approach:
/// - Use a dummy head node to simplify handling of the result list.
/// - Traverse both linked lists simultaneously, summing corresponding digits and carry.
/// - Create new nodes for each resulting digit.
/// Time Complexity: O(max(m, n)) — iterate through both lists once.
/// Space Complexity: O(max(m, n)) — new list to store result.
/// </summary>
public class Problem002_AddTwoNumbers : ILeetCodeProblem
{
    public void SolveProblem()
    {
        int[] l1Array = { 2, 4, 3 };
        int[] l2Array = { 5, 6, 4 };

        var l1 = LinkedListHelper.FromArray(l1Array);
        var l2 = LinkedListHelper.FromArray(l2Array);

        var result = AddTwoNumbers(l1, l2);

        Console.WriteLine("Input:");
        Console.WriteLine($" l1 = [{string.Join(", ", l1Array)}]");
        Console.WriteLine($" l2 = [{string.Join(", ", l2Array)}]");
        Console.WriteLine("Output:");
        Console.Write(" result = ");
        LinkedListHelper.Print(result);
    }

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode dummyHead = new ListNode(0);
        ListNode current = dummyHead;
        int carry = 0;

        while (l1 != null || l2 != null || carry != 0)
        {
            int x = (l1 != null) ? l1.val : 0;
            int y = (l2 != null) ? l2.val : 0;
            int sum = x + y + carry;

            carry = sum / 10;
            int digit = sum % 10;

            current.next = new ListNode(digit);
            current = current.next;

            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
        }

        return dummyHead.next;
    }
}