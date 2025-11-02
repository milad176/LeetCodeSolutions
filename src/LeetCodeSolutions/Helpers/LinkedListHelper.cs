namespace LeetCodeSolutions.Helpers;

public static class LinkedListHelper
{
    /// <summary>
    /// Converts an array of integers into a singly linked list.
    /// Example: [2, 4, 3] → 2 -> 4 -> 3
    /// </summary>
    public static ListNode FromArray(int[] values)
    {
        if (values == null || values.Length == 0)
            throw new ArgumentException("Array cannot be null or empty.");

        ListNode dummyHead = new ListNode(0);
        ListNode current = dummyHead;

        foreach (int value in values)
        {
            current.next = new ListNode(value);
            current = current.next;
        }

        return dummyHead.next!;
    }

    /// <summary>
    /// Converts a linked list into an integer array.
    /// Example: 2 -> 4 -> 3 → [2, 4, 3]
    /// </summary>
    public static int[] ToArray(ListNode head)
    {
        var list = new List<int>();
        var current = head;

        while (current != null)
        {
            list.Add(current.val);
            current = current.next;
        }

        return list.ToArray();
    }

    /// <summary>
    /// Prints a linked list in human-readable format.
    /// Example: 2 -> 4 -> 3
    /// </summary>
    public static void Print(ListNode head)
    {
        if (head == null)
        {
            Console.WriteLine("∅");
            return;
        }

        var current = head;
        while (current != null)
        {
            Console.Write(current.val);
            if (current.next != null)
                Console.Write(" -> ");
            current = current.next;
        }

        Console.WriteLine();
    }
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}