/***************************************************************************
* Problem Name: Reverse Linked List (recursive solution)
* Problem URL : https://leetcode.com/problems/reverse-linked-list/
* Derived from: Algorithms/Recursion_Reverse_Linked_List_demo.cpp
* Date        : 2015-07-29
* Desc        : uses the idea that all the nodes of the linked list are pushed into heap during recursive
*   calls. So when we are return from those calls use the store nodes to change the link each time
*   - This however, does changes head's next
*   - To keep track of the head we have to use global head
*   - we need to take care of the case when head.next is null in the recursive function
*   - if head is null RecReverse function does nothing so we don't set its next to null as we do
*     in regular cases
*    
*   Code updated on occassion Den meetup 2018-04-21
* Complexity  : O(n)
* Author      : Atiq Rahman
* Status      : Accepted (0.160s)
* Note        : All classes are assigned and passed to functions by reference
*   whereas structures instantiate a new object and copies the content
***************************************************************************/
public class Solution {
  ListNode gHead=null; 		// global head, class member
  public ListNode ReverseList(ListNode head)
  {
    RecReverse(head);
    if (head != null)
      head.next = null;
    return gHead;
  }

  public void RecReverse(ListNode head)
  {
    if (head == null) return ;
    if (head.next == null) { gHead = head; return ; }
    RecReverse(head.next);
    // Reverse link safely. We can perform such change on link here because at
    // this point, all of the nodes till this one is already in stack. We won't
    // lose our previous nodes we change next pointer, we will still retrieve
    // previous nodes when function returns to caller
    head.next.next = head;
  }
}
