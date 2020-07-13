/***************************************************************************
* Title : Rotate List
* URL   : https://leetcode.com/problems/rotate-list
* Date  : 2018-06-07
* Author: Atiq Rahman
* Comp  : O(n), O(1)
* Status: Accepted
* Notes : There are two ways to solve this problem.
*   1. Copying the values from old positions in the linked list into the new
*   positions.
*   2. Modifying the links of the linked list.
*   
*   Considering method#1,
*   let's calculate source and destination pointer indices,
*   After rotating right by k places,
*   0th index becomes k-th index
*   1st index becomes 3rd index
*   
*   when k>=n
*   i becomes i + (k%n) 
*   
*   2 pointers, 1 pointer to the destination and 1 to source

*   source starts from head
*   destination starts from head + k%n
*   
*   This is a bad idea considering value on destination pointer is being
*   written and being lost. If we try to save that one by advancing pointer
*   again by k... this situation continues like a leep.. This seems rather
*   complex! On the other hand, retaining these values would require additional
*   space while advancing those pointers
*   
*   Therefore, we go with approach#2 which is pretty straight-forward.
* meta: tag-ds-linked-list, tag-leetcode-medium
***************************************************************************/
public class Solution {
  private int GetLength(ListNode head) {
    if (head == null)
      return 0;
    return 1 + GetLength(head.next);
  }
  
  public ListNode RotateRight(ListNode head, int k) {
    // this can be optimized
    int n = GetLength(head);
    k = n==0? 0: k%n;     // handles divide by zero
    if (k == 0 || head == null)
      return head;

    // Advance current to head + k - 1
    ListNode current = head;
    for (int i=1; i<n-k && current.next != null; i++)
      current = current.next;
    // save new head and set next of current to null, this current is tail of
    // result linked list
    ListNode newHead = current.next;
    current.next = null;
    current = newHead;
    
    while (current.next != null)
      current = current.next;
    current.next = head;
    return newHead;
  }
}
