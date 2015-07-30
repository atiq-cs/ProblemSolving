/***************************************************************************
*   Problem Name:   Reverse Linked List (recursive solution)
*   Problem URL :   https://leetcode.com/problems/reverse-linked-list/
*   Derived from:   Algorithms/Recursion_Reverse_Linked_List_demo.cpp
 
*   Date        :   July 29, 2015
*   Desc        :   uses the idea that all the nodes of the linked list are pushed into heap during recursive
*                   calls. So when we are return from those calls use the store nodes to change the link each time
*                   - This however, does changes head's next
*                   - To keep track of the head we have to use global head
*                   - we need to take care of the case when head.next is null in the recursive function
*                   - if head is null RecReverse function does nothing so we don't set its next to null as we do
*                     in regular cases
*
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted (0.160s)
*   Note        :   All classes are assigned and passed to functions by reference whereas structures
*                     copies the object
 *                  For more tech notes look at: 206_reverse-linked-list_recursive.cs
***************************************************************************/
public class Solution
{
    ListNode gHead;
    public ListNode ReverseList(ListNode head)
    {
        gHead = null;
        RecReverse(head);
        if (head != null)
        {
            head.next = null;
            head = gHead;
        }
        return head;
    }

    public void RecReverse(ListNode head)
    {
        if (head == null)
            return;
        if (head.next == null)
        {
            if (gHead == null)
                gHead = head;
            return;
        }
        RecReverse(head.next);
        // reverse the link safely, because we know at this point all of the nodes are pushed to stack it won't
        // break the link if we change next pointer, we will still retrieve previous nodes when function returns
        // to caller
        head.next.next = head;
    }
}
